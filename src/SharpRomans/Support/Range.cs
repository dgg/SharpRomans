using System;
using System.Collections.Generic;

namespace SharpRomans.Support
{
	internal struct Range<T> where T : IComparable<T>
	{
		private readonly T _lowerBound;
		private readonly T _upperBound;

		public Range(T lowerBound, T upperBound)
		{
			if (lowerBound.IsMoreThan(upperBound)) throw new ArgumentOutOfRangeException(nameof(upperBound), string.Format("The start value of the range must not be greater than its end value.\nActual value was: {0}", upperBound));

			_lowerBound = lowerBound;
			_upperBound = upperBound;
		}

		public bool Contains(T item)
		{
			return item.IsAtLeast(_lowerBound) && item.IsAtMost(_upperBound);
		}

		public override string ToString()
		{
			return $"[{_lowerBound}..{_upperBound}]";
		}

		private bool equals(Range<T> other)
		{
			return EqualityComparer<T>.Default.Equals(_lowerBound, other._lowerBound) &&
				EqualityComparer<T>.Default.Equals(_upperBound, other._upperBound);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			return obj is Range<T> range && equals(range);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (EqualityComparer<T>.Default.GetHashCode(_lowerBound) * 397) ^
					EqualityComparer<T>.Default.GetHashCode(_upperBound);
			}
		}
	}
}