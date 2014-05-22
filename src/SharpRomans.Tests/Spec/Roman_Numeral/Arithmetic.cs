using System;
using System.Globalization;
using NUnit.Framework;
using StoryQ;

namespace SharpRomans.Tests.Spec.Roman_Numeral
{
	[TestFixture, Category("Spec"), Category("RomanNumeral"), Category("Arithmetic")]
	public class ArithmeticTester
	{
		[Test]
		public void Addition()
		{
			new Story("arithmetic addition")
				.InOrderTo("calculate the value of adding one roman numeral to another roman numeral")
				.AsA("library user")
				.IWant("to use an instance method on a roman numeral")

				.WithScenario("bounded operation")
					.Given(theRomanNumeral_, new RomanNumeral(20))
					.When(plus_, new RomanNumeral(11))
					.Then(theResultIs_, new RomanNumeral(31))
					.And(isNotDestructive)

				.WithScenario("overflowing operation")
					.Given(theRomanNumeral_, RomanNumeral.Max)
					.When(plus_, new RomanNumeral(1))
					.Then(theResultOverflows)

				.WithScenario("adding NULL")
					.Given(theRomanNumeral_, new RomanNumeral(13))
					.When(plus_, (RomanNumeral)null)
					.Then(theResultIsTheSameAs_, new Func<RomanNumeral>(() => _subject))

				.ExecuteWithReport();
		}

		[Test]
		public void AdditionOperation()
		{
			new Story("arithmetic addition")
				.InOrderTo("calculate the value of adding one roman numeral to another roman numeral")
				.AsA("library user")
				.IWant("to use an operator")

				.WithScenario("bounded operation")
					.Given(theRomanNumeral_, new RomanNumeral(20))
					.When(added_, new RomanNumeral(11))
					.Then(theResultIs_, new RomanNumeral(31))
					.And(isNotDestructive)

				.WithScenario("overflowing operation")
					.Given(theRomanNumeral_, RomanNumeral.Max)
					.When(added_, new RomanNumeral(1))
					.Then(theResultOverflows)

				.WithScenario("adding NULL to not NULL")
					.Given(theRomanNumeral_, new RomanNumeral(13))
					.When(added_, (RomanNumeral)null)
					.Then(theResultIsTheSameAs_, new Func<IValuable>(() => _subject))

				.WithScenario("adding not NULL to NULL")
					.Given(theRomanNumeral_, (RomanNumeral)null)
					.When(added_, new RomanNumeral(13))
					.Then(theResultIsTheSameAs_, new Func<IValuable>(() => _operand))

				.WithScenario("adding NULL to NULL")
					.Given(theRomanNumeral_, (RomanNumeral)null)
					.When(added_, (RomanNumeral)null)
					.Then(theResultIs_, (RomanNumeral)null)

				.ExecuteWithReport();
		}

		[Test]
		public void RomanFigureAddition()
		{
			new Story("arithmetic addition")
				.InOrderTo("calculate the value of adding a roman figure to a roman numeral")
				.AsA("library user")
				.IWant("to use an instance method on a roman numeral")

				.WithScenario("bounded operation")
					.Given(theRomanNumeral_, new RomanNumeral(20))
					.When(plus_, RomanFigure.V)
					.Then(theResultIs_, new RomanNumeral(25))
					.And(isNotDestructive)

				.WithScenario("overflowing operation")
					.Given(theRomanNumeral_, RomanNumeral.Max)
					.When(plus_, RomanFigure.I)
					.Then(theResultOverflows)

				.WithScenario("adding NULL")
					.Given(theRomanNumeral_, new RomanNumeral(13))
					.When(plus_, (RomanFigure)null)
					.Then(theResultIsTheSameAs_, new Func<RomanNumeral>(() => _subject))

				.ExecuteWithReport();
		}

		[Test]
		public void RomanFigureAdditionOperation()
		{
			new Story("arithmetic addition")
				.InOrderTo("calculate the value of adding a roman figure to a roman numeral")
				.AsA("library user")
				.IWant("to use an operator")

				.WithScenario("bounded operation")
					.Given(theRomanNumeral_, new RomanNumeral(20))
					.When(added_, RomanFigure.V)
					.Then(theResultIs_, new RomanNumeral(25))
					.And(isNotDestructive)

				.WithScenario("overflowing operation")
					.Given(theRomanNumeral_, RomanNumeral.Max)
					.When(added_, RomanFigure.I)
					.Then(theResultOverflows)

				.WithScenario("adding NULL to not NULL")
					.Given(theRomanNumeral_, new RomanNumeral(13))
					.When(added_, (RomanFigure)null)
					.Then(theResultIsTheSameAs_, new Func<RomanNumeral>(() => _subject))

				.WithScenario("adding not NULL to NULL")
					.Given(theRomanNumeral_, (RomanNumeral)null)
					.When(added_, RomanFigure.V)
					.Then(theResultIs_, new RomanNumeral(5))

				.WithScenario("adding NULL to NULL")
					.Given(theRomanNumeral_, (RomanNumeral)null)
					.When(added_, (RomanFigure)null)
					.Then(theResultIs_, (RomanNumeral)null)

				.ExecuteWithReport();
		}

		[Test]
		public void Substraction()
		{
			new Story("arithmetic substraction")
				.InOrderTo("calculate the value of substracting one roman numeral from another roman numeral")
				.AsA("library user")
				.IWant("to use an instance method on a roman numeral")

				.WithScenario("bounded operation")
					.Given(theRomanNumeral_, new RomanNumeral(20))
					.When(minus_, new RomanNumeral(11))
					.Then(theResultIs_, new RomanNumeral(9))
					.And(isNotDestructive)

				.WithScenario("overflowing operation")
					.Given(theRomanNumeral_, RomanNumeral.Min)
					.When(minus_, new RomanNumeral(1))
					.Then(theResultOverflows)

				.WithScenario("substracting NULL")
					.Given(theRomanNumeral_, new RomanNumeral(13))
					.When(minus_, (RomanNumeral)null)
					.Then(theResultIsTheSameAs_, new Func<RomanNumeral>(() => _subject))

				.ExecuteWithReport();
		}

		RomanNumeral _subject;
		private void theRomanNumeral_(RomanNumeral subject)
		{
			_subject = subject;
		}

		private Func<RomanNumeral> _operation;
		private IValuable _operand;
		private void plus_(RomanNumeral operand)
		{
			_operand = operand;
			_operation = () => _subject.Plus(operand);
		}

		private void added_(RomanNumeral operand)
		{
			_operand = operand;
			_operation = () => _subject + operand;
		}

		private void plus_(RomanFigure operand)
		{
			_operand = operand;
			_operation = () => _subject.Plus(operand);
		}

		private void added_(RomanFigure operand)
		{
			_operand = operand;
			_operation = () => _subject + operand;
		}

		private void minus_(RomanNumeral operand)
		{
			_operand = operand;
			_operation = () => _subject.Minus(operand);
		}

		private RomanNumeral _result;
		private void theResultIs_(RomanNumeral result)
		{
			_result = result;
			Assert.That(_operation(), Is.EqualTo(result));
		}

		private void isNotDestructive()
		{
			Assert.That(_subject, Is.Not.SameAs(_result).And.Not.EqualTo(_result));
			Assert.That(_operand, Is.Not.SameAs(_result).And.Not.EqualTo(_result));
		}

		private void theResultOverflows()
		{
			TestDelegate operation = () => _operation();
			Assert.That(operation, Throws.InstanceOf<NumeralOutOfRangeException>()
				.And.Message.StringContaining(RomanNumeral.MinValue.ToString(CultureInfo.InvariantCulture))
				.And.Message.StringContaining(RomanNumeral.MaxValue.ToString(CultureInfo.InvariantCulture)));
		}

		// TODO: implement pretty print of expression
		private void theResultIsTheSameAs_(Func<IValuable> same)
		{
			Assert.That(_operation(), Is.SameAs(same()));
		}
	}
}