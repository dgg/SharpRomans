using System;
using SharpRomans.Tests.Support;
using StoryQ;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Numeral
{
	[Category("Spec"), Category("RomanNumeral"), Category("Parse")]
	public class ParseTester
	{
		[Fact]
		public void NoString()
		{
			new Story("parse no string as roman numeral")
				.InOrderTo("not be surprised with unexpected results")
				.AsA("library user")
				.IWant("unparseable strings to throw.")

				.BDDfy("null")
					.Given(theInput_, (string) null)
					.When(theInputIsParsing)
					.Then(anExceptionIsThrown<ArgumentNullException>)

				.BDDfy("empty")
					.Given(theInput_, string.Empty)
					.When(theInputIsParsing)
					.Then(anExceptionIsThrown<ArgumentException>)

				.BDDfy("only spaces")
					.Given(theInput_, " ")
					.When(theInputIsParsing)
					.Then(anExceptionIsThrown<ArgumentException>)

				.ExecuteWithReport();
		}

		[Fact]
		public void Zero()
		{
			new Story("parse zero roman numeral")
				.InOrderTo("obtain the zero roman numeral from a string")
				.AsA("library user")
				.IWant("parse the zero string.")

				.BDDfy("uppercase zero")
					.Given(theInput_, "N")
					.When(theInputIsParsed)
					.Then(theNumeral_IsObtained, RomanNumeral.Zero)

				.BDDfy("lowercase zero")
					.Given(theInput_, "n")
					.When(theInputIsParsed)
					.Then(theNumeral_IsObtained, RomanNumeral.Zero)

				.BDDfy("zero repeated")
					.Given(theInput_, "NN")
					.When(theInputIsParsing)
					.Then(anExceptionIsThrown<NumeralParseException>)

				.ExecuteWithReport();
		}

		[Fact]
		public void Repetition()
		{
			new Story("parse zero roman numeral")
				.InOrderTo("prevent invalid roman numeral to be parsed")
				.AsA("library user")
				.IWant("unparseable strings to throw.")

				.BDDfy("too many I")
					.Given(theInput_, "IIII")
					.When(theInputIsParsing)
					.Then(anExceptionIsThrown<NumeralParseException>)

				.BDDfy("too many X")
					.Given(theInput_, "XXXX")
					.When(theInputIsParsing)
					.Then(anExceptionIsThrown<NumeralParseException>)

				.BDDfy("too many C")
					.Given(theInput_, "CCCC")
					.When(theInputIsParsing)
					.Then(anExceptionIsThrown<NumeralParseException>)

				.BDDfy("too many M")
					.Given(theInput_, "MMMM")
					.When(theInputIsParsing)
					.Then(anExceptionIsThrown<NumeralParseException>)

				.BDDfy("interleaved offenders")
					.Given(theInput_, "CCCXXXXV")
					.When(theInputIsParsing)
					.Then(anExceptionIsThrown<NumeralParseException>)

				.ExecuteWithReport();
		}

		[Fact]
		public void AdditiveCombination()
		{
			new Story("parse zero roman numeral")
				.InOrderTo("obtain the valid roman numeral from a string")
				.AsA("library user")
				.IWant("parse strings that contain lower figures to the right of bigger figures.")

				.BDDfy("six")
					.Given(theInput_, "VI")
					.When(theInputIsParsed)
					.Then(theNumeral_IsObtained, 6u)

				.BDDfy("1661")
					.Given(theInput_, "MDCLXI")
					.When(theInputIsParsed)
					.Then(theNumeral_IsObtained, 1661u)

				.ExecuteWithReport();
		}

		[Fact]
		public void SubstractiveCombination()
		{
			new Story("parse zero roman numeral")
				.InOrderTo("obtain the valid roman numeral from a string")
				.AsA("library user")
				.IWant("parse strings that contain lower figures to the left of bigger figures.")

				.BDDfy("four")
					.Given(theInput_, "IV")
					.When(theInputIsParsed)
					.Then(theNumeral_IsObtained, 4u)

				.BDDfy("nine")
					.Given(theInput_, "IX")
					.When(theInputIsParsed)
					.Then(theNumeral_IsObtained, 9u)

				.BDDfy("ninety-nine")
					.Given(theInput_, "XCIX")
					.When(theInputIsParsed)
					.Then(theNumeral_IsObtained, 99u)

				.BDDfy("substract once")
					.Given(theInput_, "MCMD")
					.When(theInputIsParsing)
					.Then(anExceptionIsThrown<NumeralParseException>)

				.BDDfy("substract once")
					.Given(theInput_, "CMC")
					.When(theInputIsParsing)
					.Then(anExceptionIsThrown<NumeralParseException>)

				.ExecuteWithReport();
		}

		[Fact]
		public void RepeatSingleFigures()
		{
			new Story("parse zero roman numeral")
				.InOrderTo("prevent invalid roman numeral to be parsed")
				.AsA("library user")
				.IWant("unparseable strings to throw.")

				.BDDfy("too many V")
					.Given(theInput_, "VIV")
					.When(theInputIsParsing)
					.Then(anExceptionIsThrown<NumeralParseException>)

				.BDDfy("too many L")
					.Given(theInput_, "LXL")
					.When(theInputIsParsing)
					.Then(anExceptionIsThrown<NumeralParseException>)

				.BDDfy("too many D")
					.Given(theInput_, "DDII")
					.When(theInputIsParsing)
					.Then(anExceptionIsThrown<NumeralParseException>)

				.ExecuteWithReport();
		}

		[Fact]
		public void ReducingValues()
		{
			new Story("parse zero roman numeral")
				.InOrderTo("obtain the valid roman numeral from a string")
				.AsA("library user")
				.IWant("parse strings that numbers increase from left to right.")

				.BDDfy("ninteen")
					.Given(theInput_, "XIX")
					.When(theInputIsParsed)
					.Then(theNumeral_IsObtained, 19u)

				.BDDfy("wrong 899")
					.Given(theInput_, "XIM")
					.When(theInputIsParsing)
					.Then(anExceptionIsThrown<NumeralParseException>)

				.BDDfy("wrong 3")
					.Given(theInput_, "IIV")
					.When(theInputIsParsing)
					.Then(anExceptionIsThrown<NumeralParseException>)

				.ExecuteWithReport();
		}

		[Fact]
		public void SomeBigNumbers()
		{
			new Story("parse zero roman numeral")
				.InOrderTo("obtain the valid roman numeral from a string")
				.AsA("library user")
				.IWant("parse strings that numbers increase from left to right.")

				.BDDfy("1928")
					.Given(theInput_, "MCMXXVIII")
					.When(theInputIsParsed)
					.Then(theNumeral_IsObtained, 1928u)

				.BDDfy("2009")
					.Given(theInput_, "MMIX")
					.When(theInputIsParsed)
					.Then(theNumeral_IsObtained, 2009u)

				.BDDfy("1990")
					.Given(theInput_, "MCMXC")
					.When(theInputIsParsed)
					.Then(theNumeral_IsObtained, 1990u)

				.BDDfy("1666")
					.Given(theInput_, "MDCLXVI")
					.When(theInputIsParsed)
					.Then(theNumeral_IsObtained, 1666u)

				.ExecuteWithReport();
		}

		private string _input;
		private void theInput_(string input)
		{
			_input = input;
		}

		Func<RomanNumeral> _parsing;
		private void theInputIsParsing()
		{
			_parsing = ()=> RomanNumeral.Parse(_input);
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