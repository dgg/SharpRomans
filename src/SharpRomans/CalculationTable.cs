using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SharpRomans
{
	internal static class CalculationTable
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
	}
}