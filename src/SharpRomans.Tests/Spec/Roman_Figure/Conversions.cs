using System;
using System.Globalization;
using SharpRomans.Tests.Spec.Roman_Figure.Support;
using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec"), Category("RomanFigure"), Category("Conversions")]
	[Collection("bddfy")]
	[Story(
		Title = "conversions",
		AsA = "library user",
		IWant = "to use conversion methods",
		SoThat = "I can convert a roman figure to clr types whenever possible"
	)]
	public class Conversions
	{
		[Fact]
		public void ConvertToBoolean()
		{
			this.WithTags("RomanFigure", "Conversions", "bool")
				.Given(_ => _.theRomanFigure_(RomanFigure.N))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToBoolean(f))))
				.Then(_ => _.is_(false))
				.BDDfy("zero");

			this.WithTags("RomanFigure", "Conversions")
				.Given(_ => _.theRomanFigure_(RomanFigure.I))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToBoolean(f))))
				.Then(_ => _.is_(true))
				.BDDfy("one");

			this.WithTags("RomanFigure", "Conversions")
				.Given(_ => _.theRomanFigure_(RomanFigure.D))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToBoolean(f))))
				.Then(_ => _.is_(true))
				.BDDfy("more than one");

			this.WithTags("RomanFigure", "Conversions")
				.Given(_ => _.theRomanFigure_(RomanFigure.M))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToBoolean(f))))
				.Then(_ => _.is_(true))
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToSByte()
		{
			this.WithTags("RomanFigure", "Conversions", "sbyte")
				.Given(_ => _.theRomanFigure_(RomanFigure.N))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToSByte(f))))
				.Then(_ => _.is_((sbyte)0))
				.BDDfy("zero");

			this.WithTags("RomanFigure", "Conversions", "sbyte")
				.Given(_ => _.theRomanFigure_(RomanFigure.C))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToSByte(f))))
				.Then(_ => _.is_((sbyte)100))
				.BDDfy("less than max");

			this.WithTags("RomanFigure", "Conversions", "sbyte")
				.Given(_ => _.theRomanFigure_(RomanFigure.M))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToSByte(f))))
				.Then(_ => _.overflows())
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToByte()
		{

			this.WithTags("RomanFigure", "Conversions", "byte")
				.Given(_ => _.theRomanFigure_(RomanFigure.N))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToByte(f))))
				.Then(_ => _.is_((byte)0))
				.BDDfy("zero");

			this.WithTags("RomanFigure", "Conversions", "byte")
				.Given(_ => _.theRomanFigure_(RomanFigure.C))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToByte(f))))
				.Then(_ => _.is_((byte)100))
				.BDDfy("less than max");

			this.WithTags("RomanFigure", "Conversions", "byte")
				.Given(_ => _.theRomanFigure_(RomanFigure.M))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToByte(f))))
				.Then(_ => _.overflows())
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToShort()
		{
			this.WithTags("RomanFigure", "Conversions", "short")
				.Given(_ => _.theRomanFigure_(RomanFigure.N))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToInt16(f))))
				.Then(_ => _.is_((short)0))
				.BDDfy("zero");

			this.WithTags("RomanFigure", "Conversions", "short")
				.Given(_ => _.theRomanFigure_(RomanFigure.C))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToInt16(f))))
				.Then(_ => _.is_((short)100))
				.BDDfy("less than max");

			this.WithTags("RomanFigure", "Conversions", "short")
				.Given(_ => _.theRomanFigure_(RomanFigure.M))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToInt16(f))))
				.Then(_ => _.is_((short)1000))
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToUShort()
		{
			this.WithTags("RomanFigure", "Conversions", "ushort")
				.Given(_ => _.theRomanFigure_(RomanFigure.N))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToUInt16(f))))
				.Then(_ => _.is_((ushort)0))
				.BDDfy("zero");

			this.WithTags("RomanFigure", "Conversions", "ushort")
				.Given(_ => _.theRomanFigure_(RomanFigure.C))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToUInt16(f))))
				.Then(_ => _.is_((ushort)100))
				.BDDfy("less than max");

			this.WithTags("RomanFigure", "Conversions", "ushort")
				.Given(_ => _.theRomanFigure_(RomanFigure.M))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToUInt16(f))))
				.Then(_ => _.is_((ushort)1000))
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToInt()
		{
			this.WithTags("RomanFigure", "Conversions", "int")
				.Given(_ => _.theRomanFigure_(RomanFigure.N))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToInt32(f))))
				.Then(_ => _.is_(0))
				.BDDfy("zero");

			this.WithTags("RomanFigure", "Conversions", "int")
				.Given(_ => _.theRomanFigure_(RomanFigure.C))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToInt32(f))))
				.Then(_ => _.is_(100))
				.BDDfy("less than max");

			this.WithTags("RomanFigure", "Conversions", "int")
				.Given(_ => _.theRomanFigure_(RomanFigure.M))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToInt32(f))))
				.Then(_ => _.is_(1000))
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToUInt()
		{
			this.WithTags("RomanFigure", "Conversions", "uint")
				.Given(_ => _.theRomanFigure_(RomanFigure.N))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToUInt32(f))))
				.Then(_ => _.is_(0u))
				.BDDfy("zero");

			this.WithTags("RomanFigure", "Conversions", "uint")
				.Given(_ => _.theRomanFigure_(RomanFigure.C))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToUInt32(f))))
				.Then(_ => _.is_(100u))
				.BDDfy("less than max");

			this.WithTags("RomanFigure", "Conversions", "uint")
				.Given(_ => _.theRomanFigure_(RomanFigure.M))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToUInt32(f))))
				.Then(_ => _.is_(1000u))
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToLong()
		{
			this.WithTags("RomanFigure", "Conversions", "long")
				.Given(_ => _.theRomanFigure_(RomanFigure.N))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToInt64(f))))
				.Then(_ => _.is_(0L))
				.BDDfy("zero");

			this.WithTags("RomanFigure", "Conversions", "long")
				.Given(_ => _.theRomanFigure_(RomanFigure.C))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToInt64(f))))
				.Then(_ => _.is_(100L))
				.BDDfy("less than max");

			this.WithTags("RomanFigure", "Conversions", "long")
				.Given(_ => _.theRomanFigure_(RomanFigure.M))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToInt64(f))))
				.Then(_ => _.is_(1000L))
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToULong()
		{
			this.WithTags("RomanFigure", "Conversions", "ulong")
				.Given(_ => _.theRomanFigure_(RomanFigure.N))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToUInt64(f))))
				.Then(_ => _.is_(0uL))
				.BDDfy("zero");

			this.WithTags("RomanFigure", "Conversions", "ulong")
				.Given(_ => _.theRomanFigure_(RomanFigure.C))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToUInt64(f))))
				.Then(_ => _.is_(100uL))
				.BDDfy("less than max");

			this.WithTags("RomanFigure", "Conversions", "ulong")
				.Given(_ => _.theRomanFigure_(RomanFigure.M))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToUInt64(f))))
				.Then(_ => _.is_(1000uL))
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToFloat()
		{
			this.WithTags("RomanFigure", "Conversions", "float")
				.Given(_ => _.theRomanFigure_(RomanFigure.N))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToSingle(f))))
				.Then(_ => _.is_(0f))
				.BDDfy("zero");

			this.WithTags("RomanFigure", "Conversions", "float")
				.Given(_ => _.theRomanFigure_(RomanFigure.C))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToSingle(f))))
				.Then(_ => _.is_(100f))
				.BDDfy("less than max");

			this.WithTags("RomanFigure", "Conversions", "float")
				.Given(_ => _.theRomanFigure_(RomanFigure.M))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToSingle(f))))
				.Then(_ => _.is_(1000f))
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToDouble()
		{
			this.WithTags("RomanFigure", "Conversions", "double")
				.Given(_ => _.theRomanFigure_(RomanFigure.N))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToDouble(f))))
				.Then(_ => _.is_(0d))
				.BDDfy("zero");

			this.WithTags("RomanFigure", "Conversions", "double")

				.Given(_ => _.theRomanFigure_(RomanFigure.C))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToDouble(f))))
				.Then(_ => _.is_(100d))
				.BDDfy("less than max");

			this.WithTags("RomanFigure", "Conversions", "double")
				.Given(_ => _.theRomanFigure_(RomanFigure.M))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToDouble(f))))
				.Then(_ => _.is_(1000d))
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToDecimal()
		{
			this.WithTags("RomanFigure", "Conversions", "decimal")
				.Given(_ => _.theRomanFigure_(RomanFigure.N))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToDecimal(f))))
				.Then(_ => _.is_(0m))
				.BDDfy("zero");

			this.WithTags("RomanFigure", "Conversions", "decimal")

				.Given(_ => _.theRomanFigure_(RomanFigure.C))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToDecimal(f))))
				.Then(_ => _.is_(100m))
				.BDDfy("less than max");

			this.WithTags("RomanFigure", "Conversions", "decimal")
				.Given(_ => _.theRomanFigure_(RomanFigure.M))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToDecimal(f))))
				.Then(_ => _.is_(1000m))
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToChar()
		{
			this.WithTags("RomanFigure", "Conversions", "char")
				.Given(_ => _.theRomanFigure_(RomanFigure.N))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToChar(f))))
				.Then(_ => _.is_('N'))
				.BDDfy("zero");

			this.WithTags("RomanFigure", "Conversions", "char")
				.Given(_ => _.theRomanFigure_(RomanFigure.D))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToChar(f))))
				.Then(_ => _.is_('D'))
				.BDDfy("more than one");

			this.WithTags("RomanFigure", "Conversions", "char")
				.Given(_ => _.theRomanFigure_(RomanFigure.M))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToChar(f))))
				.Then(_ => _.is_('M'))
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToString()
		{
			this.WithTags("RomanFigure", "Conversions", "string")
				.Given(_ => _.theRomanFigure_(RomanFigure.N))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToString(f, CultureInfo.InvariantCulture))))
				.Then(_ => _.is_("N"))
				.BDDfy("zero");

			this.WithTags("RomanFigure", "Conversions", "string")
				.Given(_ => _.theRomanFigure_(RomanFigure.D))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToString(f, CultureInfo.InvariantCulture))))
				.Then(_ => _.is_("D"))
				.BDDfy("more than one");

			this.WithTags("RomanFigure", "Conversions", "string")
				.Given(_ => _.theRomanFigure_(RomanFigure.M))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToString(f, CultureInfo.InvariantCulture))))
				.Then(_ => _.is_("M"))
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToDateTime()
		{
			this.WithTags("RomanFigure", "Conversions", "datetime")
				.Given(_ => _.theRomanFigure_(RomanFigure.N))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToDateTime(f))))
				.Then(_ => _.cannotConvert())
				.BDDfy("zero");

			this.WithTags("RomanFigure", "Conversions", "datetime")
				.Given(_ => _.theRomanFigure_(RomanFigure.C))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToDateTime(f))))
				.Then(_ => _.cannotConvert())
				.BDDfy("less than max");

			this.WithTags("RomanFigure", "Conversions", "datetime")
				.Given(_ => _.theRomanFigure_(RomanFigure.M))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToDateTime(f))))
				.Then(_ => _.cannotConvert())
				.BDDfy("max");
		}

		[Fact]
		public void ChangeType()
		{
			this.WithTags("RomanFigure", "Conversions", "ChangeType")
				.Given(_ => _.theRomanFigure_(RomanFigure.M))
				.When(_ => _.convertedTo(typeof(long)))
				.Then(_ => _.is_(1000L))
				.BDDfy("supported type");

			this.WithTags("RomanFigure", "Conversions", "ChangeType")
				.Given(_ => _.theRomanFigure_(RomanFigure.M))
				.When(_ => _.convertedTo(typeof(byte)))
				.Then(_ => _.overflows())
				.BDDfy("overflowing type");

			this.WithTags("RomanFigure", "Conversions", "ChangeType")
				.Given(_ => _.theRomanFigure_(RomanFigure.M))
				.When(_ => _.convertedTo(typeof(TimeSpan)))
				.Then(_ => _.cannotConvert())
				.BDDfy("unsupported type");

			this.WithTags("RomanFigure", "Conversions", "ChangeType")
				.Given(_ => _.theRomanFigure_(RomanFigure.M))
				.When(_ => _.convertedTo(typeof(Exception)))
				.Then(_ => _.cannotConvert())
				.BDDfy("unsupported type");

			this.WithTags("RomanFigure", "Conversions", "ChangeType")
				.Given(_ => _.theRomanFigure_(RomanFigure.M))
				.When(_ => _.convertedTo(typeof(RomanFigure)))
				.Then(_ => _.is_(RomanFigure.M))
				.BDDfy("itself");
		}

		private RomanFigure _subject;
		private void theRomanFigure_(RomanFigure subject)
		{
			_subject = subject;
		}

		private  Func<object> _conversion;
		private void convertedTo(Conv exp)
		{
			_conversion = () => exp.Execute(_subject);
		}

		private void convertedTo(Type to)
		{
			_conversion = () => Convert.ChangeType(_subject, to);
		}

		private void is_<T>(T value)
		{
			Assert.Equal(value, _conversion());
		}

		private void overflows()
		{
			Assert.ThrowsAny<OverflowException>(_conversion);
		}

		private void cannotConvert()
		{
			var ex = Assert.ThrowsAny<InvalidCastException>(_conversion);
			Assert.Contains(typeof(RomanFigure).Name, ex.Message);
		}
	}
}
