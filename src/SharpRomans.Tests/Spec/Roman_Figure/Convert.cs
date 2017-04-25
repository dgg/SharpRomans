using System;
using SharpRomans.Tests.Support;
using StoryQ;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec"), Category("RomanFigure"), Category("Convert")]
	public class ConvertTester
	{
		[Fact]
		public void ConvertNumber()
		{
			new Story("convert a number")
				.InOrderTo("get a figure instance")
				.AsA("library user")
				.IWant("to be able to convert a number")

				.WithScenario("convert a defined figure")
					.Given(aNumber_, 1)
					.When(theNumberIsConverted)
					.Then(theFigureIs_, RomanFigure.I)

				.WithScenario("convert an undefined figure")
					.Given(aNumber_, 3)
					.When(theNumberIsConverted)
					.Then(throwsArgumentException)

				.WithScenario("figures are unique")
					.Given(aNumber_, 10)
					.When(theNumber_IsConvertedAgain, 10)
					.Then(isTheSameFigure)

				.ExecuteWithReport();
		}

		ushort _number;
		private void aNumber_(int number)
		{
			_number = (ushort)number;
		}

		Func<RomanFigure> _figure;
		
		private void theNumberIsConverted()
		{
			_figure = () => RomanFigure.Convert(_number);
		}

		private void theFigureIs_(RomanFigure figure)
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