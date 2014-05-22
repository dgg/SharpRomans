using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using SharpRomans.Support;

namespace SharpRomans
{
	public sealed class RomanNumeral
	{
		public static readonly ushort MinValue = default(ushort);
		public static readonly ushort MaxValue = 3999;
		private static readonly Range<ushort> _validity = new Range<ushort>(MinValue, MaxValue);

		public ushort Value { get; private set; }
		public ReadOnlyCollection<RomanFigure> Figures { get; private set; }

		public RomanNumeral(ushort number)
		{
			AssertRange(number);

			Value = number;

			if (number.Equals(0))
			{
				Figures =  new ReadOnlyCollection<RomanFigure>(new[] { RomanFigure.N });
			}
		}

		public static void AssertRange(ushort value)
		{
			if (!CheckRange(value)) throw new NumeralOutOfRangeException("value", value, _validity);
		}

		public static bool CheckRange(ushort value)
		{
			return _validity.Contains(value);
		}

		public static readonly RomanNumeral Min = new RomanNumeral(MinValue);
		public static readonly RomanNumeral Max = new RomanNumeral(MaxValue);
		public static readonly RomanNumeral Zero = new RomanNumeral(0);
	}
}
