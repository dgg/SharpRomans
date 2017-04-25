using SharpRomans.Tests.Support;
using StoryQ;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec"), Category("RomanFigure"), Category("Roles")]
	public class RolesTester
	{
		[Fact]
		public void Substractiveness()
		{
			new Story("substractiveness")
				.InOrderTo("know whether a figure is substractive or not")
				.AsA("library user")
				.IWant("to be able to invoke a method on a roman figure")

				.WithScenario("substractive figure")
					.Given(aSubstractiveRomanFigure_, RomanFigure.I)
					.When(substractivenessIsChecked)
					.Then(substractivenessIs_, true)

				.WithScenario("non-substractive figure")
					.Given(aNonSubstractiveRomanFigure_, RomanFigure.V)
					.When(substractivenessIsChecked)
					.Then(substractivenessIs_, false)

				.ExecuteWithReport();
		}

		[Fact]
		public void Repeteability()
		{
			new Story("repeteability")
				.InOrderTo("know whether a figure can be repeated or not")
				.AsA("library user")
				.IWant("to be able to invoke a method on a roman figure")

				.WithScenario("repeteable figure")
					.Given(aRepeteableRomanFigure_, RomanFigure.I)
					.When(repeteabilityIsChecked)
					.Then(repeteabilityIs_, true)

				.WithScenario("non-repeteable figure")
					.Given(aNonRepeteableRomanFigure_, RomanFigure.V)
					.When(repeteabilityIsChecked)
					.Then(repeteabilityIs_, false)

				.ExecuteWithReport();
		}

		RomanFigure _subject;
		private void aSubstractiveRomanFigure_(RomanFigure figure)
		{
			_subject = figure;
		}

		private void aRepeteableRomanFigure_(RomanFigure figure)
		{
			_subject = figure;
		}

		private void aNonSubstractiveRomanFigure_(RomanFigure figure)
		{
			_subject = figure;
		}

		private void aNonRepeteableRomanFigure_(RomanFigure figure)
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
			Assert.Equal(substractiveness, _substractiveness);
		}

		private void repeteabilityIs_(bool repeteability)
		{
			Assert.Equal(repeteability, _repeteability);
		}
	}
}