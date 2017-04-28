using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec"), Category("RomanFigure"), Category("Parse")]
	[Story(
		Title = "parse a string",
		AsA = "library user",
		IWant = "to be able to parse a string",
		SoThat = "I can get a roman figure instance"
	)]
	public class ParseString : ParseBase
	{
		[Fact]
		public void Parse()
		{
			this.WithTags("RomanFigure", "Parse")
				.Given(_ => _.aString_("I"))
				.When(_ => _.theStringIsParsed())
				.Then(_ => _.theFigureIs(RomanFigure.I))
				.BDDfy("parse a defined figure");

			this.WithTags("RomanFigure", "Parse")
				.Given(_ => _.aString_("W"))
				.When(_ => _.theStringIsParsed())
				.Then(_ => _.throwsArgumentException())
				.BDDfy("parse an undefined figure");

			this.WithTags("RomanFigure", "Parse")
				.Given(_ => _.aString_("XI"))
				.When(_ => _.theStringIsParsed())
				.Then(_ => _.throwsFormatException())
				.BDDfy("parse a multiple character string");

			this.WithTags("RomanFigure", "Parse")
				.Given(_ => _.aString_("X"))
				.When(_ => _.theString_IsParsedAgain("X"))
				.Then(_ => _.isTheSameFigure())
				.BDDfy("figures are unique");
		}

		string _string;
		private void aString_(string s)
		{
			_string = s;
		}

		private void theStringIsParsed()
		{
			_figure = () => RomanFigure.Parse(_string);
		}

		private void theString_IsParsedAgain(string s)
		{
			_anotherFigure = RomanFigure.Parse(s);
		}
	}
}