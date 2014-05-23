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
				.InOrderTo("obtain the zero roman numeral")
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

		/*[Test]
		public void subject_scenario_outcome()
		{
			var numeral = RomanNumeral.Parse("MCMXXVIII");

			Assert.That(numeral.Value, Is.EqualTo(1928));
		}

		[Test]
		public void repetition()
		{
			Assert.That(RomanNumeral.Parse("III").Value, Is.EqualTo(3));

			// detect error
			//Assert.That(RomanNumeral.Parse("IIII").Value, Is.EqualTo(4));
			//Assert.That(RomanNumeral.Parse("XXXX").Value, Is.EqualTo(40));
			Assert.That(RomanNumeral.Parse("CCCXXXIIII").Value, Is.EqualTo(400));
		}

		[Test]
		public void substractive_combination()
		{
			Assert.That(RomanNumeral.Parse("XCIX").Value, Is.EqualTo(99));

			// detect error
			Assert.That(RomanNumeral.Parse("IC").Value, Is.EqualTo(99));
		}

		[Test]
		public void repeated_single()
		{
			Assert.That(RomanNumeral.Parse("XVI").Value, Is.EqualTo(16));

			// detect error
			Assert.That(RomanNumeral.Parse("VV").Value, Is.EqualTo(16));
			Assert.That(RomanNumeral.Parse("VIV").Value, Is.EqualTo(16));
		}

		[Test]
		public void reducing()
		{
			//Assert.That(RomanNumeral.Parse("XIX").Value, Is.EqualTo(19));

			// detect e
			Assert.That(RomanNumeral.Parse("XIM").Value, Is.EqualTo(-1));
			Assert.That(RomanNumeral.Parse("IIV").Value, Is.EqualTo(-1));
		}*/
	}
}