using System;
using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec"), Category("RomanFigure"), Category("Castings")]
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
				.Given(_ => _.aRomanFigure_(RomanFigure.N))
				.When(_ => _.isCastedToChar())
				.Then(_ => _.theCharacterIs_('N'))
				.BDDfy("character of a figure");

			this.WithTags("RomanFigure", "Castings")
				.Given(_ => _.aRomanFigure_(RomanFigure.X))
				.When(_ => _.isCastedToChar())
				.Then(_ => _.theCharacterIs_('X'))
				.BDDfy("character of a figure");

			this.WithTags("RomanFigure", "Castings")
				.Given(_ => _.aRomanFigure_((RomanFigure)null))
					.When(_ => _.isCastedToChar())
					.Then(_ => _.throwsArgumentException())
				.BDDfy("character of null");
		}

		[Fact]
		public void CastToNumber()
		{
			this.WithTags("RomanFigure", "Castings")
				.Given(_ => _.aRomanFigure_(RomanFigure.N))
				.When(_ => _.isCastedToNumber())
				.Then(_ => _.theNumberIs_(0))
				.BDDfy("number of a figure");

			this.WithTags("RomanFigure", "Castings")
				.Given(_ => _.aRomanFigure_(RomanFigure.X))
				.When(_ => _.isCastedToNumber())
				.Then(_ => _.theNumberIs_(10))
				.BDDfy("number of a figure");

			this.WithTags("RomanFigure", "Castings")
				.Given(_ => _.aRomanFigure_((RomanFigure)null))
				.When(_ => _.isCastedToNumber())
				.Then(_ => _.throwsArgumentException())
				.BDDfy("number of null");
		}

		[Fact]
		public void CastToString()
		{
			this.WithTags("RomanFigure", "Castings")
				.Given(_ => _.aRomanFigure_(RomanFigure.N))
				.When(_ => _.isCastedToString())
				.Then(_ => _.theStringIs_("N"))
				.BDDfy("string of a figure");

			this.WithTags("RomanFigure", "Castings")
				.Given(_ => _.aRomanFigure_(RomanFigure.X))
				.When(_ => _.isCastedToString())
				.Then(_ => _.theStringIs_("X"))
				.BDDfy("string of a figure");

			this.WithTags("RomanFigure", "Castings")
				.Given(_ => _.aRomanFigure_((RomanFigure)null))
				.When(_ => _.isCastedToString())
				.Then(_ => _.theStringIs_((string)null))
				.BDDfy("number of null");
		}

		RomanFigure _subject;
		private void aRomanFigure_(RomanFigure figure)
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

		private void theCharacterIs_(char character)
		{
			Assert.Equal(character, _character());
		}

		private void theNumberIs_(int number)
		{
			Assert.Equal(number, _number());
		}

		private void theStringIs_(string numeral)
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