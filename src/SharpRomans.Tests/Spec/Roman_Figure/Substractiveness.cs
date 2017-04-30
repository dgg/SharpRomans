using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec"), Category("RomanFigure"), Category("Roles")]
	[Story(
		Title = "substractiveness",
		AsA = "library user",
		IWant = "to be able to invoke a property on a roman figure",
		SoThat = "I am able to know whether a figure is substractive or not"
	)]
	public class Substractiveness
	{
		[Fact]
		public void Role()
		{
			this.WithTags("RomanFigure", "Roles")
				.Given(_ => _.aSubstractiveRomanFigure_(RomanFigure.I))
				.When(_ => _.substractivenessIsChecked())
				.Then(_ => _.substractivenessIs_(true))
				.BDDfy("substractive figure");

			this.WithTags("RomanFigure", "Roles")
				.Given(_ => _.aNonSubstractiveRomanFigure_(RomanFigure.V))
				.When(_ => _.substractivenessIsChecked())
				.Then(_ => _.substractivenessIs_(false))
				.BDDfy("non-substractive figure");
		}

		RomanFigure _subject;
		private void aSubstractiveRomanFigure_(RomanFigure figure)
		{
			_subject = figure;
		}

		private void aNonSubstractiveRomanFigure_(RomanFigure figure)
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