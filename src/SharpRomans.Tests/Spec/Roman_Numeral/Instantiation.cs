using System.Globalization;
using NUnit.Framework;
using SharpRomans.Tests.Spec.Roman_Numeral.Support;
using StoryQ;

namespace SharpRomans.Tests.Spec.Roman_Numeral
{
	[TestFixture, Category("Spec"), Category("RomanNumeral"), Category("Instantiation")]
	public class InstantiationTester
	{
		[Test]
		public void Instantiation()
		{
			new Story("roman numerals creation")
				.InOrderTo("convert an arabic numeral to a roman numeral")
				.AsA("library user")
				.IWant("to be able to create an instance of a roman numeral from an arabic number")

				.WithScenario("negative number")
					.Given(anArabicNumeral_, -20)
					.When(theRomanNumeralIsInstantiating)
					.Then(aRangeExceptionIsThrown)

				.WithScenario("overflowing number")
					.Given(anArabicNumeral_, 4001)
					.When(theRomanNumeralIsInstantiating)
					.Then(aRangeExceptionIsThrown)

				.WithScenario("zero")
					.Given(anArabicNumeral_, 0)
					.When(theRomanNumeralIsInstantiated)
					.Then(isARomanNumeralWithValue_, 0)

				.WithScenario("single-figure")
					.Given(anArabicNumeral_, 50)
					.When(theRomanNumeralIsInstantiated)
					.Then(isARomanNumeralWithValue_, 50)

				.WithScenario("multiple-figures")
					.Given(anArabicNumeral_, 75)
					.When(theRomanNumeralIsInstantiated)
					.Then(isARomanNumeralWithValue_, 75)

				.ExecuteWithReport();
		}

		[Test]
		public void Instances()
		{
			new Story("roman numerals instances")
				.InOrderTo("have easy access to peculiar roman numerals")
				.AsA("library user")
				.IWant("to be able to obtain instances from the roman numeral itself")

				.WithScenario("zero")
					.Given(the_RomanNumeral, Ins.tance(() => RomanNumeral.Zero))
					.When(itIsAccessed)
					.Then(isARomanNumeralWithValue_, 0)

				.WithScenario("min")
					.Given(the_RomanNumeral, Ins.tance(() => RomanNumeral.Min))
					.When(itIsAccessed)
					.Then(isARomanNumeralWithValue_, (int)RomanNumeral.MinValue)

				.WithScenario("max")
					.Given(the_RomanNumeral, Ins.tance(() => RomanNumeral.Max))
					.When(itIsAccessed)
					.Then(isARomanNumeralWithValue_, (int)RomanNumeral.MaxValue)

				.ExecuteWithReport();
		}

		ushort _number;
		private void anArabicNumeral_(int number)
		{
			_number = (ushort)number;
		}

		TestDelegate _instantiation;
		private void theRomanNumeralIsInstantiating()
		{
			_instantiation = () => new RomanNumeral(_number);
		}

		RomanNumeral _subject;
		private void theRomanNumeralIsInstantiated()
		{
			_subject = new RomanNumeral(_number);
		}

		private void the_RomanNumeral(Ins instance)
		{
			_subject = instance.Execute();
		}

		private void itIsAccessed() { }

		private void aRangeExceptionIsThrown()
		{
			Assert.That(_instantiation, Throws.InstanceOf<NumeralOutOfRangeException>()
				.With.Property("ActualValue").EqualTo(_number)
				.And.Message.StringContaining(RomanNumeral.MinValue.ToString(CultureInfo.InvariantCulture))
				.And.Message.StringContaining(RomanNumeral.MaxValue.ToString(CultureInfo.InvariantCulture)));
		}

		private void isARomanNumeralWithValue_(int value)
		{
			Assert.That(_subject.Value, Is.EqualTo(value));

		}
	}
}
