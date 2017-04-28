using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	public abstract class EqualityBase
	{
		protected RomanFigure _subject;
		protected void TheRomanFigure(RomanFigure figure)
		{
			_subject = figure;
		}
		protected bool _operation;
		protected void Is(bool result)
		{
			Assert.Equal(result, _operation);
		}
	}
}