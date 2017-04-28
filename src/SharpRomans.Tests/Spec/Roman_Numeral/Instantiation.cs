using System;
using System.Globalization;
using SharpRomans.Tests.Spec.Roman_Numeral.Support;
using SharpRomans.Tests.Support;
using StoryQ;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Numeral
{
	[Category("Spec"), Category("RomanNumeral"), Category("Instantiation")]
	public class InstantiationTester
	{
		[Fact]
		public void Instantiation()
		{
			new Story("roman numerals creation")
				.InOrderTo("convert an arabic numeral to a roman numeral")
				.AsA("library user")
				.IWant("to be able to create an instance of a roman numeral from an arabic number")

				.BDDfy("negative number")
					.Given(anArabicNumeral_, -20)
					.When(theRomanNumeralIsInstantiating)
					.Then(aRangeExceptionIsThrown)

				.BDDfy("overflowing number")
					.Given(anArabicNumeral_, 4001)
					.When(theRomanNumeralIsInstantiating)
					.Then(aRangeExceptionIsThrown)

				.BDDfy("zero")
					.Given(anArabicNumeral_, 0)
					.When(theRomanNumeralIsInstantiated)
					.Then(isARomanNumeralWithValue_, 0)

				.BDDfy("single-figure")
					.Given(anArabicNumeral_, 50)
					.When(theRomanNumeralIsInstantiated)
					.Then(isARomanNumeralWithValue_, 50)

				.BDDfy("multiple-figures")
					.Given(anArabicNumeral_, 75)
					.When(theRomanNumeralIsInstantiated)
					.Then(isARomanNumeralWithValue_, 75)

				.ExecuteWithReport();
		}

		[Fact]
		public void Instances()
		{
			new Story("roman numerals instances")
				.InOrderTo("have easy access to peculiar roman numerals")
				.AsA("library user")
				.IWant("to be able to obtain instances from the roman numeral itself")

				.BDDfy("zero")
					.Given(the_RomanNumeral, Ins.tance(() => RomanNumeral.Zero))
					.When(itIsAccessed)
					.Then(isARomanNumeralWithValue_, 0)

				.BDDfy("min")
					.Given(the_RomanNumeral, Ins.tance(() => RomanNumeral.Min))
					.When(itIsAccessed)
					.Then(isARomanNumeralWithValue_, (int)RomanNumeral.MinValue)

				.BDDfy("max")
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

		Action _instantiation;
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
			var ex = Assert.ThrowsAny<NumeralOutOfRangeException>(_instantiation);
			Assert.Contains(_number.ToString(CultureInfo.InvariantCulture), ex.Message);
			Assert.Contains(RomanNumeral.MinValue.ToString(CultureInfo.InvariantCulture), ex.Message);
			Assert.Contains(RomanNumeral.MaxValue.ToString(CultureInfo.InvariantCulture), ex.Message);
		}

		private void isARomanNumeralWithValue_(int value)
		{
			Assert.Equal(value, _subject.Value);

		}
	}
}
