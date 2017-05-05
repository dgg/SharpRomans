using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;
using System;

namespace SharpRomans.Tests.Spec.Roman_Numeral
{
	[Category("Spec", Subject = "RomanNumeral", Feature = "Parse")]
	[Collection("bddfy")]
	[Story(
		Title = "parse",
		AsA = "library user",
		IWant = "to be able to parse a string",
		SoThat = "I can get a roman numeral instance"
	)]
	public class ParseTester
	{
		[Fact]
		public void NoString()
		{
			this.WithTags("RomanNumeral", "Parse", "Unparseable", "NoString")
				.Given(_ => _.theInput(null))
				.When(_ => _.theInputIsParsing())
				.Then(_ => _.anExceptionIsThrown<ArgumentNullException>())
				.BDDfy("null");

			this.WithTags("RomanNumeral", "Parse", "Unparseable", "NoString")
				.Given(_ => _.theInput(string.Empty))
				.When(_ => _.theInputIsParsing())
				.Then(_ => _.anExceptionIsThrown<ArgumentException>())
				.BDDfy("empty");

			this.WithTags("RomanNumeral", "Parse", "Unparseable", "NoString")
				.Given(_ => _.theInput(" "))
				.When(_ => _.theInputIsParsing())
				.Then(_ => _.anExceptionIsThrown<ArgumentException>())
				.BDDfy("only spaces");
		}

		[Fact]
		public void Zero()
		{
			this.WithTags("RomanNumeral", "Parse", "Zero")
				.Given(_ => _.theInput("N"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theNumeral_IsObtained(RomanNumeral.Zero), "the numeral {0} is obtained")
				.BDDfy("uppercase zero");

			this.WithTags("RomanNumeral", "Parse", "Zero")
				.Given(_ => _.theInput("n"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theNumeral_IsObtained(RomanNumeral.Zero), "the numeral {0} is obtained")
				.BDDfy("lowercase zero");
		}

		[Fact]
		public void Repetition()
		{
			this.WithTags("RomanNumeral", "Parse", "Unparseable", "Repetition")
				.Given(_ => _.theInput("NN"))
				.When(_ => _.theInputIsParsing())
				.Then(_ => _.anExceptionIsThrown<NumeralParseException>())
				.BDDfy("zero repeated");

			this.WithTags("RomanNumeral", "TryParse", "Unparseable", "Repetition")
				.Given(_ => _.theInput("IIII"))
				.When(_ => _.theInputIsParsing())
				.Then(_ => _.anExceptionIsThrown<NumeralParseException>())
				.BDDfy("too many I");

			this.WithTags("RomanNumeral", "Parse", "Unparseable", "Repetition")
				.Given(_ => _.theInput("XXXX"))
				.When(_ => _.theInputIsParsing())
				.Then(_ => _.anExceptionIsThrown<NumeralParseException>())
				.BDDfy("too many X");

			this.WithTags("RomanNumeral", "Parse", "Unparseable", "Repetition")
				.Given(_ => _.theInput("CCCC"))
				.When(_ => _.theInputIsParsing())
				.Then(_ => _.anExceptionIsThrown<NumeralParseException>())
				.BDDfy("too many C");

			this.WithTags("RomanNumeral", "Parse", "Unparseable", "Repetition")
				.Given(_ => _.theInput("MMMM"))
				.When(_ => _.theInputIsParsing())
				.Then(_ => _.anExceptionIsThrown<NumeralParseException>())
				.BDDfy("too many M");

			this.WithTags("RomanNumeral", "Parse", "Unparseable", "Repetition")
				.Given(_ => _.theInput("CCCXXXXV"))
				.When(_ => _.theInputIsParsing())
				.Then(_ => _.anExceptionIsThrown<NumeralParseException>())
				.BDDfy("interleaved offenders");
		}

		[Fact]
		public void AdditiveCombination()
		{
			this.WithTags("RomanNumeral", "Parse", "Additive combination")
				.Given(_ => _.theInput("VI"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theNumeral_IsObtained(6u), "the numeral {0} is obtained")
				.BDDfy("six");

			this.WithTags("RomanNumeral", "Parse", "Additive combination")
				.Given(_ => _.theInput("MDCLXI"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theNumeral_IsObtained(1661u), "the numeral {0} is obtained")
				.BDDfy("1661");
		}

		[Fact]
		public void SubstractiveCombination()
		{
			this.WithTags("RomanNumeral", "Parse", "Substractive combination")
				.Given(_ => _.theInput("IV"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theNumeral_IsObtained(4u), "the numeral {0} is obtained")
				.BDDfy("four");

			this.WithTags("RomanNumeral", "Parse", "Substractive combination")
				.Given(_ => _.theInput("IX"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theNumeral_IsObtained(9u), "the numeral {0} is obtained")
				.BDDfy("nine");

			this.WithTags("RomanNumeral", "Parse", "Substractive combination")
				.Given(_ => _.theInput("XCIX"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theNumeral_IsObtained(99u), "the numeral {0} is obtained")
				.BDDfy("ninety-nine");

			this.WithTags("RomanNumeral", "Parse", "Unparseable", "Substractive combination")
				.Given(_ => _.theInput("MCMD"))
				.When(_ => _.theInputIsParsing())
				.Then(_ => _.anExceptionIsThrown<NumeralParseException>())
				.BDDfy("substract once");

			this.WithTags("RomanNumeral", "Parse", "Unparseable", "Substractive combination")
				.Given(_ => _.theInput("CMC"))
				.When(_ => _.theInputIsParsing())
				.Then(_ => _.anExceptionIsThrown<NumeralParseException>())
				.BDDfy("substract once");
		}

		[Fact]
		public void RepeatSingleFigures()
		{
			this.WithTags("RomanNumeral", "Parse", "Unparseable", "Repeat single figures")
				.Given(_ => _.theInput("VIV"))
				.When(_ => _.theInputIsParsing())
				.Then(_ => _.anExceptionIsThrown<NumeralParseException>())
				.BDDfy("too many V");

			this.WithTags("RomanNumeral", "Parse", "Unparseable", "Repeat single figures")
				.Given(_ => _.theInput("LXL"))
				.When(_ => _.theInputIsParsing())
				.Then(_ => _.anExceptionIsThrown<NumeralParseException>())
				.BDDfy("too many L");

			this.WithTags("RomanNumeral", "Parse", "Unparseable", "Repeat single figures")
				.Given(_ => _.theInput("DDII"))
				.When(_ => _.theInputIsParsing())
				.Then(_ => _.anExceptionIsThrown<NumeralParseException>())
				.BDDfy("too many D");
		}

		[Fact]
		public void ReducingValues()
		{
			this.WithTags("RomanNumeral", "Parse", "Reducing values")
				.Given(_ => _.theInput("XIX"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theNumeral_IsObtained(19u), "the numeral {0} is obtained")
				.BDDfy("ninteen");

			this.WithTags("RomanNumeral", "Parse", "Unparseable", "Reducing values")
				.Given(_ => _.theInput("XIM"))
				.When(_ => _.theInputIsParsing())
				.Then(_ => _.anExceptionIsThrown<NumeralParseException>())
				.BDDfy("wrong 899");

			this.WithTags("RomanNumeral", "Parse", "Unparseable", "Reducing values")
				.Given(_ => _.theInput("IIV"))
				.When(_ => _.theInputIsParsing())
				.Then(_ => _.anExceptionIsThrown<NumeralParseException>())
				.BDDfy("wrong 3");
		}

		[Fact]
		public void SomeBigNumbers()
		{
			this.WithTags("RomanNumeral", "Parse", "Larger numbers")
				.Given(_ => _.theInput("MCMXXVIII"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theNumeral_IsObtained(1928u), "the numeral {0} is obtained")
				.BDDfy("1928");

			this.WithTags("RomanNumeral", "Parse", "Larger numbers")
				.Given(_ => _.theInput("MMIX"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theNumeral_IsObtained(2009u), "the numeral {0} is obtained")
				.BDDfy("2009");

			this.WithTags("RomanNumeral", "Parse", "Larger numbers")
				.Given(_ => _.theInput("MCMXC"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theNumeral_IsObtained(1990u), "the numeral {0} is obtained")
				.BDDfy("1990");

			this.WithTags("RomanNumeral", "Parse", "Larger numbers")
				.Given(_ => _.theInput("MDCLXVI"))
				.When(_ => _.theInputIsParsed())
				.Then(_ => _.theNumeral_IsObtained(1666u), "the numeral {0} is obtained")
				.BDDfy("1666");
		}

		private string _input;
		private void theInput(string input)
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