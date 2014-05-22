using NUnit.Framework;
using StoryQ;

namespace SharpRomans.Tests.Spec.Roman_Numeral
{
	[TestFixture, Category("Spec"), Category("RomanNumeral"), Category("Figures")]
	public class ComparisonsTester
	{
		[Test]
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

		private void IsGreaterThanZero()
		{
			Assert.That(_comparison, Is.GreaterThan(0));
		}

		private void IsZero()
		{
			Assert.That(_comparison, Is.EqualTo(0));
		}

		private void IsLessThanZero()
		{
			Assert.That(_comparison, Is.LessThan(0));
		}
	}
}