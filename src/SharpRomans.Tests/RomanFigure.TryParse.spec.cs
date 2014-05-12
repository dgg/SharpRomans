using NUnit.Framework;
using StoryQ;

namespace SharpRomans.Tests
{
	[TestFixture, Category("Spec"), Category("RomanLiteral")]
	public class TryParseTester
	{
		[Test]
		public void TryParseChar()
		{
			new Story("try parse a char")
				.InOrderTo("try to get a figure instance")
				.AsA("library user")
				.IWant("to be able to try to parse a char")

				.WithScenario("parse a defined figure")
					.Given(aCharacter_, 'I')
					.When(theCharIsParsed)
					.Then(theResultIs_, true)
					.And(theFigure_Is, RomanFigure.I)

				.WithScenario("parse an undefined figure")
					.Given(aCharacter_, 'W')
					.When(theCharIsParsed)
					.Then(theResultIs_, false)
					.And(theFigure_Is, (RomanFigure)null)

				.WithScenario("figures are unique")
					.Given(aCharacter_, 'X')
					.When(theCharIsParsed)
					.And(theCharIsParsedAgain_, 'X')
					.Then(isTheSameFigure)

				.ExecuteWithReport();
		}

		char _character;
		private void aCharacter_(char character)
		{
			_character = character;
		}

		private bool _result;
		private RomanFigure _parsed;
		private void theCharIsParsed()
		{
			_result = RomanFigure.TryParse(_character, out _parsed);
		}

		private RomanFigure _anotherFigure;
		private void theCharIsParsedAgain_(char c)
		{
			_result = RomanFigure.TryParse(c, out _anotherFigure);
		}

		private void theResultIs_(bool obj)
		{
			Assert.That(_result, Is.EqualTo(obj));
		}

		private void theFigure_Is(RomanFigure figure)
		{
			Assert.That(_parsed, Is.EqualTo(figure));
		}

		private void isTheSameFigure()
		{
			Assert.That(_parsed, Is.SameAs(_anotherFigure));
		}
	}
}