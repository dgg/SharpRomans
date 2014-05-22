using NUnit.Framework;
using StoryQ;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[TestFixture, Category("Spec"), Category("RomanFigure")]
	public class EqualityTester
	{
		[Test]
		public void NonGenericEquals()
		{
			new Story("non generic equatable")
				.InOrderTo("say that an object is equal to a roman figure")
				.AsA("library user")
				.IWant("to use .Equals() against an object")

			.WithScenario("a roman figure is compared against a boxed char with the same value")
				.Given(TheRomanFigure_, RomanFigure.V)
				.When(ComparedTo_, (object)'V')
				.Then(Is_, false)

			.WithScenario("a roman figure is compared against a boxed char with a different value")
				.Given(TheRomanFigure_, RomanFigure.V)
				.When(ComparedTo_, (object)'X')
				.Then(Is_, false)

			.WithScenario("a roman figure is compared against a boxed number with the same value")
				.Given(TheRomanFigure_, RomanFigure.V)
				.When(ComparedTo_, (object)((ushort)5))
				.Then(Is_, false)

			.WithScenario("a roman figure is compared against a boxed number with a different value")
				.Given(TheRomanFigure_, RomanFigure.V)
				.When(ComparedTo_, (object)((ushort)10))
				.Then(Is_, false)

			.WithScenario("a roman figure is compared against the same objectified figure")
				.Given(TheRomanFigure_, RomanFigure.V)
				.When(ComparedTo_, (object)RomanFigure.V)
				.Then(Is_, true)

			.WithScenario("a roman figure is compared against another objectified figure")
				.Given(TheRomanFigure_, RomanFigure.V)
				.When(ComparedTo_, (object)RomanFigure.X)
				.Then(Is_, false)

			.WithScenario("a roman figure is compared against null")
				.Given(TheRomanFigure_, RomanFigure.V)
				.When(ComparedTo_, (object)null)
				.Then(Is_, false)

			.WithScenario("a roman figure is compared against a boxed lowercase char with the same value")
				.Given(TheRomanFigure_, RomanFigure.V)
				.When(ComparedTo_, (object)'v')
				.Then(Is_, false)

			.WithScenario("a roman figure is compared against a boxed int with the same value")
				.Given(TheRomanFigure_, RomanFigure.V)
				.When(ComparedTo_, (object)5)
				.Then(Is_, false)

			.ExecuteWithReport();
		}

		[Test]
		public void EquatableToRomanFigure()
		{
			new Story("equatable to roman figure")
				.InOrderTo("say that a figure is equal to another figure")
				.AsA("library user")
				.IWant("to use IEquatable<RomanFigure> methods against a roman figure")

			.WithScenario("a roman figure is compared against the same roman figure")
				.Given(TheRomanFigure_, RomanFigure.V)
				.When(ComparedTo_, RomanFigure.V)
				.Then(Is_, true)

			.WithScenario("a roman figure is compared against not the same roman figure")
				.Given(TheRomanFigure_, RomanFigure.V)
				.When(ComparedTo_, RomanFigure.X)
				.Then(Is_, false)

			.WithScenario("a roman figure is compared against null")
				.Given(TheRomanFigure_, RomanFigure.V)
				.When(ComparedTo_, (RomanFigure)null)
				.Then(Is_, false)

			.ExecuteWithReport();
		}

		[Test]
		public void EqualToRomanFigure()
		{
			new Story("equality to roman figure")
				.InOrderTo("say that a figure is equal to another figure")
				.AsA("library user")
				.IWant("to use the equality operator against a roman figure")

			.WithScenario("a roman figure is compared against the same roman figure")
				.Given(TheRomanFigure_, RomanFigure.V)
				.When(EqualTo_, RomanFigure.Convert(5))
				.Then(Is_, true)

			.WithScenario("a roman figure is compared against not the same roman figure")
				.Given(TheRomanFigure_, RomanFigure.V)
				.When(EqualTo_, RomanFigure.X)
				.Then(Is_, false)

			.WithScenario("a roman figure is compared against null")
				.Given(TheRomanFigure_, RomanFigure.V)
				.When(EqualTo_, (RomanFigure)null)
				.Then(Is_, false)

			.WithScenario("null is compared against a roman figure")
				.Given(TheRomanFigure_, (RomanFigure)null)
				.When(EqualTo_, RomanFigure.X)
				.Then(Is_, false)

			.WithScenario("null is compared against null")
				.Given(TheRomanFigure_, (RomanFigure)null)
				.When(EqualTo_, (RomanFigure)null)
				.Then(Is_, true)

			.ExecuteWithReport();
		}

		[Test]
		public void NotEqualToRomanFigure()
		{
			new Story("inequality to roman figure")
				.InOrderTo("say that a figure is not equal to another figure")
				.AsA("library user")
				.IWant("to use the inequality operator against a roman figure")

			.WithScenario("a roman figure is compared against the same roman figure")
				.Given(TheRomanFigure_, RomanFigure.V)
				.When(NotEqualTo_, RomanFigure.V)
				.Then(Is_, false)

			.WithScenario("a roman figure is compared against not the same roman figure")
				.Given(TheRomanFigure_, RomanFigure.V)
				.When(NotEqualTo_, RomanFigure.X)
				.Then(Is_, true)

			.WithScenario("a roman figure is compared against null")
				.Given(TheRomanFigure_, RomanFigure.V)
				.When(NotEqualTo_, (RomanFigure)null)
				.Then(Is_, true)

			.WithScenario("null is compared against a roman figure")
				.Given(TheRomanFigure_, (RomanFigure)null)
				.When(NotEqualTo_, RomanFigure.X)
				.Then(Is_, true)

			.WithScenario("null is compared against null")
				.Given(TheRomanFigure_, (RomanFigure)null)
				.When(NotEqualTo_, (RomanFigure)null)
				.Then(Is_, false)

			.ExecuteWithReport();
		}

		private RomanFigure _subject;
		private void TheRomanFigure_(RomanFigure figure)
		{
			_subject = figure;
		}

		private bool _operation;
		private void ComparedTo_(object o)
		{
			_operation = _subject.Equals(o);
		}

		private void ComparedTo_(RomanFigure anotherFigure)
		{
			_operation = _subject.Equals(anotherFigure);
		}

		private void EqualTo_(RomanFigure anotherFigure)
		{
			_operation = _subject == anotherFigure;
		}

		private void NotEqualTo_(RomanFigure anotherFigure)
		{
			_operation = _subject != anotherFigure;
		}

		private void Is_(bool result)
		{
			Assert.That(_operation, Is.EqualTo(result));
		}
	}
}