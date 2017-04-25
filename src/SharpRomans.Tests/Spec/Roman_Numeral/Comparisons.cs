using SharpRomans.Tests.Spec.Roman_Numeral.Support;
using SharpRomans.Tests.Support;
using StoryQ;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Numeral
{
	[Category("Spec"), Category("RomanNumeral"), Category("Comparisons")]
	public class ComparisonsTester
	{
		[Fact]
		public void CompareToRomanNumeral()
		{
			new Story("compare to roman numeral")
				.InOrderTo("say that a roman numeral is greater or lower than another roman numeral")
				.AsA("library user")
				.IWant("compare a roman numeral against another roman numeral")

			.WithScenario("one numeral is greater than another")
				.Given(TheRomanNumeral_, new RomanNumeral(5))
				.When(ComparedTo_, new RomanNumeral(1))
				.Then(IsGreaterThanZero)

			.WithScenario("one numeral is less than another")
				.Given(TheRomanNumeral_, new RomanNumeral(1))
				.When(ComparedTo_, new RomanNumeral(10))
				.Then(IsLessThanZero)

			.WithScenario("one numeral is equal to another")
				.Given(TheRomanNumeral_, new RomanNumeral(10))
				.When(ComparedTo_, new RomanNumeral(10))
				.Then(IsZero)

			.WithScenario("one figure is compared to NULL")
				.Given(TheRomanNumeral_, new RomanNumeral(0))
				.When(ComparedTo_, (RomanNumeral)null)
				.Then(IsGreaterThanZero)

			.ExecuteWithReport();
		}

		[Fact]
		public void GreaterThanRomanNumeral()
		{
			new Story("greater than roman numeral")
				.InOrderTo("say that a numeral is greater than another numeral")
				.AsA("library user")
				.IWant("apply a greater than operator against another roman numeral")

			.WithScenario("one numeral is greater than another")
				.Given(TheRomanNumeral_, new RomanNumeral(5))
				.When(_IsEvaluatedAgainst_, Op.Gt, new RomanNumeral(1))
				.Then(Is_, true)

			.WithScenario("one numeral is less than another")
				.Given(TheRomanNumeral_, new RomanNumeral(0))
				.When(_IsEvaluatedAgainst_, Op.Gt, new RomanNumeral(1))
				.Then(Is_, false)

			.WithScenario("one numeral is equal to another")
				.Given(TheRomanNumeral_, new RomanNumeral(10))
				.When(_IsEvaluatedAgainst_, Op.Gt, new RomanNumeral(10))
				.Then(Is_, false)

			.WithScenario("one numeral is compared to NULL")
				.Given(TheRomanNumeral_, RomanNumeral.Zero)
				.When(_IsEvaluatedAgainst_, Op.Gt, (RomanNumeral)null)
				.Then(Is_, true)

				.WithScenario("NULL is compared to a numeral")
				.Given(TheRomanNumeral_, (RomanNumeral)null)
				.When(_IsEvaluatedAgainst_, Op.Gt, RomanNumeral.Zero)
				.Then(Is_, false)

			.ExecuteWithReport();
		}

		[Fact]
		public void GreaterThanOrEqualRomanNumeral()
		{
			new Story("greater than or equal to roman numeral")
				.InOrderTo("say that a numeral is greater than or equal to another numeral")
				.AsA("library user")
				.IWant("apply a greater than or equal operator against another roman numeral")

			.WithScenario("one numeral is greater than another")
				.Given(TheRomanNumeral_, new RomanNumeral(5))
				.When(_IsEvaluatedAgainst_, Op.GtE, new RomanNumeral(1))
				.Then(Is_, true)

			.WithScenario("one numeral is less than another")
				.Given(TheRomanNumeral_, new RomanNumeral(1))
				.When(_IsEvaluatedAgainst_, Op.GtE, new RomanNumeral(11))
				.Then(Is_, false)

			.WithScenario("one numeral is equal to another")
				.Given(TheRomanNumeral_, new RomanNumeral(11))
				.When(_IsEvaluatedAgainst_, Op.GtE, new RomanNumeral(11))
				.Then(Is_, true)

			.WithScenario("one numeral is compared to NULL")
				.Given(TheRomanNumeral_, RomanNumeral.Zero)
				.When(_IsEvaluatedAgainst_, Op.Gt, (RomanNumeral)null)
				.Then(Is_, true)

				.WithScenario("NULL is compared to a numeral")
				.Given(TheRomanNumeral_, (RomanNumeral)null)
				.When(_IsEvaluatedAgainst_, Op.GtE, RomanNumeral.Zero)
				.Then(Is_, false)

			.ExecuteWithReport();
		}

		[Fact]
		public void LessThanRomanNumeral()
		{
			new Story("less than roman numeral")
				.InOrderTo("say that a numeral is less than another numeral")
				.AsA("library user")
				.IWant("apply a less than operator against another roman numeral")

			.WithScenario("one numeral is greater than another")
				.Given(TheRomanNumeral_, new RomanNumeral(5))
				.When(_IsEvaluatedAgainst_, Op.Lt, new RomanNumeral(1))
				.Then(Is_, false)

			.WithScenario("one numeral is less than another")
				.Given(TheRomanNumeral_, new RomanNumeral(1))
				.When(_IsEvaluatedAgainst_, Op.Lt, new RomanNumeral(10))
				.Then(Is_, true)

			.WithScenario("one numeral is equal to another")
				.Given(TheRomanNumeral_, new RomanNumeral(10))
				.When(_IsEvaluatedAgainst_, Op.Lt, new RomanNumeral(10))
				.Then(Is_, false)

			.WithScenario("one numeral is compared to NULL")
				.Given(TheRomanNumeral_, RomanNumeral.Zero)
				.When(_IsEvaluatedAgainst_, Op.Lt, (RomanNumeral)null)
				.Then(Is_, false)

				.WithScenario("NULL is compared to a numeral")
				.Given(TheRomanNumeral_, (RomanNumeral)null)
				.When(_IsEvaluatedAgainst_, Op.Lt, RomanNumeral.Zero)
				.Then(Is_, true)

			.ExecuteWithReport();
		}

		[Fact]
		public void LessThanOrEqualToRomanNumeral()
		{
			new Story("Lless than or equal to roman numeral")
				.InOrderTo("say that a numeral is less than or equal to another numeral")
				.AsA("library user")
				.IWant("apply a less than or equal operator against another roman numeral")

			.WithScenario("one numeral is greater than another")
				.Given(TheRomanNumeral_, new RomanNumeral(5))
				.When(_IsEvaluatedAgainst_, Op.LtE, new RomanNumeral(1))
				.Then(Is_, false)

			.WithScenario("one numeral is less than another")
				.Given(TheRomanNumeral_, new RomanNumeral(1))
				.When(_IsEvaluatedAgainst_, Op.LtE, new RomanNumeral(10))
				.Then(Is_, true)

			.WithScenario("one numeral is equal to another")
				.Given(TheRomanNumeral_, new RomanNumeral(10))
				.When(_IsEvaluatedAgainst_, Op.LtE, new RomanNumeral(10))
				.Then(Is_, true)

			.WithScenario("one numeral is compared to NULL")
				.Given(TheRomanNumeral_, RomanNumeral.Zero)
				.When(_IsEvaluatedAgainst_, Op.LtE, (RomanNumeral)null)
				.Then(Is_, false)

				.WithScenario("NULL is compared to a numeral")
				.Given(TheRomanNumeral_, (RomanNumeral)null)
				.When(_IsEvaluatedAgainst_, Op.LtE, RomanNumeral.Zero)
				.Then(Is_, true)

			.ExecuteWithReport();
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