using SharpRomans.Tests.Spec.Roman_Figure.Support;
using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec"), Category("RomanFigure"), Category("Comparisons")]
	[Collection("bddfy")]
	[Story(
		Title = "compare roman figures",
		AsA = "library user",
		IWant = "use comparison operators and methods",
		SoThat = "I can tell the relative magnitude of two roman figures"
	)]
	public class ComparisonsTester
	{
		[Fact]
		public void CompareToRomanFigure()
		{
			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.TheRomanFigure_(RomanFigure.V))
				.When(_ => _.ComparedTo_(RomanFigure.I))
				.Then(_ => _.TheResultIsGreaterThanZero())
				.BDDfy("one figure is greater than another");

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.TheRomanFigure_(RomanFigure.I))
				.When(_ => _.ComparedTo_(RomanFigure.X))
				.Then(_ => _.TheResultIsLessThanZero())
				.BDDfy("one figure is less than another");

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.TheRomanFigure_(RomanFigure.X))
				.When(_ => _.ComparedTo_(RomanFigure.X))
				.Then(_ => _.TheResultIsZero())
				.BDDfy("one figure is equal to another");

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.TheRomanFigure_(RomanFigure.X))
				.When(_ => _.ComparedTo_((RomanFigure) null))
				.Then(_ => _.TheResultIsGreaterThanZero())
				.BDDfy("one figure is compared to NULL");

		}

		[Fact]
		public void GreaterThanRomanFigure()
		{

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.TheRomanFigure_(RomanFigure.V))
				.When(_ => _._IsEvaluatedAgainst_(Op.Gt, RomanFigure.I))
				.Then(_ => _.Is_(true))
				.BDDfy("one figure is greater than another");

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.TheRomanFigure_(RomanFigure.I))
				.When(_ => _._IsEvaluatedAgainst_(Op.Gt, RomanFigure.X))
				.Then(_ => _.Is_(false))
				.BDDfy("one figure is less than another");

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.TheRomanFigure_(RomanFigure.X))
				.When(_ => _._IsEvaluatedAgainst_(Op.Gt, RomanFigure.X))
				.Then(_ => _.Is_(false))
				.BDDfy("one figure is equal to another");

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.TheRomanFigure_(RomanFigure.N))
				.When(_ => _._IsEvaluatedAgainst_(Op.Gt, (RomanFigure) null))
				.Then(_ => _.Is_(true))
				.BDDfy("one figure is compared to NULL");

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.TheRomanFigure_((RomanFigure) null))
				.When(_ => _._IsEvaluatedAgainst_(Op.Gt, RomanFigure.N))
				.Then(_ => _.Is_(false))
				.BDDfy("NULL is compared to a figure");

		}

		[Fact]
		public void GreaterThanOrEqualToRomanFigure()
		{
			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.TheRomanFigure_(RomanFigure.V))
				.When(_ => _._IsEvaluatedAgainst_(Op.GtE, RomanFigure.I))
				.Then(_ => _.Is_(true))
				.BDDfy("one figure is greater than another");

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.TheRomanFigure_(RomanFigure.I))
				.When(_ => _._IsEvaluatedAgainst_(Op.GtE, RomanFigure.X))
				.Then(_ => _.Is_(false))
				.BDDfy("one figure is less than another");

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.TheRomanFigure_(RomanFigure.X))
				.When(_ => _._IsEvaluatedAgainst_(Op.GtE, RomanFigure.X))
				.Then(_ => _.Is_(true))
				.BDDfy("one figure is equal to another");

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.TheRomanFigure_(RomanFigure.N))
				.When(_ => _._IsEvaluatedAgainst_(Op.GtE, (RomanFigure) null))
				.Then(_ => _.Is_(true))
				.BDDfy("one figure is compared to NULL");

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.TheRomanFigure_((RomanFigure) null))
				.When(_ => _._IsEvaluatedAgainst_(Op.GtE, RomanFigure.N))
				.Then(_ => _.Is_(false))
				.BDDfy("NULL is compared to a figure");

		}

		[Fact]
		public void LessThanRomanFigure()
		{
			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.TheRomanFigure_(RomanFigure.V))
				.When(_ => _._IsEvaluatedAgainst_(Op.Lt, (RomanFigure.I)))
				.Then(_ => _.Is_(false))
				.BDDfy("one figure is greater than another");

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.TheRomanFigure_(RomanFigure.V))
				.When(_ => _._IsEvaluatedAgainst_(Op.Lt, RomanFigure.I))
				.Then(_ => _.Is_(false))
				.BDDfy("one figure is greater than another");

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.TheRomanFigure_(RomanFigure.I))
				.When(_ => _._IsEvaluatedAgainst_(Op.Lt, RomanFigure.X))
				.Then(_ => _.Is_(true))
				.BDDfy("one figure is less than another")
				;

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.TheRomanFigure_(RomanFigure.X))
				.When(_ => _._IsEvaluatedAgainst_(Op.Lt, RomanFigure.X))
				.Then(_ => _.Is_(false))
				.BDDfy("one figure is equal to another");

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.TheRomanFigure_(RomanFigure.N))
				.When(_ => _._IsEvaluatedAgainst_(Op.Lt, (RomanFigure) null))
				.Then(_ => _.Is_(false))
				.BDDfy("one figure is compared to NULL");

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.TheRomanFigure_((RomanFigure) null))
				.When(_ => _._IsEvaluatedAgainst_(Op.Lt, RomanFigure.N))
				.Then(_ => _.Is_(true))
				.BDDfy("NULL is compared to a figure");
		}

		[Fact]
		public void LessThanOrEqualToRomanFigure()
		{
			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.TheRomanFigure_(RomanFigure.V))
				.When(_ => _._IsEvaluatedAgainst_(Op.LtE, RomanFigure.I))
				.Then(_ => _.Is_(false))
				.BDDfy("one figure is greater than another");

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.TheRomanFigure_(RomanFigure.I))
				.When(_ => _._IsEvaluatedAgainst_(Op.LtE, RomanFigure.X))
				.Then(_ => _.Is_(true))
				.BDDfy("one figure is less than another");

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.TheRomanFigure_(RomanFigure.X))
				.When(_ => _._IsEvaluatedAgainst_(Op.LtE, RomanFigure.X))
				.Then(_ => _.Is_(true))
				.BDDfy("one figure is equal to another");

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.TheRomanFigure_(RomanFigure.N))
				.When(_ => _._IsEvaluatedAgainst_(Op.LtE, (RomanFigure) null))
				.Then(_ => _.Is_(false))
				.BDDfy("one figure is compared to NULL");

			this.WithTags("RomanFigure", "Comparisons")
				.Given(_ => _.TheRomanFigure_((RomanFigure) null))
				.When(_ => _._IsEvaluatedAgainst_(Op.LtE, RomanFigure.N))
				.Then(_ => _.Is_(true))
				.BDDfy("NULL is compared to a figure");
		}


		RomanFigure _subject;
		private void TheRomanFigure_(RomanFigure figure)
		{
			_subject = figure;
		}

		private int _comparison;
		private void ComparedTo_(RomanFigure anotherFigure)
		{
			_comparison = _subject.CompareTo(anotherFigure);
		}

		bool _operation;
		private void _IsEvaluatedAgainst_(Op op, RomanFigure right)
		{
			_operation = op.Execute(_subject, right);
		}
		
		private void TheResultIsZero()
		{
			Assert.Equal(0, _comparison);
		}

		private void TheResultIsLessThanZero()
		{
			Assert.True(_comparison < 0);
		}

		private void TheResultIsGreaterThanZero()
		{
			Assert.True(_comparison > 0);
		}

		private void Is_(bool value)
		{
			Assert.Equal(value, _operation);
		}
	}

}