using System;
using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec", Subject = "RomanFigure", Feature = "Castings")]
	[Collection("bddfy")]
	[Story(
		Title = "explicit casting",
		AsA = "library user",
		IWant = "to be able to explicitely cast a roman figure",
		SoThat = "I can extract information of individual figures"
	)]
	public class CastingsTester
	{
		[Fact]
		public void CastToChar()
		{
			this.WithTags("RomanFigure", "Castings")
				.Given(_ => _.theRomanFigure(RomanFigure.N))
				.When(_ => _.isCastedToChar())
				.Then(_ => _.theCharacterIs('N'))
				.BDDfy("character of a figure");

			this.WithTags("RomanFigure", "Castings")
				.Given(_ => _.theRomanFigure(RomanFigure.X))
				.When(_ => _.isCastedToChar())
				.Then(_ => _.theCharacterIs('X'))
				.BDDfy("character of a figure");

			this.WithTags("RomanFigure", "Castings")
				.Given(_ => _.theRomanFigure(null))
					.When(_ => _.isCastedToChar())
					.Then(_ => _.throwsArgumentException())
				.BDDfy("character of null");
		}

		[Fact]
		public void CastToNumber()
		{
			this.WithTags("RomanFigure", "Castings")
				.Given(_ => _.theRomanFigure(RomanFigure.N))
				.When(_ => _.isCastedToNumber())
				.Then(_ => _.theNumberIs(0))
				.BDDfy("number of a figure");

			this.WithTags("RomanFigure", "Castings")
				.Given(_ => _.theRomanFigure(RomanFigure.X))
				.When(_ => _.isCastedToNumber())
				.Then(_ => _.theNumberIs(10))
				.BDDfy("number of a figure");

			this.WithTags("RomanFigure", "Castings")
				.Given(_ => _.theRomanFigure(null))
				.When(_ => _.isCastedToNumber())
				.Then(_ => _.throwsArgumentException())
				.BDDfy("number of null");
		}

		[Fact]
		public void CastToString()
		{
			this.WithTags("RomanFigure", "Castings")
				.Given(_ => _.theRomanFigure(RomanFigure.N))
				.When(_ => _.isCastedToString())
				.Then(_ => _.theStringIs("N"))
				.BDDfy("string of a figure");

			this.WithTags("RomanFigure", "Castings")
				.Given(_ => _.theRomanFigure(RomanFigure.X))
				.When(_ => _.isCastedToString())
				.Then(_ => _.theStringIs("X"))
				.BDDfy("string of a figure");

			this.WithTags("RomanFigure", "Castings")
				.Given(_ => _.theRomanFigure(null))
				.When(_ => _.isCastedToString())
				.Then(_ => _.theStringIs(null))
				.BDDfy("number of null");
		}

		RomanFigure _subject;
		private void theRomanFigure(RomanFigure figure)
		{
			_subject = figure;
		}

		Func<char> _character;
		private void isCastedToChar()
		{
			_character = () => (char)_subject;
		}

		Func<ushort> _number;
		private void isCastedToNumber()
		{
			_number = () => (ushort)_subject;
		}

		Func<string> _string;
		private void isCastedToString()
		{
			_string = () => (string)_subject;
		}

		private void theCharacterIs(char character)
		{
			Assert.Equal(character, _character());
		}

		private void theNumberIs(int number)
		{
			Assert.Equal(number, _number());
		}

		private void theStringIs(string numeral)
		{
			Assert.Equal(numeral, _string());
		}

		private void throwsArgumentException()
		{
			// using the same method for two scenarios
			Action cast;
			if (_character != null)
			{
				cast = () => _character();
			}
			else
			{
				cast = () => _number();
			}
			Assert.ThrowsAny<ArgumentNullException>(cast);
		}
	}
}