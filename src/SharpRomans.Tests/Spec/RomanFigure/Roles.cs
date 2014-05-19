using NUnit.Framework;
using StoryQ;

namespace SharpRomans.Tests.Spec.RomanFigure
{
	[TestFixture, Category("Spec"), Category("RomanFigure")]
	public class RolesTester
	{
		[Test]
		public void Substractive()
		{
			new Story("substractive")
				.InOrderTo("know whether a figure is substractive or not")
				.AsA("library user")
				.IWant("to be able to invoke a method on a roman figure")

				.WithScenario("substractive figure")
					.Given(aSubstractiveRomanFigure_, SharpRomans.RomanFigure.I)
					.When(substractivenessIsChecked)
					.Then(substractivenessIs_, true)
					.And(isNotSingle)

				.WithScenario("non-substractive figure")
					.Given(aNonSubstractiveRomanFigure_, SharpRomans.RomanFigure.V)
					.When(substractivenessIsChecked)
					.Then(substractivenessIs_, false)
					.And(isSingle)

				.ExecuteWithReport();
		}

		SharpRomans.RomanFigure _subject;
		private void aSubstractiveRomanFigure_(SharpRomans.RomanFigure figure)
		{
			_subject = figure;
		}

		private void aNonSubstractiveRomanFigure_(SharpRomans.RomanFigure figure)
		{
			_subject = figure;
		}

		bool _substractiveness;
		private void substractivenessIsChecked()
		{
			_substractiveness = _subject.IsSubstractive;
		}

		private void substractivenessIs_(bool substractiveness)
		{
			Assert.That(_substractiveness, Is.EqualTo(substractiveness));
		}

		private void isSingle()
		{
			Assert.That(_subject.IsSingle, Is.True);
		}

		private void isNotSingle()
		{
			Assert.That(_subject.IsSingle, Is.False);
		}
	}
}