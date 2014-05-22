using System;
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

		RomanNumeral _subject;
		private void theRomanNumeral_(RomanNumeral subject)
		{
			_subject = subject;
		}

		private Func<RomanNumeral> _addition;
		private RomanNumeral _operand;
		private void plus_(RomanNumeral operand)
		{
			_operand = operand;
			_addition = () => _subject.Plus(operand);
		}

		private RomanNumeral _result;
		private void theResultIs_(RomanNumeral result)
		{
			_result = result;
			Assert.That(_addition(), Is.EqualTo(result));
		}

		private void isNotDestructive()
		{
			Assert.That(_subject, Is.Not.SameAs(_result).And.Not.EqualTo(_result));
			Assert.That(_operand, Is.Not.SameAs(_result).And.Not.EqualTo(_result));
		}

		private void theResultOverflows()
		{
			TestDelegate operation = () => _addition();
			Assert.That(operation, Throws.InstanceOf<NumeralOutOfRangeException>()
				.And.Message.StringContaining(RomanNumeral.MinValue.ToString())
				.And.Message.StringContaining(RomanNumeral.MaxValue.ToString()));
		}

		private void theResultIsTheSameAs_(Func<RomanNumeral> same)
		{
			Assert.That(_addition(), Is.SameAs(same()));
		}
	}
}