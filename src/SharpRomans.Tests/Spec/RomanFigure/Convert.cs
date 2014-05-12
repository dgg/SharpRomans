using System;
using NUnit.Framework;
using StoryQ;

namespace SharpRomans.Tests.Spec.RomanFigure
{
	[TestFixture, Category("Spec"), Category("RomanFigure")]
	public class ConvertTester
	{
		[Test]
		public void ConvertNumber()
		{
			new Story("convert a number")
				.InOrderTo("get a figure instance")
				.AsA("library user")
				.IWant("to be able to convert a number")

				.WithScenario("convert a defined figure")
					.Given(aNumber_, 1)
					.When(theNumberIsConverted)
					.Then(theFigure_Is, SharpRomans.RomanFigure.I)

				.WithScenario("convert an undefined figure")
					.Given(aNumber_, 3)
					.When(theNumberIsConverted)
					.Then(throwsArgumentException)

				.WithScenario("figures are unique")
					.Given(aNumber_, 10)
					.When(theNumberIsConvertedAgain_, 10)
					.Then(isTheSameFigure)

				.ExecuteWithReport();
		}

		ushort _number;
		private void aNumber_(int number)
		{
			_number = (ushort)number;
		}

		Func<SharpRomans.RomanFigure> _figure;
		
		private void theNumberIsConverted()
		{
			_figure = () => SharpRomans.RomanFigure.Convert(_number);
		}

		private void theFigure_Is(SharpRomans.RomanFigure figure)
		{
			Assert.That(_figure(), Is.EqualTo(figure));
		}

		private void throwsArgumentException()
		{
			TestDelegate cast = () => _figure();
			Assert.That(cast, Throws.ArgumentException);
		}

		private SharpRomans.RomanFigure _anotherFigure;
		private void theNumberIsConvertedAgain_(int number)
		{
			_anotherFigure = SharpRomans.RomanFigure.Convert((ushort)number);
		}

		private void isTheSameFigure()
		{
			Assert.That(_figure(), Is.SameAs(_anotherFigure));
		}
	}
}