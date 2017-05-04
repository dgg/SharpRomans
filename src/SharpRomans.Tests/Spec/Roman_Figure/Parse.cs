using System;
using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec"), Category("RomanFigure"), Category("Parse")]
	[Collection("bddfy")]
	[Story(
		Title = "parse",
		AsA = "library user",
		IWant = "to be able to parse text",
		SoThat = "I can get a roman figure instance"
	)]
	public class Parse
	{
		[Fact]
		public void ParseString()
		{
			this.WithTags("RomanFigure", "Parse", "string")
				.Given(_ => _.theString("I"))
				.When(_ => _.theStringIsParsed())
				.Then(_ => _.theFigureIs(RomanFigure.I))
				.BDDfy("parse a defined figure");

			this.WithTags("RomanFigure", "Parse", "string")
				.Given(_ => _.theString("W"))
				.When(_ => _.theStringIsParsed())
				.Then(_ => _.throwsArgumentException())
				.BDDfy("parse an undefined figure");

			this.WithTags("RomanFigure", "Parse", "string")
				.Given(_ => _.theString("XI"))
				.When(_ => _.theStringIsParsed())
				.Then(_ => _.throwsFormatException())
				.BDDfy("parse a multiple character string");

			this.WithTags("RomanFigure", "Parse", "string")
				.Given(_ => _.theString("X"))
				.When(_ => _.theString_IsParsedAgain("X"))
				.Then(_ => _.isTheSameFigure())
				.BDDfy("figures are unique");
		}

		[Fact]
		public void ParseChar()
		{
			this.WithTags("RomanFigure", "Parse", "char")
				.Given(_ => _.theCharacter('I'))
				.When(_ => _.theCharIsParsed())
				.Then(_ => _.theFigureIs(RomanFigure.I))
				.BDDfy("parse a defined figure");

			this.WithTags("RomanFigure", "Parse", "char")
				.Given(_ => _.theCharacter('W'))
				.When(_ => _.theCharIsParsed())
				.Then(_ => _.throwsArgumentException())
				.BDDfy("parse an undefined figure");

			this.WithTags("RomanFigure", "Parse", "char")
				.Given(_ => _.theCharacter('X'))
				.When(_ => _.theChar_IsParsedAgain('X'))
				.Then(_ => _.isTheSameFigure())
				.BDDfy("figures are unique");
		}

		string _string;
		private void theString(string s)
		{
			_string = s;
		}

		private char _character;
		private void theCharacter(char character)
		{
			_character = character;
		}

		private Func<RomanFigure> _figure;
		private void theStringIsParsed()
		{
			_figure = () => RomanFigure.Parse(_string);
		}

		private void theCharIsParsed()
		{
			_figure = () => RomanFigure.Parse(_character);
		}

		private void theString_IsParsedAgain(string s)
		{
			_anotherFigure = RomanFigure.Parse(s);
		}

		private void theChar_IsParsedAgain(char c)
		{
			_anotherFigure = RomanFigure.Parse(c);
		}

		private void theFigureIs(RomanFigure figure)
		{
			Assert.Equal(figure, _figure());
		}

		private RomanFigure _anotherFigure;
		private void isTheSameFigure()
		{
			Assert.Same(_anotherFigure, _figure());
		}

		private void throwsArgumentException()
		{
			Assert.ThrowsAny<ArgumentException>(_figure);
		}

		private void throwsFormatException()
		{
			Assert.ThrowsAny<FormatException>(_figure);
		}
	}
}