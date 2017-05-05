using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Numeral
{
	[Category("Spec", Subject = "RomanNumeral", Feature = "Equality")]
	[Collection("bddfy")]
	[Story(
		Title = "roman numeral equality",
		AsA = "library user",
		IWant = "to use equality methods and operands",
		SoThat = "I can check the equality of two roman numerals"
	)]
	public class EqualityTester
	{
		[Fact]
		public void NonGenericEquals()
		{
			this.WithTags("RomanNumeral", "Equality", "Non-generic")
				.Given(_ => _.theRomanNumeral(new RomanNumeral(5)))
				.When(_ => _.comparedTo((short)5))
				.Then(_ => _.@is(false))
				.BDDfy("a roman numeral is compared against a boxed short with the same value");

			this.WithTags("RomanNumeral", "Equality", "Non-generic")
				.Given(_ => _.theRomanNumeral(new RomanNumeral(5)))
				.When(_ => _.comparedTo((short)10))
				.Then(_ => _.@is(false))
				.BDDfy("a roman numeral is compared against a boxed short with a different value");

			this.WithTags("RomanNumeral", "Equality", "Non-generic")
				.Given(_ => _.theRomanNumeral(new RomanNumeral(5)))
				.When(_ => _.comparedTo((object) new RomanNumeral(5)))
				.Then(_ => _.@is(true))
				.BDDfy("a roman numeral is compared against the same objectified numeral");

			this.WithTags("RomanNumeral", "Equality", "Non-generic")
				.Given(_ => _.theRomanNumeral(new RomanNumeral(5)))
				.When(_ => _.comparedTo((object) new RomanNumeral(10)))
				.Then(_ => _.@is(false))
				.BDDfy("a roman numeral is compared against another objectified numeral");

			this.WithTags("RomanNumeral", "Equality", "Non-generic")
				.Given(_ => _.theRomanNumeral(new RomanNumeral(5)))
				.When(_ => _.comparedTo(RomanFigure.V))
				.Then(_ => _.@is(false))
				.BDDfy("a roman numeral is compared against the same objectified figure");

			this.WithTags("RomanNumeral", "Equality", "Non-generic")
				.Given(_ => _.theRomanNumeral(new RomanNumeral(5)))
				.When(_ => _.comparedTo(RomanFigure.C))
				.Then(_ => _.@is(false))
				.BDDfy("a roman numeral is compared against another objectified figure");

			this.WithTags("RomanNumeral", "Equality", "Non-generic")
				.Given(_ => _.theRomanNumeral(new RomanNumeral(5)))
				.When(_ => _.comparedTo((object) null))
				.Then(_ => _.@is(false))
				.BDDfy("a roman numeral is compared against null");

			this.WithTags("RomanNumeral", "Equality", "Non-generic")
				.Given(_ => _.theRomanNumeral(new RomanNumeral(5)))
				.When(_ => _.comparedTo(5))
				.Then(_ => _.@is(false))
				.BDDfy("a roman numeral is compared against a boxed int with the same value");
		}

		[Fact]
		public void EquatableToRomanNumeral()
		{
			this.WithTags("RomanNumeral", "Equality", "IEquatable<>")
				.Given(_ => _.theRomanNumeral(new RomanNumeral(5)))
				.When(_ => _.comparedTo(new RomanNumeral(5)))
				.Then(_ => _.@is(true))
				.BDDfy("a roman numeral is compared against the same roman numeral");

			this.WithTags("RomanNumeral", "Equality", "IEquatable<>")
				.Given(_ => _.theRomanNumeral(new RomanNumeral(5)))
				.When(_ => _.comparedTo(new RomanNumeral(15)))
				.Then(_ => _.@is(false))
				.BDDfy("a roman numeral is compared against not the same roman numeral");

			this.WithTags("RomanNumeral", "Equality", "IEquatable<>")
				.Given(_ => _.theRomanNumeral(new RomanNumeral(5)))
				.When(_ => _.comparedTo(null))
				.Then(_ => _.@is(false))
				.BDDfy("a roman numeral is compared against null");
		}

		[Fact]
		public void EqualToRomanNumeral()
		{
			this.WithTags("RomanNumeral", "Equality", "equality operator")
				.Given(_ => _.theRomanNumeral(new RomanNumeral(5)))
				.When(_ => _.equalTo(new RomanNumeral(5)))
				.Then(_ => _.@is(true))
				.BDDfy("a roman numeral is compared against the same roman numeral");

			this.WithTags("RomanNumeral", "Equality", "equality operator")
				.Given(_ => _.theRomanNumeral(new RomanNumeral(5)))
				.When(_ => _.equalTo(new RomanNumeral(15)))
				.Then(_ => _.@is(false))
				.BDDfy("a roman numeral is compared against not the same roman numeral");

			this.WithTags("RomanNumeral", "Equality", "equality operator")
				.Given(_ => _.theRomanNumeral(RomanNumeral.Zero))
				.When(_ => _.equalTo(null))
				.Then(_ => _.@is(false))
				.BDDfy("a roman numeral is compared against null");

			this.WithTags("RomanNumeral", "Equality", "equality operator")
				.Given(_ => _.theRomanNumeral(null))
				.When(_ => _.equalTo(RomanNumeral.Zero))
				.Then(_ => _.@is(false))
				.BDDfy("null is compared against a roman numeral");

			this.WithTags("RomanNumeral", "Equality", "equality operator")
				.Given(_ => _.theRomanNumeral(null))
				.When(_ => _.equalTo(null))
				.Then(_ => _.@is(true))
				.BDDfy("null is compared against null");
		}

		[Fact]
		public void NotEqualToRomanNumeral()
		{
			this.WithTags("RomanNumeral", "Equality", "inequality operator")
				.Given(_ => _.theRomanNumeral(new RomanNumeral(5)))
				.When(_ => _.notEqualTo(new RomanNumeral(5)))
				.Then(_ => _.@is(false))
				.BDDfy("a roman numeral is compared against the same roman numeral");

			this.WithTags("RomanNumeral", "Equality", "inequality operator")
				.Given(_ => _.theRomanNumeral(new RomanNumeral(5)))
				.When(_ => _.notEqualTo(new RomanNumeral(15)))
				.Then(_ => _.@is(true))
				.BDDfy("a roman numeral is compared against not the same roman numeral");

			this.WithTags("RomanNumeral", "Equality", "inequality operator")
				.Given(_ => _.theRomanNumeral(new RomanNumeral(5)))
				.When(_ => _.notEqualTo(null))
				.Then(_ => _.@is(true))
				.BDDfy("a roman numeral is compared against null");

			this.WithTags("RomanNumeral", "Equality", "inequality operator")
				.Given(_ => _.theRomanNumeral(null))
				.When(_ => _.notEqualTo(new RomanNumeral(5)))
				.Then(_ => _.@is(true))
				.BDDfy("null is compared against a roman numeral");

			this.WithTags("RomanNumeral", "Equality", "inequality operator")
				.Given(_ => _.theRomanNumeral(null))
				.When(_ => _.notEqualTo(null))
				.Then(_ => _.@is(false))
				.BDDfy("null is compared against null");
		}

		private RomanNumeral _subject;
		private void theRomanNumeral(RomanNumeral numeral)
		{
			_subject = numeral;
		}

		private bool _operation;
		private void comparedTo(object o)
		{
			_operation = _subject.Equals(o);
		}

		private void comparedTo(RomanNumeral another)
		{
			_operation = _subject.Equals(another);
		}

		private void equalTo(RomanNumeral another)
		{
			_operation = _subject == another;
		}

		private void notEqualTo(RomanNumeral another)
		{
			_operation = _subject != another;
		}

		private void @is(bool result)
		{
			Assert.Equal(result, _operation);
		}
	}
}