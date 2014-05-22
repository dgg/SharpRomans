using System;
using NUnit.Framework;
using SharpRomans.Tests.Spec.Roman_Numeral.Support;
using StoryQ;

namespace SharpRomans.Tests.Spec.Roman_Numeral
{
	[TestFixture, Category("Spec"), Category("RomanNumeral"), Category("Conversions")]
	public class ConversionsTester
	{
		[Test]
		public void ConvertToBoolean()
		{
			new Story("convert to Boolean")
				.InOrderTo("convert a roman numeral to boolean whenever possible")
				.AsA("library user")
				.IWant("Convert() to a roman numeral")

			.WithScenario("zero")
				.Given(TheRomanNumeral_, RomanNumeral.Zero)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToBoolean(f)))
				.Then(Is_, false)

			.WithScenario("one")
				.Given(TheRomanNumeral_, new RomanNumeral(1))
				.When(ConvertedTo_, Conv.ert(f => Convert.ToBoolean(f)))
				.Then(Is_, true)

			.WithScenario("more than one")
				.Given(TheRomanNumeral_, new RomanNumeral(51))
				.When(ConvertedTo_, Conv.ert(f => Convert.ToBoolean(f)))
				.Then(Is_, true)

			.WithScenario("max")
				.Given(TheRomanNumeral_, RomanNumeral.Max)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToBoolean(f)))
				.Then(Is_, true)

			.ExecuteWithReport();
		}

		[Test]
		public void ConvertToChar()
		{
			new Story("convert to Char")
				.InOrderTo("convert a roman numeral to a char whenever possible")
				.AsA("library user")
				.IWant("Convert() to a roman numeral")

			.WithScenario("zero")
				.Given(TheRomanNumeral_, RomanNumeral.Zero)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToChar(f)))
				.Then(Is_, 'N')

			.WithScenario("single figure")
				.Given(TheRomanNumeral_, new RomanNumeral(500))
				.When(ConvertedTo_, Conv.ert(f => Convert.ToChar(f)))
				.Then(Is_, 'D')

			.WithScenario("multiple figure")
				.Given(TheRomanNumeral_, new RomanNumeral(11))
				.When(ConvertedTo_, Conv.ert(f => Convert.ToChar(f)))
				.Then(ThrowsException)

			.ExecuteWithReport();
		}

		[Test]
		public void ConvertToSByte()
		{
			new Story("convert to SByte")
				.InOrderTo("convert a roman numeral to a signed byte whenever possible")
				.AsA("library user")
				.IWant("Convert() to a roman numeral")

			.WithScenario("zero")
				.Given(TheRomanNumeral_, RomanNumeral.Zero)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToSByte(f)))
				.Then(Is_, 0)

			.WithScenario("less than max")
				.Given(TheRomanNumeral_, new RomanNumeral(101))
				.When(ConvertedTo_, Conv.ert(f => Convert.ToSByte(f)))
				.Then(Is_, 101)

			.WithScenario("max")
				.Given(TheRomanNumeral_, RomanNumeral.Max)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToSByte(f)))
				.Then(Overflows)

			.ExecuteWithReport();
		}

		[Test]
		public void ConvertToByte()
		{
			new Story("convert to Byte")
				.InOrderTo("convert a roman numeral to a byte whenever possible")
				.AsA("library user")
				.IWant("Convert() to a roman numeral")

			.WithScenario("zero")
				.Given(TheRomanNumeral_, RomanNumeral.Zero)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToByte(f)))
				.Then(Is_, 0)

			.WithScenario("less than max")
				.Given(TheRomanNumeral_, new RomanNumeral(100))
				.When(ConvertedTo_, Conv.ert(f => Convert.ToByte(f)))
				.Then(Is_, 100)

			.WithScenario("max")
				.Given(TheRomanNumeral_, RomanNumeral.Max)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToByte(f)))
				.Then(Overflows)

			.ExecuteWithReport();
		}

		[Test]
		public void ConvertToShort()
		{
			new Story("convert to short")
				.InOrderTo("convert a roman numeral to a short whenever possible")
				.AsA("library user")
				.IWant("Convert() to a roman numeral")

			.WithScenario("zero")
				.Given(TheRomanNumeral_, RomanNumeral.Zero)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToInt16(f)))
				.Then(Is_, 0)

			.WithScenario("less than max")
				.Given(TheRomanNumeral_, new RomanNumeral(100))
				.When(ConvertedTo_, Conv.ert(f => Convert.ToInt16(f)))
				.Then(Is_, 100)

			.WithScenario("max")
				.Given(TheRomanNumeral_, RomanNumeral.Max)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToInt16(f)))
				.Then(Is_, 3999)

			.ExecuteWithReport();
		}

		[Test]
		public void ConvertToUShort()
		{
			new Story("convert to UShort")
				.InOrderTo("convert a roman numeral to an unsigned short whenever possible")
				.AsA("library user")
				.IWant("Convert() to a roman numeral")

			.WithScenario("zero")
				.Given(TheRomanNumeral_, RomanNumeral.Zero)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToUInt16(f)))
				.Then(Is_, 0)

			.WithScenario("less than max")
				.Given(TheRomanNumeral_, new RomanNumeral(100))
				.When(ConvertedTo_, Conv.ert(f => Convert.ToUInt16(f)))
				.Then(Is_, 100)

			.WithScenario("max")
				.Given(TheRomanNumeral_, RomanNumeral.Max)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToUInt16(f)))
				.Then(Is_, 3999)

			.ExecuteWithReport();
		}

		[Test]
		public void ConvertToInt()
		{
			new Story("convert to Int")
				.InOrderTo("convert a roman numeral to an int whenever possible")
				.AsA("library user")
				.IWant("Convert() to a roman numeral")

			.WithScenario("zero")
				.Given(TheRomanNumeral_, RomanNumeral.Zero)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToInt32(f)))
				.Then(Is_, 0)

			.WithScenario("less than max")
				.Given(TheRomanNumeral_, new RomanNumeral(100))
				.When(ConvertedTo_, Conv.ert(f => Convert.ToInt32(f)))
				.Then(Is_, 100)

			.WithScenario("max")
				.Given(TheRomanNumeral_, RomanNumeral.Max)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToInt32(f)))
				.Then(Is_, 3999)

			.ExecuteWithReport();
		}

		[Test]
		public void ConvertToUInt()
		{
			new Story("convert to UInt")
				.InOrderTo("convert a roman numeral to an unsigned int whenever possible")
				.AsA("library user")
				.IWant("Convert() to a roman numeral")

			.WithScenario("zero")
				.Given(TheRomanNumeral_, RomanNumeral.Zero)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToUInt32(f)))
				.Then(Is_, 0)

			.WithScenario("less than max")
				.Given(TheRomanNumeral_, new RomanNumeral(100))
				.When(ConvertedTo_, Conv.ert(f => Convert.ToUInt32(f)))
				.Then(Is_, 100)

			.WithScenario("max")
				.Given(TheRomanNumeral_, RomanNumeral.Max)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToUInt32(f)))
				.Then(Is_, 3999)

			.ExecuteWithReport();
		}

		[Test]
		public void ConvertToLong()
		{
			new Story("convert to Long")
				.InOrderTo("convert a roman numeral to a long whenever possible")
				.AsA("library user")
				.IWant("Convert() to a roman numeral")

			.WithScenario("zero")
				.Given(TheRomanNumeral_, RomanNumeral.Zero)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToInt64(f)))
				.Then(Is_, 0)

			.WithScenario("less than max")
				.Given(TheRomanNumeral_, new RomanNumeral(100))
				.When(ConvertedTo_, Conv.ert(f => Convert.ToInt64(f)))
				.Then(Is_, 100)

			.WithScenario("max")
				.Given(TheRomanNumeral_, RomanNumeral.Max)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToInt64(f)))
				.Then(Is_, 3999)

			.ExecuteWithReport();
		}

		[Test]
		public void ConvertToULong()
		{
			new Story("convert to ULong")
				.InOrderTo("convert a roman numeral to an unsigned long whenever possible")
				.AsA("library user")
				.IWant("Convert() to a roman numeral")

			.WithScenario("zero")
				.Given(TheRomanNumeral_, RomanNumeral.Zero)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToUInt64(f)))
				.Then(Is_, 0)

			.WithScenario("less than max")
				.Given(TheRomanNumeral_, new RomanNumeral(100))
				.When(ConvertedTo_, Conv.ert(f => Convert.ToUInt64(f)))
				.Then(Is_, 100)

			.WithScenario("max")
				.Given(TheRomanNumeral_, RomanNumeral.Max)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToUInt64(f)))
				.Then(Is_, 3999)

			.ExecuteWithReport();
		}

		[Test]
		public void ConvertToFloat()
		{
			new Story("convert to Float")
				.InOrderTo("convert a roman numeral to a float whenever possible")
				.AsA("library user")
				.IWant("Convert() to a roman numeral")

			.WithScenario("zero")
				.Given(TheRomanNumeral_, RomanNumeral.Zero)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToSingle(f)))
				.Then(Is_, 0)

			.WithScenario("less than max")
				.Given(TheRomanNumeral_, new RomanNumeral(100))
				.When(ConvertedTo_, Conv.ert(f => Convert.ToSingle(f)))
				.Then(Is_, 100)

			.WithScenario("max")
				.Given(TheRomanNumeral_, RomanNumeral.Max)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToSingle(f)))
				.Then(Is_, 3999)

			.ExecuteWithReport();
		}

		[Test]
		public void ConvertToDouble()
		{
			new Story("convert to Double")
				.InOrderTo("convert a roman numeral to a double whenever possible")
				.AsA("library user")
				.IWant("Convert() to a roman numeral")

			.WithScenario("zero")
				.Given(TheRomanNumeral_, RomanNumeral.Zero)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToDouble(f)))
				.Then(Is_, 0)

			.WithScenario("less than max")
				.Given(TheRomanNumeral_, new RomanNumeral(100))
				.When(ConvertedTo_, Conv.ert(f => Convert.ToDouble(f)))
				.Then(Is_, 100)

			.WithScenario("max")
				.Given(TheRomanNumeral_, RomanNumeral.Max)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToDouble(f)))
				.Then(Is_, 3999)

			.ExecuteWithReport();
		}

		RomanNumeral _subject;
		private void TheRomanNumeral_(RomanNumeral subject)
		{
			_subject = subject;
		}

		Func<object> _conversion;
		private void ConvertedTo_(Conv exp)
		{
			_conversion = () => exp.Execute(_subject);
		}

		private void Is_<T>(T value)
		{
			Assert.That(_conversion(), Is.EqualTo(value));
		}

		private void ThrowsException()
		{
			TestDelegate conversion = () => _conversion();
			Assert.That(conversion, Throws.InstanceOf<FormatException>());
		}

		private void Overflows()
		{
			TestDelegate conversion = () => _conversion();
			Assert.That(conversion, Throws.InstanceOf<OverflowException>());
		}
	}
}