using NUnit.Framework;
using StoryQ;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[TestFixture, Category("Spec"), Category("RomanFigure"), Category("Value")]
	public class ValueTester
	{
		[Test]
		public void Value()
		{
			new Story("values").Tag("RomanFigure")
				.InOrderTo("get the integral values of individual figures")
				.AsA("library user")
				.IWant("to be able to invoke a method on a roman figure")

				.WithScenario("value of a figure")
					.Given(aRomanFigure_, RomanFigure.I)
					.When(theValueIsObtained)
					.Then(theValueIs_, 1u)

				.WithScenario("value of a figure")
					.Given(aRomanFigure_, RomanFigure.V)
					.When(theValueIsObtained)
					.Then(theValueIs_, 5u)

				.WithScenario("value of a figure")
					.Given(aRomanFigure_, RomanFigure.X)
					.When(theValueIsObtained)
					.Then(theValueIs_, 10u)

				.WithScenario("value of a figure")
					.Given(aRomanFigure_, RomanFigure.L)
					.When(theValueIsObtained)
					.Then(theValueIs_, 50u)

				.WithScenario("value of a figure")
					.Given(aRomanFigure_, RomanFigure.C)
					.When(theValueIsObtained)
					.Then(theValueIs_, 100u)

				.WithScenario("value of a figure")
					.Given(aRomanFigure_, RomanFigure.D)
					.When(theValueIsObtained)
					.Then(theValueIs_, 500u)

				.WithScenario("value of a figure")
					.Given(aRomanFigure_, RomanFigure.M)
					.When(theValueIsObtained)
					.Then(theValueIs_, 1000u)

				.ExecuteWithReport();
		}

		RomanFigure _subject;
		private void aRomanFigure_(RomanFigure figure)
		{
			_subject = figure;
		}

		ushort _value;
		private void theValueIsObtained()
		{
			_value = _subject.Value;
		}

		private void theValueIs_(uint value)
		{
			Assert.That(_value, Is.EqualTo(value));
		}
	}
}