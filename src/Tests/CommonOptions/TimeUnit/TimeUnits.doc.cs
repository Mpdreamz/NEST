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
		/** #  Time units
		 * Whenever durations need to be specified, eg for a timeout parameter, the duration can be specified 
		 * as a whole number representing time in milliseconds, or as a time value like `2d` for 2 days. 
		 * 
		 * ## Using Time units in NEST
		 * NEST uses `Time` to strongly type this and there are several ways to construct one.
		 *
		 * ### Constructor
		 * The most straight forward way to construct a `Time` is through its constructor
		 */
		
		[U] public void Constructor()
		{
			var unitString = new Time("2d");
			var unitComposed = new Time(2, Nest.TimeUnit.Day);
			var unitTimeSpan = new Time(TimeSpan.FromDays(2));
			var unitMilliseconds = new Time(1000 * 60 * 60 * 24 * 2);

			/**
			* When serializing Time constructed from a string, milliseconds, composition of factor and 
			* interval, or a `TimeSpan` the expression will be serialized as time unit string
			*/
			Expect("2d")
				.WhenSerializing(unitString)
				.WhenSerializing(unitComposed)
				.WhenSerializing(unitTimeSpan)
				.WhenSerializing(unitMilliseconds);

			/**
			* Milliseconds are always calculated even when not using the constructor that takes a long
			*/
			unitMilliseconds.Milliseconds.Should().Be(1000*60*60*24*2);
			unitComposed.Milliseconds.Should().Be(1000*60*60*24*2);
			unitTimeSpan.Milliseconds.Should().Be(1000*60*60*24*2);
			unitString.Milliseconds.Should().Be(1000*60*60*24*2);
		}
		/**
		* ### Implicit conversion
		* Alternatively `string`, `TimeSpan` and `double` can be implicitly assigned to `Time` properties and variables 
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
			* Milliseconds are calculated even when values are not passed as long
			*/
			oneAndHalfYear.Milliseconds.Should().BeGreaterThan(1);
			twoWeeks.Milliseconds.Should().BeGreaterThan(1);

			/**
			* This allows you to do comparisons on the expressions
			*/
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
			/**
			* Time units are specified as a union of either a `DateInterval` or `Time`
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

		[U]
		public void ExpectedValues()
		{
			Assert(
				1, Nest.TimeUnit.Year, TimeSpan.FromDays(365).TotalMilliseconds, "1y",
				new Time(1, Nest.TimeUnit.Year),
				new Time("1y"),
				new Time(TimeSpan.FromDays(365).TotalMilliseconds)
			);

			Assert(
				1, Nest.TimeUnit.Month, TimeSpan.FromDays(30).TotalMilliseconds, "1M",
				new Time(1, Nest.TimeUnit.Month),
				new Time("1M"),
				new Time(TimeSpan.FromDays(30).TotalMilliseconds)
			);

			Assert(
				1, Nest.TimeUnit.Week, TimeSpan.FromDays(7).TotalMilliseconds, "1w",
				new Time(1, Nest.TimeUnit.Week),
				new Time("1w"),
				new Time(TimeSpan.FromDays(7).TotalMilliseconds)
			);

			Assert(
				1, Nest.TimeUnit.Day, TimeSpan.FromDays(1).TotalMilliseconds, "1d",
				new Time(1, Nest.TimeUnit.Day),
				new Time("1d"),
				new Time(TimeSpan.FromDays(1).TotalMilliseconds)
			);

			Assert(
				1, Nest.TimeUnit.Hour, TimeSpan.FromHours(1).TotalMilliseconds, "1h",
				new Time(1, Nest.TimeUnit.Hour),
				new Time("1h"),
				new Time(TimeSpan.FromHours(1).TotalMilliseconds)
			);

			Assert(
				1, Nest.TimeUnit.Minute, TimeSpan.FromMinutes(1).TotalMilliseconds, "1m",
				new Time(1, Nest.TimeUnit.Minute),
				new Time("1m"),
				new Time(TimeSpan.FromMinutes(1).TotalMilliseconds)
			);

			Assert(
				1, Nest.TimeUnit.Second, TimeSpan.FromSeconds(1).TotalMilliseconds, "1s",
				new Time(1, Nest.TimeUnit.Second),
				new Time("1s"),
				new Time(TimeSpan.FromSeconds(1).TotalMilliseconds)
			);
		}

		private void Assert(double expectedFactor, Nest.TimeUnit expectedInterval, double expectedMilliseconds, string expectedSerialized, params Time[] times)
		{
			foreach (var time in times)
			{
				time.Factor.Should().Be(expectedFactor);
				time.Interval.Should().Be(expectedInterval);
				time.Milliseconds.Should().Be(expectedMilliseconds);
				Expect(expectedSerialized).WhenSerializing(time);
			}
		}
	}
}
