using NUnit.Framework;
using StoryQ;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[TestFixture, Category("Spec"), Category("RomanFigure")]
	public class LiteralTester
	{
		[Test]
		public void Literals()
		{
			new Story("literals")
				.InOrderTo("get the literal of individual figures")
				.AsA("library user")
				.IWant("to be able to invoke a method on a roman figure")

				.WithScenario("character of a figure")
					.Given(aRomanFigure_, RomanFigure.I)
					.When(theLiteralIsObtained)
					.Then(theLiteralIs_, 'I')

				.WithScenario("character of a figure")
					.Given(aRomanFigure_, RomanFigure.V)
					.When(theLiteralIsObtained)
					.Then(theLiteralIs_, 'V')

				.WithScenario("character of a figure")
					.Given(aRomanFigure_, RomanFigure.X)
					.When(theLiteralIsObtained)
					.Then(theLiteralIs_, 'X')

				.WithScenario("character of a figure")
					.Given(aRomanFigure_, RomanFigure.L)
					.When(theLiteralIsObtained)
					.Then(theLiteralIs_, 'L')

				.WithScenario("character of a figure")
					.Given(aRomanFigure_, RomanFigure.C)
					.When(theLiteralIsObtained)
					.Then(theLiteralIs_, 'C')

				.WithScenario("character of a figure")
					.Given(aRomanFigure_, RomanFigure.D)
					.When(theLiteralIsObtained)
					.Then(theLiteralIs_, 'D')

				.WithScenario("character of a figure")
					.Given(aRomanFigure_, RomanFigure.M)
					.When(theLiteralIsObtained)
					.Then(theLiteralIs_, 'M')

				.ExecuteWithReport();
		}

		RomanFigure _subject;
		private void aRomanFigure_(RomanFigure figure)
		{
			_subject = figure;
		}

		char _literal;
		private void theLiteralIsObtained()
		{
			_literal = _subject.Literal;
		}

		private void theLiteralIs_(char character)
		{
			Assert.That(_literal, Is.EqualTo(character));
		}
	}
}