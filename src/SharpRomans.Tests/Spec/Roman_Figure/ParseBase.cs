using System;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	public abstract class ParseBase
	{
		protected Func<RomanFigure> _figure;

		protected void theFigureIs(RomanFigure figure)
		{
			Assert.Equal(figure, _figure());
		}

		protected RomanFigure _anotherFigure;
		protected void isTheSameFigure()
		{
			Assert.Same(_anotherFigure, _figure());
		}

		protected void throwsArgumentException()
		{
			Assert.ThrowsAny<ArgumentException>(_figure);
		}

		protected void throwsFormatException()
		{
			Assert.ThrowsAny<FormatException>(_figure);
		}
	}
}