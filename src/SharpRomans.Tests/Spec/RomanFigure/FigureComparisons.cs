using NUnit.Framework;
using StoryQ;

namespace SharpRomans.Tests.Spec.RomanFigure
{
	[TestFixture, Category("Spec"), Category("RomanFigure")]
	public class FigureComparisonsTester
	{
		[Test]
		public void CompareToRomanFigure()
		{
			new Story("compare to roman figure")
				.InOrderTo("say that a figure is greater or lower than another figure")
				.AsA("library user")
				.IWant("compare a roman figure against another roman figure")

			.WithScenario("one figure is greater than another")
				.Given(TheRomanFigure_, SharpRomans.RomanFigure.V)
				.When(ComparedTo_, SharpRomans.RomanFigure.I)
				.Then(TheResultIsGreaterThanZero)

			.WithScenario("one figure is less than another")
				.Given(TheRomanFigure_, SharpRomans.RomanFigure.I)
				.When(ComparedTo_, SharpRomans.RomanFigure.X)
				.Then(TheResultIsLessThanZero)

			.WithScenario("one figure is equal to another")
				.Given(TheRomanFigure_, SharpRomans.RomanFigure.X)
				.When(ComparedTo_, SharpRomans.RomanFigure.X)
				.Then(TheResultIsZero)

			.WithScenario("one figure is compared to NULL")
				.Given(TheRomanFigure_, SharpRomans.RomanFigure.X)
				.When(ComparedTo_, (SharpRomans.RomanFigure)null)
				.Then(TheResultIsGreaterThanZero)

			.ExecuteWithReport();
		}

		private void TheResultIsZero()
		{
			Assert.That(_comparison, Is.EqualTo(0));
		}

		private void TheResultIsLessThanZero()
		{
			Assert.That(_comparison, Is.LessThan(0));
		}

		private void TheResultIsGreaterThanZero()
		{
			Assert.That(_comparison, Is.GreaterThan(0));
		}

		private int _comparison;

		private void ComparedTo_(SharpRomans.RomanFigure anotherFigure)
		{
			_comparison = _subject.CompareTo(anotherFigure);
		}

		SharpRomans.RomanFigure _subject;
		private void TheRomanFigure_(SharpRomans.RomanFigure figure)
		{
			_subject = figure;
		}
	}
}