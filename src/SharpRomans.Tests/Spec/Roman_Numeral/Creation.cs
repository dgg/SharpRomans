using NUnit.Framework;
using StoryQ;

namespace SharpRomans.Tests.Spec.Roman_Numeral
{
	[TestFixture, Category("Spec"), Category("RomanNumeral"), Category("Creation")]
	public class CreationTester
	{
		[Test]
		public void RomanNumeralCreation()
		{
			new Story("roman numerals creation")
				.InOrderTo("convert an arabic numeral to a roman numeral")
				.AsA("library user")
				.IWant("to be able to create an instance of a roman numeral from an arabic number")

				.WithScenario("negative number")
					.Given(anArabicNumeral_, -20)
					.When(theRomanNumeralIsInstantiated)
					.Then(aRangeExceptionIsThrown)

				.WithScenario("overflowing number")
					.Given(anArabicNumeral_, 4001)
					.When(theRomanNumeralIsInstantiated)
					.Then(aRangeExceptionIsThrown)

				.WithScenario("zero")
					.Given(anArabicNumeral_, 0)
					.When(theRomanNumeralIsCreated)
					.Then(isA_ValuedRomanNumeral, 0)

				.WithScenario("single-figure")
					.Given(anArabicNumeral_, 50)
					.When(theRomanNumeralIsCreated)
					.Then(isA_ValuedRomanNumeral, 50)

				.WithScenario("multiple-figures")
					.Given(anArabicNumeral_, 75)
					.When(theRomanNumeralIsCreated)
					.Then(isA_ValuedRomanNumeral, 75)

				.ExecuteWithReport();
		}

		ushort _number;
		private void anArabicNumeral_(int number)
		{
			_number = (ushort)number;
		}

		TestDelegate _subjectInstantion;
		private void theRomanNumeralIsInstantiated()
		{
			_subjectInstantion = () => new RomanNumeral(_number);
		}

		RomanNumeral _subject;
		private void theRomanNumeralIsCreated()
		{
			_subject = new RomanNumeral(_number);
		}

		private void aRangeExceptionIsThrown()
		{
			Assert.That(_subjectInstantion, Throws.InstanceOf<NumeralOutOfRangeException>()
				.With.Property("ActualValue").EqualTo(_number)
				.And.Message.StringContaining(RomanNumeral.MinValue.ToString())
				.And.Message.StringContaining(RomanNumeral.MaxValue.ToString()));
		}

		private void isA_ValuedRomanNumeral(int value)
		{
			Assert.That(_subject.Value, Is.EqualTo(value));
			
		}
	}
}
