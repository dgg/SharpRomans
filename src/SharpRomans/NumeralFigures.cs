using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace SharpRomans
{
	internal static class NumeralFigures
	{
		internal static Tuple<RomanFigure[], ushort> AsCalculationRow(this RomanFigure figure)
		{
			return new Tuple<RomanFigure[], ushort>(new[] { figure }, figure.Value);
		}

		internal static void AddRange(this ReadOnlyCollectionBuilder<RomanFigure> builder, IEnumerable<RomanFigure> figures)
		{
			foreach (var figure in figures)
			{
				builder.Add(figure);
			}
		}

		private static readonly Tuple<RomanFigure[], ushort>[] _calculationTable;
		public static readonly ReadOnlyCollection<RomanFigure> _zero;
		internal static ReadOnlyCollection<RomanFigure> Zero { get { return _zero; } }
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
			_zero = new ReadOnlyCollection<RomanFigure>(new[] { RomanFigure.N });
		}

		private static Tuple<RomanFigure[], ushort> calculationRow(ushort value, params RomanFigure[] figures)
		{
			return new Tuple<RomanFigure[], ushort>(figures, value);
		}

		internal static ReadOnlyCollection<RomanFigure> Calculate(ushort number)
		{
			if (number == 0) throw new ArgumentOutOfRangeException("number", number, "only > 0");

			var figures = new ReadOnlyCollectionBuilder<RomanFigure>(16);
			for (int i = 0; i < _calculationTable.Length; i++)
			{
				while (number >= _calculationTable[i].Item2)
				{
					number -= _calculationTable[i].Item2;
					figures.AddRange(_calculationTable[i].Item1);
				}
			}

			var collection = figures.ToReadOnlyCollection();
			return collection;
		}
	}
}