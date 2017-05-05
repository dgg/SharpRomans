using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec", Subject = "RomanFigure", Feature = "Roles")]
	[Collection("bddfy")]
	[Story(
		Title = "roles",
		AsA = "library user",
		IWant = "to be able to invoke a property on a roman figure",
		SoThat = "I am able to know what the role of the figure is in a roman numeral"
	)]
	public class RolesTester
	{
		[Fact]
		public void Repeatibility()
		{
			this.WithTags("RomanFigure", "Roles", "Repeatibility")
				.Given(_ => _.aRepeteableRomanFigure(RomanFigure.I))
				.When(_ => _.repeteabilityIsChecked())
				.Then(_ => _.repeteabilityIs(true))
				.BDDfy("repeteable figure");

			this.WithTags("RomanFigure", "Roles", "Repeatibility")
				.Given(_ => _.aNonRepeteableRomanFigure(RomanFigure.V))
				.When(_ => _.repeteabilityIsChecked())
				.Then(_ => _.repeteabilityIs(false))
				.BDDfy("non-repeteable figure");
		}

		[Fact]
		public void Substractiveness()
		{
			this.WithTags("RomanFigure", "Roles", "Substractiveness")
				.Given(_ => _.aSubstractiveRomanFigure_(RomanFigure.I))
				.When(_ => _.substractivenessIsChecked())
				.Then(_ => _.substractivenessIs(true))
				.BDDfy("substractive figure");

			this.WithTags("RomanFigure", "Roles", "Substractiveness")
				.Given(_ => _.aNonSubstractiveRomanFigure(RomanFigure.V))
				.When(_ => _.substractivenessIsChecked())
				.Then(_ => _.substractivenessIs(false))
				.BDDfy("non-substractive figure");
		}

		private RomanFigure _subject;
		private void aRepeteableRomanFigure(RomanFigure figure)
		{
			_subject = figure;
		}
		
		private void aNonRepeteableRomanFigure(RomanFigure figure)
		{
			_subject = figure;
		}

		private void aNonSubstractiveRomanFigure(RomanFigure figure)
		{
			_subject = figure;
		}

		bool _repeteability;
		private void repeteabilityIsChecked()
		{
			_repeteability = _subject.IsRepeteable;
		}
		
		private void repeteabilityIs(bool repeteability)
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
		
		private void substractivenessIs(bool substractiveness)
		{
			Assert.Equal(substractiveness, _substractiveness);
		}
	}
}