using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec"), Category("RomanFigure"), Category("Roles")]
	[Story(
		Title = "repeteability",
		AsA = "library user",
		IWant = "to be able to invoke a property on a roman figure",
		SoThat = "I am able to know whether a figure can be repeated or not"
	)]
	public class Repeteability
	{
		[Fact]
		public void Role()
		{
			this.WithTags("RomanFigure", "Roles")
				.Given(_ => _.aRepeteableRomanFigure_(RomanFigure.I))
				.When(_ => _.repeteabilityIsChecked())
				.Then(_ => _.repeteabilityIs_(true))
				.BDDfy("repeteable figure");

			this.WithTags("RomanFigure", "Roles")
				.Given(_ => _.aNonRepeteableRomanFigure_(RomanFigure.V))
				.When(_ => _.repeteabilityIsChecked())
				.Then(_ => _.repeteabilityIs_(false))
				.BDDfy("non-repeteable figure");
		}

		RomanFigure _subject;
		private void aRepeteableRomanFigure_(RomanFigure figure)
		{
			_subject = figure;
		}
		
		private void aNonRepeteableRomanFigure_(RomanFigure figure)
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
	}
}