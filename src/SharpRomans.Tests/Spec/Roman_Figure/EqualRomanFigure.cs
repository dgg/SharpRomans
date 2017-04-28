using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec"), Category("RomanFigure"), Category("Equality")]
	[Story(
		Title = "equal to roman figure",
		AsA = "library user",
		IWant = "to use the equality operator against a roman figure",
		SoThat = "I can say that a figure is equal to another figure"
	)]
	public class EqualRomanFigure : EqualityBase
	{
		[Fact]
		public void EqualToRomanFigure()
		{
			this.WithTags("RomanFigure", "Equality")
				.Given(_ => _.TheRomanFigure(RomanFigure.V))
				.When(_ => _.equalTo(RomanFigure.Convert(5)))
				.Then(_ => _.Is(true))
				.BDDfy("a roman figure is compared against the same roman figure");

			this.WithTags("RomanFigure", "Equality")
				.Given(_ => _.TheRomanFigure(RomanFigure.V))
				.When(_ => _.equalTo(RomanFigure.X))
				.Then(_ => _.Is(false))
				.BDDfy("a roman figure is compared against not the same roman figure");

			this.WithTags("RomanFigure", "Equality")
				.Given(_ => _.TheRomanFigure(RomanFigure.V))
				.When(_ => _.equalTo(null))
				.Then(_ => _.Is(false))
				.BDDfy("a roman figure is compared against null");

			this.WithTags("RomanFigure", "Equality")

				.Given(_ => _.TheRomanFigure(null))
				.When(_ => _.equalTo(RomanFigure.X))
				.Then(_ => _.Is(false))
				.BDDfy("null is compared against a roman figure");

			this.WithTags("RomanFigure", "Equality")
				
				.Given(_ => _.TheRomanFigure(null))
				.When(_ => _.equalTo(null))
				.Then(_ => _.Is(true))
				.BDDfy("null is compared against null");
		}

		private void equalTo(RomanFigure anotherFigure)
		{
			_operation = _subject == anotherFigure;
		}
	}
}