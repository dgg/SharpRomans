using NUnit.Framework;
using StoryQ;

namespace SharpRomans.Tests.Spec.Roman_Numeral
{
	[TestFixture, Category("Spec"), Category("RomanNumeral"), Category("Equality")]
	public class EqualityTester
	{
		[Test]
		public void NonGenericEquals()
		{
			new Story("non generic equals")
				.InOrderTo("say that an object is equal to a roman numeral")
				.AsA("library user")
				.IWant("to use .Equals() against an object")

			.WithScenario("a roman numeral is compared against a boxed short with the same value")
				.Given(TheRomanNumeral_, new RomanNumeral(5))
				.When(ComparedTo_, (object)((short)5))
				.Then(Is_, false)

			.WithScenario("a roman numeral is compared against a boxed short with a different value")
				.Given(TheRomanNumeral_, new RomanNumeral(5))
				.When(ComparedTo_, (object)((short)10))
				.Then(Is_, false)

			.WithScenario("a roman numeral is compared against the same objectified numeral")
				.Given(TheRomanNumeral_, new RomanNumeral(5))
				.When(ComparedTo_, (object)new RomanNumeral(5))
				.Then(Is_, true)

			.WithScenario("a roman numeral is compared against another objectified numeral")
				.Given(TheRomanNumeral_, new RomanNumeral(5))
				.When(ComparedTo_, (object)new RomanNumeral(10))
				.Then(Is_, false)

			.WithScenario("a roman numeral is compared against the same objectified figure")
				.Given(TheRomanNumeral_, new RomanNumeral(5))
				.When(ComparedTo_, (object)RomanFigure.V)
				.Then(Is_, false)

			.WithScenario("a roman numeral is compared against another objectified figure")
				.Given(TheRomanNumeral_, new RomanNumeral(5))
				.When(ComparedTo_, (object)RomanFigure.C)
				.Then(Is_, false)

			.WithScenario("a roman numeral is compared against null")
				.Given(TheRomanNumeral_, new RomanNumeral(5))
				.When(ComparedTo_, (object)null)
				.Then(Is_, false)

			.WithScenario("a roman numeral is compared against a boxed int with the same value")
				.Given(TheRomanNumeral_, new RomanNumeral(5))
				.When(ComparedTo_, (object)5)
				.Then(Is_, false)

			.ExecuteWithReport();
		}

		[Test]
		public void EquatableToRomanNumeral()
		{
			new Story("equatable to roman numeral")
				.InOrderTo("say that a numeral is equal to another numeral")
				.AsA("library user")
				.IWant("to use IEquatable<RomanNumeral> methods against a roman numeral")

			.WithScenario("a roman numeral is compared against the same roman numeral")
				.Given(TheRomanNumeral_, new RomanNumeral(5))
				.When(ComparedTo_, new RomanNumeral(5))
				.Then(Is_, true)

			.WithScenario("a roman numeral is compared against not the same roman numeral")
				.Given(TheRomanNumeral_, new RomanNumeral(5))
				.When(ComparedTo_, new RomanNumeral(15))
				.Then(Is_, false)

			.WithScenario("a roman numeral is compared against null")
				.Given(TheRomanNumeral_, new RomanNumeral(5))
				.When(ComparedTo_, (RomanNumeral)null)
				.Then(Is_, false)

			.ExecuteWithReport();
		}

		[Test]
		public void EqualToRomanNumeral()
		{
			new Story("equality to roman numeral")
				.InOrderTo("say that a numeral is equal to another numeral")
				.AsA("library user")
				.IWant("to use the equality operator against a roman numeral")

			.WithScenario("a roman numeral is compared against the same roman numeral")
				.Given(TheRomanNumeral_, new RomanNumeral(5))
				.When(EqualTo_, new RomanNumeral(5))
				.Then(Is_, true)

			.WithScenario("a roman numeral is compared against not the same roman numeral")
				.Given(TheRomanNumeral_, new RomanNumeral(5))
				.When(EqualTo_, new RomanNumeral(15))
				.Then(Is_, false)

			.WithScenario("a roman numeral is compared against null")
				.Given(TheRomanNumeral_, RomanNumeral.Zero)
				.When(EqualTo_, (RomanNumeral)null)
				.Then(Is_, false)

			.WithScenario("null is compared against a roman numeral")
				.Given(TheRomanNumeral_, (RomanNumeral)null)
				.When(EqualTo_, RomanNumeral.Zero)
				.Then(Is_, false)

			.WithScenario("null is compared against null")
				.Given(TheRomanNumeral_, (RomanNumeral)null)
				.When(EqualTo_, (RomanNumeral)null)
				.Then(Is_, true)

			.ExecuteWithReport();
		}

		[Test]
		public void NotEqualToRomanNumeral()
		{
			new Story("inequality to roman numeral")
				.InOrderTo("say that a numeral is not equal to another numeral")
				.AsA("library user")
				.IWant("to use the inequality operator against a roman numeral")

			.WithScenario("a roman numeral is compared against the same roman numeral")
				.Given(TheRomanNumeral_, new RomanNumeral(5))
				.When(NotEqualTo_, new RomanNumeral(5))
				.Then(Is_, false)

			.WithScenario("a roman numeral is compared against not the same roman numeral")
				.Given(TheRomanNumeral_, new RomanNumeral(5))
				.When(NotEqualTo_, new RomanNumeral(15))
				.Then(Is_, true)

			.WithScenario("a roman numeral is compared against null")
				.Given(TheRomanNumeral_, new RomanNumeral(5))
				.When(NotEqualTo_, (RomanNumeral)null)
				.Then(Is_, true)

			.WithScenario("null is compared against a roman numeral")
				.Given(TheRomanNumeral_, (RomanNumeral)null)
				.When(NotEqualTo_, new RomanNumeral(5))
				.Then(Is_, true)

			.WithScenario("null is compared against null")
				.Given(TheRomanNumeral_, (RomanNumeral)null)
				.When(NotEqualTo_, (RomanNumeral)null)
				.Then(Is_, false)

			.ExecuteWithReport();
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
			Assert.That(_operation, Is.EqualTo(result));
		}
	}
}