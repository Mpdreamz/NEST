﻿using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Nest;
using Tests.Framework;
using static Tests.Framework.RoundTripper;

namespace Tests.CommonOptions.TimeUnit
{
	public class TimeUnits 
	{
		/** ==  Time units
		 * Whenever durations need to be specified, eg for a timeout parameter, the duration can be specified 
		 * as a whole number representing time in milliseconds, or as a time value like `2d` for 2 days. 
		 * 
		 * === Using Time units in NEST
		 * NEST uses `Time` to strongly type this and there are several ways to construct one.
		 *
		 * ==== Constructor
		 * The most straight forward way to construct a `Time` is through its constructor
		 */
		[U] public void Constructor()
		{
			var unitString = new Time("2d");
			var unitComposed = new Time(2, Nest.TimeUnit.Day);
			var unitTimeSpan = new Time(TimeSpan.FromDays(2));
			var unitMilliseconds = new Time(1000 * 60 * 60 * 24 * 2);

			/**
			* When serializing Time constructed from 
			* - a string 
			* - milliseconds (as a double) 
			* - composition of factor and interval
			* - a `TimeSpan` 
			*
			* the expression will be serialized to a time unit string composed of the factor and interval e.g. `2d`
			*/
			Expect("2d")
				.WhenSerializing(unitString)
				.WhenSerializing(unitComposed)
				.WhenSerializing(unitTimeSpan)
				.WhenSerializing(unitMilliseconds);

			/**
			* The `Milliseconds` property on `Time` is calculated even when not using the constructor that takes a double
			*/
			unitMilliseconds.Milliseconds.Should().Be(1000*60*60*24*2);
			unitComposed.Milliseconds.Should().Be(1000*60*60*24*2);
			unitTimeSpan.Milliseconds.Should().Be(1000*60*60*24*2);
			unitString.Milliseconds.Should().Be(1000*60*60*24*2);
		}
		/**
		* ==== Implicit conversion
		* Alternatively to using the constructor, `string`, `TimeSpan` and `double` can be implicitly converted to `Time` 
		*/
		[U] [SuppressMessage("ReSharper", "SuggestVarOrType_SimpleTypes")]
		public void ImplicitConversion()
		{
			Time oneAndHalfYear = "1.5y";
			Time twoWeeks = TimeSpan.FromDays(14);
			Time twoDays = 1000*60*60*24*2;

			Expect("1.5y").WhenSerializing(oneAndHalfYear);
			Expect("2w").WhenSerializing(twoWeeks);
			Expect("2d").WhenSerializing(twoDays);
		}

		[U] [SuppressMessage("ReSharper", "SuggestVarOrType_SimpleTypes")]
		public void EqualityAndComparable()
		{
			Time oneAndHalfYear = "1.5y";
			Time twoWeeks = TimeSpan.FromDays(14);
			Time twoDays = 1000*60*60*24*2;

			/**
			* Again, the `Milliseconds` property is calculated on `Time`, 
			* allowing you to do comparisons
			*/
			oneAndHalfYear.Milliseconds.Should().BeGreaterThan(1);
			twoWeeks.Milliseconds.Should().BeGreaterThan(1);

			oneAndHalfYear.Should().BeGreaterThan(twoWeeks);
			(oneAndHalfYear > twoWeeks).Should().BeTrue();
			(oneAndHalfYear >= twoWeeks).Should().BeTrue();
			(twoDays >= new Time("2d")).Should().BeTrue();
			
			twoDays.Should().BeLessThan(twoWeeks);
			(twoDays < twoWeeks).Should().BeTrue();
			(twoDays <= twoWeeks).Should().BeTrue();
			(twoDays <= new Time("2d")).Should().BeTrue();
			
			/**
			* And assert equality
			*/
			twoDays.Should().Be(new Time("2d"));
			(twoDays == new Time("2d")).Should().BeTrue();
			(twoDays != new Time("2.1d")).Should().BeTrue();
			(new Time("2.1d") == new Time(TimeSpan.FromDays(2.1))).Should().BeTrue();
		}

		[U]
		public void UsingInterval()
		{
			/** === Time units
			* Time units are specified as a union of either a `DateInterval` or `Time`,
			* both of which implicitly convert to the `Union` of these two.
			*/
			Expect("month").WhenSerializing<Union<DateInterval, Time>>(DateInterval.Month);
			Expect("day").WhenSerializing<Union<DateInterval, Time>>(DateInterval.Day);
			Expect("hour").WhenSerializing<Union<DateInterval, Time>>(DateInterval.Hour);
			Expect("minute").WhenSerializing<Union<DateInterval, Time>>(DateInterval.Minute);
			Expect("quarter").WhenSerializing<Union<DateInterval, Time>>(DateInterval.Quarter);
			Expect("second").WhenSerializing<Union<DateInterval, Time>>(DateInterval.Second);
			Expect("week").WhenSerializing<Union<DateInterval, Time>>(DateInterval.Week);
			Expect("year").WhenSerializing<Union<DateInterval, Time>>(DateInterval.Year);

			Expect("2d").WhenSerializing<Union<DateInterval, Time>>((Time)"2d");
			Expect("1.16w").WhenSerializing<Union<DateInterval, Time>>((Time)TimeSpan.FromDays(8.1));
		}
	}
}
