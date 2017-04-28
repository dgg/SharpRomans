using System;
using SharpRomans.Tests.Spec.Roman_Figure.Support;
using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec"), Category("RomanFigure"), Category("Conversions")]
	[Story(
		Title = "convert to Boolean",
		AsA = "library user",
		IWant = "Convert() to a roman figure",
		SoThat = "I can convert a roman figure to a boolean"
	)]
	public class ConversionToBoolean : ConversionsBase
	{
		[Fact]
		public void ConvertToBoolean()
		{
			this.WithTags("RomanFigure", "Conversions")
				.Given(_ => _.TheRomanFigure_(RomanFigure.N))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToBoolean(f))))
				.Then(_ => _.Is_(false))
				.BDDfy("zero");

			this.WithTags("RomanFigure", "Conversions")
				.Given(_ => _.TheRomanFigure_(RomanFigure.I))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToBoolean(f))))
				.Then(_ => _.Is_(true))
				.BDDfy("one");

			this.WithTags("RomanFigure", "Conversions")
				.Given(_ => _.TheRomanFigure_(RomanFigure.D))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToBoolean(f))))
				.Then(_ => _.Is_(true))
				.BDDfy("more than one");

			this.WithTags("RomanFigure", "Conversions")
				.Given(_ => _.TheRomanFigure_(RomanFigure.M))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToBoolean(f))))
				.Then(_ => _.Is_(true))
				.BDDfy("max");
		}
	}
}
