using System;
using System.Collections.Generic;
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
		IWant = "to get rid of little used code",
		SoThat = "I can reach as many platforms as possible"
	)]
	public class ConversionsTester
	{
		public static IEnumerable<object[]> NotConvertibleAnymore_Data = new []{
			new object[] { Conv.ert(f => Convert.ToBoolean(f)) },
			new object[] { Conv.ert(f => Convert.ToSByte(f)) },
			new object[] { Conv.ert(f => Convert.ToByte(f)) },
			new object[] { Conv.ert(f => Convert.ToInt16(f)) },
			new object[] { Conv.ert(f => Convert.ToUInt16(f)) },
			new object[] { Conv.ert(f => Convert.ToInt32(f)) },
			new object[] { Conv.ert(f => Convert.ToUInt32(f)) },
			new object[] { Conv.ert(f => Convert.ToInt64(f)) },
			new object[] { Conv.ert(f => Convert.ToUInt64(f)) },
			new object[] { Conv.ert(f => Convert.ToSingle(f)) },
			new object[] { Conv.ert(f => Convert.ToDouble(f)) },
			new object[] { Conv.ert(f => Convert.ToDecimal(f)) },
			new object[] { Conv.ert(f => Convert.ToChar(f)) }
		};

		[Theory]
		[MemberData(nameof(NotConvertibleAnymore_Data))]
		internal void NotConvertibleAnymore(Conv exp)
		{
			this.WithTags("RomanFigure", "Conversions", "Convert.Toxxx()")
				.Given(_ => _.theMostConvertibleRomanFigure(RomanFigure.I))
				.When(_ => _.convertedTo(exp))
				.Then(_ => _.cannotConvert())
				.BDDfy("cannot Convert.Toxxx()");
		}

		[Fact]
		public void StillConvertibleToString()
		{
			this.WithTags("RomanFigure", "Conversions", "Convert.ToString()")
				.Given(_ => _.theMostConvertibleRomanFigure(RomanFigure.I))
				.When(_ => _.convertedTo(Conv.ert(f => Convert.ToString(f))))
				.Then(_ => _.@is("I"))
				.BDDfy("Convert.ToString()");
		}

		public static IEnumerable<object[]> CannotChangeTypeAnymore_Data = new[]{
			new object[] { typeof(long) },
			new object[] { typeof(byte) },
			new object[] { typeof(TimeSpan) },
			new object[] { typeof(Exception) }
		};

		[Theory]
		[MemberData(nameof(CannotChangeTypeAnymore_Data))]
		public void CannotChangeTypeAnymore(Type type)
		{
			this.WithTags("RomanFigure", "Conversions", "ChangeType")
				.Given(_ => _.theMostConvertibleRomanFigure(RomanFigure.I))
				.When(_ => _.convertedTo(type))
				.Then(_ => _.cannotConvert())
				.BDDfy("cannot ChangeType()");
		}

		[Fact]
		public void StillChangeTypeToRomanFigure()
		{
			this.WithTags("RomanFigure", "Conversions", "ChangeType")
				.Given(_ => _.theMostConvertibleRomanFigure(RomanFigure.I))
				.When(_ => _.convertedTo(typeof(RomanFigure)))
				.Then(_ => _.@is(RomanFigure.I))
				.BDDfy("Convert.ToString()");
		}

		private RomanFigure _subject;
		private void theMostConvertibleRomanFigure(RomanFigure subject)
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
			Assert.ThrowsAny<InvalidCastException>(_conversion);
		}
	}
}
