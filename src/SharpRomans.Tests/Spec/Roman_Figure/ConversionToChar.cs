using System;
using SharpRomans.Tests.Spec.Roman_Figure.Support;
using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec"), Category("RomanFigure"), Category("Conversions")]
	[Story(
		Title = "convert to Char",
		AsA = "library user",
		IWant = "Convert() to a roman figure",
		SoThat = "I can convert a roman figure to char"
	)]
	public class ConversionToChar : ConversionsBase
	{
		[Fact]
		public void ConvertToChar()
		{
			this.WithTags("RomanFigure", "Conversions")
				.Given(_ => _.TheRomanFigure_(RomanFigure.N))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToChar(f))))
				.Then(_ => _.Is_('N'))
				.BDDfy("zero");

			this.WithTags("RomanFigure", "Conversions")
				.Given(_ => _.TheRomanFigure_(RomanFigure.D))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToChar(f))))
				.Then(_ => _.Is_('D'))
				.BDDfy("more than one");

			this.WithTags("RomanFigure", "Conversions")
				.Given(_ => _.TheRomanFigure_(RomanFigure.M))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToChar(f))))
				.Then(_ => _.Is_('M'))
				.BDDfy("max");
		}
	}
}