using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SharpRomans
{
	internal static class NumeralFigures
	{
		private static Tuple<RomanFigure[], ushort> AsCalculationRow(this RomanFigure figure)
		{
			return new Tuple<RomanFigure[], ushort>(new[] { figure }, figure.Value);
		}
		
		private static readonly Tuple<RomanFigure[], ushort>[] _calculationTable;
		internal static ReadOnlyCollection<RomanFigure> Zero { get; }

		static NumeralFigures()
		{
			_calculationTable = new[]
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
			Zero = new ReadOnlyCollection<RomanFigure>(new[] { RomanFigure.N });
		}

		internal static readonly int MaxLength = 16;

		private static Tuple<RomanFigure[], ushort> calculationRow(ushort value, params RomanFigure[] figures)
		{
			return new Tuple<RomanFigure[], ushort>(figures, value);
		}

		internal static ReadOnlyCollection<RomanFigure> Calculate(ushort number)
		{
			if (number == 0) throw new ArgumentOutOfRangeException(nameof(number), "only > 0");

			var figures = new List<RomanFigure>(MaxLength);
			for (int i = 0; i < _calculationTable.Length; i++)
			{
				while (number >= _calculationTable[i].Item2)
				{
					number -= _calculationTable[i].Item2;
					figures.AddRange(_calculationTable[i].Item1);
				}
			}

			var collection = new ReadOnlyCollection<RomanFigure>(figures);
			return collection;
		}
	}
}