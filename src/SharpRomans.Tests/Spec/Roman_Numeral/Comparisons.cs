using SharpRomans.Tests.Spec.Roman_Numeral.Support;
using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Numeral
{
	[Category("Spec"), Category("RomanNumeral"), Category("Comparisons")]
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
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(5)))
				.When(_ => _.ComparedTo_(new RomanNumeral(1)))
				.Then(_ => _.IsGreaterThanZero())
				.BDDfy("one numeral is greater than another");

			this.WithTags("RomanNumeral", "Comparisons", "Compare")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(1)))
				.When(_ => _.ComparedTo_(new RomanNumeral(10)))
				.Then(_ => _.IsLessThanZero())
				.BDDfy("one numeral is less than another");

			this.WithTags("RomanNumeral", "Comparisons", "Compare")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(10)))
				.When(_ => _.ComparedTo_(new RomanNumeral(10)))
				.Then(_ => _.IsZero())
				.BDDfy("one numeral is equal to another");

			this.WithTags("RomanNumeral", "Comparisons", "Compare")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(0)))
				.When(_ => _.ComparedTo_((RomanNumeral)null))
				.Then(_ => _.IsGreaterThanZero())
				.BDDfy("one figure is compared to NULL");
		}

		[Fact]
		public void GreaterThanRomanNumeral()
		{
			this.WithTags("RomanNumeral", "Comparisons", "greather than")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(5)))
				.When(_ => _._IsEvaluatedAgainst_(Op.Gt, new RomanNumeral(1)))
				.Then(_ => _.Is_(true))
				.BDDfy("one numeral is greater than another");

			this.WithTags("RomanNumeral", "Comparisons", "greather than")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(0)))
				.When(_ => _._IsEvaluatedAgainst_(Op.Gt, new RomanNumeral(1)))
				.Then(_ => _.Is_(false))
				.BDDfy("one numeral is less than another");

			this.WithTags("RomanNumeral", "Comparisons", "greather than")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(10)))
				.When(_ => _._IsEvaluatedAgainst_(Op.Gt, new RomanNumeral(10)))
				.Then(_ => _.Is_(false))
				.BDDfy("one numeral is equal to another");

			this.WithTags("RomanNumeral", "Comparisons", "greather than")
				.Given(_ => _.TheRomanNumeral_(RomanNumeral.Zero))
				.When(_ => _._IsEvaluatedAgainst_(Op.Gt, (RomanNumeral)null))
				.Then(_ => _.Is_(true))
				.BDDfy("one numeral is compared to NULL");

			this.WithTags("RomanNumeral", "Comparisons", "greather than")
				.Given(_ => _.TheRomanNumeral_((RomanNumeral)null))
				.When(_ => _._IsEvaluatedAgainst_(Op.Gt, RomanNumeral.Zero))
				.Then(_ => _.Is_(false))
				.BDDfy("NULL is compared to a numeral");
		}

		[Fact]
		public void GreaterThanOrEqualRomanNumeral()
		{
			this.WithTags("RomanNumeral", "Comparisons", "greather than or equal")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(5)))
				.When(_ => _._IsEvaluatedAgainst_(Op.GtE, new RomanNumeral(1)))
				.Then(_ => _.Is_(true))
				.BDDfy("one numeral is greater than another");

			this.WithTags("RomanNumeral", "Comparisons", "greather than or equal")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(1)))
				.When(_ => _._IsEvaluatedAgainst_(Op.GtE, new RomanNumeral(11)))
				.Then(_ => _.Is_(false))
				.BDDfy("one numeral is less than another");

			this.WithTags("RomanNumeral", "Comparisons", "greather than or equal")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(11)))
				.When(_ => _._IsEvaluatedAgainst_(Op.GtE, new RomanNumeral(11)))
				.Then(_ => _.Is_(true))
				.BDDfy("one numeral is equal to another");

			this.WithTags("RomanNumeral", "Comparisons", "greather than or equal")
				.Given(_ => _.TheRomanNumeral_(RomanNumeral.Zero))
				.When(_ => _._IsEvaluatedAgainst_(Op.Gt, (RomanNumeral)null))
				.Then(_ => _.Is_(true))
				.BDDfy("one numeral is compared to NULL");


			this.WithTags("RomanNumeral", "Comparisons", "greather than or equal")
				.Given(_ => _.TheRomanNumeral_((RomanNumeral)null))
				.When(_ => _._IsEvaluatedAgainst_(Op.GtE, RomanNumeral.Zero))
				.Then(_ => _.Is_(false))
				.BDDfy("NULL is compared to a numeral");
		}

		[Fact]
		public void LessThanRomanNumeral()
		{
			this.WithTags("RomanNumeral", "Comparisons", "less than")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(5)))
				.When(_ => _._IsEvaluatedAgainst_(Op.Lt, new RomanNumeral(1)))
				.Then(_ => _.Is_(false))
				.BDDfy("one numeral is greater than another");

			this.WithTags("RomanNumeral", "Comparisons", "less than")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(1)))
				.When(_ => _._IsEvaluatedAgainst_(Op.Lt, new RomanNumeral(10)))
				.Then(_ => _.Is_(true))
				.BDDfy("one numeral is less than another");

			this.WithTags("RomanNumeral", "Comparisons", "less than")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(10)))
				.When(_ => _._IsEvaluatedAgainst_(Op.Lt, new RomanNumeral(10)))
				.Then(_ => _.Is_(false))
				.BDDfy("one numeral is equal to another");

			this.WithTags("RomanNumeral", "Comparisons", "less than")
				.Given(_ => _.TheRomanNumeral_(RomanNumeral.Zero))
				.When(_ => _._IsEvaluatedAgainst_(Op.Lt, (RomanNumeral)null))
				.Then(_ => _.Is_(false))
				.BDDfy("one numeral is compared to NULL");

			this.WithTags("RomanNumeral", "Comparisons", "less than")
				.Given(_ => _.TheRomanNumeral_((RomanNumeral)null))
				.When(_ => _._IsEvaluatedAgainst_(Op.Lt, RomanNumeral.Zero))
				.Then(_ => _.Is_(true))
				.BDDfy("NULL is compared to a numeral");
		}

		[Fact]
		public void LessThanOrEqualToRomanNumeral()
		{
			this.WithTags("RomanNumeral", "Comparisons", "less than or equals")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(5)))
				.When(_ => _._IsEvaluatedAgainst_(Op.LtE, new RomanNumeral(1)))
				.Then(_ => _.Is_(false))
				.BDDfy("one numeral is greater than another");

			this.WithTags("RomanNumeral", "Comparisons", "less than or equals")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(1)))
				.When(_ => _._IsEvaluatedAgainst_(Op.LtE, new RomanNumeral(10)))
				.Then(_ => _.Is_(true))
				.BDDfy("one numeral is less than another");

			this.WithTags("RomanNumeral", "Comparisons", "less than or equals")
				.Given(_ => _.TheRomanNumeral_(new RomanNumeral(10)))
				.When(_ => _._IsEvaluatedAgainst_(Op.LtE, new RomanNumeral(10)))
				.Then(_ => _.Is_(true))
				.BDDfy("one numeral is equal to another");

			this.WithTags("RomanNumeral", "Comparisons", "less than or equals")
			.Given(_ => _.TheRomanNumeral_(RomanNumeral.Zero))
				.When(_ => _._IsEvaluatedAgainst_(Op.LtE, (RomanNumeral)null))
				.Then(_ => _.Is_(false))
				.BDDfy("one numeral is compared to NULL");

			this.WithTags("RomanNumeral", "Comparisons", "less than or equals")
				.Given(_ => _.TheRomanNumeral_((RomanNumeral)null))
				.When(_ => _._IsEvaluatedAgainst_(Op.LtE, RomanNumeral.Zero))
				.Then(_ => _.Is_(true))
				.BDDfy("NULL is compared to a numeral");
		}

		RomanNumeral _subject;
		private void TheRomanNumeral_(RomanNumeral numeral)
		{
			_subject = numeral;
		}

		private int _comparison;
		private void ComparedTo_(RomanNumeral another)
		{
			_comparison = _subject.CompareTo(another);
		}

		bool _operation;
		private void _IsEvaluatedAgainst_(Op op, RomanNumeral right)
		{
			_operation = op.Execute(_subject, right);
		}

		private void IsGreaterThanZero()
		{
			Assert.True(_comparison > 0);
		}

		private void IsZero()
		{
			Assert.Equal(0, _comparison);
		}

		private void IsLessThanZero()
		{
			Assert.True(_comparison < 0);
		}

		private void Is_(bool value)
		{
			Assert.Equal(value, _operation);
		}
	}
}