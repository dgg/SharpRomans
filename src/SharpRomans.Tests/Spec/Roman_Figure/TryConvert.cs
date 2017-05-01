using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec"), Category("RomanFigure"), Category("TryConvert")]
	[Collection("bddfy")]
	[Story(
		Title = "try convert a number",
		AsA = "library user",
		IWant = "to be able to try to convert a number",
		SoThat = "I can try to get a figure instance"
	)]
	public class TryConvertTester
	{
		[Fact]
		public void TryConvertNumber()
		{
			this.WithTags("RomanFigure", "TryConvert")
				.Given(_ => _.theNumber_(10))
				.When(_ => _.theNumberIsConverted())
				.Then(_ => _.theResultIs(true))
					.And(_ => _.theFigureIs(RomanFigure.X))
				.BDDfy("convert a defined figure");

			this.WithTags("RomanFigure", "TryConvert")
				.Given(_ => _.theNumber_(11))
				.When(_ => _.theNumberIsConverted())
				.Then(_ => _.theResultIs(false))
				.And(_ => _.theFigureIs(null))
				.BDDfy("convert an undefined figure");

			this.WithTags("RomanFigure", "TryConvert")
				.Given(_ => _.theNumber_(10))
				.When(_ => _.theNumberIsConverted())
				.And(_ => _.theNumber_IsConvertedAgain(10))
				.Then(_ => _.isTheSameFigure())
				.BDDfy("figures are unique");
		}

		ushort _number;
		private void theNumber_(int number)
		{
			_number = (ushort)number;
		}

		private bool _result;
		private RomanFigure _parsed;
		private void theNumberIsConverted()
		{
			_result = RomanFigure.TryConvert(_number, out _parsed);
		}

		private RomanFigure _anotherFigure;
		private void theNumber_IsConvertedAgain(int number)
		{
			_result = RomanFigure.TryConvert((ushort)number, out _anotherFigure);
		}

		private void theResultIs(bool obj)
		{
			Assert.Equal(obj, _result);
		}

		private void theFigureIs(RomanFigure figure)
		{
			Assert.Equal(figure, _parsed);
		}

		private void isTheSameFigure()
		{
			Assert.Same(_anotherFigure, _parsed);
		}
	}
}