using NUnit.Framework;
using StoryQ;

namespace SharpRomans.Tests.Spec.RomanFigure
{
	[TestFixture, Category("Spec"), Category("RomanFigure")]
	public class FigureTester
	{
		[Test]
		public void Figures()
		{
			new Story("figures")
				.InOrderTo("get the character of individual figures")
				.AsA("library user")
				.IWant("to be able to invoke a method on a roman figure")

				.WithScenario("character of a figure")
					.Given(aRomanFigure_, SharpRomans.RomanFigure.I)
					.When(theFigureIsObtained)
					.Then(theFigureIs_, 'I')

				.WithScenario("character of a figure")
					.Given(aRomanFigure_, SharpRomans.RomanFigure.V)
					.When(theFigureIsObtained)
					.Then(theFigureIs_, 'V')

				.WithScenario("character of a figure")
					.Given(aRomanFigure_, SharpRomans.RomanFigure.X)
					.When(theFigureIsObtained)
					.Then(theFigureIs_, 'X')

				.WithScenario("character of a figure")
					.Given(aRomanFigure_, SharpRomans.RomanFigure.L)
					.When(theFigureIsObtained)
					.Then(theFigureIs_, 'L')

				.WithScenario("character of a figure")
					.Given(aRomanFigure_, SharpRomans.RomanFigure.C)
					.When(theFigureIsObtained)
					.Then(theFigureIs_, 'C')

				.WithScenario("character of a figure")
					.Given(aRomanFigure_, SharpRomans.RomanFigure.D)
					.When(theFigureIsObtained)
					.Then(theFigureIs_, 'D')

				.WithScenario("character of a figure")
					.Given(aRomanFigure_, SharpRomans.RomanFigure.M)
					.When(theFigureIsObtained)
					.Then(theFigureIs_, 'M')

				.ExecuteWithReport();
		}

		SharpRomans.RomanFigure _subject;
		private void aRomanFigure_(SharpRomans.RomanFigure figure)
		{
			_subject = figure;
		}

		char _character;
		private void theFigureIsObtained()
		{
			_character = _subject.Figure;
		}

		private void theFigureIs_(char character)
		{
			Assert.That(_character, Is.EqualTo(character));
		}
	}
}