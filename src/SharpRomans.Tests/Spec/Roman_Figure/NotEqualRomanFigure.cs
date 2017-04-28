using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec"), Category("RomanFigure"), Category("Equality")]
	[Story(
		Title = "not equal to roman figure",
		AsA = "library user",
		IWant = "to use the intequality operator against a roman figure",
		SoThat = "I can say that a figure is not equal to another figure"
	)]
	public class NotEqualRomanFigure : EqualityBase
	{
		[Fact]
		public void NotEqualToRomanFigure()
		{

			this.WithTags("RomanFigure", "Equality")
				.Given(_ => _.TheRomanFigure(RomanFigure.V))
				.When(_ => _.notEqualTo(RomanFigure.V))
				.Then(_ => _.Is(false))
				.BDDfy("a roman figure is compared against the same roman figure");

			this.WithTags("RomanFigure", "Equality")
				.Given(_ => _.TheRomanFigure(RomanFigure.V))
				.When(_ => _.notEqualTo(RomanFigure.X))
				.Then(_ => _.Is(true))
				.BDDfy("a roman figure is compared against not the same roman figure");

			this.WithTags("RomanFigure", "Equality")
				.Given(_ => _.TheRomanFigure(RomanFigure.V))
				.When(_ => _.notEqualTo((RomanFigure) null))
				.Then(_ => _.Is(true))
				.BDDfy("a roman figure is compared against null");

			this.WithTags("RomanFigure", "Equality")
				.Given(_ => _.TheRomanFigure((RomanFigure) null))
				.When(_ => _.notEqualTo(RomanFigure.X))
				.Then(_ => _.Is(true))
				.BDDfy("null is compared against a roman figure");

			this.WithTags("RomanFigure", "Equality")
				.Given(_ => _.TheRomanFigure((RomanFigure)null))
				.When(_ => _.notEqualTo((RomanFigure)null))
				.Then(_ => _.Is(false))
				.BDDfy("null is compared against null");
		}

		private void notEqualTo(RomanFigure anotherFigure)
		{
			_operation = _subject != anotherFigure;
		}
	}
}