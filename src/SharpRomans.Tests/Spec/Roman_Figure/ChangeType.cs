using System;
using System.Runtime.Remoting;
using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec"), Category("RomanFigure"), Category("Conversions")]
	[Story(
		Title = "convert a roman figure to a clr type whenever possible",
		AsA = "library user",
		IWant = "to be able to use ChangeType()",
		SoThat = "I can convert a roman figure to a boolean"
	)]
	public class ChangeType : ConversionsBase
	{
		[Fact]
		public void Test()
		{
			this.WithTags("RomanFigure", "Conversions")
				.Given(_ => _.TheRomanFigure_(RomanFigure.M))
				.When(_ => _.ConvertedTo_(typeof(long)))
				.Then(_ => _.Is_(1000L))
				.BDDfy("supported type");

			this.WithTags("RomanFigure", "Conversions")
				.Given(_ => _.TheRomanFigure_(RomanFigure.M))
				.When(_ => _.ConvertedTo_(typeof(byte)))
				.Then(_ => _.Overflows())
				.BDDfy("overflowing type");

			this.WithTags("RomanFigure", "Conversions")
				.Given(_ => _.TheRomanFigure_(RomanFigure.M))
				.When(_ => _.ConvertedTo_(typeof(TimeSpan)))
				.Then(_ => _.CannotCast())
				.BDDfy("unsupported type");

			this.WithTags("RomanFigure", "Conversions")
				.Given(_ => _.TheRomanFigure_(RomanFigure.M))
				.When(_ => _.ConvertedTo_(typeof(Exception)))
				.Then(_ => _.CannotCast())
				.BDDfy("unsupported type");

			this.WithTags("RomanFigure", "Conversions")
				.Given(_ => _.TheRomanFigure_(RomanFigure.M))
				.When(_ => _.ConvertedTo_(typeof(RomanFigure)))
				.Then(_ => _.Is_(RomanFigure.M))
				.BDDfy("itself");
		}

		private void ConvertedTo_(Type to)
		{
			_conversion = () => Convert.ChangeType(_subject, to);
		}

		private void CannotCast()
		{
			var ex = Assert.ThrowsAny<InvalidCastException>(_conversion);
			Assert.Contains(typeof(RomanFigure).Name, ex.Message);
		}
	}
}