using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Nest
{
	[JsonConverter(typeof(TimeJsonConverter))]
	public class Time : IComparable<Time>, IEquatable<Time>
	{
		private static readonly Regex _expressionRegex = new Regex(@"^(?<factor>[-+]?\d+(?:\.\d+)?)(?<interval>(?:y|M|w|d|h|m|s|ms))?$", RegexOptions.Compiled | RegexOptions.ExplicitCapture);

		private static readonly double _yearApproximate = TimeSpan.FromDays(365).TotalMilliseconds;
		private static readonly double _monthApproximate = TimeSpan.FromDays(30).TotalMilliseconds;
		private static readonly double _week = TimeSpan.FromDays(7).TotalMilliseconds;
		private static readonly double _day = TimeSpan.FromDays(1).TotalMilliseconds;
		private static readonly double _hour = TimeSpan.FromHours(1).TotalMilliseconds;
		private static readonly double _minute = TimeSpan.FromMinutes(1).TotalMilliseconds;
		private static readonly double _second = TimeSpan.FromSeconds(1).TotalMilliseconds;

		public double? Factor { get; private set; }
		public TimeUnit? Interval { get; private set; }

		// TODO make nullable in 3.0
		public double Milliseconds { get; private set; }

		public static implicit operator Time(TimeSpan span) => new Time(span);
		public static implicit operator Time(double milliseconds) => new Time(milliseconds);
		public static implicit operator Time(string expression) => new Time(expression);

		public Time(double factor, TimeUnit interval)
		{
			this.Factor = factor;
			this.Interval = interval;
			this.Milliseconds = GetMilliseconds(this.Interval.Value, this.Factor.Value);
		}

		public Time(TimeSpan timeSpan)
		{
			Reduce(timeSpan.TotalMilliseconds);
		}

		public Time(double milliseconds)
		{
			Reduce(milliseconds);
		}

		public Time(string timeUnit)
		{
			if (timeUnit.IsNullOrEmpty()) throw new ArgumentException("Time expression string is empty", nameof(timeUnit));
			var match = _expressionRegex.Match(timeUnit);
			if (!match.Success) throw new ArgumentException($"Time expression '{timeUnit}' string is invalid", nameof(timeUnit));

			this.Factor = double.Parse(match.Groups["factor"].Value, CultureInfo.InvariantCulture);

			if (this.Factor > 0)
			{
				this.Interval = match.Groups["interval"].Success
					? match.Groups["interval"].Value.ToEnum<TimeUnit>(StringComparison.Ordinal)
					: TimeUnit.Millisecond;
			}

			this.Milliseconds = this.Interval.HasValue
				? GetMilliseconds(this.Interval.Value, this.Factor.Value)
				: this.Factor.Value;
		}

		public int CompareTo(Time other)
		{
			if (other == null) return 1;
			var ms = GetMilliseconds(this.Interval.Value, this.Factor.Value, approximate: true);
			var otherMs = GetMilliseconds(other.Interval.Value, other.Factor.Value, approximate: true);
			if (ms == otherMs) return 0;
			if (ms < otherMs) return -1;
			return 1;
		}

		public static bool operator <(Time left, Time right) => left.CompareTo(right) < 0;
		public static bool operator <=(Time left, Time right) => left.CompareTo(right) < 0 || left.Equals(right);

		public static bool operator >(Time left, Time right) => left.CompareTo(right) > 0;
		public static bool operator >=(Time left, Time right) => left.CompareTo(right) > 0 || left.Equals(right);

		public static bool operator ==(Time left, Time right) =>
			object.ReferenceEquals(left, null) ? object.ReferenceEquals(right, null) : left.Equals(right);

		public static bool operator !=(Time left, Time right) =>
			!object.ReferenceEquals(left, null) && !object.ReferenceEquals(right, null) && !left.Equals(right);

		public TimeSpan ToTimeSpan() => TimeSpan.FromMilliseconds(this.Milliseconds);

		public override string ToString()
		{
			var factor = this.Factor.Value.ToString("0.##", CultureInfo.InvariantCulture);
			return (this.Interval.HasValue) ? factor + this.Interval.Value.GetStringValue() : factor;
		}

		public bool Equals(Time other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Milliseconds == other.Milliseconds;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Time)obj);
		}

		public override int GetHashCode() => this.Milliseconds.GetHashCode();

		private double GetMilliseconds(TimeUnit interval, double factor, bool approximate = false)
		{
			switch (interval)
			{
				case TimeUnit.Year:
					return approximate ? factor * _yearApproximate : -1;
				case TimeUnit.Month:
					return approximate ? factor * _monthApproximate : -1;
				case TimeUnit.Week:
					return factor * _week;
				case TimeUnit.Day:
					return factor * _day;
				case TimeUnit.Hour:
					return factor * _hour;
				case TimeUnit.Minute:
					return factor * _minute;
				case TimeUnit.Second:
					return factor * _second;
				default: // ms
					return factor;
			}
		}

		private void Reduce(double ms)
		{
			this.Milliseconds = ms;

			if (ms >= _week)
			{
				Factor = ms / _week;
				Interval = TimeUnit.Week;
			}
			else if (ms >= _day)
			{
				Factor = ms / _day;
				Interval = TimeUnit.Day;
			}
			else if (ms >= _hour)
			{
				Factor = ms / _hour;
				Interval = TimeUnit.Hour;
			}
			else if (ms >= _minute)
			{
				Factor = ms / _minute;
				Interval = TimeUnit.Minute;
			}
			else if (ms >= _second)
			{
				Factor = ms / _second;
				Interval = TimeUnit.Second;
			}
			else
			{
				Factor = ms;
				// If milliseconds is <= 0 then don't set an interval.
				// This is used when setting things like index.refresh_interval = -1 (the only case where a unit isn't required)
				Interval = (ms > 0) ? (TimeUnit?)TimeUnit.Millisecond : null;
			}
		}
	}
}