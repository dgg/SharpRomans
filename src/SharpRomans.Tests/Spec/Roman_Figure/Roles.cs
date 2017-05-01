using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec"), Category("RomanFigure"), Category("Roles")]
	[Story(
		Title = "roles",
		AsA = "library user",
		IWant = "to be able to invoke a property on a roman figure",
		SoThat = "I am able to know what the role of the figure is in a roman numeral"
	)]
	public class Roles
	{
		[Fact]
		public void Repeatibility()
		{
			this.WithTags("RomanFigure", "Roles", "Repeatibility")
				.Given(_ => _.aRepeteableRomanFigure_(RomanFigure.I))
				.When(_ => _.repeteabilityIsChecked())
				.Then(_ => _.repeteabilityIs_(true))
				.BDDfy("repeteable figure");

			this.WithTags("RomanFigure", "Roles", "Repeatibility")
				.Given(_ => _.aNonRepeteableRomanFigure_(RomanFigure.V))
				.When(_ => _.repeteabilityIsChecked())
				.Then(_ => _.repeteabilityIs_(false))
				.BDDfy("non-repeteable figure");
		}

		[Fact]
		public void Substractiveness()
		{
			this.WithTags("RomanFigure", "Roles", "Substractiveness")
				.Given(_ => _.aSubstractiveRomanFigure_(RomanFigure.I))
				.When(_ => _.substractivenessIsChecked())
				.Then(_ => _.substractivenessIs_(true))
				.BDDfy("substractive figure");

			this.WithTags("RomanFigure", "Roles", "Substractiveness")
				.Given(_ => _.aNonSubstractiveRomanFigure_(RomanFigure.V))
				.When(_ => _.substractivenessIsChecked())
				.Then(_ => _.substractivenessIs_(false))
				.BDDfy("non-substractive figure");
		}

		private RomanFigure _subject;
		private void aRepeteableRomanFigure_(RomanFigure figure)
		{
			_subject = figure;
		}
		
		private void aNonRepeteableRomanFigure_(RomanFigure figure)
		{
			_subject = figure;
		}

		private void aNonSubstractiveRomanFigure_(RomanFigure figure)
		{
			_subject = figure;
		}

		bool _repeteability;
		private void repeteabilityIsChecked()
		{
			_repeteability = _subject.IsRepeteable;
		}
		
		private void repeteabilityIs_(bool repeteability)
		{
			Assert.Equal(repeteability, _repeteability);
		}

		private void aSubstractiveRomanFigure_(RomanFigure figure)
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
			Assert.Equal(substractiveness, _substractiveness);
		}
	}
}