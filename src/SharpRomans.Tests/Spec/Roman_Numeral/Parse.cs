using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;
using System;

namespace SharpRomans.Tests.Spec.Roman_Numeral
{
	[Category("Spec"), Category("RomanNumeral"), Category("Parse")]
	[Story(
		Title = "parse",
		AsA = "library user",
		IWant = "to be able to parse a string",
		SoThat = "I can get a roman numeral instance",
		Narrative1 = "lower figures to the right of bigger figures",
		Narrative2 = "lower figures to the left of bigger figures",
		Narrative3 = "numbers increase from left to right"
	)]
	public class ParseTester
	{
		[Fact]
		public void NoString()
		{
			this.WithTags("RomanNumeral", "Parse", "Unparseable", "NoString")
				.Given(_ => _.theInput_((string) null))
				.When(_ => _.theInputIsParsing())
				.Then(_ => _.anExceptionIsThrown<ArgumentNullException>())
				.BDDfy("null");

			this.WithTags("RomanNumeral", "Parse", "Unparseable", "NoString")
				.Given(_ => _.theInput_(string.Empty))
				.When(_ => _.theInputIsParsing())
				.Then(_ => _.anExceptionIsThrown<ArgumentException>())
				.BDDfy("empty");

			this.WithTags("RomanNumeral", "Parse", "Unparseable", "NoString")
				.Given(_ => _.theInput_(" "))
				.When(_ => _.theInputIsParsing())
				.Then(_ => _.anExceptionIsThrown<ArgumentException>())
				.BDDfy("only spaces");
		}

		[Fact]
		public void Zero()
		{
			this.WithTags("RomanNumeral", "Parse", "Zero")
				.Given(_ => _.theInput_("N"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theNumeral_IsObtained(RomanNumeral.Zero))
				.BDDfy("uppercase zero");

			this.WithTags("RomanNumeral", "Parse", "Zero")
				.Given(_ => _.theInput_("n"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theNumeral_IsObtained(RomanNumeral.Zero))
				.BDDfy("lowercase zero");
		}

		[Fact]
		public void Repetition()
		{
			this.WithTags("RomanNumeral", "Parse", "Unparseable", "Repetition")
				.Given(_ => _.theInput_("NN"))
				.When(_ => _.theInputIsParsing())
				.Then(_ => _.anExceptionIsThrown<NumeralParseException>())
				.BDDfy("zero repeated");

			this.WithTags("RomanNumeral", "TryParse", "Unparseable", "Repetition")
				.Given(_ => _.theInput_("IIII"))
				.When(_ => _.theInputIsParsing())
				.Then(_ => _.anExceptionIsThrown<NumeralParseException>())
				.BDDfy("too many I");

			this.WithTags("RomanNumeral", "Parse", "Unparseable", "Repetition")
				.Given(_ => _.theInput_("XXXX"))
				.When(_ => _.theInputIsParsing())
				.Then(_ => _.anExceptionIsThrown<NumeralParseException>())
				.BDDfy("too many X");

			this.WithTags("RomanNumeral", "Parse", "Unparseable", "Repetition")
				.Given(_ => _.theInput_("CCCC"))
				.When(_ => _.theInputIsParsing())
				.Then(_ => _.anExceptionIsThrown<NumeralParseException>())
				.BDDfy("too many C");

			this.WithTags("RomanNumeral", "Parse", "Unparseable", "Repetition")
				.Given(_ => _.theInput_("MMMM"))
				.When(_ => _.theInputIsParsing())
				.Then(_ => _.anExceptionIsThrown<NumeralParseException>())
				.BDDfy("too many M");

			this.WithTags("RomanNumeral", "Parse", "Unparseable", "Repetition")
				.Given(_ => _.theInput_("CCCXXXXV"))
				.When(_ => _.theInputIsParsing())
				.Then(_ => _.anExceptionIsThrown<NumeralParseException>())
				.BDDfy("interleaved offenders");
		}

		[Fact]
		public void AdditiveCombination()
		{
			this.WithTags("RomanNumeral", "Parse", "Additive combination")
				.Given(_ => _.theInput_("VI"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theNumeral_IsObtained(6u))
				.BDDfy("six");

			this.WithTags("RomanNumeral", "Parse", "Additive combination")
				.Given(_ => _.theInput_("MDCLXI"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theNumeral_IsObtained(1661u))
				.BDDfy("1661");
		}

		[Fact]
		public void SubstractiveCombination()
		{
			this.WithTags("RomanNumeral", "Parse", "Substractive combination")
				.Given(_ => _.theInput_("IV"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theNumeral_IsObtained(4u))
				.BDDfy("four");

			this.WithTags("RomanNumeral", "Parse", "Substractive combination")
				.Given(_ => _.theInput_("IX"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theNumeral_IsObtained(9u))
				.BDDfy("nine");

			this.WithTags("RomanNumeral", "Parse", "Substractive combination")
				.Given(_ => _.theInput_("XCIX"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theNumeral_IsObtained(99u))
				.BDDfy("ninety-nine");

			this.WithTags("RomanNumeral", "Parse", "Unparseable", "Substractive combination")
				.Given(_ => _.theInput_("MCMD"))
				.When(_ => _.theInputIsParsing())
				.Then(_ => _.anExceptionIsThrown<NumeralParseException>())
				.BDDfy("substract once");

			this.WithTags("RomanNumeral", "Parse", "Unparseable", "Substractive combination")
				.Given(_ => _.theInput_("CMC"))
				.When(_ => _.theInputIsParsing())
				.Then(_ => _.anExceptionIsThrown<NumeralParseException>())
				.BDDfy("substract once");
		}

		[Fact]
		public void RepeatSingleFigures()
		{
			this.WithTags("RomanNumeral", "Parse", "Unparseable", "Repeat single figures")
				.Given(_ => _.theInput_("VIV"))
				.When(_ => _.theInputIsParsing())
				.Then(_ => _.anExceptionIsThrown<NumeralParseException>())
				.BDDfy("too many V");

			this.WithTags("RomanNumeral", "Parse", "Unparseable", "Repeat single figures")
				.Given(_ => _.theInput_("LXL"))
				.When(_ => _.theInputIsParsing())
				.Then(_ => _.anExceptionIsThrown<NumeralParseException>())
				.BDDfy("too many L");

			this.WithTags("RomanNumeral", "Parse", "Unparseable", "Repeat single figures")
				.Given(_ => _.theInput_("DDII"))
				.When(_ => _.theInputIsParsing())
				.Then(_ => _.anExceptionIsThrown<NumeralParseException>())
				.BDDfy("too many D");
		}

		[Fact]
		public void ReducingValues()
		{
			this.WithTags("RomanNumeral", "Parse", "Reducing values")
				.Given(_ => _.theInput_("XIX"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theNumeral_IsObtained(19u))
				.BDDfy("ninteen");

			this.WithTags("RomanNumeral", "Parse", "Unparseable", "Reducing values")
				.Given(_ => _.theInput_("XIM"))
				.When(_ => _.theInputIsParsing())
				.Then(_ => _.anExceptionIsThrown<NumeralParseException>())
				.BDDfy("wrong 899");

			this.WithTags("RomanNumeral", "Parse", "Unparseable", "Reducing values")
				.Given(_ => _.theInput_("IIV"))
				.When(_ => _.theInputIsParsing())
				.Then(_ => _.anExceptionIsThrown<NumeralParseException>())
				.BDDfy("wrong 3");
		}

		[Fact]
		public void SomeBigNumbers()
		{
			this.WithTags("RomanNumeral", "Parse", "Larger numbers")
				.Given(_ => _.theInput_("MCMXXVIII"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theNumeral_IsObtained(1928u))
				.BDDfy("1928");

			this.WithTags("RomanNumeral", "Parse", "Larger numbers")
				.Given(_ => _.theInput_("MMIX"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theNumeral_IsObtained(2009u))
				.BDDfy("2009");

			this.WithTags("RomanNumeral", "Parse", "Larger numbers")
				.Given(_ => _.theInput_("MCMXC"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theNumeral_IsObtained(1990u))
				.BDDfy("1990");

			this.WithTags("RomanNumeral", "Parse", "Larger numbers")
				.Given(_ => _.theInput_("MDCLXVI"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theNumeral_IsObtained(1666u))
				.BDDfy("1666");
		}

		private string _input;
		private void theInput_(string input)
		{
			_input = input;
		}

		Func<RomanNumeral> _parsing;
		private void theInputIsParsing()
		{
			_parsing = () => RomanNumeral.Parse(_input);
		}

		RomanNumeral _parsed;
		private void theInputIsParsed()
		{
			_parsed = RomanNumeral.Parse(_input);
		}

		private void anExceptionIsThrown<T>() where T : Exception
		{
			Action del = () => _parsing();
			Assert.ThrowsAny<T>(del);
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