using SharpRomans.Tests.Support;
using StoryQ;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec"), Category("RomanFigure"), Category("TryConvert")]
	public class TryConvertTester
	{
		[Fact]
		public void TryConvertNumber()
		{
			new Story("try convert a number").Tag("RomanFigure")
				.InOrderTo("try to get a figure instance")
				.AsA("library user")
				.IWant("to be able to try to convert a number")

				.WithScenario("convert a defined figure")
					.Given(aNumber_, 10)
					.When(theNumberIsConverted)
					.Then(theResultIs_, true)
					.And(theFigureIs_, RomanFigure.X)

				.WithScenario("convert an undefined figure")
					.Given(aNumber_, 11)
					.When(theNumberIsConverted)
					.Then(theResultIs_, false)
					.And(theFigureIs_, (RomanFigure)null)

				.WithScenario("figures are unique")
					.Given(aNumber_, 10)
					.When(theNumberIsConverted)
					.And(theNumber_IsConvertedAgain, 10)
					.Then(isTheSameFigure)

				.ExecuteWithReport();
		}

		ushort _number;
		private void aNumber_(int number)
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

		private void theResultIs_(bool obj)
		{
			Assert.Equal(obj, _result);
		}

		private void theFigureIs_(RomanFigure figure)
		{
			Assert.Equal(figure, _parsed);
		}

		private void isTheSameFigure()
		{
			Assert.Same(_anotherFigure, _parsed);
		}
	}
}