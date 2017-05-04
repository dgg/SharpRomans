using SharpRomans.Tests.Spec.Roman_Figure.Support;
using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec", Subject = "RomanFigure", Feature = "Comparisons")]
	[Collection("bddfy")]
	[Story(
		Title = "compare roman figures",
		AsA = "library user",
		IWant = "to use comparison operators and methods",
		SoThat = "I can tell the relative magnitude of two roman figures"
	)]
	public class ComparisonsTester
	{
		[Fact]
		public void CompareToRomanFigure()
		{
			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.theRomanFigure(RomanFigure.V))
				.When(_ => _.comparedTo(RomanFigure.I))
				.Then(_ => _.theResultIsGreaterThanZero())
				.BDDfy("one figure is greater than another");

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.theRomanFigure(RomanFigure.I))
				.When(_ => _.comparedTo(RomanFigure.X))
				.Then(_ => _.theResultIsLessThanZero())
				.BDDfy("one figure is less than another");

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.theRomanFigure(RomanFigure.X))
				.When(_ => _.comparedTo(RomanFigure.X))
				.Then(_ => _.theResultIsZero())
				.BDDfy("one figure is equal to another");

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.theRomanFigure(RomanFigure.X))
				.When(_ => _.comparedTo(null))
				.Then(_ => _.theResultIsGreaterThanZero())
				.BDDfy("one figure is compared to NULL");
		}

		[Fact]
		public void GreaterThanRomanFigure()
		{

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.theRomanFigure(RomanFigure.V))
				.When(_ => _.isEvaluatedAgainst(Op.Gt, RomanFigure.I), "When '{0}' is evaluated against {1}")
				.Then(_ => _.@is(true))
				.BDDfy("one figure is greater than another");

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.theRomanFigure(RomanFigure.I))
				.When(_ => _.isEvaluatedAgainst(Op.Gt, RomanFigure.X), "When '{0}' is evaluated against {1}")
				.Then(_ => _.@is(false))
				.BDDfy("one figure is less than another");

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.theRomanFigure(RomanFigure.X))
				.When(_ => _.isEvaluatedAgainst(Op.Gt, RomanFigure.X), "When '{0}' is evaluated against {1}")
				.Then(_ => _.@is(false))
				.BDDfy("one figure is equal to another");

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.theRomanFigure(RomanFigure.N))
				.When(_ => _.isEvaluatedAgainst(Op.Gt, null), "When '{0}' is evaluated against {1}")
				.Then(_ => _.@is(true))
				.BDDfy("one figure is compared to NULL");

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.theRomanFigure(null))
				.When(_ => _.isEvaluatedAgainst(Op.Gt, RomanFigure.N), "When '{0}' is evaluated against {1}")
				.Then(_ => _.@is(false))
				.BDDfy("NULL is compared to a figure");

		}

		[Fact]
		public void GreaterThanOrEqualToRomanFigure()
		{
			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.theRomanFigure(RomanFigure.V))
				.When(_ => _.isEvaluatedAgainst(Op.GtE, RomanFigure.I), "When '{0}' is evaluated against {1}")
				.Then(_ => _.@is(true))
				.BDDfy("one figure is greater than another");

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.theRomanFigure(RomanFigure.I))
				.When(_ => _.isEvaluatedAgainst(Op.GtE, RomanFigure.X), "When '{0}' is evaluated against {1}")
				.Then(_ => _.@is(false))
				.BDDfy("one figure is less than another");

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.theRomanFigure(RomanFigure.X))
				.When(_ => _.isEvaluatedAgainst(Op.GtE, RomanFigure.X), "When '{0}' is evaluated against {1}")
				.Then(_ => _.@is(true))
				.BDDfy("one figure is equal to another");

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.theRomanFigure(RomanFigure.N))
				.When(_ => _.isEvaluatedAgainst(Op.GtE, null), "When '{0}' is evaluated against {1}")
				.Then(_ => _.@is(true))
				.BDDfy("one figure is compared to NULL");

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.theRomanFigure(null))
				.When(_ => _.isEvaluatedAgainst(Op.GtE, RomanFigure.N), "When '{0}' is evaluated against {1}")
				.Then(_ => _.@is(false))
				.BDDfy("NULL is compared to a figure");

		}

		[Fact]
		public void LessThanRomanFigure()
		{
			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.theRomanFigure(RomanFigure.V))
				.When(_ => _.isEvaluatedAgainst(Op.Lt, RomanFigure.I), "When '{0}' is evaluated against {1}")
				.Then(_ => _.@is(false))
				.BDDfy("one figure is greater than another");

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.theRomanFigure(RomanFigure.V))
				.When(_ => _.isEvaluatedAgainst(Op.Lt, RomanFigure.I), "When '{0}' is evaluated against {1}")
				.Then(_ => _.@is(false))
				.BDDfy("one figure is greater than another");

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.theRomanFigure(RomanFigure.I))
				.When(_ => _.isEvaluatedAgainst(Op.Lt, RomanFigure.X), "When '{0}' is evaluated against {1}")
				.Then(_ => _.@is(true))
				.BDDfy("one figure is less than another")
				;

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.theRomanFigure(RomanFigure.X))
				.When(_ => _.isEvaluatedAgainst(Op.Lt, RomanFigure.X), "When '{0}' is evaluated against {1}")
				.Then(_ => _.@is(false))
				.BDDfy("one figure is equal to another");

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.theRomanFigure(RomanFigure.N))
				.When(_ => _.isEvaluatedAgainst(Op.Lt, null), "When '{0}' is evaluated against {1}")
				.Then(_ => _.@is(false))
				.BDDfy("one figure is compared to NULL");

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.theRomanFigure(null))
				.When(_ => _.isEvaluatedAgainst(Op.Lt, RomanFigure.N), "When '{0}' is evaluated against {1}")
				.Then(_ => _.@is(true))
				.BDDfy("NULL is compared to a figure");
		}

		[Fact]
		public void LessThanOrEqualToRomanFigure()
		{
			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.theRomanFigure(RomanFigure.V))
				.When(_ => _.isEvaluatedAgainst(Op.LtE, RomanFigure.I), "When '{0}' is evaluated against {1}")
				.Then(_ => _.@is(false))
				.BDDfy("one figure is greater than another");

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.theRomanFigure(RomanFigure.I))
				.When(_ => _.isEvaluatedAgainst(Op.LtE, RomanFigure.X), "When '{0}' is evaluated against {1}")
				.Then(_ => _.@is(true))
				.BDDfy("one figure is less than another");

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.theRomanFigure(RomanFigure.X))
				.When(_ => _.isEvaluatedAgainst(Op.LtE, RomanFigure.X), "When '{0}' is evaluated against {1}")
				.Then(_ => _.@is(true))
				.BDDfy("one figure is equal to another");

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.theRomanFigure(RomanFigure.N))
				.When(_ => _.isEvaluatedAgainst(Op.LtE, null), "When '{0}' is evaluated against {1}")
				.Then(_ => _.@is(false))
				.BDDfy("one figure is compared to NULL");

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.theRomanFigure(null))
				.When(_ => _.isEvaluatedAgainst(Op.LtE, RomanFigure.N), "When '{0}' is evaluated against {1}")
				.Then(_ => _.@is(true))
				.BDDfy("NULL is compared to a figure");
		}


		RomanFigure _subject;
		private void theRomanFigure(RomanFigure figure)
		{
			_subject = figure;
		}

		private int _comparison;
		private void comparedTo(RomanFigure anotherFigure)
		{
			_comparison = _subject.CompareTo(anotherFigure);
		}

		bool _operation;
		private void isEvaluatedAgainst(Op op, RomanFigure right)
		{
			_operation = op.Execute(_subject, right);
		}
		
		private void theResultIsZero()
		{
			Assert.Equal(0, _comparison);
		}

		private void theResultIsLessThanZero()
		{
			Assert.True(_comparison < 0);
		}

		private void theResultIsGreaterThanZero()
		{
			Assert.True(_comparison > 0);
		}

		private void @is(bool value)
		{
			Assert.Equal(value, _operation);
		}
	}

}