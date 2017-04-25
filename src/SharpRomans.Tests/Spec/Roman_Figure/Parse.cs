using System;
using SharpRomans.Tests.Support;
using StoryQ;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec"), Category("RomanFigure"), Category("Parse")]
	public class ParseTester
	{
		[Fact]
		public void ParseChar()
		{
			new Story("parse a char")
				.InOrderTo("get a figure instance")
				.AsA("library user")
				.IWant("to be able to parse a char")

				.WithScenario("parse a defined figure")
					.Given(aCharacter_, 'I')
					.When(theCharIsParsed)
					.Then(theFigureIs_, RomanFigure.I)

				.WithScenario("parse an undefined figure")
					.Given(aCharacter_, 'W')
					.When(theCharIsParsed)
					.Then(throwsArgumentException)

				.WithScenario("figures are unique")
					.Given(aCharacter_, 'X')
					.When(theChar_IsParsedAgain, 'X')
					.Then(isTheSameFigure)

				.ExecuteWithReport();
		}

		[Fact]
		public void ParseString()
		{
			new Story("parse a string")
				.InOrderTo("get a figure instance")
				.AsA("library user")
				.IWant("to be able to parse a string")

				.WithScenario("parse a defined figure")
					.Given(aString_, "I")
					.When(theStringIsParsed)
					.Then(theFigureIs_, RomanFigure.I)

				.WithScenario("parse an undefined figure")
					.Given(aString_, "W")
					.When(theStringIsParsed)
					.Then(throwsArgumentException)

				.WithScenario("parse a multiple character string")
					.Given(aString_, "XI")
					.When(theStringIsParsed)
					.Then(throwsFormatException)

				.WithScenario("figures are unique")
					.Given(aString_, "X")
					.When(theString_IsParsedAgain, "X")
					.Then(isTheSameFigure)

				.ExecuteWithReport();
		}

		char _character;
		private void aCharacter_(char character)
		{
			_character = character;
		}

		string _string;
		private void aString_(string s)
		{
			_string = s;
		}

		Func<RomanFigure> _figure;
		private void theCharIsParsed()
		{
			_figure = () => RomanFigure.Parse(_character);
		}

		private void theStringIsParsed()
		{
			_figure = () => RomanFigure.Parse(_string);
		}

		private void theFigureIs_(RomanFigure figure)
		{
			Assert.Equal(figure, _figure());
		}

		private void throwsArgumentException()
		{
			Action cast = () => _figure();
			Assert.ThrowsAny<ArgumentException>(cast);
		}

		private void throwsFormatException()
		{
			Action cast = () => _figure();
			Assert.ThrowsAny<FormatException>(cast);
		}

		private RomanFigure _anotherFigure;
		private void theChar_IsParsedAgain(char c)
		{
			_anotherFigure = RomanFigure.Parse(c);
		}

		private void theString_IsParsedAgain(string s)
		{
			_anotherFigure = RomanFigure.Parse(s);
		}

		private void isTheSameFigure()
		{
			Assert.Same(_anotherFigure, _figure());
		}
	}
}