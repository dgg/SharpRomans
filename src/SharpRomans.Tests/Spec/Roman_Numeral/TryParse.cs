using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Numeral
{
	[Category("Spec"), Category("RomanNumeral"), Category("TryParse")]
	[Collection("bddfy")]
	[Story(
		Title = "try parse",
		AsA = "library user",
		IWant = "to be able to try to parse a string",
		SoThat = "I can get a roman numeral instance without exceptions",
		Narrative1 = "lower figures to the right of bigger figures",
		Narrative2 = "lower figures to the left of bigger figures",
		Narrative3 = "numbers increase from left to right"
	)]
	public class TryParseTester
	{
		[Fact]
		public void NoString()
		{
			this.WithTags("RomanNumeral", "TryParse", "Unparseable", "NoString")
				.Given(_ => _.theInput(null))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theResultIs(false))
				.And(_ => _.theNumeral_IsObtained(null))
				.BDDfy("null");

			this.WithTags("RomanNumeral", "TryParse", "Unparseable", "NoString")
				.Given(_ => _.theInput(string.Empty))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theResultIs(false))
				.And(_ => _.theNumeral_IsObtained(null))
				.BDDfy("empty");

			this.WithTags("RomanNumeral", "TryParse", "Unparseable", "NoString")
				.Given(_ => _.theInput(" "))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theResultIs(false))
				.And(_ => _.theNumeral_IsObtained(null))
				.BDDfy("only spaces");
		}

		[Fact]
		public void Zero()
		{
			this.WithTags("RomanNumeral", "TryParse", "Zero")
				.Given(_ => _.theInput("N"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theResultIs(true))
				.And(_ => _.theNumeral_IsObtained(RomanNumeral.Zero))
				.BDDfy("uppercase zero");

			this.WithTags("RomanNumeral", "TryParse", "Zero")
				.Given(_ => _.theInput("n"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theResultIs(true))
				.And(_ => _.theNumeral_IsObtained(RomanNumeral.Zero))
				.BDDfy("lowercase zero");
		}

		[Fact]
		public void Repetition()
		{
			this.WithTags("RomanNumeral", "TryParse", "Unparseable", "Repetition")
				.Given(_ => _.theInput("NN"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theResultIs(false))
				.And(_ => _.theNumeral_IsObtained(null))
				.BDDfy("zero repeated");

			this.WithTags("RomanNumeral", "TryParse", "Unparseable", "Repetition")
				.Given(_ => _.theInput("IIII"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theResultIs(false))
				.And(_ => _.theNumeral_IsObtained(null))
				.BDDfy("too many I");

			this.WithTags("RomanNumeral", "TryParse", "Unparseable", "Repetition")
				.Given(_ => _.theInput("XXXX"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theResultIs(false))
				.And(_ => _.theNumeral_IsObtained(null))
				.BDDfy("too many X");

			this.WithTags("RomanNumeral", "TryParse", "Unparseable", "Repetition")
				.Given(_ => _.theInput("CCCC"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theResultIs(false))
				.And(_ => _.theNumeral_IsObtained(null))
				.BDDfy("too many C");

			this.WithTags("RomanNumeral", "TryParse", "Unparseable", "Repetition")
				.Given(_ => _.theInput("MMMM"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theResultIs(false))
				.And(_ => _.theNumeral_IsObtained(null))
				.BDDfy("too many M");

			this.WithTags("RomanNumeral", "TryParse", "Unparseable", "Repetition")
				.Given(_ => _.theInput("CCCXXXXV"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theResultIs(false))
				.And(_ => _.theNumeral_IsObtained(null))
				.BDDfy("interleaved offenders");
		}

		[Fact]
		public void AdditiveCombination()
		{
			this.WithTags("RomanNumeral", "TryParse", "Additive combination")
				.Given(_ => _.theInput("VI"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theResultIs(true))
				.And(_ => _.theNumeral_IsObtained(6u))
				.BDDfy("six");

			this.WithTags("RomanNumeral", "TryParse", "Additive combination")
				.Given(_ => _.theInput("MDCLXI"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theResultIs(true))
				.And(_ => _.theNumeral_IsObtained(1661u))
				.BDDfy("1661");
		}

		[Fact]
		public void SubstractiveCombination()
		{
			this.WithTags("RomanNumeral", "TryParse", "Substractive combination")
				.Given(_ => _.theInput("IV"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theResultIs(true))
				.And(_ => _.theNumeral_IsObtained(4u))
				.BDDfy("four");

			this.WithTags("RomanNumeral", "TryParse", "Substractive combination")
				.Given(_ => _.theInput("IX"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theResultIs(true))
				.And(_ => _.theNumeral_IsObtained(9u))
				.BDDfy("nine");

			this.WithTags("RomanNumeral", "TryParse", "Substractive combination")
				.Given(_ => _.theInput("XCIX"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theResultIs(true))
				.And(_ => _.theNumeral_IsObtained(99u))
				.BDDfy("ninety-nine");

			this.WithTags("RomanNumeral", "TryParse", "Unparseable", "Substractive combination")
				.Given(_ => _.theInput("MCMD"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theResultIs(false))
				.And(_ => _.theNumeral_IsObtained(null))
				.BDDfy("substract once");

			this.WithTags("RomanNumeral", "TryParse", "Unparseable", "Substractive combination")
				.Given(_ => _.theInput("CMC"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theResultIs(false))
				.And(_ => _.theNumeral_IsObtained(null))
				.BDDfy("substract once");
		}

		[Fact]
		public void RepeatSingleFigures()
		{
			this.WithTags("RomanNumeral", "TryParse", "Unparseable", "Repeat single figures")
				.Given(_ => _.theInput("VIV"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theResultIs(false))
				.And(_ => _.theNumeral_IsObtained(null))
				.BDDfy("too many V");

			this.WithTags("RomanNumeral", "TryParse", "Unparseable", "Repeat single figures")
				.Given(_ => _.theInput("LXL"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theResultIs(false))
				.And(_ => _.theNumeral_IsObtained(null))
				.BDDfy("too many L");

			this.WithTags("RomanNumeral", "TryParse", "Unparseable", "Repeat single figures")
				.Given(_ => _.theInput("DDII"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theResultIs(false))
				.And(_ => _.theNumeral_IsObtained(null))
				.BDDfy("too many D");
		}

		[Fact]
		public void ReducingValues()
		{
			this.WithTags("RomanNumeral", "TryParse", "Reducing values")
				.Given(_ => _.theInput("XIX"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theResultIs(true))
				.And(_ => _.theNumeral_IsObtained(19u))
				.BDDfy("nineteen");

			this.WithTags("RomanNumeral", "TryParse", "Unparseable", "Reducing values")
				.Given(_ => _.theInput("XIM"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theResultIs(false))
				.And(_ => _.theNumeral_IsObtained(null))
				.BDDfy("wrong 899");

			this.WithTags("RomanNumeral", "TryParse", "Unparseable", "Reducing values")
				.Given(_ => _.theInput("IIV"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theResultIs(false))
				.And(_ => _.theNumeral_IsObtained(null))
				.BDDfy("wrong 3");
		}

		[Fact]
		public void SomeBigNumbers()
		{
			this.WithTags("RomanNumeral", "TryParse", "Larger numbers")
				.Given(_ => _.theInput("MCMXXVIII"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theResultIs(true))
				.And(_ => _.theNumeral_IsObtained(1928u))
				.BDDfy("1928");

			this.WithTags("RomanNumeral", "TryParse", "Larger numbers")
				.Given(_ => _.theInput("MMIX"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theResultIs(true))
				.And(_ => _.theNumeral_IsObtained(2009u))
				.BDDfy("2009");

			this.WithTags("RomanNumeral", "TryParse", "Larger numbers")
				.Given(_ => _.theInput("MCMXC"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theResultIs(true))
				.And(_ => _.theNumeral_IsObtained(1990u))
				.BDDfy("1990");

			this.WithTags("RomanNumeral", "TryParse", "Larger numbers")
				.Given(_ => _.theInput("MDCLXVI"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theResultIs(true))
				.And(_ => _.theNumeral_IsObtained(1666u))
				.BDDfy("1666");
		}

		private string _input;
		private void theInput(string input)
		{
			_input = input;
		}

		RomanNumeral _parsed;
		private bool _result;
		private void theInputIsParsed()
		{
			_result = RomanNumeral.TryParse(_input, out _parsed);
		}

		private void theResultIs(bool obj)
		{
			Assert.Equal(obj, _result);
		}

		private void theNumeral_IsObtained(RomanNumeral numeral)
		{
			Assert.Equal(numeral, _parsed);
		}

		private void theNumeral_IsObtained(uint numeral)
		{
			Assert.Equal(new RomanNumeral((ushort)numeral), _parsed);
		}
	}
}