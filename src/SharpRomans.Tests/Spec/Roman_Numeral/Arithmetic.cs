using System;
using System.Globalization;
using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Numeral
{
	[Category("Spec"), Category("RomanNumeral"), Category("Arithmetic")]
	[Collection("bddfy")]
	[Story(
		Title = "try parse a string",
		AsA = "library user",
		IWant = "use methods and operands on roman numeral instances",
		SoThat = "I can perform simple arithmetic operations"
	)]
	public class ArithmeticTester
	{
		[Fact]
		public void Addition()
		{
			this.WithTags("RomanNumeral", "Arithmetic", "Addition", "plus")
				.Given(_ => _.theRomanNumeral_(new RomanNumeral(20)))
				.When(_ => _.plus_(new RomanNumeral(11)))
				.Then(_ => _.theResultIs_(new RomanNumeral(31)))
				.And(_ => _.isNotDestructive())
				.BDDfy("bounded operation");

			this.WithTags("RomanNumeral", "Arithmetic", "Addition", "plus")
				.Given(_ => _.theRomanNumeral_(RomanNumeral.Max))
				.When(_ => _.plus_(new RomanNumeral(1)))
				.Then(_ => _.theResultOverflows())
				.BDDfy("overflowing operation");

			this.WithTags("RomanNumeral", "Arithmetic", "Addition", "plus")
				.Given(_ => _.theRomanNumeral_(new RomanNumeral(13)))
				.When(_ => _.plus_((RomanNumeral) null))
				.Then(_ => _.theResultIsTheSameAs_(_subject))
				.BDDfy("adding NULL");
		}

		[Fact]
		public void AdditionOperation()
		{
			this.WithTags("RomanNumeral", "Arithmetic", "Addition", "add")
				.Given(_ => _.theRomanNumeral_(new RomanNumeral(20)))
				.When(_ => _.added_(new RomanNumeral(11)))
				.Then(_ => _.theResultIs_(new RomanNumeral(31)))
				.And(_ => _.isNotDestructive())
				.BDDfy("bounded operation");

			this.WithTags("RomanNumeral", "Arithmetic", "Addition", "add")
				.Given(_ => _.theRomanNumeral_(RomanNumeral.Max))
				.When(_ => _.added_(new RomanNumeral(1)))
				.Then(_ => _.theResultOverflows())
				.BDDfy("overflowing operation");

			this.WithTags("RomanNumeral", "Arithmetic", "Addition", "add")
				.Given(_ => _.theRomanNumeral_(new RomanNumeral(13)))
				.When(_ => _.added_((RomanNumeral)null))
				.Then(_ => _.theResultIsTheSameAs_(_subject))
				.BDDfy("adding NULL to not NULL");

			this.WithTags("RomanNumeral", "Arithmetic", "Addition", "add")
				.Given(_ => _.theRomanNumeral_(null))
				.When(_ => _.added_(new RomanNumeral(13)))
				.Then(_ => _.theResultIsTheSameAs_(_operand))
				.BDDfy("adding not NULL to NULL");

			this.WithTags("RomanNumeral", "Arithmetic", "Addition", "add")
				.Given(_ => _.theRomanNumeral_(null))
				.When(_ => _.added_((RomanNumeral)null))
				.Then(_ => _.theResultIs_(null))
				.BDDfy("adding NULL to NULL");
		}

		[Fact]
		public void RomanFigureAddition()
		{
			this.WithTags("RomanNumeral", "Arithmetic", "Addition", "plus figure")
				.Given(_ => _.theRomanNumeral_(new RomanNumeral(20)))
				.When(_ => _.plus_(RomanFigure.V))
				.Then(_ => _.theResultIs_(new RomanNumeral(25)))
				.And(_ => _.isNotDestructive())
				.BDDfy("bounded operation");

			this.WithTags("RomanNumeral", "Arithmetic", "Addition", "plus figure")
				.Given(_ => _.theRomanNumeral_(RomanNumeral.Max))
				.When(_ => _.plus_(RomanFigure.I))
				.Then(_ => _.theResultOverflows())
				.BDDfy("overflowing operation");

			this.WithTags("RomanNumeral", "Arithmetic", "Addition", "plus figure")
				.Given(_ => _.theRomanNumeral_(new RomanNumeral(13)))
				.When(_ => _.plus_((RomanFigure)null))
				.Then(_ => _.theResultIsTheSameAs_(_subject))
				.BDDfy("adding NULL");
		}

		[Fact]
		public void RomanFigureAdditionOperation()
		{
			this.WithTags("RomanNumeral", "Arithmetic", "Addition", "add figure")
				.Given(_ => _.theRomanNumeral_(new RomanNumeral(20)))
				.When(_ => _.added_(RomanFigure.V))
				.Then(_ => _.theResultIs_(new RomanNumeral(25)))
				.And(_ => _.isNotDestructive())
				.BDDfy("bounded operation");

			this.WithTags("RomanNumeral", "Arithmetic", "Addition", "add figure")
				.Given(_ => _.theRomanNumeral_(RomanNumeral.Max))
				.When(_ => _.added_(RomanFigure.I))
				.Then(_ => _.theResultOverflows())
				.BDDfy("overflowing operation");

			this.WithTags("RomanNumeral", "Arithmetic", "Addition", "add figure")
				.Given(_ => _.theRomanNumeral_(new RomanNumeral(13)))
				.When(_ => _.added_((RomanFigure)null))
				.Then(_ => _.theResultIsTheSameAs_(_subject))
				.BDDfy("adding NULL to not NULL");

			this.WithTags("RomanNumeral", "Arithmetic", "Addition", "add figure")
				.Given(_ => _.theRomanNumeral_(null))
				.When(_ => _.added_(RomanFigure.V))
				.Then(_ => _.theResultIs_(new RomanNumeral(5)))
				.BDDfy("adding not NULL to NULL");

			this.WithTags("RomanNumeral", "Arithmetic", "Addition", "add figure")
				.Given(_ => _.theRomanNumeral_(null))
				.When(_ => _.added_((RomanFigure)null))
				.Then(_ => _.theResultIs_(null))
				.BDDfy("adding NULL to NULL");
		}

		[Fact]
		public void Substraction()
		{
			this.WithTags("RomanNumeral", "Arithmetic", "Substraction", "minus")
				.Given(_ => _.theRomanNumeral_(new RomanNumeral(20)))
				.When(_ => _.minus_(new RomanNumeral(11)))
				.Then(_ => _.theResultIs_(new RomanNumeral(9)))
				.And(_ => _.isNotDestructive())
				.BDDfy("bounded operation");

			this.WithTags("RomanNumeral", "Arithmetic", "Substraction", "minus")
				.Given(_ => _.theRomanNumeral_(RomanNumeral.Min))
				.When(_ => _.minus_(new RomanNumeral(1)))
				.Then(_ => _.theResultOverflows())
				.BDDfy("overflowing operation");

			this.WithTags("RomanNumeral", "Arithmetic", "Substraction", "minus")
				.Given(_ => _.theRomanNumeral_(new RomanNumeral(13)))
				.When(_ => _.minus_((RomanNumeral)null))
				.Then(_ => _.theResultIsTheSameAs_(_subject))
				.BDDfy("substracting NULL");
		}

		[Fact]
		public void SubstractionOperation()
		{
			this.WithTags("RomanNumeral", "Arithmetic", "Substraction", "substract")
				.Given(_ => _.theRomanNumeral_(new RomanNumeral(20)))
				.When(_ => _.substracted_(new RomanNumeral(11)))
				.Then(_ => _.theResultIs_(new RomanNumeral(9)))
				.And(_ => _.isNotDestructive())
				.BDDfy("bounded operation");

			this.WithTags("RomanNumeral", "Arithmetic", "Substraction", "substract")
				.Given(_ => _.theRomanNumeral_(RomanNumeral.Min))
				.When(_ => _.substracted_(new RomanNumeral(1)))
				.Then(_ => _.theResultOverflows())
				.BDDfy("overflowing operation");

			this.WithTags("RomanNumeral", "Arithmetic", "Substraction", "substract")
				.Given(_ => _.theRomanNumeral_(new RomanNumeral(13)))
				.When(_ => _.substracted_((RomanNumeral)null))
				.Then(_ => _.theResultIsTheSameAs_(_subject))
				.BDDfy("substracting NULL to not NULL");

			this.WithTags("RomanNumeral", "Arithmetic", "Substraction", "substract")
				.Given(_ => _.theRomanNumeral_(null))
				.When(_ => _.substracted_(new RomanNumeral(13)))
				.Then(_ => _.theResultIsTheSameAs_(_operand))
				.BDDfy("substracting not NULL to NULL");

			this.WithTags("RomanNumeral", "Arithmetic", "Substraction", "substract")
				.Given(_ => _.theRomanNumeral_(null))
				.When(_ => _.substracted_((RomanNumeral)null))
				.Then(_ => _.theResultIs_(null))
				.BDDfy("substracting NULL to NULL");
		}

		[Fact]
		public void RomanFigureSubstraction()
		{
			this.WithTags("RomanNumeral", "Arithmetic", "Substraction", "minus figure")
				.Given(_ => _.theRomanNumeral_(new RomanNumeral(20)))
				.When(_ => _.minus_(RomanFigure.V))
				.Then(_ => _.theResultIs_(new RomanNumeral(15)))
				.And(_ => _.isNotDestructive())
				.BDDfy("bounded operation");

			this.WithTags("RomanNumeral", "Arithmetic", "Substraction", "minus figure")
				.Given(_ => _.theRomanNumeral_(RomanNumeral.Min))
				.When(_ => _.minus_(RomanFigure.I))
				.Then(_ => _.theResultOverflows())
				.BDDfy("overflowing operation");

			this.WithTags("RomanNumeral", "Arithmetic", "Substraction", "minus figure")
				.Given(_ => _.theRomanNumeral_(new RomanNumeral(13)))
				.When(_ => _.minus_((RomanFigure)null))
				.Then(_ => _.theResultIsTheSameAs_(_subject))
				.BDDfy("substracting NULL");
		}

		[Fact]
		public void RomanFigureSubstractionOperation()
		{
			this.WithTags("RomanNumeral", "Arithmetic", "Substraction", "substract figure")
				.Given(_ => _.theRomanNumeral_(new RomanNumeral(20)))
				.When(_ => _.substracted_(RomanFigure.V))
				.Then(_ => _.theResultIs_(new RomanNumeral(15)))
				.And(_ => _.isNotDestructive())
				.BDDfy("bounded operation");

			this.WithTags("RomanNumeral", "Arithmetic", "Substraction", "substract figure")
				.Given(_ => _.theRomanNumeral_(RomanNumeral.Min))
				.When(_ => _.substracted_(RomanFigure.I))
				.Then(_ => _.theResultOverflows())
				.BDDfy("overflowing operation");

			this.WithTags("RomanNumeral", "Arithmetic", "Substraction", "substract figure")
				.Given(_ => _.theRomanNumeral_(new RomanNumeral(13)))
				.When(_ => _.substracted_((RomanFigure)null))
				.Then(_ => _.theResultIsTheSameAs_(_subject))
				.BDDfy("substracting NULL from not NULL");

			this.WithTags("RomanNumeral", "Arithmetic", "Substraction", "substract figure")
				.Given(_ => _.theRomanNumeral_(null))
				.When(_ => _.substracted_(RomanFigure.V))
				.Then(_ => _.theResultIs_(new RomanNumeral(5)))
				.BDDfy("substracting not NULL to NULL");

			this.WithTags("RomanNumeral", "Arithmetic", "Substraction", "substract figure")
				.Given(_ => _.theRomanNumeral_(null))
				.When(_ => _.substracted_((RomanFigure)null))
				.Then(_ => _.theResultIs_(null))
				.BDDfy("substracting NULL to NULL");
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

		private void theResultIsTheSameAs_(IValuable same)
		{
			Assert.Same(same, _operation());
		}
	}
}