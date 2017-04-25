using System;
using System.Globalization;
using SharpRomans.Tests.Support;
using StoryQ;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Numeral
{
	[Category("Spec"), Category("RomanNumeral"), Category("Arithmetic")]
	public class ArithmeticTester
	{
		[Fact]
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

		[Fact]
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

		[Fact]
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

		[Fact]
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

		[Fact]
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

		[Fact]
		public void SubstractionOperation()
		{
			new Story("arithmetic substraction")
				.InOrderTo("calculate the value of substracting one roman numeral from another roman numeral")
				.AsA("library user")
				.IWant("to use an operator")

				.WithScenario("bounded operation")
					.Given(theRomanNumeral_, new RomanNumeral(20))
					.When(substracted_, new RomanNumeral(11))
					.Then(theResultIs_, new RomanNumeral(9))
					.And(isNotDestructive)

				.WithScenario("overflowing operation")
					.Given(theRomanNumeral_, RomanNumeral.Min)
					.When(substracted_, new RomanNumeral(1))
					.Then(theResultOverflows)

				.WithScenario("substracting NULL to not NULL")
					.Given(theRomanNumeral_, new RomanNumeral(13))
					.When(substracted_, (RomanNumeral)null)
					.Then(theResultIsTheSameAs_, new Func<IValuable>(() => _subject))

				.WithScenario("substracting not NULL to NULL")
					.Given(theRomanNumeral_, (RomanNumeral)null)
					.When(substracted_, new RomanNumeral(13))
					.Then(theResultIsTheSameAs_, new Func<IValuable>(() => _operand))

				.WithScenario("substracting NULL to NULL")
					.Given(theRomanNumeral_, (RomanNumeral)null)
					.When(substracted_, (RomanNumeral)null)
					.Then(theResultIs_, (RomanNumeral)null)

				.ExecuteWithReport();
		}

		[Fact]
		public void RomanFigureSubstraction()
		{
			new Story("arithmetic addition")
				.InOrderTo("calculate the value of substracting a roman figure from a roman numeral")
				.AsA("library user")
				.IWant("to use an instance method on a roman numeral")

				.WithScenario("bounded operation")
					.Given(theRomanNumeral_, new RomanNumeral(20))
					.When(minus_, RomanFigure.V)
					.Then(theResultIs_, new RomanNumeral(15))
					.And(isNotDestructive)

				.WithScenario("overflowing operation")
					.Given(theRomanNumeral_, RomanNumeral.Min)
					.When(minus_, RomanFigure.I)
					.Then(theResultOverflows)

				.WithScenario("substracting NULL")
					.Given(theRomanNumeral_, new RomanNumeral(13))
					.When(minus_, (RomanFigure)null)
					.Then(theResultIsTheSameAs_, new Func<IValuable>(() => _subject))

				.ExecuteWithReport();
		}

		[Fact]
		public void RomanFigureSubstractionOperation()
		{
			new Story("arithmetic addition")
				.InOrderTo("calculate the value of substracting a roman figure from a roman numeral")
				.AsA("library user")
				.IWant("to use an operator")

				.WithScenario("bounded operation")
					.Given(theRomanNumeral_, new RomanNumeral(20))
					.When(substracted_, RomanFigure.V)
					.Then(theResultIs_, new RomanNumeral(15))
					.And(isNotDestructive)

				.WithScenario("overflowing operation")
					.Given(theRomanNumeral_, RomanNumeral.Min)
					.When(substracted_, RomanFigure.I)
					.Then(theResultOverflows)

				.WithScenario("substracting NULL from not NULL")
					.Given(theRomanNumeral_, new RomanNumeral(13))
					.When(substracted_, (RomanFigure)null)
					.Then(theResultIsTheSameAs_, new Func<IValuable>(() => _subject))

				.WithScenario("substracting not NULL to NULL")
					.Given(theRomanNumeral_, (RomanNumeral)null)
					.When(substracted_, RomanFigure.V)
					.Then(theResultIs_, new RomanNumeral(5))

				.WithScenario("substracting NULL to NULL")
					.Given(theRomanNumeral_, (RomanNumeral)null)
					.When(substracted_, (RomanFigure)null)
					.Then(theResultIs_, (RomanNumeral)null)

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

		private void substracted_(RomanNumeral operand)
		{
			_operand = operand;
			_operation = () => _subject - operand;
		}

		private void minus_(RomanFigure operand)
		{
			_operand = operand;
			_operation = () => _subject.Minus(operand);
		}

		private void substracted_(RomanFigure operand)
		{
			_operand = operand;
			_operation = () => _subject - operand;
		}

		private RomanNumeral _result;
		private void theResultIs_(RomanNumeral result)
		{
			_result = result;
			Assert.Equal(result, _operation());
		}

		private void isNotDestructive()
		{
			Assert.NotSame(_result, _subject);
			Assert.NotEqual(_result, _subject);

			Assert.NotSame(_result, _operand);
			Assert.NotEqual(_result, _operand);
		}

		private void theResultOverflows()
		{
			var ex = Assert.ThrowsAny<NumeralOutOfRangeException>(_operation);
			Assert.Contains(RomanNumeral.MinValue.ToString(CultureInfo.InvariantCulture), ex.Message);
			Assert.Contains(RomanNumeral.MaxValue.ToString(CultureInfo.InvariantCulture), ex.Message);
		}

		// TODO: implement pretty print of expression
		private void theResultIsTheSameAs_(Func<IValuable> same)
		{
			Assert.Same(same(), _operation());
		}
	}
}