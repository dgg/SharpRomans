using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec"), Category("RomanFigure"), Category("Equality")]
	[Collection("bddfy")]
	[Story(
		Title = "equality",
		AsA = "library user",
		IWant = "to use methods and operators on roman figures",
		SoThat = "I can say that two roman figures are equal"
	)]
	public class Equality
	{
		[Fact]
		public void EqualsObject()
		{

			this.WithTags("RomanFigure", "Equality", "non-generic")
				.Given(_ => _.TheRomanFigure(RomanFigure.V))
				.When(_=>_.equals('V'))
				.Then(_ => _.Is(false))
				.BDDfy("a roman figure is compared against a boxed char with the same value");

			this.WithTags("RomanFigure", "Equality", "non-generic")
				.Given(_ => _.TheRomanFigure(RomanFigure.V))
				.When(_ => _.equals('X'))
				.Then(_ => _.Is(false))
				.BDDfy("a roman figure is compared against a boxed char with a different value");

			this.WithTags("RomanFigure", "Equality", "non-generic")
				.Given(_ => _.TheRomanFigure(RomanFigure.V))
				.When(_ => _.equals((ushort) 5))
				.Then(_ => _.Is(false))
				.BDDfy("a roman figure is compared against a boxed number with the same value");

			this.WithTags("RomanFigure", "Equality", "non-generic")
				.Given(_ => _.TheRomanFigure(RomanFigure.V))
				.When(_ => _.equals((ushort) 10))
				.Then(_ => _.Is(false))
				.BDDfy("a roman figure is compared against a boxed number with a different value");

			this.WithTags("RomanFigure", "Equality", "non-generic")
				.Given(_ => _.TheRomanFigure(RomanFigure.V))
				.When(_ => _.equals((object) RomanFigure.V))
				.Then(_ => _.Is(true))
				.BDDfy("a roman figure is compared against the same objectified figure");

			this.WithTags("RomanFigure", "Equality", "non-generic")
				.Given(_ => _.TheRomanFigure(RomanFigure.V))
				.When(_ => _.equals((object) RomanFigure.X))
				.Then(_ => _.Is(false))
				.BDDfy("a roman figure is compared against another objectified figure");

			this.WithTags("RomanFigure", "Equality", "non-generic")
				.Given(_ => _.TheRomanFigure(RomanFigure.V))
				.When(_ => _.equals((object) null))
				.Then(_ => _.Is(false))
				.BDDfy("a roman figure is compared against null");

			this.WithTags("RomanFigure", "Equality", "non-generic")
				.Given(_ => _.TheRomanFigure(RomanFigure.V))
				.When(_ => _.equals('v'))
				.Then(_ => _.Is(false))
				.BDDfy("a roman figure is compared against a boxed lowercase char with the same value");

			this.WithTags("RomanFigure", "Equality", "non-generic")
				.Given(_ => _.TheRomanFigure(RomanFigure.V))
				.When(_ => _.equals(5))
				.Then(_ => _.Is(false))
				.BDDfy("a roman figure is compared against a boxed int with the same value");
		}

		[Fact]
		public void EqualsRomanFigure()
		{
			this.WithTags("RomanFigure", "Equality", "generic")
				.Given(_ => _.TheRomanFigure(RomanFigure.V))
				.When(_ => _.equals(RomanFigure.V))
				.Then(_ => _.Is(true))
				.BDDfy("a roman figure is compared against the same roman figure");

			this.WithTags("RomanFigure", "Equality", "generic")
				.Given(_ => _.TheRomanFigure(RomanFigure.V))
				.When(_ => _.equals(RomanFigure.X))
				.Then(_ => _.Is(false))
				.BDDfy("a roman figure is compared against not the same roman figure");

			this.WithTags("RomanFigure", "Equality", "generic")
				.Given(_ => _.TheRomanFigure(RomanFigure.V))
				.When(_ => _.equals(null))
				.Then(_ => _.Is(false))
				.BDDfy("a roman figure is compared against null");
		}

		[Fact]
		public void EqualToRomanFigure()
		{
			this.WithTags("RomanFigure", "Equality", "equality operator")
				.Given(_ => _.TheRomanFigure(RomanFigure.V))
				.When(_ => _.equalTo(RomanFigure.Convert(5)))
				.Then(_ => _.Is(true))
				.BDDfy("a roman figure is compared against the same roman figure");

			this.WithTags("RomanFigure", "Equality", "equality operator")
				.Given(_ => _.TheRomanFigure(RomanFigure.V))
				.When(_ => _.equalTo(RomanFigure.X))
				.Then(_ => _.Is(false))
				.BDDfy("a roman figure is compared against not the same roman figure");

			this.WithTags("RomanFigure", "Equality", "equality operator")
				.Given(_ => _.TheRomanFigure(RomanFigure.V))
				.When(_ => _.equalTo(null))
				.Then(_ => _.Is(false))
				.BDDfy("a roman figure is compared against null");

			this.WithTags("RomanFigure", "Equality", "equality operator")
				.Given(_ => _.TheRomanFigure(null))
				.When(_ => _.equalTo(RomanFigure.X))
				.Then(_ => _.Is(false))
				.BDDfy("null is compared against a roman figure");

			this.WithTags("RomanFigure", "Equality", "equality operator")
				.Given(_ => _.TheRomanFigure(null))
				.When(_ => _.equalTo(null))
				.Then(_ => _.Is(true))
				.BDDfy("null is compared against null");
		}

		[Fact]
		public void NotEqualToRomanFigure()
		{

			this.WithTags("RomanFigure", "Equality", "inequality operator")
				.Given(_ => _.TheRomanFigure(RomanFigure.V))
				.When(_ => _.notEqualTo(RomanFigure.V))
				.Then(_ => _.Is(false))
				.BDDfy("a roman figure is compared against the same roman figure");

			this.WithTags("RomanFigure", "Equality", "inequality operator")
				.Given(_ => _.TheRomanFigure(RomanFigure.V))
				.When(_ => _.notEqualTo(RomanFigure.X))
				.Then(_ => _.Is(true))
				.BDDfy("a roman figure is compared against not the same roman figure");

			this.WithTags("RomanFigure", "Equality", "inequality operator")
				.Given(_ => _.TheRomanFigure(RomanFigure.V))
				.When(_ => _.notEqualTo(null))
				.Then(_ => _.Is(true))
				.BDDfy("a roman figure is compared against null");

			this.WithTags("RomanFigure", "Equality", "inequality operator")
				.Given(_ => _.TheRomanFigure(null))
				.When(_ => _.notEqualTo(RomanFigure.X))
				.Then(_ => _.Is(true))
				.BDDfy("null is compared against a roman figure");

			this.WithTags("RomanFigure", "Equality", "inequality operator")
				.Given(_ => _.TheRomanFigure(null))
				.When(_ => _.notEqualTo(null))
				.Then(_ => _.Is(false))
				.BDDfy("null is compared against null");
		}

		private RomanFigure _subject;
		private void TheRomanFigure(RomanFigure figure)
		{
			_subject = figure;
		}
		private bool _operation;
		private void Is(bool result)
		{
			Assert.Equal(result, _operation);
		}

		private void equals(object o)
		{
			_operation = _subject.Equals(o);
		}

		private void equals(RomanFigure anotherFigure)
		{
			_operation = _subject.Equals(anotherFigure);
		}

		private void equalTo(RomanFigure anotherFigure)
		{
			_operation = _subject == anotherFigure;
		}

		private void notEqualTo(RomanFigure anotherFigure)
		{
			_operation = _subject != anotherFigure;
		}
	}
}