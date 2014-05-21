using System;
using NUnit.Framework;
using StoryQ;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[TestFixture, Category("Spec"), Category("RomanFigure")]
	public class ConversionsTester
	{
		[Test]
		public void ConvertToBoolean()
		{
			new Story("convert to Boolean")
				.InOrderTo("convert a roman figure to boolean whenever possible")
				.AsA("library user")
				.IWant("Convert() to a roman figure")

			.WithScenario("zero")
				.Given(TheRomanFigure_, RomanFigure.N)
				.When(ConvertedToBoolean)
				.Then(Is_, false)

			.WithScenario("one")
				.Given(TheRomanFigure_, RomanFigure.I)
				.When(ConvertedToBoolean)
				.Then(Is_, true)

			.WithScenario("more than one")
				.Given(TheRomanFigure_, RomanFigure.D)
				.When(ConvertedToBoolean)
				.Then(Is_, true)

			.WithScenario("max")
				.Given(TheRomanFigure_, RomanFigure.M)
				.When(ConvertedToBoolean)
				.Then(Is_, true)

			.ExecuteWithReport();
		}

		RomanFigure _subject;
		private void TheRomanFigure_(RomanFigure subject)
		{
			_subject = subject;
		}

		Func<object> _conversion;
		private void ConvertedToBoolean()
		{
			_conversion = () => Convert.ToBoolean(_subject);
		}

		private void Is_(bool value)
		{
			Assert.That(_conversion(), Is.EqualTo(value));
		}
	}
}
