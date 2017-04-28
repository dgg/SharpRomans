using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec"), Category("RomanFigure"), Category("Equality")]
	[Story(
		Title = "equatable to object",
		AsA = "library user",
		IWant = "to use .Equals() against an object",
		SoThat = "I can say that an object is equal to a roman figure"
	)]
	public class EquatableObject : EqualityBase
	{
		[Fact]
		public void Test()
		{

			this.WithTags("RomanFigure", "Equality")
				.Given(_=>_.TheRomanFigure(RomanFigure.V))
				.When(_=>_.comparedTo((object)'V'))
				.Then(_ => _.Is(false))
				.BDDfy("a roman figure is compared against a boxed char with the same value");

			this.WithTags("RomanFigure", "Equality")
				.Given(_ => _.TheRomanFigure(RomanFigure.V))
				.When(_ => _.comparedTo((object) 'X'))
				.Then(_ => _.Is(false))
				.BDDfy("a roman figure is compared against a boxed char with a different value");

			this.WithTags("RomanFigure", "Equality")
				.Given(_ => _.TheRomanFigure(RomanFigure.V))
				.When(_ => _.comparedTo((object) ((ushort) 5)))
				.Then(_ => _.Is(false))
				.BDDfy("a roman figure is compared against a boxed number with the same value");

			this.WithTags("RomanFigure", "Equality")
				.Given(_ => _.TheRomanFigure(RomanFigure.V))
				.When(_ => _.comparedTo((object) ((ushort) 10)))
				.Then(_ => _.Is(false))
				.BDDfy("a roman figure is compared against a boxed number with a different value");

			this.WithTags("RomanFigure", "Equality")
				.Given(_ => _.TheRomanFigure(RomanFigure.V))
				.When(_ => _.comparedTo((object) RomanFigure.V))
				.Then(_ => _.Is(true))
				.BDDfy("a roman figure is compared against the same objectified figure");

			this.WithTags("RomanFigure", "Equality")
				.Given(_ => _.TheRomanFigure(RomanFigure.V))
				.When(_ => _.comparedTo((object) RomanFigure.X))
				.Then(_ => _.Is(false))
				.BDDfy("a roman figure is compared against another objectified figure");

			this.WithTags("RomanFigure", "Equality")
				.Given(_ => _.TheRomanFigure(RomanFigure.V))
				.When(_ => _.comparedTo((object) null))
				.Then(_ => _.Is(false))
				.BDDfy("a roman figure is compared against null");

			this.WithTags("RomanFigure", "Equality")
				.Given(_ => _.TheRomanFigure(RomanFigure.V))
				.When(_ => _.comparedTo((object) 'v'))
				.Then(_ => _.Is(false))
				.BDDfy("a roman figure is compared against a boxed lowercase char with the same value");

			this.WithTags("RomanFigure", "Equality")
				.Given(_ => _.TheRomanFigure(RomanFigure.V))
				.When(_ => _.comparedTo((object)5))
				.Then(_ => _.Is(false))
				.BDDfy("a roman figure is compared against a boxed int with the same value");
		}
		
		private void comparedTo(object o)
		{
			_operation = _subject.Equals(o);
		}
	}
}