
using SharpRomans.Tests.Support;
using Xunit;
using TestStack.BDDfy;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec"), Category("RomanFigure"), Category("TryParse")]
	[Story(
		Title = "try parse a string",
		AsA = "library user",
		IWant = "to be able to try to parse a string",
		SoThat = "I can try to get a figure instance"
	)]
	public class TryParseString : TryParseBase
	{
		[Fact]
		public void TryParse()
		{

			this.WithTags("RomanFigure", "TryParse")
				.Given(_ => _.theString("I"))
				.When(_=> _.theStringIsParsed())
				.Then(_ => _.theResultIs(true))
				.And(_ => _.theFigureIs(RomanFigure.I))
				.BDDfy("parse a defined figure");

			this.WithTags("RomanFigure", "TryParse")
				.Given(_ => _.theString("W"))
				.When(_ => _.theStringIsParsed())
				.Then(_ => _.theResultIs(false))
				.And(_ => _.theFigureIs(null))
				.BDDfy("parse an undefined figure");

			this.WithTags("RomanFigure", "TryParse")
				.Given(_ => _.theString("X"))
				.When(_ => _.theStringIsParsed())
				.And(_ => _.theString_IsParsedAgain("X"))
				.Then(_ => _.isTheSameFigure())
				.BDDfy("figures are unique");
		}

		string _string;
		private void theString(string str)
		{
			_string = str;
		}
		
		private void theStringIsParsed()
		{
			_result = RomanFigure.TryParse(_string, out _parsed);
		}

		private void theString_IsParsedAgain(string s)
		{
			_result = RomanFigure.TryParse(s, out _anotherFigure);
		}
	}
}