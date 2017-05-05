using System;
using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Numeral
{
	[Category("Spec", Subject = "RomanNumeral", Feature = "Castings")]
	[Collection("bddfy")]
	[Story(
		Title = "explicit casting",
		AsA = "library user",
		IWant = "to be able to explicitely cast a roman numeral",
		SoThat = "I can get information about the numeral"
	)]
	public class CastingsTester
	{
		[Fact]
		public void CastToNumber()
		{
			this.WithTags("RomanNumeral", "Castings", "to number")
				.Given(_ => _.theRomanNumeral(RomanNumeral.Zero))
				.When(_ => _.isCastedToNumber())
				.Then(_ => _.theNumberIs(0))
				.BDDfy("number of a numeral");

			this.WithTags("RomanNumeral", "Castings", "to number")
				.Given(_ => _.theRomanNumeral(new RomanNumeral(11)))
				.When(_ => _.isCastedToNumber())
				.Then(_ => _.theNumberIs(11))
				.BDDfy("number of a numeral");

			this.WithTags("RomanNumeral", "Castings", "to number")
				.Given(_ => _.theRomanNumeral(null))
				.When(_ => _.isCastedToNumber())
				.Then(_ => _.throwsArgumentException())
				.BDDfy("number of null");
		}

		[Fact]
		public void CastToString()
		{
			this.WithTags("RomanNumeral", "Castings", "to string")
				.Given(_ => _.theRomanNumeral(RomanNumeral.Zero))
				.When(_ => _.isCastedToString())
				.Then(_ => _.theStringIs_("N"))
				.BDDfy("string of a numeral");

			this.WithTags("RomanNumeral", "Castings", "to string")
				.Given(_ => _.theRomanNumeral(new RomanNumeral(11)))
				.When(_ => _.isCastedToString())
				.Then(_ => _.theStringIs_("XI"))
				.BDDfy("string of a numeral");

			this.WithTags("RomanNumeral", "Castings", "to string")
				.Given(_ => _.theRomanNumeral(null))
				.When(_ => _.isCastedToString())
				.Then(_ => _.theStringIs_(null))
				.BDDfy("string of null");
		}

		RomanNumeral _subject;
		private void theRomanNumeral(RomanNumeral numeral)
		{
			_subject = numeral;
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

		private void theNumberIs(int number)
		{
			Assert.Equal(number, _number());
		}

		private void theStringIs_(string numeral)
		{
			Assert.Equal(numeral, _string());
		}

		private void throwsArgumentException()
		{
			Action cast = () =>_number();
			Assert.ThrowsAny<ArgumentNullException>(cast);
		}
	}
}
