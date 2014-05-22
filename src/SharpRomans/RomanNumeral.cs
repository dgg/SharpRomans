using System;
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

		private static readonly Tuple<RomanFigure[], ushort>[] _calculationTable = new[]
		{
			RomanFigure.M.AsCalculationRow(),
			calculationRow(900, RomanFigure.C, RomanFigure.M),
			RomanFigure.D.AsCalculationRow(),
			calculationRow(400, RomanFigure.C, RomanFigure.D),
			RomanFigure.C.AsCalculationRow(),
			calculationRow(90, RomanFigure.X, RomanFigure.C),
			RomanFigure.L.AsCalculationRow(),
			calculationRow(40, RomanFigure.X, RomanFigure.L),
			RomanFigure.X.AsCalculationRow(),
			calculationRow(9, RomanFigure.I, RomanFigure.X),
			RomanFigure.V.AsCalculationRow(),
			calculationRow(4, RomanFigure.I, RomanFigure.V),
			RomanFigure.I.AsCalculationRow()
		};

		private static Tuple<RomanFigure[], ushort> calculationRow(ushort value, params RomanFigure[] figures)
		{
			return new Tuple<RomanFigure[], ushort>(figures, value);
		}

		public RomanNumeral(ushort number)
		{
			AssertRange(number);

			Value = number;

			if (number.Equals(0))
			{
				Figures = new ReadOnlyCollection<RomanFigure>(new[] {RomanFigure.N});
			}
			else
			{
				var figures = new ReadOnlyCollectionBuilder<RomanFigure>(16);
				for (int i = 0; i < _calculationTable.Length; i++)
				{
					while (number >= _calculationTable[i].Item2)
					{
						number -= _calculationTable[i].Item2;
						figures.AddRange(_calculationTable[i].Item1);
						//sb.Append(string.Concat(_calculationTable[i].Item1.Select(f => f.ToString(CultureInfo.InvariantCulture)).ToArray()));
					}
				}
				Figures = figures.ToReadOnlyCollection();
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
