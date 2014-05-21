using System;
using NUnit.Framework;
using SharpRomans.Tests.Spec.Roman_Figure.Support;
using StoryQ;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[TestFixture, Category("Spec"), Category("RomanFigure")]
	public class ConversionsTester
	{
		[Test]
		public void ConvertToBoolean()
		{
			new Story("convert to Boolean")
				.InOrderTo("convert a roman figure to boolean")
				.AsA("library user")
				.IWant("Convert() to a roman figure")

			.WithScenario("zero")
				.Given(TheRomanFigure_, RomanFigure.N)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToBoolean(f)))
				.Then(Is_, false)

			.WithScenario("one")
				.Given(TheRomanFigure_, RomanFigure.I)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToBoolean(f)))
				.Then(Is_, true)

			.WithScenario("more than one")
				.Given(TheRomanFigure_, RomanFigure.D)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToBoolean(f)))
				.Then(Is_, true)

			.WithScenario("max")
				.Given(TheRomanFigure_, RomanFigure.M)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToBoolean(f)))
				.Then(Is_, true)

			.ExecuteWithReport();
		}

		[Test]
		public void ConvertToChar()
		{
			new Story("convert to Char")
				.InOrderTo("convert a roman figure to a char")
				.AsA("library user")
				.IWant("Convert() to a roman figure")

			.WithScenario("zero")
				.Given(TheRomanFigure_, RomanFigure.N)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToChar(f)))
				.Then(Is_, 'N')

			.WithScenario("more than one")
				.Given(TheRomanFigure_, RomanFigure.D)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToChar(f)))
				.Then(Is_, 'D')

			.WithScenario("max")
				.Given(TheRomanFigure_, RomanFigure.M)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToChar(f)))
				.Then(Is_, 'M')

			.ExecuteWithReport();
		}

		[Test]
		public void ConvertToSByte()
		{
			new Story("convert to SByte")
				.InOrderTo("convert a roman figure to a signed byte")
				.AsA("library user")
				.IWant("Convert() to a roman figure")

			.WithScenario("zero")
				.Given(TheRomanFigure_, RomanFigure.N)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToSByte(f)))
				.Then(Is_, 0)

			.WithScenario("less than max")
				.Given(TheRomanFigure_, RomanFigure.C)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToSByte(f)))
				.Then(Is_, 100)

			.WithScenario("max")
				.Given(TheRomanFigure_, RomanFigure.M)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToSByte(f)))
				.Then(Overflows)

			.ExecuteWithReport();
		}

		[Test]
		public void ConvertToByte()
		{
			new Story("convert to Byte")
				.InOrderTo("convert a roman figure to a byte whenever possible")
				.AsA("library user")
				.IWant("Convert() to a roman figure")

			.WithScenario("zero")
				.Given(TheRomanFigure_, RomanFigure.N)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToByte(f)))
				.Then(Is_, 0)

			.WithScenario("less than max")
				.Given(TheRomanFigure_, RomanFigure.C)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToByte(f)))
				.Then(Is_, 100)

			.WithScenario("max")
				.Given(TheRomanFigure_, RomanFigure.M)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToByte(f)))
				.Then(Overflows)

			.ExecuteWithReport();
		}

		[Test]
		public void ConvertToShort()
		{
			new Story("convert to short")
				.InOrderTo("convert a roman figure to a short")
				.AsA("library user")
				.IWant("Convert() to a roman figure")

			.WithScenario("zero")
				.Given(TheRomanFigure_, RomanFigure.N)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToInt16(f)))
				.Then(Is_, 0)

			.WithScenario("less than max")
				.Given(TheRomanFigure_, RomanFigure.C)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToInt16(f)))
				.Then(Is_, 100)

			.WithScenario("max")
				.Given(TheRomanFigure_, RomanFigure.M)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToInt16(f)))
				.Then(Is_, 1000)

			.ExecuteWithReport();
		}

		[Test]
		public void ConvertToUShort()
		{
			new Story("convert to UShort")
				.InOrderTo("convert a roman figure to an unsigned short")
				.AsA("library user")
				.IWant("Convert() to a roman figure")

			.WithScenario("zero")
				.Given(TheRomanFigure_, RomanFigure.N)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToUInt16(f)))
				.Then(Is_, 0)

			.WithScenario("less than max")
				.Given(TheRomanFigure_, RomanFigure.C)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToUInt16(f)))
				.Then(Is_, 100)

			.WithScenario("max")
				.Given(TheRomanFigure_, RomanFigure.M)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToUInt16(f)))
				.Then(Is_, 1000)

			.ExecuteWithReport();
		}

		[Test]
		public void ConvertToInt()
		{
			new Story("convert to Int")
				.InOrderTo("convert a roman figure to an int")
				.AsA("library user")
				.IWant("Convert() to a roman figure")

			.WithScenario("zero")
				.Given(TheRomanFigure_, RomanFigure.N)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToInt32(f)))
				.Then(Is_, 0)

			.WithScenario("less than max")
				.Given(TheRomanFigure_, RomanFigure.C)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToInt32(f)))
				.Then(Is_, 100)

			.WithScenario("max")
				.Given(TheRomanFigure_, RomanFigure.M)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToInt32(f)))
				.Then(Is_, 1000)

			.ExecuteWithReport();
		}

		[Test]
		public void ConvertToUInt()
		{
			new Story("convert to UInt")
				.InOrderTo("convert a roman figure to an unsigned int")
				.AsA("library user")
				.IWant("Convert() to a roman figure")

			.WithScenario("zero")
				.Given(TheRomanFigure_, RomanFigure.N)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToUInt32(f)))
				.Then(Is_, 0)

			.WithScenario("less than max")
				.Given(TheRomanFigure_, RomanFigure.C)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToUInt32(f)))
				.Then(Is_, 100)

			.WithScenario("max")
				.Given(TheRomanFigure_, RomanFigure.M)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToUInt32(f)))
				.Then(Is_, 1000)

			.ExecuteWithReport();
		}

		[Test]
		public void ConvertToLong()
		{
			new Story("convert to Long")
				.InOrderTo("convert a roman figure to a long")
				.AsA("library user")
				.IWant("Convert() to a roman figure")

			.WithScenario("zero")
				.Given(TheRomanFigure_, RomanFigure.N)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToInt64(f)))
				.Then(Is_, 0)

			.WithScenario("less than max")
				.Given(TheRomanFigure_, RomanFigure.C)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToInt64(f)))
				.Then(Is_, 100)

			.WithScenario("max")
				.Given(TheRomanFigure_, RomanFigure.M)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToInt64(f)))
				.Then(Is_, 1000)

			.ExecuteWithReport();
		}

		[Test]
		public void ConvertToULong()
		{
			new Story("convert to ULong")
				.InOrderTo("convert a roman figure to an unsigned long")
				.AsA("library user")
				.IWant("Convert() to a roman figure")

			.WithScenario("zero")
				.Given(TheRomanFigure_, RomanFigure.N)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToUInt64(f)))
				.Then(Is_, 0)

			.WithScenario("less than max")
				.Given(TheRomanFigure_, RomanFigure.C)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToUInt64(f)))
				.Then(Is_, 100)

			.WithScenario("max")
				.Given(TheRomanFigure_, RomanFigure.M)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToUInt64(f)))
				.Then(Is_, 1000)

			.ExecuteWithReport();
		}

		[Test]
		public void ConvertToFloat()
		{
			new Story("convert to Float")
				.InOrderTo("convert a roman figure to a float")
				.AsA("library user")
				.IWant("Convert() to a roman figure")

			.WithScenario("zero")
				.Given(TheRomanFigure_, RomanFigure.N)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToSingle(f)))
				.Then(Is_, 0)

			.WithScenario("less than max")
				.Given(TheRomanFigure_, RomanFigure.C)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToSingle(f)))
				.Then(Is_, 100)

			.WithScenario("max")
				.Given(TheRomanFigure_, RomanFigure.M)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToSingle(f)))
				.Then(Is_, 1000)

			.ExecuteWithReport();
		}

		[Test]
		public void ConvertToDouble()
		{
			new Story("convert to Double")
				.InOrderTo("convert a roman figure to a double")
				.AsA("library user")
				.IWant("Convert() to a roman figure")

			.WithScenario("zero")
				.Given(TheRomanFigure_, RomanFigure.N)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToDouble(f)))
				.Then(Is_, 0)

			.WithScenario("less than max")
				.Given(TheRomanFigure_, RomanFigure.C)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToDouble(f)))
				.Then(Is_, 100)

			.WithScenario("max")
				.Given(TheRomanFigure_, RomanFigure.M)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToDouble(f)))
				.Then(Is_, 1000)

			.ExecuteWithReport();
		}

		[Test]
		public void ConvertToDecimal()
		{
			new Story("convert to Decimal")
				.InOrderTo("convert a roman figure to a decimal")
				.AsA("library user")
				.IWant("Convert() to a roman figure")

			.WithScenario("zero")
				.Given(TheRomanFigure_, RomanFigure.N)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToDecimal(f)))
				.Then(Is_, 0)

			.WithScenario("less than max")
				.Given(TheRomanFigure_, RomanFigure.C)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToDecimal(f)))
				.Then(Is_, 100)

			.WithScenario("max")
				.Given(TheRomanFigure_, RomanFigure.M)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToDecimal(f)))
				.Then(Is_, 1000)

			.ExecuteWithReport();
		}

		[Test]
		public void ConvertToDateTime()
		{
			new Story("convert to DateTime")
				.InOrderTo("convert a roman figure to date-time whenever possible")
				.AsA("library user")
				.IWant("Convert() to a roman figure")

			.WithScenario("zero")
				.Given(TheRomanFigure_, RomanFigure.N)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToDateTime(f)))
				.Then(CannotCast)

			.WithScenario("less than max")
				.Given(TheRomanFigure_, RomanFigure.C)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToDateTime(f)))
				.Then(CannotCast)

			.WithScenario("max")
				.Given(TheRomanFigure_, RomanFigure.M)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToDateTime(f)))
				.Then(CannotCast)

			.ExecuteWithReport();
		}

		[Test]
		public void ConvertToString()
		{
			new Story("convert to Char")
				.InOrderTo("convert a roman figure to a string")
				.AsA("library user")
				.IWant("Convert() to a roman figure")

			.WithScenario("zero")
				.Given(TheRomanFigure_, RomanFigure.N)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToString(f)))
				.Then(Is_, "N")

			.WithScenario("more than one")
				.Given(TheRomanFigure_, RomanFigure.D)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToString(f)))
				.Then(Is_, "D")

			.WithScenario("max")
				.Given(TheRomanFigure_, RomanFigure.M)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToString(f)))
				.Then(Is_, "M")

			.ExecuteWithReport();
		}

		[Test]
		public void ChangeType()
		{
			new Story("ChangeType")
				.InOrderTo("convert a roman figure to a clr type whenever possible")
				.AsA("library user")
				.IWant("Convert() to a roman figure")

			.WithScenario("supported type")
				.Given(TheRomanFigure_, RomanFigure.M)
				.When(ConvertedTo_, typeof(long))
				.Then(Is_, 1000)

			.WithScenario("overflowing type")
				.Given(TheRomanFigure_, RomanFigure.M)
				.When(ConvertedTo_, typeof(byte))
				.Then(Overflows)

			.WithScenario("unsupported type")
				.Given(TheRomanFigure_, RomanFigure.M)
				.When(ConvertedTo_, typeof(TimeSpan))
				.Then(CannotCast)

			.WithScenario("unsupported type")
				.Given(TheRomanFigure_, RomanFigure.M)
				.When(ConvertedTo_, typeof(Exception))
				.Then(CannotCast)

			.WithScenario("itself")
				.Given(TheRomanFigure_, RomanFigure.M)
				.When(ConvertedTo_, typeof(RomanFigure))
				.Then(Is_, RomanFigure.M)

			.ExecuteWithReport();
		}

		RomanFigure _subject;
		private void TheRomanFigure_(RomanFigure subject)
		{
			_subject = subject;
		}

		Func<object> _conversion;
		private void ConvertedTo_(Conv exp)
		{
			_conversion = () => exp.Execute(_subject);
		}

		private void ConvertedTo_(Type to)
		{
			_conversion = () => Convert.ChangeType(_subject, to);
		}

		private void Is_<T>(T value)
		{
			Assert.That(_conversion(), Is.EqualTo(value));
		}

		private void Overflows()
		{
			TestDelegate conversion = () => _conversion();
			Assert.That(conversion, Throws.InstanceOf<OverflowException>());
		}

		private void CannotCast()
		{
			TestDelegate conversion = () => _conversion();
			Assert.That(conversion, Throws.InstanceOf<InvalidCastException>()
				.With.Message.StringContaining(typeof(RomanFigure).Name));
		}
	}
}
