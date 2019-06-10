using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Elasticsearch.Net
{
	/// <summary>
	/// Methods for working with <see cref="SecureString"/>
	/// </summary>
	public static class SecureStrings
	{
		/// <summary>
		/// Creates a string from a secure string
		/// </summary>
		public static string CreateString(this SecureString secureString)
		{
			var num = IntPtr.Zero;
			if (secureString != null && secureString.Length != 0)
			{
				try
				{
					num = Marshal.SecureStringToBSTR(secureString);
					return Marshal.PtrToStringBSTR(num);
				}
				finally
				{
					if (num != IntPtr.Zero)
						Marshal.ZeroFreeBSTR(num);
				}
			}

			return string.Empty;
		}

		/// <summary>
		/// Creates a secure string from a string
		/// </summary>
		public static SecureString CreateSecureString(this string plainString)
		{
			var secureString = new SecureString();

			if (plainString == null)
				return secureString;

			foreach (var ch in plainString)
				secureString.AppendChar(ch);

			return secureString;
		}
	}
}
