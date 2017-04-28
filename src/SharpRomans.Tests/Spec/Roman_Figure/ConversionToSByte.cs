using System;
using SharpRomans.Tests.Spec.Roman_Figure.Support;
using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec"), Category("RomanFigure"), Category("Conversions")]
	[Story(
		Title = "convert to SByte",
		AsA = "library user",
		IWant = "Convert() to a roman figure",
		SoThat = "I can convert a roman figure to a signed byte when possible"
	)]
	public class ConversionToSByte : ConversionsBase
	{
		[Fact]
		public void ConvertToSByte()
		{
			this.WithTags("RomanFigure", "Conversions")
				.Given(_ => _.TheRomanFigure_(RomanFigure.N))
				.When(_=>_.ConvertedTo_(Conv.ert(f => Convert.ToSByte(f))))
				.Then(_ => _.Is_((sbyte) 0))
				.BDDfy("zero");

			this.WithTags("RomanFigure", "Conversions")
				.Given(_ => _.TheRomanFigure_(RomanFigure.C))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToSByte(f))))
				.Then(_ => _.Is_((sbyte) 100))
				.BDDfy("less than max");

			this.WithTags("RomanFigure", "Conversions")
				.Given(_ => _.TheRomanFigure_(RomanFigure.M))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToSByte(f))))
				.Then(_ => _.Overflows())
				.BDDfy("max");
		}
	}
}