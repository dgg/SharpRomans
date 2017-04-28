using System;
using SharpRomans.Tests.Spec.Roman_Figure.Support;
using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec"), Category("RomanFigure"), Category("Conversions")]
	[Story(
		Title = "convert to ULong",
		AsA = "library user",
		IWant = "Convert() to a roman figure",
		SoThat = "I can convert a roman figure to an unsigned long"
	)]
	public class ConversionToULong : ConversionsBase
	{
		[Fact]
		public void ConvertToULong()
		{
			this.WithTags("RomanFigure", "Conversions")
				.Given(_ => _.TheRomanFigure_(RomanFigure.N))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToUInt64(f))))
				.Then(_ => _.Is_(0uL))
				.BDDfy("zero");

			this.WithTags("RomanFigure", "Conversions")
				.Given(_ => _.TheRomanFigure_(RomanFigure.C))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToUInt64(f))))
				.Then(_ => _.Is_(100uL))
				.BDDfy("less than max");

			this.WithTags("RomanFigure", "Conversions")
				.Given(_ => _.TheRomanFigure_(RomanFigure.M))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToUInt64(f))))
				.Then(_ => _.Is_(1000uL))
				.BDDfy("max");
		}
	}
}