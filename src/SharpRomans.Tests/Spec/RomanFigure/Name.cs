using NUnit.Framework;
using StoryQ;

namespace SharpRomans.Tests.Spec.RomanFigure
{
	[TestFixture, Category("Spec"), Category("RomanFigure")]
	public class NameTester
	{
		[Test]
		public void Name()
		{
			new Story("names").Tag("RomanFigure")
				.InOrderTo("get the latin names of individual figures")
				.AsA("library user")
				.IWant("to be able to invoke a property on a roman figure")

						.WithScenario("zero")
							.Given(theFigure_DoesHaveAName, SharpRomans.RomanFigure.N)
							.When(theNameIsObtained)
							.Then(theNameIsNotEmpty)

						.WithScenario("one")
							.Given(theFigure_DoesHaveAName, SharpRomans.RomanFigure.I)
							.When(theNameIsObtained)
							.Then(theNameIsNotEmpty)

						.WithScenario("five")
							.Given(theFigure_DoesHaveAName, SharpRomans.RomanFigure.V)
							.When(theNameIsObtained)
							.Then(theNameIsNotEmpty)

						.WithScenario("ten")
							.Given(theFigure_DoesHaveAName, SharpRomans.RomanFigure.X)
							.When(theNameIsObtained)
							.Then(theNameIsNotEmpty)

						.WithScenario("figures with names")
							.Given(theFigure_DoesHaveAName, SharpRomans.RomanFigure.L)
							.When(theNameIsObtained)
							.Then(theNameIsNotEmpty)

						.WithScenario("figures with names")
							.Given(theFigure_DoesHaveAName, SharpRomans.RomanFigure.C)
							.When(theNameIsObtained)
							.Then(theNameIsNotEmpty)

						.WithScenario("figures with names")
							.Given(theFigure_DoesHaveAName, SharpRomans.RomanFigure.D)
							.When(theNameIsObtained)
							.Then(theNameIsNotEmpty)

						.WithScenario("figures with names")
							.Given(theFigure_DoesHaveAName, SharpRomans.RomanFigure.M)
							.When(theNameIsObtained)
							.Then(theNameIsNotEmpty)
				.ExecuteWithReport();
		}

		SharpRomans.RomanFigure _subject;
		string _name;
		private void theNameIsObtained()
		{
			_name = _subject.Name;
		}

		private void theFigure_DoesHaveAName(SharpRomans.RomanFigure figureWithName)
		{
			_subject = figureWithName;
		}

		private void theNameIsNotEmpty()
		{
			Assert.That(_name, Is.Not.Empty);
		}
	}
}