using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Numeral
{
	[Category("Spec"), Category("RomanNumeral"), Category("Equality")]
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
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(5)))
				.When(_ => _.ComparedTo_((short)5))
				.Then(_ => _.Is_(false))
				.BDDfy("a roman numeral is compared against a boxed short with the same value");

			this.WithTags("RomanNumeral", "Equality", "Non-generic")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(5)))
				.When(_ => _.ComparedTo_((short)10))
				.Then(_ => _.Is_(false))
				.BDDfy("a roman numeral is compared against a boxed short with a different value");

			this.WithTags("RomanNumeral", "Equality", "Non-generic")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(5)))
				.When(_ => _.ComparedTo_((object) new RomanNumeral(5)))
				.Then(_ => _.Is_(true))
				.BDDfy("a roman numeral is compared against the same objectified numeral");

			this.WithTags("RomanNumeral", "Equality", "Non-generic")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(5)))
				.When(_ => _.ComparedTo_((object) new RomanNumeral(10)))
				.Then(_ => _.Is_(false))
				.BDDfy("a roman numeral is compared against another objectified numeral");

			this.WithTags("RomanNumeral", "Equality", "Non-generic")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(5)))
				.When(_ => _.ComparedTo_(RomanFigure.V))
				.Then(_ => _.Is_(false))
				.BDDfy("a roman numeral is compared against the same objectified figure");

			this.WithTags("RomanNumeral", "Equality", "Non-generic")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(5)))
				.When(_ => _.ComparedTo_(RomanFigure.C))
				.Then(_ => _.Is_(false))
				.BDDfy("a roman numeral is compared against another objectified figure");

			this.WithTags("RomanNumeral", "Equality", "Non-generic")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(5)))
				.When(_ => _.ComparedTo_((object) null))
				.Then(_ => _.Is_(false))
				.BDDfy("a roman numeral is compared against null");

			this.WithTags("RomanNumeral", "Equality", "Non-generic")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(5)))
				.When(_ => _.ComparedTo_(5))
				.Then(_ => _.Is_(false))
				.BDDfy("a roman numeral is compared against a boxed int with the same value");
		}

		[Fact]
		public void EquatableToRomanNumeral()
		{
			this.WithTags("RomanNumeral", "Equality", "IEquatable<>")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(5)))
				.When(_ => _.ComparedTo_(new RomanNumeral(5)))
				.Then(_ => _.Is_(true))
				.BDDfy("a roman numeral is compared against the same roman numeral");

			this.WithTags("RomanNumeral", "Equality", "IEquatable<>")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(5)))
				.When(_ => _.ComparedTo_(new RomanNumeral(15)))
				.Then(_ => _.Is_(false))
				.BDDfy("a roman numeral is compared against not the same roman numeral");

			this.WithTags("RomanNumeral", "Equality", "IEquatable<>")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(5)))
				.When(_ => _.ComparedTo_(null))
				.Then(_ => _.Is_(false))
				.BDDfy("a roman numeral is compared against null");
		}

		[Fact]
		public void EqualToRomanNumeral()
		{
			this.WithTags("RomanNumeral", "Equality", "equality operator")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(5)))
				.When(_ => _.EqualTo_(new RomanNumeral(5)))
				.Then(_ => _.Is_(true))
				.BDDfy("a roman numeral is compared against the same roman numeral");

			this.WithTags("RomanNumeral", "Equality", "equality operator")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(5)))
				.When(_ => _.EqualTo_(new RomanNumeral(15)))
				.Then(_ => _.Is_(false))
				.BDDfy("a roman numeral is compared against not the same roman numeral");

			this.WithTags("RomanNumeral", "Equality", "equality operator")
				.Given(_ => _.TheRomanNumeral_(RomanNumeral.Zero))
				.When(_ => _.EqualTo_(null))
				.Then(_ => _.Is_(false))
				.BDDfy("a roman numeral is compared against null");

			this.WithTags("RomanNumeral", "Equality", "equality operator")
				.Given(_ => _.TheRomanNumeral_(null))
				.When(_ => _.EqualTo_(RomanNumeral.Zero))
				.Then(_ => _.Is_(false))
				.BDDfy("null is compared against a roman numeral");

			this.WithTags("RomanNumeral", "Equality", "equality operator")
				.Given(_ => _.TheRomanNumeral_(null))
				.When(_ => _.EqualTo_(null))
				.Then(_ => _.Is_(true))
				.BDDfy("null is compared against null");
		}

		[Fact]
		public void NotEqualToRomanNumeral()
		{
			this.WithTags("RomanNumeral", "Equality", "inequality operator")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(5)))
				.When(_ => _.NotEqualTo_(new RomanNumeral(5)))
				.Then(_ => _.Is_(false))
				.BDDfy("a roman numeral is compared against the same roman numeral");

			this.WithTags("RomanNumeral", "Equality", "inequality operator")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(5)))
				.When(_ => _.NotEqualTo_(new RomanNumeral(15)))
				.Then(_ => _.Is_(true))
				.BDDfy("a roman numeral is compared against not the same roman numeral");

			this.WithTags("RomanNumeral", "Equality", "inequality operator")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(5)))
				.When(_ => _.NotEqualTo_(null))
				.Then(_ => _.Is_(true))
				.BDDfy("a roman numeral is compared against null");

			this.WithTags("RomanNumeral", "Equality", "inequality operator")
				.Given(_ => _.TheRomanNumeral_(null))
				.When(_ => _.NotEqualTo_(new RomanNumeral(5)))
				.Then(_ => _.Is_(true))
				.BDDfy("null is compared against a roman numeral");

			this.WithTags("RomanNumeral", "Equality", "inequality operator")
				.Given(_ => _.TheRomanNumeral_(null))
				.When(_ => _.NotEqualTo_(null))
				.Then(_ => _.Is_(false))
				.BDDfy("null is compared against null");
		}

		private RomanNumeral _subject;
		private void TheRomanNumeral_(RomanNumeral numeral)
		{
			_subject = numeral;
		}

		private bool _operation;
		private void ComparedTo_(object o)
		{
			_operation = _subject.Equals(o);
		}

		private void ComparedTo_(RomanNumeral another)
		{
			_operation = _subject.Equals(another);
		}

		private void EqualTo_(RomanNumeral another)
		{
			_operation = _subject == another;
		}

		private void NotEqualTo_(RomanNumeral another)
		{
			_operation = _subject != another;
		}

		private void Is_(bool result)
		{
			Assert.Equal(result, _operation);
		}
	}
}