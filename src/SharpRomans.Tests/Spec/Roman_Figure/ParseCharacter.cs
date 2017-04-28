using System;
using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec"), Category("RomanFigure"), Category("Parse")]
	[Story(
		Title = "parse a char",
		AsA = "library user",
		IWant = "to be able to parse a char",
		SoThat = "I can get a roman figure instance"
	)]
	public class ParseCharacter : ParseBase
	{
		[Fact]
		public void Parse()
		{
			this.WithTags("RomanFigure", "Parse")
				.Given(_=>_.theCharacter('I'))
				.When(_ => _.theCharIsParsed())
				.Then(_ => _.theFigureIs(RomanFigure.I))
				.BDDfy("parse a defined figure");

			this.WithTags("RomanFigure", "Parse")
				.Given(_ => _.theCharacter('W'))
				.When(_ => _.theCharIsParsed())
				.Then(_ => _.throwsArgumentException())
				.BDDfy("parse an undefined figure");

			this.WithTags("RomanFigure", "Parse")
				.Given(_ => _.theCharacter('X'))
				.When(_ => _.theChar_IsParsedAgain('X'))
				.Then(_ => _.isTheSameFigure())
				.BDDfy("figures are unique");
		}

		char _character;
		private void theCharacter(char character)
		{
			_character = character;
		}
		
		private void theCharIsParsed()
		{
			_figure = () => RomanFigure.Parse(_character);
		}
		
		private void theChar_IsParsedAgain(char c)
		{
			_anotherFigure = RomanFigure.Parse(c);
		}
	}
}