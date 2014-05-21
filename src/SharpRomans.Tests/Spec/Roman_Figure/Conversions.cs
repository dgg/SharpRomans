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

		private void Is_<T>(T value) where T : struct
		{
			Assert.That(_conversion(), Is.EqualTo(value));
		}

		private void Overflows()
		{
			TestDelegate conversion = () => _conversion();
			Assert.That(conversion, Throws.InstanceOf<OverflowException>());
		}
	}
}
