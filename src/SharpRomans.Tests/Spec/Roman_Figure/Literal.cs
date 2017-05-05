using System.Collections.Generic;
using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec", Subject = "RomanFigure", Feature = "Literal")]
	[Collection("bddfy")]
	[Story(
		Title = "literals",
		AsA = "library user",
		IWant = "to be able to invoke a property on a roman figure",
		SoThat = "I can get the literal of individual figures"
	)]
	public class LiteralTester
	{
		public static IEnumerable<object[]> FigureLiterals = new []
		{
			new object[]{RomanFigure.I, 'I'}, 
			new object[]{RomanFigure.V, 'V'}, 
			new object[]{RomanFigure.X, 'X'}, 
			new object[]{RomanFigure.L, 'L'}, 
			new object[]{RomanFigure.C, 'C'}, 
			new object[]{RomanFigure.D, 'D'}, 
			new object[]{RomanFigure.M, 'M'}, 
		};

		[Theory]
		[MemberData(nameof(FigureLiterals))]
		public void Literals(RomanFigure figure, char literal)
		{
			this.WithTags("RomanFigure", "Literal")
				.Given(_ => _.theRomanFigure(figure))
				.When(_ => _.theLiteralIsObtained())
				.Then(_ => _.theLiteralIs(literal))
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