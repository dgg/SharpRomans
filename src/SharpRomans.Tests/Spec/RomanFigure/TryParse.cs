using NUnit.Framework;
using StoryQ;

namespace SharpRomans.Tests.Spec.RomanFigure
{
	[TestFixture, Category("Spec"), Category("RomanFigure")]
	public class TryParseTester
	{
		[Test]
		public void TryParseChar()
		{
			new Story("try parse a char").Tag("RomanFigure")
				.InOrderTo("try to get a figure instance")
				.AsA("library user")
				.IWant("to be able to try to parse a char")

				.WithScenario("parse a defined figure")
					.Given(aCharacter_, 'I')
					.When(theCharIsParsed)
					.Then(theResultIs_, true)
					.And(theFigureIs_, SharpRomans.RomanFigure.I)

				.WithScenario("parse an undefined figure")
					.Given(aCharacter_, 'W')
					.When(theCharIsParsed)
					.Then(theResultIs_, false)
					.And(theFigureIs_, (SharpRomans.RomanFigure)null)

				.WithScenario("figures are unique")
					.Given(aCharacter_, 'X')
					.When(theCharIsParsed)
					.And(theChar_IsParsedAgain, 'X')
					.Then(isTheSameFigure)

				.ExecuteWithReport();
		}

		[Test]
		public void TryParseString()
		{
			new Story("try parse a string").Tag("RomanFigure")
				.InOrderTo("try to get a figure instance")
				.AsA("library user")
				.IWant("to be able to try to parse a string")

				.WithScenario("parse a defined figure")
					.Given(aString_, "I")
					.When(theStringIsParsed)
					.Then(theResultIs_, true)
					.And(theFigureIs_, SharpRomans.RomanFigure.I)

				.WithScenario("parse an undefined figure")
					.Given(aString_, "W")
					.When(theStringIsParsed)
					.Then(theResultIs_, false)
					.And(theFigureIs_, (SharpRomans.RomanFigure)null)

				.WithScenario("figures are unique")
					.Given(aString_, "X")
					.When(theStringIsParsed)
					.And(theString_IsParsedAgain, "X")
					.Then(isTheSameFigure)

				.ExecuteWithReport();
		}

		char _character;
		private void aCharacter_(char character)
		{
			_character = character;
		}

		string _string;
		private void aString_(string str)
		{
			_string = str;
		}

		private bool _result;
		private SharpRomans.RomanFigure _parsed;
		private void theCharIsParsed()
		{
			_result = SharpRomans.RomanFigure.TryParse(_character, out _parsed);
		}

		private SharpRomans.RomanFigure _anotherFigure;
		private void theChar_IsParsedAgain(char c)
		{
			_result = SharpRomans.RomanFigure.TryParse(c, out _anotherFigure);
		}

		private void theStringIsParsed()
		{
			_result = SharpRomans.RomanFigure.TryParse(_string, out _parsed);
		}

		private void theString_IsParsedAgain(string s)
		{
			_result = SharpRomans.RomanFigure.TryParse(s, out _anotherFigure);
		}

		private void theResultIs_(bool obj)
		{
			Assert.That(_result, Is.EqualTo(obj));
		}

		private void theFigureIs_(SharpRomans.RomanFigure figure)
		{
			Assert.That(_parsed, Is.EqualTo(figure));
		}

		private void isTheSameFigure()
		{
			Assert.That(_parsed, Is.SameAs(_anotherFigure));
		}
	}
}