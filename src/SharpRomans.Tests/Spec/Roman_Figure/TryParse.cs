
using SharpRomans.Tests.Support;
using Xunit;
using TestStack.BDDfy;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec", Subject = "RomanFigure", Feature = "TryParse")]
	[Collection("bddfy")]
	[Story(
		Title = "try parse",
		AsA = "library user",
		IWant = "to be able to try to parse text",
		SoThat = "I can get a figure instance"
	)]
	public class TryParseTester
	{
		[Fact]
		public void TryParseString()
		{
			this.WithTags("RomanFigure", "TryParse", "string")
				.Given(_ => _.theString("I"))
				.When(_=> _.theStringIsParsed())
				.Then(_ => _.theResultIs(true))
				.And(_ => _.theFigureIs(RomanFigure.I))
				.BDDfy("parse a defined figure");

			this.WithTags("RomanFigure", "TryParse", "string")
				.Given(_ => _.theString("W"))
				.When(_ => _.theStringIsParsed())
				.Then(_ => _.theResultIs(false))
				.And(_ => _.theFigureIs(null))
				.BDDfy("parse an undefined figure");

			this.WithTags("RomanFigure", "TryParse", "string")
				.Given(_ => _.theString("X"))
				.When(_ => _.theStringIsParsed())
				.And(_ => _.theString_IsParsedAgain("X"), "the string {0} is parsed again")
				.Then(_ => _.isTheSameFigure())
				.BDDfy("figures are unique");
		}

		[Fact]
		public void TryParseChar()
		{
			this.WithTags("RomanFigure", "TryParse", "char")
				.Given(_ => _.theCharacter('I'))
				.When(_ => _.theCharIsParsed())
				.Then(_ => _.theResultIs(true))
				.And(_ => _.theFigureIs(RomanFigure.I))
				.BDDfy("parse a defined figure");

			this.WithTags("RomanFigure", "TryParse", "char")
				.Given(_ => _.theCharacter('W'))
				.When(_ => _.theCharIsParsed())
				.Then(_ => _.theResultIs(false))
				.And(_ => _.theFigureIs(null))
				.BDDfy("parse an undefined figure");

			this.WithTags("RomanFigure", "TryParse", "char")
				.Given(_ => _.theCharacter('X'))
				.When(_ => _.theCharIsParsed())
				.And(_ => _.theChar_IsParsedAgain('X'), "the char {0} is parsed again")
				.Then(_ => _.isTheSameFigure())
				.BDDfy("figures are unique");
		}

		private string _string;
		private void theString(string str)
		{
			_string = str;
		}

		char _character;
		private void theCharacter(char character)
		{
			_character = character;
		}

		private void theStringIsParsed()
		{
			_result = RomanFigure.TryParse(_string, out _parsed);
		}
		private void theCharIsParsed()
		{
			_result = RomanFigure.TryParse(_character, out _parsed);
		}

		private void theString_IsParsedAgain(string s)
		{
			_result = RomanFigure.TryParse(s, out _anotherFigure);
		}

		private void theChar_IsParsedAgain(char c)
		{
			_result = RomanFigure.TryParse(c, out _anotherFigure);
		}

		private bool _result;
		private void theResultIs(bool obj)
		{
			Assert.Equal(obj, _result);
		}

		private RomanFigure _parsed;
		private void theFigureIs(RomanFigure figure)
		{
			Assert.Equal(figure, _parsed);
		}

		private RomanFigure _anotherFigure;
		private void isTheSameFigure()
		{
			Assert.Same(_anotherFigure, _parsed);
		}
	}
}