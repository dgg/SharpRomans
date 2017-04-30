using System;
using SharpRomans.Tests.Spec.Roman_Numeral.Support;
using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Numeral
{
	[Category("Spec"), Category("RomanNumeral"), Category("Conversions")]
	[Story(
		Title = "roman numeral equality",
		AsA = "library user",
		IWant = "to use conversion methods",
		SoThat = "I can convert a roman numeral to clr types whenever possible"
	)]
	public class ConversionsTester
	{
		[Fact]
		public void ConvertToBoolean()
		{
			this.WithTags("RomanNumeral", "Conversions", "bool")
				.Given(_ => _.TheRomanNumeral_(RomanNumeral.Zero))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToBoolean(f))))
				.Then(_ => _.Is_(false))
				.BDDfy("zero");

			this.WithTags("RomanNumeral", "Conversions", "bool")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(1)))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToBoolean(f))))
				.Then(_ => _.Is_(true))
				.BDDfy("one");

			this.WithTags("RomanNumeral", "Conversions", "bool")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(51)))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToBoolean(f))))
				.Then(_ => _.Is_(true))
				.BDDfy("more than one");

			this.WithTags("RomanNumeral", "Conversions", "bool")
				.Given(_ => _.TheRomanNumeral_(RomanNumeral.Max))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToBoolean(f))))
				.Then(_ => _.Is_(true))
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToChar()
		{
			this.WithTags("RomanNumeral", "Conversions", "char")
				.Given(_ => _.TheRomanNumeral_(RomanNumeral.Zero))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToChar(f))))
				.Then(_ => _.Is_('N'))
				.BDDfy("zero");

			this.WithTags("RomanNumeral", "Conversions", "char")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(500)))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToChar(f))))
				.Then(_ => _.Is_('D'))
				.BDDfy("single figure");

			this.WithTags("RomanNumeral", "Conversions", "char")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(11)))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToChar(f))))
				.Then(_ => _.ThrowsException())
				.BDDfy("multiple figure");
		}

		[Fact]
		public void ConvertToSByte()
		{
			this.WithTags("RomanNumeral", "Conversions", "sbyte")
				.Given(_ => _.TheRomanNumeral_(RomanNumeral.Zero))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToSByte(f))))
				.Then(_ => _.Is_((sbyte)0))
				.BDDfy("zero");

			this.WithTags("RomanNumeral", "Conversions", "sbyte")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(101)))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToSByte(f))))
				.Then(_ => _.Is_((sbyte)101))
				.BDDfy("less than max");

			this.WithTags("RomanNumeral", "Conversions", "sbyte")
				.Given(_ => _.TheRomanNumeral_(RomanNumeral.Max))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToSByte(f))))
				.Then(_ => _.Overflows())
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToByte()
		{
			this.WithTags("RomanNumeral", "Conversions", "byte")
				.Given(_ => _.TheRomanNumeral_(RomanNumeral.Zero))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToByte(f))))
				.Then(_ => _.Is_((byte)0))
				.BDDfy("zero");

			this.WithTags("RomanNumeral", "Conversions", "byte")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(100)))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToByte(f))))
				.Then(_ => _.Is_((byte)100))
				.BDDfy("less than max");

			this.WithTags("RomanNumeral", "Conversions", "byte")
				.Given(_ => _.TheRomanNumeral_(RomanNumeral.Max))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToByte(f))))
				.Then(_ => _.Overflows())
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToShort()
		{
			this.WithTags("RomanNumeral", "Conversions", "short")
				.Given(_ => _.TheRomanNumeral_(RomanNumeral.Zero))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToInt16(f))))
				.Then(_ => _.Is_((short)0))
				.BDDfy("zero");

			this.WithTags("RomanNumeral", "Conversions", "short")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(100)))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToInt16(f))))
				.Then(_ => _.Is_((short)100))
				.BDDfy("less than max");

			this.WithTags("RomanNumeral", "Conversions", "short")
				.Given(_ => _.TheRomanNumeral_(RomanNumeral.Max))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToInt16(f))))
				.Then(_ => _.Is_((short)3999))
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToUShort()
		{
			this.WithTags("RomanNumeral", "Conversions", "ushort")
				.Given(_ => _.TheRomanNumeral_(RomanNumeral.Zero))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToUInt16(f))))
				.Then(_ => _.Is_((ushort)0))
				.BDDfy("zero");

			this.WithTags("RomanNumeral", "Conversions", "ushort")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(100)))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToUInt16(f))))
				.Then(_ => _.Is_((ushort)100))
				.BDDfy("less than max");

			this.WithTags("RomanNumeral", "Conversions", "ushort")
				.Given(_ => _.TheRomanNumeral_(RomanNumeral.Max))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToUInt16(f))))
				.Then(_ => _.Is_((ushort)3999))
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToInt()
		{
			this.WithTags("RomanNumeral", "Conversions", "int")
				.Given(_ => _.TheRomanNumeral_(RomanNumeral.Zero))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToInt32(f))))
				.Then(_ => _.Is_(0))
				.BDDfy("zero");

			this.WithTags("RomanNumeral", "Conversions", "int")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(100)))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToInt32(f))))
				.Then(_ => _.Is_(100))
				.BDDfy("less than max");

			this.WithTags("RomanNumeral", "Conversions", "int")
				.Given(_ => _.TheRomanNumeral_(RomanNumeral.Max))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToInt32(f))))
				.Then(_ => _.Is_(3999))
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToUInt()
		{
			this.WithTags("RomanNumeral", "Conversions", "uint")
				.Given(_ => _.TheRomanNumeral_(RomanNumeral.Zero))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToUInt32(f))))
				.Then(_ => _.Is_(0u))
				.BDDfy("zero");

			this.WithTags("RomanNumeral", "Conversions", "uint")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(100)))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToUInt32(f))))
				.Then(_ => _.Is_(100u))
				.BDDfy("less than max");

			this.WithTags("RomanNumeral", "Conversions", "uint")
				.Given(_ => _.TheRomanNumeral_(RomanNumeral.Max))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToUInt32(f))))
				.Then(_ => _.Is_(3999u))
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToLong()
		{
			this.WithTags("RomanNumeral", "Conversions", "long")
				.Given(_ => _.TheRomanNumeral_(RomanNumeral.Zero))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToInt64(f))))
				.Then(_ => _.Is_(0L))
				.BDDfy("zero");

			this.WithTags("RomanNumeral", "Conversions", "long")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(100)))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToInt64(f))))
				.Then(_ => _.Is_(100L))
				.BDDfy("less than max");

			this.WithTags("RomanNumeral", "Conversions", "long")
				.Given(_ => _.TheRomanNumeral_(RomanNumeral.Max))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToInt64(f))))
				.Then(_ => _.Is_(3999L))
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToULong()
		{
			this.WithTags("RomanNumeral", "Conversions", "ulong")
				.Given(_ => _.TheRomanNumeral_(RomanNumeral.Zero))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToUInt64(f))))
				.Then(_ => _.Is_(0uL))
				.BDDfy("zero");

			this.WithTags("RomanNumeral", "Conversions", "ulong")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(100)))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToUInt64(f))))
				.Then(_ => _.Is_(100uL))
				.BDDfy("less than max");

			this.WithTags("RomanNumeral", "Conversions", "ulong")
				.Given(_ => _.TheRomanNumeral_(RomanNumeral.Max))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToUInt64(f))))
				.Then(_ => _.Is_(3999uL))
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToFloat()
		{
			this.WithTags("RomanNumeral", "Conversions", "float")
				.Given(_ => _.TheRomanNumeral_(RomanNumeral.Zero))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToSingle(f))))
				.Then(_ => _.Is_(0f))
				.BDDfy("zero");

			this.WithTags("RomanNumeral", "Conversions", "float")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(100)))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToSingle(f))))
				.Then(_ => _.Is_(100f))
				.BDDfy("less than max");

			this.WithTags("RomanNumeral", "Conversions", "float")
				.Given(_ => _.TheRomanNumeral_(RomanNumeral.Max))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToSingle(f))))
				.Then(_ => _.Is_(3999f))
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToDouble()
		{
			this.WithTags("RomanNumeral", "Conversions", "double")
				.Given(_ => _.TheRomanNumeral_(RomanNumeral.Zero))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToDouble(f))))
				.Then(_ => _.Is_(0d))
				.BDDfy("zero");

			this.WithTags("RomanNumeral", "Conversions", "double")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(100)))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToDouble(f))))
				.Then(_ => _.Is_(100d))
				.BDDfy("less than max");

			this.WithTags("RomanNumeral", "Conversions", "double")
				.Given(_ => _.TheRomanNumeral_(RomanNumeral.Max))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToDouble(f))))
				.Then(_ => _.Is_(3999d))
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToDecimal()
		{
			this.WithTags("RomanNumeral", "Conversions", "decimal")
				.Given(_ => _.TheRomanNumeral_(RomanNumeral.Zero))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToDecimal(f))))
				.Then(_ => _.Is_(0m))
				.BDDfy("zero");

			this.WithTags("RomanNumeral", "Conversions", "decimal")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(100)))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToDecimal(f))))
				.Then(_ => _.Is_(100m))
				.BDDfy("less than max");

			this.WithTags("RomanNumeral", "Conversions", "decimal")
				.Given(_ => _.TheRomanNumeral_(RomanNumeral.Max))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToDecimal(f))))
				.Then(_ => _.Is_(3999m))
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToDateTime()
		{
			this.WithTags("RomanNumeral", "Conversions", "datetime")
				.Given(_ => _.TheRomanNumeral_(RomanNumeral.Zero))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToDateTime(f))))
				.Then(_ => _.CannotCast())
				.BDDfy("zero");

			this.WithTags("RomanNumeral", "Conversions", "datetime")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(100)))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToDateTime(f))))
				.Then(_ => _.CannotCast())
				.BDDfy("less than max");

			this.WithTags("RomanNumeral", "Conversions", "datetime")
				.Given(_ => _.TheRomanNumeral_(RomanNumeral.Max))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToDateTime(f))))
				.Then(_ => _.CannotCast())
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToString()
		{
			this.WithTags("RomanNumeral", "Conversions", "string")
				.Given(_ => _.TheRomanNumeral_(RomanNumeral.Zero))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToString(f))))
				.Then(_ => _.Is_("N"))
				.BDDfy("zero");

			this.WithTags("RomanNumeral", "Conversions", "string")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(500)))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToString(f))))
				.Then(_ => _.Is_("D"))
				.BDDfy("single figure");

			this.WithTags("RomanNumeral", "Conversions", "string")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(11)))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToString(f))))
				.Then(_ => _.Is_("XI"))
				.BDDfy("multiple figure");
		}

		[Fact]
		public void ChangeType()
		{
			this.WithTags("RomanNumeral", "Conversions", "ChangeType")
				.Given(_ => _.TheRomanNumeral_(RomanNumeral.Max))
				.When(_ => _.ConvertedTo_(typeof(long)))
				.Then(_ => _.Is_(3999L))
				.BDDfy("supported type");

			this.WithTags("RomanNumeral", "Conversions", "ChangeType")
				.Given(_ => _.TheRomanNumeral_(RomanNumeral.Max))
				.When(_ => _.ConvertedTo_(typeof(byte)))
				.Then(_ => _.Overflows())
				.BDDfy("overflowing type");

			this.WithTags("RomanNumeral", "Conversions", "ChangeType")
				.Given(_ => _.TheRomanNumeral_(RomanNumeral.Min))
				.When(_ => _.ConvertedTo_(typeof(TimeSpan)))
				.Then(_ => _.CannotCast())
				.BDDfy("unsupported type");

			this.WithTags("RomanNumeral", "Conversions", "ChangeType")
				.Given(_ => _.TheRomanNumeral_(RomanNumeral.Min))
				.When(_ => _.ConvertedTo_(typeof(Exception)))
				.Then(_ => _.CannotCast()) 
				.BDDfy("unsupported type");

			this.WithTags("RomanNumeral", "Conversions", "ChangeType")
				.Given(_ => _.TheRomanNumeral_(RomanNumeral.Max))
				.When(_ => _.ConvertedTo_(typeof(RomanNumeral)))
				.Then(_ => _.Is_(RomanNumeral.Max))
				.BDDfy("itself");
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