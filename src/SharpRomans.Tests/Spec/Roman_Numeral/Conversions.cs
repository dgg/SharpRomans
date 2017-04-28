using System;
using SharpRomans.Tests.Spec.Roman_Numeral.Support;
using SharpRomans.Tests.Support;
using StoryQ;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Numeral
{
	[Category("Spec"), Category("RomanNumeral"), Category("Conversions")]
	public class ConversionsTester
	{
		[Fact]
		public void ConvertToBoolean()
		{
			new Story("convert to Boolean")
				.InOrderTo("convert a roman numeral to boolean whenever possible")
				.AsA("library user")
				.IWant("Convert() to a roman numeral")

			.BDDfy("zero")
				.Given(TheRomanNumeral_, RomanNumeral.Zero)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToBoolean(f)))
				.Then(Is_, false)

			.BDDfy("one")
				.Given(TheRomanNumeral_, new RomanNumeral(1))
				.When(ConvertedTo_, Conv.ert(f => Convert.ToBoolean(f)))
				.Then(Is_, true)

			.BDDfy("more than one")
				.Given(TheRomanNumeral_, new RomanNumeral(51))
				.When(ConvertedTo_, Conv.ert(f => Convert.ToBoolean(f)))
				.Then(Is_, true)

			.BDDfy("max")
				.Given(TheRomanNumeral_, RomanNumeral.Max)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToBoolean(f)))
				.Then(Is_, true)

			.ExecuteWithReport();
		}

		[Fact]
		public void ConvertToChar()
		{
			new Story("convert to Char")
				.InOrderTo("convert a roman numeral to a char whenever possible")
				.AsA("library user")
				.IWant("Convert() to a roman numeral")

			.BDDfy("zero")
				.Given(TheRomanNumeral_, RomanNumeral.Zero)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToChar(f)))
				.Then(Is_, 'N')

			.BDDfy("single figure")
				.Given(TheRomanNumeral_, new RomanNumeral(500))
				.When(ConvertedTo_, Conv.ert(f => Convert.ToChar(f)))
				.Then(Is_, 'D')

			.BDDfy("multiple figure")
				.Given(TheRomanNumeral_, new RomanNumeral(11))
				.When(ConvertedTo_, Conv.ert(f => Convert.ToChar(f)))
				.Then(ThrowsException)

			.ExecuteWithReport();
		}

		[Fact]
		public void ConvertToSByte()
		{
			new Story("convert to SByte")
				.InOrderTo("convert a roman numeral to a signed byte whenever possible")
				.AsA("library user")
				.IWant("Convert() to a roman numeral")

			.BDDfy("zero")
				.Given(TheRomanNumeral_, RomanNumeral.Zero)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToSByte(f)))
				.Then(Is_, (sbyte)0)

			.BDDfy("less than max")
				.Given(TheRomanNumeral_, new RomanNumeral(101))
				.When(ConvertedTo_, Conv.ert(f => Convert.ToSByte(f)))
				.Then(Is_, (sbyte)101)

			.BDDfy("max")
				.Given(TheRomanNumeral_, RomanNumeral.Max)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToSByte(f)))
				.Then(Overflows)

			.ExecuteWithReport();
		}

		[Fact]
		public void ConvertToByte()
		{
			new Story("convert to Byte")
				.InOrderTo("convert a roman numeral to a byte whenever possible")
				.AsA("library user")
				.IWant("Convert() to a roman numeral")

			.BDDfy("zero")
				.Given(TheRomanNumeral_, RomanNumeral.Zero)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToByte(f)))
				.Then(Is_, (byte)0)

			.BDDfy("less than max")
				.Given(TheRomanNumeral_, new RomanNumeral(100))
				.When(ConvertedTo_, Conv.ert(f => Convert.ToByte(f)))
				.Then(Is_, (byte)100)

			.BDDfy("max")
				.Given(TheRomanNumeral_, RomanNumeral.Max)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToByte(f)))
				.Then(Overflows)

			.ExecuteWithReport();
		}

		[Fact]
		public void ConvertToShort()
		{
			new Story("convert to short")
				.InOrderTo("convert a roman numeral to a short whenever possible")
				.AsA("library user")
				.IWant("Convert() to a roman numeral")

			.BDDfy("zero")
				.Given(TheRomanNumeral_, RomanNumeral.Zero)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToInt16(f)))
				.Then(Is_, (short)0)

			.BDDfy("less than max")
				.Given(TheRomanNumeral_, new RomanNumeral(100))
				.When(ConvertedTo_, Conv.ert(f => Convert.ToInt16(f)))
				.Then(Is_, (short)100)

			.BDDfy("max")
				.Given(TheRomanNumeral_, RomanNumeral.Max)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToInt16(f)))
				.Then(Is_, (short)3999)

			.ExecuteWithReport();
		}

		[Fact]
		public void ConvertToUShort()
		{
			new Story("convert to UShort")
				.InOrderTo("convert a roman numeral to an unsigned short whenever possible")
				.AsA("library user")
				.IWant("Convert() to a roman numeral")

			.BDDfy("zero")
				.Given(TheRomanNumeral_, RomanNumeral.Zero)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToUInt16(f)))
				.Then(Is_, (ushort)0)

			.BDDfy("less than max")
				.Given(TheRomanNumeral_, new RomanNumeral(100))
				.When(ConvertedTo_, Conv.ert(f => Convert.ToUInt16(f)))
				.Then(Is_, (ushort)100)

			.BDDfy("max")
				.Given(TheRomanNumeral_, RomanNumeral.Max)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToUInt16(f)))
				.Then(Is_, (ushort)3999)

			.ExecuteWithReport();
		}

		[Fact]
		public void ConvertToInt()
		{
			new Story("convert to Int")
				.InOrderTo("convert a roman numeral to an int whenever possible")
				.AsA("library user")
				.IWant("Convert() to a roman numeral")

			.BDDfy("zero")
				.Given(TheRomanNumeral_, RomanNumeral.Zero)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToInt32(f)))
				.Then(Is_, 0)

			.BDDfy("less than max")
				.Given(TheRomanNumeral_, new RomanNumeral(100))
				.When(ConvertedTo_, Conv.ert(f => Convert.ToInt32(f)))
				.Then(Is_, 100)

			.BDDfy("max")
				.Given(TheRomanNumeral_, RomanNumeral.Max)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToInt32(f)))
				.Then(Is_, 3999)

			.ExecuteWithReport();
		}

		[Fact]
		public void ConvertToUInt()
		{
			new Story("convert to UInt")
				.InOrderTo("convert a roman numeral to an unsigned int whenever possible")
				.AsA("library user")
				.IWant("Convert() to a roman numeral")

			.BDDfy("zero")
				.Given(TheRomanNumeral_, RomanNumeral.Zero)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToUInt32(f)))
				.Then(Is_, 0u)

			.BDDfy("less than max")
				.Given(TheRomanNumeral_, new RomanNumeral(100))
				.When(ConvertedTo_, Conv.ert(f => Convert.ToUInt32(f)))
				.Then(Is_, 100u)

			.BDDfy("max")
				.Given(TheRomanNumeral_, RomanNumeral.Max)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToUInt32(f)))
				.Then(Is_, 3999u)

			.ExecuteWithReport();
		}

		[Fact]
		public void ConvertToLong()
		{
			new Story("convert to Long")
				.InOrderTo("convert a roman numeral to a long whenever possible")
				.AsA("library user")
				.IWant("Convert() to a roman numeral")

			.BDDfy("zero")
				.Given(TheRomanNumeral_, RomanNumeral.Zero)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToInt64(f)))
				.Then(Is_, 0L)

			.BDDfy("less than max")
				.Given(TheRomanNumeral_, new RomanNumeral(100))
				.When(ConvertedTo_, Conv.ert(f => Convert.ToInt64(f)))
				.Then(Is_, 100L)

			.BDDfy("max")
				.Given(TheRomanNumeral_, RomanNumeral.Max)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToInt64(f)))
				.Then(Is_, 3999L)

			.ExecuteWithReport();
		}

		[Fact]
		public void ConvertToULong()
		{
			new Story("convert to ULong")
				.InOrderTo("convert a roman numeral to an unsigned long whenever possible")
				.AsA("library user")
				.IWant("Convert() to a roman numeral")

			.BDDfy("zero")
				.Given(TheRomanNumeral_, RomanNumeral.Zero)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToUInt64(f)))
				.Then(Is_, 0uL)

			.BDDfy("less than max")
				.Given(TheRomanNumeral_, new RomanNumeral(100))
				.When(ConvertedTo_, Conv.ert(f => Convert.ToUInt64(f)))
				.Then(Is_, 100uL)

			.BDDfy("max")
				.Given(TheRomanNumeral_, RomanNumeral.Max)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToUInt64(f)))
				.Then(Is_, 3999uL)

			.ExecuteWithReport();
		}

		[Fact]
		public void ConvertToFloat()
		{
			new Story("convert to Float")
				.InOrderTo("convert a roman numeral to a float whenever possible")
				.AsA("library user")
				.IWant("Convert() to a roman numeral")

			.BDDfy("zero")
				.Given(TheRomanNumeral_, RomanNumeral.Zero)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToSingle(f)))
				.Then(Is_, 0f)

			.BDDfy("less than max")
				.Given(TheRomanNumeral_, new RomanNumeral(100))
				.When(ConvertedTo_, Conv.ert(f => Convert.ToSingle(f)))
				.Then(Is_, 100f)

			.BDDfy("max")
				.Given(TheRomanNumeral_, RomanNumeral.Max)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToSingle(f)))
				.Then(Is_, 3999f)

			.ExecuteWithReport();
		}

		[Fact]
		public void ConvertToDouble()
		{
			new Story("convert to Double")
				.InOrderTo("convert a roman numeral to a double whenever possible")
				.AsA("library user")
				.IWant("Convert() to a roman numeral")

			.BDDfy("zero")
				.Given(TheRomanNumeral_, RomanNumeral.Zero)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToDouble(f)))
				.Then(Is_, 0d)

			.BDDfy("less than max")
				.Given(TheRomanNumeral_, new RomanNumeral(100))
				.When(ConvertedTo_, Conv.ert(f => Convert.ToDouble(f)))
				.Then(Is_, 100d)

			.BDDfy("max")
				.Given(TheRomanNumeral_, RomanNumeral.Max)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToDouble(f)))
				.Then(Is_, 3999d)

			.ExecuteWithReport();
		}

		[Fact]
		public void ConvertToDecimal()
		{
			new Story("convert to Decimal")
				.InOrderTo("convert a roman numeral to a decimal whenever possible")
				.AsA("library user")
				.IWant("Convert() to a roman numeral")

			.BDDfy("zero")
				.Given(TheRomanNumeral_, RomanNumeral.Zero)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToDecimal(f)))
				.Then(Is_, 0m)

			.BDDfy("less than max")
				.Given(TheRomanNumeral_, new RomanNumeral(100))
				.When(ConvertedTo_, Conv.ert(f => Convert.ToDecimal(f)))
				.Then(Is_, 100m)

			.BDDfy("max")
				.Given(TheRomanNumeral_, RomanNumeral.Max)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToDecimal(f)))
				.Then(Is_, 3999m)

			.ExecuteWithReport();
		}

		[Fact]
		public void ConvertToDateTime()
		{
			new Story("convert to DateTime")
				.InOrderTo("convert a roman numeral to date-time whenever possible")
				.AsA("library user")
				.IWant("Convert() to a roman numeral")

			.BDDfy("zero")
				.Given(TheRomanNumeral_, RomanNumeral.Zero)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToDateTime(f)))
				.Then(CannotCast)

			.BDDfy("less than max")
				.Given(TheRomanNumeral_, new RomanNumeral(100))
				.When(ConvertedTo_, Conv.ert(f => Convert.ToDateTime(f)))
				.Then(CannotCast)

			.BDDfy("max")
				.Given(TheRomanNumeral_, RomanNumeral.Max)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToDateTime(f)))
				.Then(CannotCast)

			.ExecuteWithReport();
		}

		[Fact]
		public void ConvertToString()
		{
			new Story("convert to Char")
				.InOrderTo("convert a roman figure to a string")
				.AsA("library user")
				.IWant("Convert() to a roman figure")

			.BDDfy("zero")
				.Given(TheRomanNumeral_, RomanNumeral.Zero)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToString(f)))
				.Then(Is_, "N")

			.BDDfy("single figure")
				.Given(TheRomanNumeral_, new RomanNumeral(500))
				.When(ConvertedTo_, Conv.ert(f => Convert.ToString(f)))
				.Then(Is_, "D")

			.BDDfy("multiple figure")
				.Given(TheRomanNumeral_, new RomanNumeral(11))
				.When(ConvertedTo_, Conv.ert(f => Convert.ToString(f)))
				.Then(Is_, "XI")

			.ExecuteWithReport();
		}

		[Fact]
		public void ChangeType()
		{
			new Story("change type")
				.InOrderTo("convert a roman numeral to a clr type whenever possible")
				.AsA("library user")
				.IWant("Convert() to a roman numeral")

			.BDDfy("supported type")
				.Given(TheRomanNumeral_, RomanNumeral.Max)
				.When(ConvertedTo_, typeof(long))
				.Then(Is_, 3999L)

			.BDDfy("overflowing type")
				.Given(TheRomanNumeral_, RomanNumeral.Max)
				.When(ConvertedTo_, typeof(byte))
				.Then(Overflows)

			.BDDfy("unsupported type")
				.Given(TheRomanNumeral_, RomanNumeral.Min)
				.When(ConvertedTo_, typeof(TimeSpan))
				.Then(CannotCast)

			.BDDfy("unsupported type")
				.Given(TheRomanNumeral_, RomanNumeral.Min)
				.When(ConvertedTo_, typeof(Exception))
				.Then(CannotCast)

			.BDDfy("itself")
				.Given(TheRomanNumeral_, RomanNumeral.Max)
				.When(ConvertedTo_, typeof(RomanNumeral))
				.Then(Is_, RomanNumeral.Max)

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

		private void ConvertedTo_(Type to)
		{
			_conversion = () => Convert.ChangeType(_subject, to);
		}

		private void Is_<T>(T value)
		{
			Assert.Equal(value, _conversion());
		}

		private void ThrowsException()
		{
			Action conversion = () => _conversion();
			Assert.ThrowsAny<FormatException>(conversion);
		}

		private void Overflows()
		{
			Action conversion = () => _conversion();
			Assert.ThrowsAny<OverflowException>(conversion);
		}

		private void CannotCast()
		{
			Action conversion = () => _conversion();
			var ex = Assert.ThrowsAny<InvalidCastException>(conversion);
			Assert.Contains(typeof(RomanNumeral).Name, ex.Message);
		}
	}
}