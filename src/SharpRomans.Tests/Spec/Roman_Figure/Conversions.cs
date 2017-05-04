using System;
using System.Globalization;
using SharpRomans.Tests.Spec.Roman_Figure.Support;
using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec", Subject = "RomanFigure", Feature = "Conversions")]
	[Collection("bddfy")]
	[Story(
		Title = "conversions",
		AsA = "library user",
		IWant = "to use conversion methods",
		SoThat = "I can convert a roman figure to clr types whenever possible"
	)]
	public class ConversionsTester
	{
		[Fact]
		public void ConvertToBoolean()
		{
			this.WithTags("RomanFigure", "Conversions", "bool")
				.Given(_ => _.theRomanFigure(RomanFigure.N))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToBoolean(f))))
				.Then(_ => _.@is(false))
				.BDDfy("zero");

			this.WithTags("RomanFigure", "Conversions")
				.Given(_ => _.theRomanFigure(RomanFigure.I))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToBoolean(f))))
				.Then(_ => _.@is(true))
				.BDDfy("one");

			this.WithTags("RomanFigure", "Conversions")
				.Given(_ => _.theRomanFigure(RomanFigure.D))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToBoolean(f))))
				.Then(_ => _.@is(true))
				.BDDfy("more than one");

			this.WithTags("RomanFigure", "Conversions")
				.Given(_ => _.theRomanFigure(RomanFigure.M))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToBoolean(f))))
				.Then(_ => _.@is(true))
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToSByte()
		{
			this.WithTags("RomanFigure", "Conversions", "sbyte")
				.Given(_ => _.theRomanFigure(RomanFigure.N))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToSByte(f))))
				.Then(_ => _.@is((sbyte)0))
				.BDDfy("zero");

			this.WithTags("RomanFigure", "Conversions", "sbyte")
				.Given(_ => _.theRomanFigure(RomanFigure.C))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToSByte(f))))
				.Then(_ => _.@is((sbyte)100))
				.BDDfy("less than max");

			this.WithTags("RomanFigure", "Conversions", "sbyte")
				.Given(_ => _.theRomanFigure(RomanFigure.M))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToSByte(f))))
				.Then(_ => _.overflows())
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToByte()
		{

			this.WithTags("RomanFigure", "Conversions", "byte")
				.Given(_ => _.theRomanFigure(RomanFigure.N))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToByte(f))))
				.Then(_ => _.@is((byte)0))
				.BDDfy("zero");

			this.WithTags("RomanFigure", "Conversions", "byte")
				.Given(_ => _.theRomanFigure(RomanFigure.C))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToByte(f))))
				.Then(_ => _.@is((byte)100))
				.BDDfy("less than max");

			this.WithTags("RomanFigure", "Conversions", "byte")
				.Given(_ => _.theRomanFigure(RomanFigure.M))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToByte(f))))
				.Then(_ => _.overflows())
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToShort()
		{
			this.WithTags("RomanFigure", "Conversions", "short")
				.Given(_ => _.theRomanFigure(RomanFigure.N))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToInt16(f))))
				.Then(_ => _.@is((short)0))
				.BDDfy("zero");

			this.WithTags("RomanFigure", "Conversions", "short")
				.Given(_ => _.theRomanFigure(RomanFigure.C))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToInt16(f))))
				.Then(_ => _.@is((short)100))
				.BDDfy("less than max");

			this.WithTags("RomanFigure", "Conversions", "short")
				.Given(_ => _.theRomanFigure(RomanFigure.M))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToInt16(f))))
				.Then(_ => _.@is((short)1000))
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToUShort()
		{
			this.WithTags("RomanFigure", "Conversions", "ushort")
				.Given(_ => _.theRomanFigure(RomanFigure.N))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToUInt16(f))))
				.Then(_ => _.@is((ushort)0))
				.BDDfy("zero");

			this.WithTags("RomanFigure", "Conversions", "ushort")
				.Given(_ => _.theRomanFigure(RomanFigure.C))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToUInt16(f))))
				.Then(_ => _.@is((ushort)100))
				.BDDfy("less than max");

			this.WithTags("RomanFigure", "Conversions", "ushort")
				.Given(_ => _.theRomanFigure(RomanFigure.M))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToUInt16(f))))
				.Then(_ => _.@is((ushort)1000))
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToInt()
		{
			this.WithTags("RomanFigure", "Conversions", "int")
				.Given(_ => _.theRomanFigure(RomanFigure.N))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToInt32(f))))
				.Then(_ => _.@is(0))
				.BDDfy("zero");

			this.WithTags("RomanFigure", "Conversions", "int")
				.Given(_ => _.theRomanFigure(RomanFigure.C))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToInt32(f))))
				.Then(_ => _.@is(100))
				.BDDfy("less than max");

			this.WithTags("RomanFigure", "Conversions", "int")
				.Given(_ => _.theRomanFigure(RomanFigure.M))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToInt32(f))))
				.Then(_ => _.@is(1000))
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToUInt()
		{
			this.WithTags("RomanFigure", "Conversions", "uint")
				.Given(_ => _.theRomanFigure(RomanFigure.N))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToUInt32(f))))
				.Then(_ => _.@is(0u))
				.BDDfy("zero");

			this.WithTags("RomanFigure", "Conversions", "uint")
				.Given(_ => _.theRomanFigure(RomanFigure.C))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToUInt32(f))))
				.Then(_ => _.@is(100u))
				.BDDfy("less than max");

			this.WithTags("RomanFigure", "Conversions", "uint")
				.Given(_ => _.theRomanFigure(RomanFigure.M))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToUInt32(f))))
				.Then(_ => _.@is(1000u))
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToLong()
		{
			this.WithTags("RomanFigure", "Conversions", "long")
				.Given(_ => _.theRomanFigure(RomanFigure.N))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToInt64(f))))
				.Then(_ => _.@is(0L))
				.BDDfy("zero");

			this.WithTags("RomanFigure", "Conversions", "long")
				.Given(_ => _.theRomanFigure(RomanFigure.C))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToInt64(f))))
				.Then(_ => _.@is(100L))
				.BDDfy("less than max");

			this.WithTags("RomanFigure", "Conversions", "long")
				.Given(_ => _.theRomanFigure(RomanFigure.M))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToInt64(f))))
				.Then(_ => _.@is(1000L))
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToULong()
		{
			this.WithTags("RomanFigure", "Conversions", "ulong")
				.Given(_ => _.theRomanFigure(RomanFigure.N))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToUInt64(f))))
				.Then(_ => _.@is(0uL))
				.BDDfy("zero");

			this.WithTags("RomanFigure", "Conversions", "ulong")
				.Given(_ => _.theRomanFigure(RomanFigure.C))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToUInt64(f))))
				.Then(_ => _.@is(100uL))
				.BDDfy("less than max");

			this.WithTags("RomanFigure", "Conversions", "ulong")
				.Given(_ => _.theRomanFigure(RomanFigure.M))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToUInt64(f))))
				.Then(_ => _.@is(1000uL))
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToFloat()
		{
			this.WithTags("RomanFigure", "Conversions", "float")
				.Given(_ => _.theRomanFigure(RomanFigure.N))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToSingle(f))))
				.Then(_ => _.@is(0f))
				.BDDfy("zero");

			this.WithTags("RomanFigure", "Conversions", "float")
				.Given(_ => _.theRomanFigure(RomanFigure.C))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToSingle(f))))
				.Then(_ => _.@is(100f))
				.BDDfy("less than max");

			this.WithTags("RomanFigure", "Conversions", "float")
				.Given(_ => _.theRomanFigure(RomanFigure.M))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToSingle(f))))
				.Then(_ => _.@is(1000f))
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToDouble()
		{
			this.WithTags("RomanFigure", "Conversions", "double")
				.Given(_ => _.theRomanFigure(RomanFigure.N))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToDouble(f))))
				.Then(_ => _.@is(0d))
				.BDDfy("zero");

			this.WithTags("RomanFigure", "Conversions", "double")

				.Given(_ => _.theRomanFigure(RomanFigure.C))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToDouble(f))))
				.Then(_ => _.@is(100d))
				.BDDfy("less than max");

			this.WithTags("RomanFigure", "Conversions", "double")
				.Given(_ => _.theRomanFigure(RomanFigure.M))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToDouble(f))))
				.Then(_ => _.@is(1000d))
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToDecimal()
		{
			this.WithTags("RomanFigure", "Conversions", "decimal")
				.Given(_ => _.theRomanFigure(RomanFigure.N))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToDecimal(f))))
				.Then(_ => _.@is(0m))
				.BDDfy("zero");

			this.WithTags("RomanFigure", "Conversions", "decimal")

				.Given(_ => _.theRomanFigure(RomanFigure.C))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToDecimal(f))))
				.Then(_ => _.@is(100m))
				.BDDfy("less than max");

			this.WithTags("RomanFigure", "Conversions", "decimal")
				.Given(_ => _.theRomanFigure(RomanFigure.M))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToDecimal(f))))
				.Then(_ => _.@is(1000m))
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToChar()
		{
			this.WithTags("RomanFigure", "Conversions", "char")
				.Given(_ => _.theRomanFigure(RomanFigure.N))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToChar(f))))
				.Then(_ => _.@is('N'))
				.BDDfy("zero");

			this.WithTags("RomanFigure", "Conversions", "char")
				.Given(_ => _.theRomanFigure(RomanFigure.D))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToChar(f))))
				.Then(_ => _.@is('D'))
				.BDDfy("more than one");

			this.WithTags("RomanFigure", "Conversions", "char")
				.Given(_ => _.theRomanFigure(RomanFigure.M))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToChar(f))))
				.Then(_ => _.@is('M'))
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToString()
		{
			this.WithTags("RomanFigure", "Conversions", "string")
				.Given(_ => _.theRomanFigure(RomanFigure.N))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToString(f, CultureInfo.InvariantCulture))))
				.Then(_ => _.@is("N"))
				.BDDfy("zero");

			this.WithTags("RomanFigure", "Conversions", "string")
				.Given(_ => _.theRomanFigure(RomanFigure.D))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToString(f, CultureInfo.InvariantCulture))))
				.Then(_ => _.@is("D"))
				.BDDfy("more than one");

			this.WithTags("RomanFigure", "Conversions", "string")
				.Given(_ => _.theRomanFigure(RomanFigure.M))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToString(f, CultureInfo.InvariantCulture))))
				.Then(_ => _.@is("M"))
				.BDDfy("max");
		}

		[Fact]
		public void ConvertToDateTime()
		{
			this.WithTags("RomanFigure", "Conversions", "datetime")
				.Given(_ => _.theRomanFigure(RomanFigure.N))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToDateTime(f))))
				.Then(_ => _.cannotConvert())
				.BDDfy("zero");

			this.WithTags("RomanFigure", "Conversions", "datetime")
				.Given(_ => _.theRomanFigure(RomanFigure.C))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToDateTime(f))))
				.Then(_ => _.cannotConvert())
				.BDDfy("less than max");

			this.WithTags("RomanFigure", "Conversions", "datetime")
				.Given(_ => _.theRomanFigure(RomanFigure.M))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToDateTime(f))))
				.Then(_ => _.cannotConvert())
				.BDDfy("max");
		}

		[Fact]
		public void ChangeType()
		{
			this.WithTags("RomanFigure", "Conversions", "ChangeType")
				.Given(_ => _.theRomanFigure(RomanFigure.M))
				.When(_ => _.convertedTo(typeof(long)))
				.Then(_ => _.@is(1000L))
				.BDDfy("supported type");

			this.WithTags("RomanFigure", "Conversions", "ChangeType")
				.Given(_ => _.theRomanFigure(RomanFigure.M))
				.When(_ => _.convertedTo(typeof(byte)))
				.Then(_ => _.overflows())
				.BDDfy("overflowing type");

			this.WithTags("RomanFigure", "Conversions", "ChangeType")
				.Given(_ => _.theRomanFigure(RomanFigure.M))
				.When(_ => _.convertedTo(typeof(TimeSpan)))
				.Then(_ => _.cannotConvert())
				.BDDfy("unsupported type");

			this.WithTags("RomanFigure", "Conversions", "ChangeType")
				.Given(_ => _.theRomanFigure(RomanFigure.M))
				.When(_ => _.convertedTo(typeof(Exception)))
				.Then(_ => _.cannotConvert())
				.BDDfy("unsupported type");

			this.WithTags("RomanFigure", "Conversions", "ChangeType")
				.Given(_ => _.theRomanFigure(RomanFigure.M))
				.When(_ => _.convertedTo(typeof(RomanFigure)))
				.Then(_ => _.@is(RomanFigure.M))
				.BDDfy("itself");
		}

		private RomanFigure _subject;
		private void theRomanFigure(RomanFigure subject)
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

		private void @is<T>(T value)
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
