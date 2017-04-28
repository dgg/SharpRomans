using System;
using SharpRomans.Tests.Spec.Roman_Figure.Support;
using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec"), Category("RomanFigure"), Category("Conversions")]
	[Story(
		Title = "convert to DateTime",
		AsA = "library user",
		IWant = "Convert() to a roman figure",
		SoThat = "I can convert a roman figure to date-time whenever possible"
	)]
	public class ConversionToDateTime : ConversionsBase
	{
		[Fact]
		public void ConvertToDateTime()
		{
			this.WithTags("RomanFigure", "Conversions")
				.Given(_ => _.TheRomanFigure_(RomanFigure.N))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToDateTime(f))))
				.Then(_ => _.cannotCast())
				.BDDfy("zero");

			this.WithTags("RomanFigure", "Conversions")
				.Given(_ => _.TheRomanFigure_(RomanFigure.C))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToDateTime(f))))
				.Then(_ => _.cannotCast())
				.BDDfy("less than max");

			this.WithTags("RomanFigure", "Conversions")
				.Given(_ => _.TheRomanFigure_(RomanFigure.M))
				.When(_ => _.ConvertedTo_(Conv.ert(f => Convert.ToDateTime(f))))
				.Then(_ => _.cannotCast())
				.BDDfy("max");
		}

		private void cannotCast()
		{
			var ex = Assert.ThrowsAny<InvalidCastException>(_conversion);
			Assert.Contains(typeof(RomanFigure).Name, ex.Message);
		}
	}
}