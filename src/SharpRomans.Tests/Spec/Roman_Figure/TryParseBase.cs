using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	public abstract class TryParseBase
	{
		protected bool _result;
		protected void theResultIs(bool obj)
		{
			Assert.Equal(obj, _result);
		}

		protected RomanFigure _parsed;
		protected void theFigureIs(RomanFigure figure)
		{
			Assert.Equal(figure, _parsed);
		}

		protected RomanFigure _anotherFigure;
		protected void isTheSameFigure()
		{
			Assert.Same(_anotherFigure, _parsed);
		}
	}
}