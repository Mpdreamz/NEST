﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nest.Litterateur.Documentation.Blocks;

namespace Nest.Litterateur.Walkers
{
	class DocumentationFileWalker : CSharpSyntaxWalker
	{
		public DocumentationFileWalker() : base(SyntaxWalkerDepth.StructuredTrivia) { }

		private string _propertyName;
		private int ClassDepth { get; set; }
		private bool InsideMultiLineDocumentation { get; set; }
		private bool InsideAutoIncludeMethodBlock { get; set; }
		private bool InsideFluentOrInitializerExample { get; set; }
		public List<IDocumentationBlock> Blocks { get; } = new List<IDocumentationBlock>();

		public override void VisitClassDeclaration(ClassDeclarationSyntax node)
		{
			++ClassDepth;
			if (ClassDepth == 1)
			{
				base.VisitClassDeclaration(node);
			}				
			else if (node.ChildNodes().All(childNode => childNode is PropertyDeclarationSyntax || childNode is AttributeListSyntax))
			{
				// simple nested POCO	
				var line = node.SyntaxTree.GetLineSpan(node.Span).StartLinePosition.Line;
				var walker = new CodeWithDocumentationWalker(ClassDepth - 2, line);
				walker.Visit(node);
				this.Blocks.AddRange(walker.Blocks);
			}
			else
			{
				var methods = node.ChildNodes().OfType<MethodDeclarationSyntax>();
				if (!methods.Any(m => m.AttributeLists.SelectMany(a => a.Attributes).Any()))
				{
					// nested class with methods that are not unit or integration tests e.g. example PropertyVisitor
					var line = node.SyntaxTree.GetLineSpan(node.Span).StartLinePosition.Line;
					var walker = new CodeWithDocumentationWalker(ClassDepth - 2, line);
					walker.Visit(node);
					this.Blocks.AddRange(walker.Blocks);
				}
			}
			--ClassDepth;
		}

		public override void VisitPropertyDeclaration(PropertyDeclarationSyntax node)
		{
			var propertyName = node.Identifier.Text;
			if (propertyName == "ExpectJson" || propertyName == "QueryJson")
			{
				_propertyName = propertyName;
				this.InsideFluentOrInitializerExample = true;
				base.VisitPropertyDeclaration(node);
				this.InsideFluentOrInitializerExample = false;
			}
			else if (propertyName == "Fluent" || 
				propertyName == "Initializer" || 
				propertyName == "QueryFluent" || 
				propertyName == "QueryInitializer")
			{
				// TODO: Look to get the generic types for the call so that we can prettify the fluent and OIS calls in docs e.g. client.Search<Project>({Call});
				// var genericArguments = node.DescendantNodes().OfType<GenericNameSyntax>().FirstOrDefault();
				// List<TypeSyntax> arguments = new List<TypeSyntax>();
				// if (genericArguments != null)
				// {
				// 	arguments.AddRange(genericArguments.TypeArgumentList.Arguments);
				// }

				_propertyName = propertyName;
				this.InsideFluentOrInitializerExample = true;
				base.VisitPropertyDeclaration(node);
				this.InsideFluentOrInitializerExample = false;
			}
			else
			{
				_propertyName = null;
			}
		}

		public override void VisitArrowExpressionClause(ArrowExpressionClauseSyntax node)
		{
			if (!this.InsideFluentOrInitializerExample) return;
			var syntaxNode = node?.ChildNodes()?.LastOrDefault()?.WithAdditionalAnnotations();
			if (syntaxNode == null) return;
			var line = node.SyntaxTree.GetLineSpan(node.Span).StartLinePosition.Line;
			var walker = new CodeWithDocumentationWalker(ClassDepth, line, _propertyName);
			walker.Visit(syntaxNode);
			this.Blocks.AddRange(walker.Blocks);
		}

		public override void VisitAccessorDeclaration(AccessorDeclarationSyntax node)
		{
			if (!this.InsideFluentOrInitializerExample) return;
			var syntaxNode = node?.ChildNodes()?.LastOrDefault()?.WithAdditionalAnnotations() as BlockSyntax;
			if (syntaxNode == null) return;
			var line = node.SyntaxTree.GetLineSpan(node.Span).StartLinePosition.Line;
			var walker = new CodeWithDocumentationWalker(ClassDepth, line, _propertyName);
			walker.VisitBlock(syntaxNode);
			this.Blocks.AddRange(walker.Blocks);
		}

		public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
		{
			if (this.ClassDepth == 1) this.InsideAutoIncludeMethodBlock = true;
			base.VisitMethodDeclaration(node);
			this.InsideAutoIncludeMethodBlock = false;
		}

		public override void VisitExpressionStatement(ExpressionStatementSyntax node)
		{
			if (this.InsideAutoIncludeMethodBlock)
			{
				var line = node.SyntaxTree.GetLineSpan(node.Span).StartLinePosition.Line;
				var allchildren = node.DescendantNodesAndTokens(descendIntoTrivia: true);
				if (allchildren.Any(a => a.Kind() == SyntaxKind.MultiLineDocumentationCommentTrivia))
				{
					var walker = new CodeWithDocumentationWalker(ClassDepth, line, _propertyName);
					walker.Visit(node.WithAdditionalAnnotations());
					this.Blocks.AddRange(walker.Blocks);
					return;
				}
				base.VisitExpressionStatement(node);
				var code = node.WithoutLeadingTrivia().ToFullString();
				code = code.RemoveNumberOfLeadingTabsAfterNewline(ClassDepth + 2);
				this.Blocks.Add(new CodeBlock(code, line, Language.CSharp));
			}
			else base.VisitExpressionStatement(node);

		}

		public override void VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
		{
			if (this.InsideAutoIncludeMethodBlock)
			{
				var allchildren = node.DescendantNodesAndTokens(descendIntoTrivia: true);
				var line = node.SyntaxTree.GetLineSpan(node.Span).StartLinePosition.Line;
				if (allchildren.Any(a => a.Kind() == SyntaxKind.MultiLineDocumentationCommentTrivia))
				{
					var walker = new CodeWithDocumentationWalker(ClassDepth, line, _propertyName);
					walker.Visit(node.WithAdditionalAnnotations());
					this.Blocks.AddRange(walker.Blocks);
					return;
				}
				var code = node.WithoutLeadingTrivia().ToFullString();
				code = code.RemoveNumberOfLeadingTabsAfterNewline(ClassDepth + 2);
				this.Blocks.Add(new CodeBlock(code, line, Language.CSharp));
			}
			base.VisitLocalDeclarationStatement(node);
		}

		public override void VisitTrivia(SyntaxTrivia trivia)
		{
			if (trivia.Kind() != SyntaxKind.MultiLineDocumentationCommentTrivia)
			{
				base.VisitTrivia(trivia);
				return;
			}

			this.InsideMultiLineDocumentation = true;

			var tokens = trivia.ToFullString()
				.RemoveLeadingAndTrailingMultiLineComments()
				.SplitOnNewLines(StringSplitOptions.None);
			var builder = new StringBuilder();

			foreach (var token in tokens)
			{
				var currentToken = token.RemoveLeadingSpacesAndAsterisk();
				var decodedToken = System.Net.WebUtility.HtmlDecode(currentToken);
				builder.AppendLine(decodedToken);
			}

			var text = builder.ToString();
			var line = trivia.SyntaxTree.GetLineSpan(trivia.Span).StartLinePosition.Line;
			this.Blocks.Add(new TextBlock(text, line));

			this.InsideMultiLineDocumentation = false;
		}
	}
}
