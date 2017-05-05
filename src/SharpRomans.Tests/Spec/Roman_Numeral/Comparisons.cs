using SharpRomans.Tests.Spec.Roman_Numeral.Support;
using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Numeral
{
	[Category("Spec", Subject = "RomanNumeral", Feature = "Comparisons")]
	[Collection("bddfy")]
	[Story(
		Title = "roman numeral comparison",
		AsA = "library user",
		IWant = "to use comparison methods and operators",
		SoThat = "I can tell the larger of two roman numerals"
	)]
	public class ComparisonsTester
	{
		[Fact]
		public void CompareToRomanNumeral()
		{
			this.WithTags("RomanNumeral", "Comparisons", "Compare")
				.Given(_ => _.theRomanNumeral(new RomanNumeral(5)))
				.When(_ => _.comparedTo(new RomanNumeral(1)))
				.Then(_ => _.isGreaterThanZero())
				.BDDfy("one numeral is greater than another");

			this.WithTags("RomanNumeral", "Comparisons", "Compare")
				.Given(_ => _.theRomanNumeral(new RomanNumeral(1)))
				.When(_ => _.comparedTo(new RomanNumeral(10)))
				.Then(_ => _.isLessThanZero())
				.BDDfy("one numeral is less than another");

			this.WithTags("RomanNumeral", "Comparisons", "Compare")
				.Given(_ => _.theRomanNumeral(new RomanNumeral(10)))
				.When(_ => _.comparedTo(new RomanNumeral(10)))
				.Then(_ => _.isZero())
				.BDDfy("one numeral is equal to another");

			this.WithTags("RomanNumeral", "Comparisons", "Compare")
				.Given(_ => _.theRomanNumeral(new RomanNumeral(0)))
				.When(_ => _.comparedTo(null))
				.Then(_ => _.isGreaterThanZero())
				.BDDfy("one figure is compared to NULL");
		}

		[Fact]
		public void GreaterThanRomanNumeral()
		{
			this.WithTags("RomanNumeral", "Comparisons", "greather than")
				.Given(_ => _.theRomanNumeral(new RomanNumeral(5)))
				.When(_ => _._IsEvaluatedAgainst_(Op.Gt, new RomanNumeral(1)), "'{0}' is evaluated against {1}")
				.Then(_ => _.@is(true))
				.BDDfy("one numeral is greater than another");

			this.WithTags("RomanNumeral", "Comparisons", "greather than")
				.Given(_ => _.theRomanNumeral(new RomanNumeral(0)))
				.When(_ => _._IsEvaluatedAgainst_(Op.Gt, new RomanNumeral(1)), "'{0}' is evaluated against {1}")
				.Then(_ => _.@is(false))
				.BDDfy("one numeral is less than another");

			this.WithTags("RomanNumeral", "Comparisons", "greather than")
				.Given(_ => _.theRomanNumeral(new RomanNumeral(10)))
				.When(_ => _._IsEvaluatedAgainst_(Op.Gt, new RomanNumeral(10)), "'{0}' is evaluated against {1}")
				.Then(_ => _.@is(false))
				.BDDfy("one numeral is equal to another");

			this.WithTags("RomanNumeral", "Comparisons", "greather than")
				.Given(_ => _.theRomanNumeral(RomanNumeral.Zero))
				.When(_ => _._IsEvaluatedAgainst_(Op.Gt, null), "'{0}' is evaluated against {1}")
				.Then(_ => _.@is(true))
				.BDDfy("one numeral is compared to NULL");

			this.WithTags("RomanNumeral", "Comparisons", "greather than")
				.Given(_ => _.theRomanNumeral(null))
				.When(_ => _._IsEvaluatedAgainst_(Op.Gt, RomanNumeral.Zero), "'{0}' is evaluated against {1}")
				.Then(_ => _.@is(false))
				.BDDfy("NULL is compared to a numeral");
		}

		[Fact]
		public void GreaterThanOrEqualRomanNumeral()
		{
			this.WithTags("RomanNumeral", "Comparisons", "greather than or equal")
				.Given(_ => _.theRomanNumeral(new RomanNumeral(5)))
				.When(_ => _._IsEvaluatedAgainst_(Op.GtE, new RomanNumeral(1)), "'{0}' is evaluated against {1}")
				.Then(_ => _.@is(true))
				.BDDfy("one numeral is greater than another");

			this.WithTags("RomanNumeral", "Comparisons", "greather than or equal")
				.Given(_ => _.theRomanNumeral(new RomanNumeral(1)))
				.When(_ => _._IsEvaluatedAgainst_(Op.GtE, new RomanNumeral(11)), "'{0}' is evaluated against {1}")
				.Then(_ => _.@is(false))
				.BDDfy("one numeral is less than another");

			this.WithTags("RomanNumeral", "Comparisons", "greather than or equal")
				.Given(_ => _.theRomanNumeral(new RomanNumeral(11)))
				.When(_ => _._IsEvaluatedAgainst_(Op.GtE, new RomanNumeral(11)), "'{0}' is evaluated against {1}")
				.Then(_ => _.@is(true))
				.BDDfy("one numeral is equal to another");

			this.WithTags("RomanNumeral", "Comparisons", "greather than or equal")
				.Given(_ => _.theRomanNumeral(RomanNumeral.Zero))
				.When(_ => _._IsEvaluatedAgainst_(Op.Gt, null), "'{0}' is evaluated against {1}")
				.Then(_ => _.@is(true))
				.BDDfy("one numeral is compared to NULL");


			this.WithTags("RomanNumeral", "Comparisons", "greather than or equal")
				.Given(_ => _.theRomanNumeral(null))
				.When(_ => _._IsEvaluatedAgainst_(Op.GtE, RomanNumeral.Zero), "'{0}' is evaluated against {1}")
				.Then(_ => _.@is(false))
				.BDDfy("NULL is compared to a numeral");
		}

		[Fact]
		public void LessThanRomanNumeral()
		{
			this.WithTags("RomanNumeral", "Comparisons", "less than")
				.Given(_ => _.theRomanNumeral(new RomanNumeral(5)))
				.When(_ => _._IsEvaluatedAgainst_(Op.Lt, new RomanNumeral(1)), "'{0}' is evaluated against {1}")
				.Then(_ => _.@is(false))
				.BDDfy("one numeral is greater than another");

			this.WithTags("RomanNumeral", "Comparisons", "less than")
				.Given(_ => _.theRomanNumeral(new RomanNumeral(1)))
				.When(_ => _._IsEvaluatedAgainst_(Op.Lt, new RomanNumeral(10)), "'{0}' is evaluated against {1}")
				.Then(_ => _.@is(true))
				.BDDfy("one numeral is less than another");

			this.WithTags("RomanNumeral", "Comparisons", "less than")
				.Given(_ => _.theRomanNumeral(new RomanNumeral(10)))
				.When(_ => _._IsEvaluatedAgainst_(Op.Lt, new RomanNumeral(10)), "'{0}' is evaluated against {1}")
				.Then(_ => _.@is(false))
				.BDDfy("one numeral is equal to another");

			this.WithTags("RomanNumeral", "Comparisons", "less than")
				.Given(_ => _.theRomanNumeral(RomanNumeral.Zero))
				.When(_ => _._IsEvaluatedAgainst_(Op.Lt, null), "'{0}' is evaluated against {1}")
				.Then(_ => _.@is(false))
				.BDDfy("one numeral is compared to NULL");

			this.WithTags("RomanNumeral", "Comparisons", "less than")
				.Given(_ => _.theRomanNumeral(null))
				.When(_ => _._IsEvaluatedAgainst_(Op.Lt, RomanNumeral.Zero), "'{0}' is evaluated against {1}")
				.Then(_ => _.@is(true))
				.BDDfy("NULL is compared to a numeral");
		}

		[Fact]
		public void LessThanOrEqualToRomanNumeral()
		{
			this.WithTags("RomanNumeral", "Comparisons", "less than or equals")
				.Given(_ => _.theRomanNumeral(new RomanNumeral(5)))
				.When(_ => _._IsEvaluatedAgainst_(Op.LtE, new RomanNumeral(1)), "'{0}' is evaluated against {1}")
				.Then(_ => _.@is(false))
				.BDDfy("one numeral is greater than another");

			this.WithTags("RomanNumeral", "Comparisons", "less than or equals")
				.Given(_ => _.theRomanNumeral(new RomanNumeral(1)))
				.When(_ => _._IsEvaluatedAgainst_(Op.LtE, new RomanNumeral(10)), "'{0}' is evaluated against {1}")
				.Then(_ => _.@is(true))
				.BDDfy("one numeral is less than another");

			this.WithTags("RomanNumeral", "Comparisons", "less than or equals")
				.Given(_ => _.theRomanNumeral(new RomanNumeral(10)))
				.When(_ => _._IsEvaluatedAgainst_(Op.LtE, new RomanNumeral(10)), "'{0}' is evaluated against {1}")
				.Then(_ => _.@is(true))
				.BDDfy("one numeral is equal to another");

			this.WithTags("RomanNumeral", "Comparisons", "less than or equals")
			.Given(_ => _.theRomanNumeral(RomanNumeral.Zero))
				.When(_ => _._IsEvaluatedAgainst_(Op.LtE, null), "'{0}' is evaluated against {1}")
				.Then(_ => _.@is(false))
				.BDDfy("one numeral is compared to NULL");

			this.WithTags("RomanNumeral", "Comparisons", "less than or equals")
				.Given(_ => _.theRomanNumeral(null))
				.When(_ => _._IsEvaluatedAgainst_(Op.LtE, RomanNumeral.Zero), "'{0}' is evaluated against {1}")
				.Then(_ => _.@is(true))
				.BDDfy("NULL is compared to a numeral");
		}

		RomanNumeral _subject;
		private void theRomanNumeral(RomanNumeral numeral)
		{
			_subject = numeral;
		}

		private int _comparison;
		private void comparedTo(RomanNumeral another)
		{
			_comparison = _subject.CompareTo(another);
		}

		bool _operation;
		private void _IsEvaluatedAgainst_(Op op, RomanNumeral right)
		{
			_operation = op.Execute(_subject, right);
		}

		private void isGreaterThanZero()
		{
			Assert.True(_comparison > 0);
		}

		private void isZero()
		{
			Assert.Equal(0, _comparison);
		}

		private void isLessThanZero()
		{
			Assert.True(_comparison < 0);
		}

		private void @is(bool value)
		{
			Assert.Equal(value, _operation);
		}
	}
}