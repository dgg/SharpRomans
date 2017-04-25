using SharpRomans.Tests.Support;
using StoryQ;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Numeral
{
	[Category("Spec"), Category("RomanNumeral"), Category("TryParse")]
	public class TryParseTester
	{
		[Fact]
		public void NoString()
		{
			new Story("try parse no string as roman numeral")
				.InOrderTo("not be surprised with unexpected results")
				.AsA("library user")
				.IWant("unparseable strings to not parse.")

				.WithScenario("null")
					.Given(theInput_, (string) null)
					.When(theInputIsParsed)
					.Then(theResultIs_, false)
					.And(theNumeral_IsObtained, (RomanNumeral)null)

				.WithScenario("empty")
					.Given(theInput_, string.Empty)
					.When(theInputIsParsed)
					.Then(theResultIs_, false)
					.And(theNumeral_IsObtained, (RomanNumeral)null)

				.WithScenario("only spaces")
					.Given(theInput_, " ")
					.When(theInputIsParsed)
					.Then(theResultIs_, false)
					.And(theNumeral_IsObtained, (RomanNumeral)null)

				.ExecuteWithReport();
		}

		[Fact]
		public void Zero()
		{
			new Story("try parse zero roman numeral")
				.InOrderTo("obtain the zero roman numeral from a string")
				.AsA("library user")
				.IWant("parse the zero string.")

				.WithScenario("uppercase zero")
					.Given(theInput_, "N")
					.When(theInputIsParsed)
					.Then(theResultIs_, true)
					.And(theNumeral_IsObtained, RomanNumeral.Zero)

				.WithScenario("lowercase zero")
					.Given(theInput_, "n")
					.When(theInputIsParsed)
					.Then(theResultIs_, true)
					.And(theNumeral_IsObtained, RomanNumeral.Zero)

				.WithScenario("zero repeated")
					.Given(theInput_, "NN")
					.When(theInputIsParsed)
					.Then(theResultIs_, false)
					.And(theNumeral_IsObtained, (RomanNumeral)null)

				.ExecuteWithReport();
		}

		[FactAttribute]
		public void Repetition()
		{
			new Story("try parse zero roman numeral")
				.InOrderTo("prevent invalid roman numeral to be parsed")
				.AsA("library user")
				.IWant("unparseable strings to not parse.")

				.WithScenario("too many I")
					.Given(theInput_, "IIII")
					.When(theInputIsParsed)
					.Then(theResultIs_, false)
					.And(theNumeral_IsObtained, (RomanNumeral)null)

				.WithScenario("too many X")
					.Given(theInput_, "XXXX")
					.When(theInputIsParsed)
					.Then(theResultIs_, false)
					.And(theNumeral_IsObtained, (RomanNumeral)null)

				.WithScenario("too many C")
					.Given(theInput_, "CCCC")
					.When(theInputIsParsed)
					.Then(theResultIs_, false)
					.And(theNumeral_IsObtained, (RomanNumeral)null)

				.WithScenario("too many M")
					.Given(theInput_, "MMMM")
					.When(theInputIsParsed)
					.Then(theResultIs_, false)
					.And(theNumeral_IsObtained, (RomanNumeral)null)

				.WithScenario("interleaved offenders")
					.Given(theInput_, "CCCXXXXV")
					.When(theInputIsParsed)
					.Then(theResultIs_, false)
					.And(theNumeral_IsObtained, (RomanNumeral)null)

				.ExecuteWithReport();
		}

		[FactAttribute]
		public void AdditiveCombination()
		{
			new Story("try parse zero roman numeral")
				.InOrderTo("obtain the valid roman numeral from a string")
				.AsA("library user")
				.IWant("try parse strings that contain lower figures to the right of bigger figures.")

				.WithScenario("six")
					.Given(theInput_, "VI")
					.When(theInputIsParsed)
					.Then(theResultIs_, true)
					.And(theNumeral_IsObtained, 6u)

				.WithScenario("1661")
					.Given(theInput_, "MDCLXI")
					.When(theInputIsParsed)
					.Then(theResultIs_, true)
					.And(theNumeral_IsObtained, 1661u)

				.ExecuteWithReport();
		}

		[FactAttribute]
		public void SubstractiveCombination()
		{
			new Story("try parse zero roman numeral")
				.InOrderTo("obtain the valid roman numeral from a string")
				.AsA("library user")
				.IWant("try parse strings that contain lower figures to the left of bigger figures.")

				.WithScenario("four")
					.Given(theInput_, "IV")
					.When(theInputIsParsed)
					.Then(theResultIs_, true)
					.And(theNumeral_IsObtained, 4u)

				.WithScenario("nine")
					.Given(theInput_, "IX")
					.When(theInputIsParsed)
					.Then(theResultIs_, true)
					.And(theNumeral_IsObtained, 9u)

				.WithScenario("ninety-nine")
					.Given(theInput_, "XCIX")
					.When(theInputIsParsed)
					.Then(theResultIs_, true)
					.And(theNumeral_IsObtained, 99u)

				.WithScenario("substract once")
					.Given(theInput_, "MCMD")
					.When(theInputIsParsed)
					.Then(theResultIs_, false)
					.And(theNumeral_IsObtained, (RomanNumeral)null)

				.WithScenario("substract once")
					.Given(theInput_, "CMC")
					.When(theInputIsParsed)
					.Then(theResultIs_, false)
					.And(theNumeral_IsObtained, (RomanNumeral)null)

				.ExecuteWithReport();
		}

		[FactAttribute]
		public void RepeatSingleFigures()
		{
			new Story("try parse zero roman numeral")
				.InOrderTo("prevent invalid roman numeral to be parsed")
				.AsA("library user")
				.IWant("unparseable strings to not parse.")

				.WithScenario("too many V")
					.Given(theInput_, "VIV")
					.When(theInputIsParsed)
					.Then(theResultIs_, false)
					.And(theNumeral_IsObtained, (RomanNumeral)null)

				.WithScenario("too many L")
					.Given(theInput_, "LXL")
					.When(theInputIsParsed)
					.Then(theResultIs_, false)
					.And(theNumeral_IsObtained, (RomanNumeral)null)

				.WithScenario("too many D")
					.Given(theInput_, "DDII")
					.When(theInputIsParsed)
					.Then(theResultIs_, false)
					.And(theNumeral_IsObtained, (RomanNumeral)null)

				.ExecuteWithReport();
		}

		[FactAttribute]
		public void ReducingValues()
		{
			new Story("try parse zero roman numeral")
				.InOrderTo("obtain the valid roman numeral from a string")
				.AsA("library user")
				.IWant("try parse strings that numbers increase from left to right.")

				.WithScenario("ninteen")
					.Given(theInput_, "XIX")
					.When(theInputIsParsed)
					.Then(theResultIs_, true)
					.And(theNumeral_IsObtained, 19u)

				.WithScenario("wrong 899")
					.Given(theInput_, "XIM")
					.When(theInputIsParsed)
					.Then(theResultIs_, false)
					.And(theNumeral_IsObtained, (RomanNumeral)null)

				.WithScenario("wrong 3")
					.Given(theInput_, "IIV")
					.When(theInputIsParsed)
					.Then(theResultIs_, false)
					.And(theNumeral_IsObtained, (RomanNumeral)null)

				.ExecuteWithReport();
		}

		[FactAttribute]
		public void SomeBigNumbers()
		{
			new Story("parse zero roman numeral")
				.InOrderTo("obtain the valid roman numeral from a string")
				.AsA("library user")
				.IWant("parse strings that numbers increase from left to right.")

				.WithScenario("1928")
					.Given(theInput_, "MCMXXVIII")
					.When(theInputIsParsed)
					.Then(theResultIs_, true)
					.And(theNumeral_IsObtained, 1928u)

				.WithScenario("2009")
					.Given(theInput_, "MMIX")
					.When(theInputIsParsed)
					.Then(theResultIs_, true)
					.And(theNumeral_IsObtained, 2009u)

				.WithScenario("1990")
					.Given(theInput_, "MCMXC")
					.When(theInputIsParsed)
					.Then(theResultIs_, true)
					.And(theNumeral_IsObtained, 1990u)

				.WithScenario("1666")
					.Given(theInput_, "MDCLXVI")
					.When(theInputIsParsed)
					.Then(theResultIs_, true)
					.And(theNumeral_IsObtained, 1666u)

				.ExecuteWithReport();
		}

		private string _input;
		private void theInput_(string input)
		{
			_input = input;
		}

		RomanNumeral _parsed;
		private bool _result;
		private void theInputIsParsed()
		{
			_result = RomanNumeral.TryParse(_input, out _parsed);
		}

		private void theResultIs_(bool obj)
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