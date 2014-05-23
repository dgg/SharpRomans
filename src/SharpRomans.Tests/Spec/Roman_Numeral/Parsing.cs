using System;
using NUnit.Framework;
using StoryQ;

namespace SharpRomans.Tests.Spec.Roman_Numeral
{
	[TestFixture, Category("Spec"), Category("RomanNumeral"), Category("Parsing")]
	public class ParsingTester
	{
		[Test]
		public void NoString()
		{
			new Story("parse no string as roman numeral")
				.InOrderTo("not be surprised with unexpected results")
				.AsA("library user")
				.IWant("unparseable strings to throw.")

				.WithScenario("null")
					.Given(theInput_, (string) null)
					.When(theInputIsParsing)
					.Then(anExceptionIsThrown<ArgumentNullException>)

				.WithScenario("empty")
					.Given(theInput_, string.Empty)
					.When(theInputIsParsing)
					.Then(anExceptionIsThrown<ArgumentException>)

				.WithScenario("only spaces")
					.Given(theInput_, " ")
					.When(theInputIsParsing)
					.Then(anExceptionIsThrown<ArgumentException>)

				.ExecuteWithReport();
		}

		[Test]
		public void Zero()
		{
			new Story("parse zero roman numeral")
				.InOrderTo("obtain the zero roman numeral from a string")
				.AsA("library user")
				.IWant("parse the zero string.")

				.WithScenario("uppercase zero")
					.Given(theInput_, "N")
					.When(theInputIsParsed)
					.Then(theNumeral_IsObtained, RomanNumeral.Zero)

				.WithScenario("lowercase zero")
					.Given(theInput_, "n")
					.When(theInputIsParsed)
					.Then(theNumeral_IsObtained, RomanNumeral.Zero)

				.WithScenario("zero repeated")
					.Given(theInput_, "NN")
					.When(theInputIsParsing)
					.Then(anExceptionIsThrown<NumeralParseException>)

				.ExecuteWithReport();
		}

		[Test]
		public void Repetition()
		{
			new Story("parse zero roman numeral")
				.InOrderTo("prevent invalid roman numeral to be parsed")
				.AsA("library user")
				.IWant("unparseable strings to throw.")

				.WithScenario("too many I")
					.Given(theInput_, "IIII")
					.When(theInputIsParsing)
					.Then(anExceptionIsThrown<NumeralParseException>)

				.WithScenario("too many X")
					.Given(theInput_, "XXXX")
					.When(theInputIsParsing)
					.Then(anExceptionIsThrown<NumeralParseException>)

				.WithScenario("too many C")
					.Given(theInput_, "CCCC")
					.When(theInputIsParsing)
					.Then(anExceptionIsThrown<NumeralParseException>)

				.WithScenario("too many M")
					.Given(theInput_, "MMMM")
					.When(theInputIsParsing)
					.Then(anExceptionIsThrown<NumeralParseException>)

				.WithScenario("interleaved offenders")
					.Given(theInput_, "CCCXXXXV")
					.When(theInputIsParsing)
					.Then(anExceptionIsThrown<NumeralParseException>)

				.ExecuteWithReport();
		}

		[Test]
		public void AdditiveCombination()
		{
			new Story("parse zero roman numeral")
				.InOrderTo("obtain the valid roman numeral from a string")
				.AsA("library user")
				.IWant("parse strings that contain lower figures to the right of bigger figures.")

				.WithScenario("six")
					.Given(theInput_, "VI")
					.When(theInputIsParsed)
					.Then(theNumeral_IsObtained, 6u)

				.WithScenario("1661")
					.Given(theInput_, "MDCLXI")
					.When(theInputIsParsed)
					.Then(theNumeral_IsObtained, 1661u)

				.ExecuteWithReport();
		}

		[Test]
		public void SubstractiveCombination()
		{
			new Story("parse zero roman numeral")
				.InOrderTo("obtain the valid roman numeral from a string")
				.AsA("library user")
				.IWant("parse strings that contain lower figures to the left of bigger figures.")

				.WithScenario("four")
					.Given(theInput_, "IV")
					.When(theInputIsParsed)
					.Then(theNumeral_IsObtained, 4u)

				.WithScenario("nine")
					.Given(theInput_, "IX")
					.When(theInputIsParsed)
					.Then(theNumeral_IsObtained, 9u)

				.WithScenario("ninety-nine")
					.Given(theInput_, "XCIX")
					.When(theInputIsParsed)
					.Then(theNumeral_IsObtained, 99u)

				.WithScenario("substract once")
					.Given(theInput_, "MCMD")
					.When(theInputIsParsing)
					.Then(anExceptionIsThrown<NumeralParseException>)

				.WithScenario("substract once")
					.Given(theInput_, "CMC")
					.When(theInputIsParsing)
					.Then(anExceptionIsThrown<NumeralParseException>)

				.ExecuteWithReport();
		}

		[Test]
		public void RepeatSingleFigures()
		{
			new Story("parse zero roman numeral")
				.InOrderTo("prevent invalid roman numeral to be parsed")
				.AsA("library user")
				.IWant("unparseable strings to throw.")

				.WithScenario("too many V")
					.Given(theInput_, "VIV")
					.When(theInputIsParsing)
					.Then(anExceptionIsThrown<NumeralParseException>)

				.WithScenario("too many L")
					.Given(theInput_, "LXL")
					.When(theInputIsParsing)
					.Then(anExceptionIsThrown<NumeralParseException>)

				.WithScenario("too many D")
					.Given(theInput_, "DDII")
					.When(theInputIsParsing)
					.Then(anExceptionIsThrown<NumeralParseException>)

				.ExecuteWithReport();
		}

		[Test]
		public void ReducingValues()
		{
			new Story("parse zero roman numeral")
				.InOrderTo("obtain the valid roman numeral from a string")
				.AsA("library user")
				.IWant("parse strings that numbers increase from left to right.")

				.WithScenario("ninteen")
					.Given(theInput_, "XIX")
					.When(theInputIsParsed)
					.Then(theNumeral_IsObtained, 19u)

				.WithScenario("wrong 899")
					.Given(theInput_, "XIM")
					.When(theInputIsParsing)
					.Then(anExceptionIsThrown<NumeralParseException>)

				.WithScenario("wrong 3")
					.Given(theInput_, "IIV")
					.When(theInputIsParsing)
					.Then(anExceptionIsThrown<NumeralParseException>)

				.ExecuteWithReport();
		}

		[Test]
		public void SomeBigNumbers()
		{
			new Story("parse zero roman numeral")
				.InOrderTo("obtain the valid roman numeral from a string")
				.AsA("library user")
				.IWant("parse strings that numbers increase from left to right.")

				.WithScenario("1928")
					.Given(theInput_, "MCMXXVIII")
					.When(theInputIsParsed)
					.Then(theNumeral_IsObtained, 1928u)

				.WithScenario("2009")
					.Given(theInput_, "MMIX")
					.When(theInputIsParsed)
					.Then(theNumeral_IsObtained, 2009u)

				.WithScenario("1990")
					.Given(theInput_, "MCMXC")
					.When(theInputIsParsed)
					.Then(theNumeral_IsObtained, 1990u)

				.WithScenario("1666")
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
			TestDelegate del = () => _parsing();
			Assert.That(del, Throws.InstanceOf<T>());
		}

		private void theNumeral_IsObtained(RomanNumeral numeral)
		{
			Assert.That(_parsed, Is.EqualTo(numeral));
		}

		private void theNumeral_IsObtained(uint numeral)
		{
			Assert.That(_parsed, Is.EqualTo(new RomanNumeral((ushort)numeral)));
		}
	}
}