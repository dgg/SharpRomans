using NUnit.Framework;
using SharpRomans.Tests.Spec.Roman_Figure.Support;
using StoryQ;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[TestFixture, Category("Spec"), Category("RomanFigure")]
	public class ComparisonsTester
	{
		[Test]
		public void CompareToRomanFigure()
		{
			new Story("compare to roman figure")
				.InOrderTo("say that a figure is greater or lower than another figure")
				.AsA("library user")
				.IWant("compare a roman figure against another roman figure")

			.WithScenario("one figure is greater than another")
				.Given(TheRomanFigure_, RomanFigure.V)
				.When(ComparedTo_, RomanFigure.I)
				.Then(TheResultIsGreaterThanZero)

			.WithScenario("one figure is less than another")
				.Given(TheRomanFigure_, RomanFigure.I)
				.When(ComparedTo_, RomanFigure.X)
				.Then(TheResultIsLessThanZero)

			.WithScenario("one figure is equal to another")
				.Given(TheRomanFigure_, RomanFigure.X)
				.When(ComparedTo_, RomanFigure.X)
				.Then(TheResultIsZero)

			.WithScenario("one figure is compared to NULL")
				.Given(TheRomanFigure_, RomanFigure.X)
				.When(ComparedTo_, (RomanFigure)null)
				.Then(TheResultIsGreaterThanZero)

			.ExecuteWithReport();
		}

		[Test]
		public void GreaterThanRomanFigure()
		{
			new Story("greater than roman figure")
				.InOrderTo("say that a figure is greater than another figure")
				.AsA("library user")
				.IWant("apply a greater than operator against another roman figure")

			.WithScenario("one figure is greater than another")
				.Given(TheRomanFigure_, RomanFigure.V)
				.When(_IsEvaluatedAgainst_, Op.Gt, RomanFigure.I)
				.Then(Is_, true)

			.WithScenario("one figure is less than another")
				.Given(TheRomanFigure_, RomanFigure.I)
				.When(_IsEvaluatedAgainst_, Op.Gt, RomanFigure.X)
				.Then(Is_, false)

			.WithScenario("one figure is equal to another")
				.Given(TheRomanFigure_, RomanFigure.X)
				.When(_IsEvaluatedAgainst_, Op.Gt, RomanFigure.X)
				.Then(Is_, false)

			.WithScenario("one figure is compared to NULL")
				.Given(TheRomanFigure_, RomanFigure.N)
				.When(_IsEvaluatedAgainst_, Op.Gt, (RomanFigure)null)
				.Then(Is_, true)

				.WithScenario("NULL is compared to a figure")
				.Given(TheRomanFigure_, (RomanFigure)null)
				.When(_IsEvaluatedAgainst_, Op.Gt, RomanFigure.N)
				.Then(Is_, false)

			.ExecuteWithReport();
		}

		[Test]
		public void GreaterThanOrEqualToRomanFigure()
		{
			new Story("greater than or equal to roman figure")
				.InOrderTo("say that a figure is greater than or equal to another figure")
				.AsA("library user")
				.IWant("apply a greater than or equal operator against another roman figure")

			.WithScenario("one figure is greater than another")
				.Given(TheRomanFigure_, RomanFigure.V)
				.When(_IsEvaluatedAgainst_, Op.GtE, RomanFigure.I)
				.Then(Is_, true)

			.WithScenario("one figure is less than another")
				.Given(TheRomanFigure_, RomanFigure.I)
				.When(_IsEvaluatedAgainst_, Op.GtE, RomanFigure.X)
				.Then(Is_, false)

			.WithScenario("one figure is equal to another")
				.Given(TheRomanFigure_, RomanFigure.X)
				.When(_IsEvaluatedAgainst_, Op.GtE, RomanFigure.X)
				.Then(Is_, true)

			.WithScenario("one figure is compared to NULL")
				.Given(TheRomanFigure_, RomanFigure.N)
				.When(_IsEvaluatedAgainst_, Op.GtE, (RomanFigure)null)
				.Then(Is_, true)

				.WithScenario("NULL is compared to a figure")
				.Given(TheRomanFigure_, (RomanFigure)null)
				.When(_IsEvaluatedAgainst_, Op.GtE, RomanFigure.N)
				.Then(Is_, false)

			.ExecuteWithReport();
		}

		[Test]
		public void LessThanRomanFigure()
		{
			new Story("less than roman figure")
				.InOrderTo("say that a figure is less than another figure")
				.AsA("library user")
				.IWant("apply a less than operator against another roman figure")

			.WithScenario("one figure is greater than another")
				.Given(TheRomanFigure_, RomanFigure.V)
				.When(_IsEvaluatedAgainst_, Op.Lt, (RomanFigure.I))
				.Then(Is_, false)

			.WithScenario("one figure is greater than another")
				.Given(TheRomanFigure_, RomanFigure.V)
				.When(_IsEvaluatedAgainst_, Op.Lt, RomanFigure.I)
				.Then(Is_, false)

			.WithScenario("one figure is less than another")
				.Given(TheRomanFigure_, RomanFigure.I)
				.When(_IsEvaluatedAgainst_, Op.Lt, RomanFigure.X)
				.Then(Is_, true)

			.WithScenario("one figure is equal to another")
				.Given(TheRomanFigure_, RomanFigure.X)
				.When(_IsEvaluatedAgainst_, Op.Lt, RomanFigure.X)
				.Then(Is_, false)

			.WithScenario("one figure is compared to NULL")
				.Given(TheRomanFigure_, RomanFigure.N)
				.When(_IsEvaluatedAgainst_, Op.Lt, (RomanFigure)null)
				.Then(Is_, false)

				.WithScenario("NULL is compared to a figure")
				.Given(TheRomanFigure_, (RomanFigure)null)
				.When(_IsEvaluatedAgainst_, Op.Lt, RomanFigure.N)
				.Then(Is_, true)

			.ExecuteWithReport();
		}

		[Test]
		public void LessThanOrEqualToRomanFigure()
		{
			new Story("less than or equal to roman figure")
				.InOrderTo("say that a figure is less than or equal to another figure")
				.AsA("library user")
				.IWant("apply a less than or equal operator against another roman figure")

			.WithScenario("one figure is greater than another")
				.Given(TheRomanFigure_, RomanFigure.V)
				.When(_IsEvaluatedAgainst_, Op.LtE, RomanFigure.I)
				.Then(Is_, false)

			.WithScenario("one figure is less than another")
				.Given(TheRomanFigure_, RomanFigure.I)
				.When(_IsEvaluatedAgainst_, Op.LtE, RomanFigure.X)
				.Then(Is_, true)

			.WithScenario("one figure is equal to another")
				.Given(TheRomanFigure_, RomanFigure.X)
				.When(_IsEvaluatedAgainst_, Op.LtE, RomanFigure.X)
				.Then(Is_, true)

			.WithScenario("one figure is compared to NULL")
				.Given(TheRomanFigure_, RomanFigure.N)
				.When(_IsEvaluatedAgainst_, Op.LtE, (RomanFigure)null)
				.Then(Is_, false)

				.WithScenario("NULL is compared to a figure")
				.Given(TheRomanFigure_, (RomanFigure)null)
				.When(_IsEvaluatedAgainst_, Op.LtE, RomanFigure.N)
				.Then(Is_, true)

			.ExecuteWithReport();
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
			Assert.That(_comparison, Is.EqualTo(0));
		}

		private void TheResultIsLessThanZero()
		{
			Assert.That(_comparison, Is.LessThan(0));
		}

		private void TheResultIsGreaterThanZero()
		{
			Assert.That(_comparison, Is.GreaterThan(0));
		}

		private void Is_(bool value)
		{
			Assert.That(_operation, Is.EqualTo(value));
		}
	}

}