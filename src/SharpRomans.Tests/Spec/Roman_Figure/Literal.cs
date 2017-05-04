using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec"), Category("RomanFigure"), Category("Literal")]
	[Collection("bddfy")]
	[Story(
		Title = "literals",
		AsA = "library user",
		IWant = "to be able to invoke a property on a roman figure",
		SoThat = "I can get the literal of individual figures"
	)]
	public class LiteralTester
	{
		[Fact]
		public void Literals()
		{
			this.WithTags("RomanFigure", "Literal")
				.Given(_ => _.theRomanFigure(RomanFigure.I))
				.When(_ => _.theLiteralIsObtained())
				.Then(_ => _.theLiteralIs('I'))
				.BDDfy("character of a figure");

			this.WithTags("RomanFigure", "Literal")
				.Given(_ => _.theRomanFigure(RomanFigure.V))
				.When(_ => _.theLiteralIsObtained())
				.Then(_ => _.theLiteralIs('V'))
				.BDDfy("character of a figure");

			this.WithTags("RomanFigure", "Literal")
				.Given(_ => _.theRomanFigure(RomanFigure.X))
				.When(_ => _.theLiteralIsObtained())
				.Then(_ => _.theLiteralIs('X'))
				.BDDfy("character of a figure");

			this.WithTags("RomanFigure", "Literal")
				.Given(_ => _.theRomanFigure(RomanFigure.L))
				.When(_ => _.theLiteralIsObtained())
				.Then(_ => _.theLiteralIs('L'))
				.BDDfy("character of a figure");

			this.WithTags("RomanFigure", "Literal")
				.Given(_ => _.theRomanFigure(RomanFigure.C))
				.When(_ => _.theLiteralIsObtained())
				.Then(_ => _.theLiteralIs('C'))
				.BDDfy("character of a figure");

			this.WithTags("RomanFigure", "Literal")
				.Given(_ => _.theRomanFigure(RomanFigure.D))
				.When(_ => _.theLiteralIsObtained())
				.Then(_ => _.theLiteralIs('D'))
				.BDDfy("character of a figure");

			this.WithTags("RomanFigure", "Literal")
				.Given(_ => _.theRomanFigure(RomanFigure.M))
				.When(_ => _.theLiteralIsObtained())
				.Then(_ => _.theLiteralIs('M'))
				.BDDfy("character of a figure");
		}

		RomanFigure _subject;
		private void theRomanFigure(RomanFigure figure)
		{
			_subject = figure;
		}

		char _literal;
		private void theLiteralIsObtained()
		{
			_literal = _subject.Literal;
		}

		private void theLiteralIs(char character)
		{
			Assert.Equal(character, _literal);
		}
	}
}