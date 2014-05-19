using NUnit.Framework;
using StoryQ;

namespace SharpRomans.Tests.Spec.RomanFigure
{
	[TestFixture, Category("Spec"), Category("RomanFigure")]
	public class RolesTester
	{
		[Test]
		public void Substractiveness()
		{
			new Story("substractiveness")
				.InOrderTo("know whether a figure is substractive or not")
				.AsA("library user")
				.IWant("to be able to invoke a method on a roman figure")

				.WithScenario("substractive figure")
					.Given(aSubstractiveRomanFigure_, SharpRomans.RomanFigure.I)
					.When(substractivenessIsChecked)
					.Then(substractivenessIs_, true)

				.WithScenario("non-substractive figure")
					.Given(aNonSubstractiveRomanFigure_, SharpRomans.RomanFigure.V)
					.When(substractivenessIsChecked)
					.Then(substractivenessIs_, false)

				.ExecuteWithReport();
		}

		[Test]
		public void Repeteability()
		{
			new Story("repeteability")
				.InOrderTo("know whether a figure can be repeated or not")
				.AsA("library user")
				.IWant("to be able to invoke a method on a roman figure")

				.WithScenario("repeteable figure")
					.Given(aRepeteableRomanFigure_, SharpRomans.RomanFigure.I)
					.When(repeteabilityIsChecked)
					.Then(repeteabilityIs_, true)

				.WithScenario("non-repeteable figure")
					.Given(aNonRepeteableRomanFigure_, SharpRomans.RomanFigure.V)
					.When(repeteabilityIsChecked)
					.Then(repeteabilityIs_, false)

				.ExecuteWithReport();
		}

		SharpRomans.RomanFigure _subject;
		private void aSubstractiveRomanFigure_(SharpRomans.RomanFigure figure)
		{
			_subject = figure;
		}

		private void aRepeteableRomanFigure_(SharpRomans.RomanFigure figure)
		{
			_subject = figure;
		}

		private void aNonSubstractiveRomanFigure_(SharpRomans.RomanFigure figure)
		{
			_subject = figure;
		}

		private void aNonRepeteableRomanFigure_(SharpRomans.RomanFigure figure)
		{
			_subject = figure;
		}

		bool _substractiveness;
		private void substractivenessIsChecked()
		{
			_substractiveness = _subject.IsSubstractive;
		}

		bool _repeteability;
		private void repeteabilityIsChecked()
		{
			_repeteability = _subject.IsRepeteable;
		}

		private void substractivenessIs_(bool substractiveness)
		{
			Assert.That(_substractiveness, Is.EqualTo(substractiveness));
		}

		private void repeteabilityIs_(bool repeteability)
		{
			Assert.That(_repeteability, Is.EqualTo(repeteability));
		}
	}
}