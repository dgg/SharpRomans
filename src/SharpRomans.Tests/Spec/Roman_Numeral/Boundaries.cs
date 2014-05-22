using System.Globalization;
using NUnit.Framework;
using StoryQ;

namespace SharpRomans.Tests.Spec.Roman_Numeral
{
	[TestFixture, Category("Spec"), Category("RomanNumeral"), Category("Boundaries")]
	public class BoundariesTester
	{
		[Test]
		public void Boundaries()
		{
			new Story("roman numerals boundaries")
				.InOrderTo("verify whether an arabic numeral can be converted into a roman numeral")
				.AsA("library user")
				.IWant("to be able to invoke methods taking the arabic number a argument")

				.WithScenario("check a number in range")
					.Given(anArabicNumeral_, 20)
					.When(theNumeralIsChecked)
					.Then(theResultIs_, true)

				.WithScenario("check a negative number")
					.Given(anArabicNumeral_, -1)
					.When(theNumeralIsChecked)
					.Then(theResultIs_, false)

				.WithScenario("check an overflowing number")
					.Given(anArabicNumeral_, 4001)
					.When(theNumeralIsChecked)
					.Then(theResultIs_, false)

				.WithScenario("assert a number in range")
					.Given(anArabicNumeral_, 20)
					.When(theNumeralIsAsserted)
					.Then(noExceptionIsRaised)

				.WithScenario("assert a negative number")
					.Given(anArabicNumeral_, -1)
					.When(theNumeralIsAsserted)
					.Then(aRangeExceptionIsThrown)

				.WithScenario("assert an overflowing number")
					.Given(anArabicNumeral_, 4001)
					.When(theNumeralIsAsserted)
					.Then(aRangeExceptionIsThrown)

				.ExecuteWithReport();
		}
		ushort _number;
		private void anArabicNumeral_(int number)
		{
			_number = (ushort)number;
		}

		bool _check;
		private void theNumeralIsChecked()
		{
			_check = RomanNumeral.CheckRange(_number);
		}

		TestDelegate _assertion;
		private void theNumeralIsAsserted()
		{
			_assertion = () => RomanNumeral.AssertRange(_number);
		}

		private void theResultIs_(bool check)
		{
			Assert.That(_check, Is.EqualTo(check));
		}

		private void noExceptionIsRaised()
		{
			Assert.That(_assertion, Throws.Nothing);
		}

		private void aRangeExceptionIsThrown()
		{
			Assert.That(_assertion, Throws.InstanceOf<NumeralOutOfRangeException>()
				.With.Property("ActualValue").EqualTo(_number)
				.And.Message.StringContaining(RomanNumeral.MinValue.ToString(CultureInfo.InvariantCulture))
				.And.Message.StringContaining(RomanNumeral.MaxValue.ToString(CultureInfo.InvariantCulture)));
		}
	}
}