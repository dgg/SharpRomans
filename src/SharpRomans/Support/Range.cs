using System;

namespace SharpRomans.Support
{
	internal class Range<T> where T : IComparable<T>
	{
		private readonly T _lowerBound;
		private readonly T _upperBound;

		public Range() { }

		public Range(T lowerBound, T upperBound)
		{
			if (lowerBound.IsMoreThan(upperBound)) throw new ArgumentOutOfRangeException("upperBound", upperBound, "The start value of the range must not be greater than its end value.");

			_lowerBound = lowerBound;
			_upperBound = upperBound;
		}

		public T LowerBound { get { return _lowerBound; } }

		public T UpperBound { get { return _upperBound; } }

		public virtual bool Contains(T item)
		{
			return item.IsAtLeast(_lowerBound) && item.IsAtMost(_upperBound);
		}

		public override string ToString()
		{
			return string.Format("[{0}..{1}]", LowerBound, UpperBound);
		}
	}
}