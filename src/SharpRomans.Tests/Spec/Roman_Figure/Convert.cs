using System;
using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec"), Category("RomanFigure"), Category("Convert")]
	[Story(
		Title = "convert a number",
		AsA = "library user",
		IWant = "to be able to convert a number",
		SoThat = "I can get a figure instance"
	)]
	public class ConvertTester
	{
		[Fact]
		public void ConvertNumber()
		{
			this.WithTags("RomanFigure", "Equality")
				.Given(_ => _.theNumber(1))
				.When(_ => _.theNumberIsConverted())
				.Then(_ => _.theFigureIs(RomanFigure.I))
				.BDDfy("convert a defined figure");

			this.WithTags("RomanFigure", "Equality")
				.Given(_ => _.theNumber(3))
				.When(_ => _.theNumberIsConverted())
				.Then(_ => _.throwsArgumentException())
				.BDDfy("convert an undefined figure");

			this.WithTags("RomanFigure", "Equality")
				.Given(_ => _.theNumber(10))
				.When(_ => _.theNumber_IsConvertedAgain(10))
				.Then(_ => _.isTheSameFigure())
				.BDDfy("figures are unique");
		}

		ushort _number;
		private void theNumber(int number)
		{
			_number = (ushort)number;
		}

		Func<RomanFigure> _figure;
		
		private void theNumberIsConverted()
		{
			_figure = () => RomanFigure.Convert(_number);
		}

		private void theFigureIs(RomanFigure figure)
		{
			Assert.Equal(figure, _figure());
		}

		private void throwsArgumentException()
		{
			Action cast = () => _figure();
			Assert.ThrowsAny<ArgumentException>(cast);
		}

		private RomanFigure _anotherFigure;
		private void theNumber_IsConvertedAgain(int number)
		{
			_anotherFigure = RomanFigure.Convert((ushort)number);
		}

		private void isTheSameFigure()
		{
			Assert.Same(_anotherFigure, _figure());
		}
	}
}