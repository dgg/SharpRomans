using NUnit.Framework;
using SharpRomans.Tests.Spec.RomanFigure.Support;
using StoryQ;

namespace SharpRomans.Tests.Spec.RomanFigure
{
	[TestFixture, Category("Spec"), Category("RomanFigure")]
	public class FigureComparisonsTester
	{
		[Test]
		public void CompareToRomanFigure()
		{
			new Story("compare to roman figure")
				.InOrderTo("say that a figure is greater or lower than another figure")
				.AsA("library user")
				.IWant("compare a roman figure against another roman figure")

			.WithScenario("one figure is greater than another")
				.Given(TheRomanFigure_, SharpRomans.RomanFigure.V)
				.When(ComparedTo_, SharpRomans.RomanFigure.I)
				.Then(TheResultIsGreaterThanZero)

			.WithScenario("one figure is less than another")
				.Given(TheRomanFigure_, SharpRomans.RomanFigure.I)
				.When(ComparedTo_, SharpRomans.RomanFigure.X)
				.Then(TheResultIsLessThanZero)

			.WithScenario("one figure is equal to another")
				.Given(TheRomanFigure_, SharpRomans.RomanFigure.X)
				.When(ComparedTo_, SharpRomans.RomanFigure.X)
				.Then(TheResultIsZero)

			.WithScenario("one figure is compared to NULL")
				.Given(TheRomanFigure_, SharpRomans.RomanFigure.X)
				.When(ComparedTo_, (SharpRomans.RomanFigure)null)
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
				.Given(TheRomanFigure_, SharpRomans.RomanFigure.V)
				.When(_IsEvaluatedAgainst_, Op.Gt, SharpRomans.RomanFigure.I)
				.Then(Is_, true)

			.WithScenario("one figure is less than another")
				.Given(TheRomanFigure_, SharpRomans.RomanFigure.I)
				.When(_IsEvaluatedAgainst_, Op.Gt, SharpRomans.RomanFigure.X)
				.Then(Is_, false)

			.WithScenario("one figure is equal to another")
				.Given(TheRomanFigure_, SharpRomans.RomanFigure.X)
				.When(_IsEvaluatedAgainst_, Op.Gt, SharpRomans.RomanFigure.X)
				.Then(Is_, false)

			.WithScenario("one figure is compared to NULL")
				.Given(TheRomanFigure_, SharpRomans.RomanFigure.N)
				.When(_IsEvaluatedAgainst_, Op.Gt, (SharpRomans.RomanFigure)null)
				.Then(Is_, true)

				.WithScenario("NULL is compared to a figure")
				.Given(TheRomanFigure_, (SharpRomans.RomanFigure)null)
				.When(_IsEvaluatedAgainst_, Op.Gt, SharpRomans.RomanFigure.N)
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
				.Given(TheRomanFigure_, SharpRomans.RomanFigure.V)
				.When(_IsEvaluatedAgainst_, Op.GtOE, SharpRomans.RomanFigure.I)
				.Then(Is_, true)

			.WithScenario("one figure is less than another")
				.Given(TheRomanFigure_, SharpRomans.RomanFigure.I)
				.When(_IsEvaluatedAgainst_, Op.GtOE, SharpRomans.RomanFigure.X)
				.Then(Is_, false)

			.WithScenario("one figure is equal to another")
				.Given(TheRomanFigure_, SharpRomans.RomanFigure.X)
				.When(_IsEvaluatedAgainst_, Op.GtOE, SharpRomans.RomanFigure.X)
				.Then(Is_, true)

			.WithScenario("one figure is compared to NULL")
				.Given(TheRomanFigure_, SharpRomans.RomanFigure.N)
				.When(_IsEvaluatedAgainst_, Op.GtOE, (SharpRomans.RomanFigure)null)
				.Then(Is_, true)

				.WithScenario("NULL is compared to a figure")
				.Given(TheRomanFigure_, (SharpRomans.RomanFigure)null)
				.When(_IsEvaluatedAgainst_, Op.GtOE, SharpRomans.RomanFigure.N)
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
				.Given(TheRomanFigure_, SharpRomans.RomanFigure.V)
				.When(_IsEvaluatedAgainst_, Op.Lt, (SharpRomans.RomanFigure.I))
				.Then(Is_, false)

			.WithScenario("one figure is greater than another")
				.Given(TheRomanFigure_, SharpRomans.RomanFigure.V)
				.When(_IsEvaluatedAgainst_, Op.Lt, SharpRomans.RomanFigure.I)
				.Then(Is_, false)

			.WithScenario("one figure is less than another")
				.Given(TheRomanFigure_, SharpRomans.RomanFigure.I)
				.When(_IsEvaluatedAgainst_, Op.Lt, SharpRomans.RomanFigure.X)
				.Then(Is_, true)

			.WithScenario("one figure is equal to another")
				.Given(TheRomanFigure_, SharpRomans.RomanFigure.X)
				.When(_IsEvaluatedAgainst_, Op.Lt, SharpRomans.RomanFigure.X)
				.Then(Is_, false)

			.WithScenario("one figure is compared to NULL")
				.Given(TheRomanFigure_, SharpRomans.RomanFigure.N)
				.When(_IsEvaluatedAgainst_, Op.Lt, (SharpRomans.RomanFigure)null)
				.Then(Is_, false)

				.WithScenario("NULL is compared to a figure")
				.Given(TheRomanFigure_, (SharpRomans.RomanFigure)null)
				.When(_IsEvaluatedAgainst_, Op.Lt, SharpRomans.RomanFigure.N)
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
				.Given(TheRomanFigure_, SharpRomans.RomanFigure.V)
				.When(_IsEvaluatedAgainst_, Op.LtOE, SharpRomans.RomanFigure.I)
				.Then(Is_, false)

			.WithScenario("one figure is less than another")
				.Given(TheRomanFigure_, SharpRomans.RomanFigure.I)
				.When(_IsEvaluatedAgainst_, Op.LtOE, SharpRomans.RomanFigure.X)
				.Then(Is_, true)

			.WithScenario("one figure is equal to another")
				.Given(TheRomanFigure_, SharpRomans.RomanFigure.X)
				.When(_IsEvaluatedAgainst_, Op.LtOE, SharpRomans.RomanFigure.X)
				.Then(Is_, true)

			.WithScenario("one figure is compared to NULL")
				.Given(TheRomanFigure_, SharpRomans.RomanFigure.N)
				.When(_IsEvaluatedAgainst_, Op.LtOE, (SharpRomans.RomanFigure)null)
				.Then(Is_, false)

				.WithScenario("NULL is compared to a figure")
				.Given(TheRomanFigure_, (SharpRomans.RomanFigure)null)
				.When(_IsEvaluatedAgainst_, Op.LtOE, SharpRomans.RomanFigure.N)
				.Then(Is_, true)

			.ExecuteWithReport();
		}


		SharpRomans.RomanFigure _subject;
		private void TheRomanFigure_(SharpRomans.RomanFigure figure)
		{
			_subject = figure;
		}

		private int _comparison;
		private void ComparedTo_(SharpRomans.RomanFigure anotherFigure)
		{
			_comparison = _subject.CompareTo(anotherFigure);
		}

		bool _operation;
		private void _IsEvaluatedAgainst_(Op op, SharpRomans.RomanFigure right)
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