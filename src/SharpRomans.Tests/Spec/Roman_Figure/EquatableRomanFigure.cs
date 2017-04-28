using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec"), Category("RomanFigure"), Category("Equality")]
	[Story(
		Title = "equatable to roman figure",
		AsA = "library user",
		IWant = "to use IEquatable<RomanFigure> methods against a roman figure",
		SoThat = "I can say that a figure is equal to another figure"
	)]
	public class EquatableRomanFigure : EqualityBase
	{
		[Fact]
		public void Test()
		{
			this.WithTags("RomanFigure", "Equality")
				.Given(_ => _.TheRomanFigure(RomanFigure.V))
				.When(_ => _.comparedTo(RomanFigure.V))
				.Then(_ => _.Is(true))
				.BDDfy("a roman figure is compared against the same roman figure");

			this.WithTags("RomanFigure", "Equality")
				.Given(_ => _.TheRomanFigure(RomanFigure.V))
				.When(_ => _.comparedTo(RomanFigure.X))
				.Then(_ => _.Is(false))
				.BDDfy("a roman figure is compared against not the same roman figure");

			this.WithTags("RomanFigure", "Equality")
				.Given(_ => _.TheRomanFigure(RomanFigure.V))
				.When(_ => _.comparedTo((RomanFigure)null))
				.Then(_ => _.Is(false))
				.BDDfy("a roman figure is compared against null");
		}

		private void comparedTo(RomanFigure anotherFigure)
		{
			_operation = _subject.Equals(anotherFigure);
		}
	}
}