
using SharpRomans.Tests.Support;
using Xunit;
using TestStack.BDDfy;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec"), Category("RomanFigure"), Category("TryParse")]
	[Story(
		Title = "try parse a char",
		AsA = "library user",
		IWant = "to be able to try to parse a char",
		SoThat = "I can try to get a figure instance"
	)]
	public class TryParseCharacter : TryParseBase
	{
		[Fact]
		public void TryParse()
		{

			this.WithTags("RomanFigure", "TryParse")
				.Given(_ => _.theCharacter('I'))
				.When(_ => _.theCharIsParsed())
				.Then(_ => _.theResultIs(true))
				.And(_ => _.theFigureIs(RomanFigure.I))
				.BDDfy("parse a defined figure");

			this.WithTags("RomanFigure", "TryParse")
				.Given(_ => _.theCharacter('W'))
				.When(_ => _.theCharIsParsed())
				.Then(_ => _.theResultIs(false))
				.And(_ => _.theFigureIs(null))
				.BDDfy("parse an undefined figure");

			this.WithTags("RomanFigure", "TryParse")
				.Given(_ => _.theCharacter('X'))
				.When(_ => _.theCharIsParsed())
				.And(_ => _.theChar_IsParsedAgain('X'))
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
			_result = RomanFigure.TryParse(_character, out _parsed);
		}

		private void theChar_IsParsedAgain(char c)
		{
			_result = RomanFigure.TryParse(c, out _anotherFigure);
		}
	}
}