using System;
using System.Globalization;
using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Numeral
{
	[Category("Spec"), Category("RomanNumeral"), Category("Boundaries")]
	[Story(
		Title = "roman numerals boundaries",
		AsA = "library user",
		IWant = "to be able to invoke methods taking the arabic number a argument",
		SoThat = "I can verify whether an arabic numeral can be converted into a roman numeral"
	)]
	public class BoundariesTester
	{
		[Fact]
		public void Boundaries()
		{
			this.WithTags("RomanNumeral", "Boundaries")
				.Given(_ => _.anArabicNumeral_(20))
				.When(_ => _.theNumeralIsChecked())
				.Then(_ => _.theResultIs_(true))
				.BDDfy("check a number in range");

			this.WithTags("RomanNumeral", "Boundaries")
				.Given(_ => _.anArabicNumeral_(-1))
				.When(_ => _.theNumeralIsChecked())
				.Then(_ => _.theResultIs_(false))
				.BDDfy("check a negative number");

			this.WithTags("RomanNumeral", "Boundaries")
				.Given(_ => _.anArabicNumeral_(4001))
				.When(_ => _.theNumeralIsChecked())
				.Then(_ => _.theResultIs_(false))
				.BDDfy("check an overflowing number");

			this.WithTags("RomanNumeral", "Boundaries")
				.Given(_ => _.anArabicNumeral_(20))
				.When(_ => _.theNumeralIsAsserted())
				.Then(_ => _.noExceptionIsRaised())
				.BDDfy("assert a number in range");

			this.WithTags("RomanNumeral", "Boundaries")
				.Given(_ => _.anArabicNumeral_(-1))
				.When(_ => _.theNumeralIsAsserted())
				.Then(_ => _.aRangeExceptionIsThrown())
				.BDDfy("assert a negative number");

			this.WithTags("RomanNumeral", "Boundaries")
				.Given(_ => _.anArabicNumeral_(4001))
				.When(_ => _.theNumeralIsAsserted())
				.Then(_ => _.aRangeExceptionIsThrown())
				.BDDfy("assert an overflowing number");
		}

		ushort _number;
		private void anArabicNumeral_(int number)
		{
			_number = (ushort)number;
		}

		bool _check;
		private void theNumeralIsChecked()
		{
			_check = RomanNumeral.CheckRange(_number);
		}

		Action _assertion;
		private void theNumeralIsAsserted()
		{
			_assertion = () => RomanNumeral.AssertRange(_number);
		}

		private void theResultIs_(bool check)
		{
			Assert.Equal(check, _check);
		}

		private void noExceptionIsRaised()
		{
			Exception ex = Record.Exception(_assertion);
			Assert.Null(ex);
		}

		private void aRangeExceptionIsThrown()
		{
			var ex = Assert.ThrowsAny<NumeralOutOfRangeException>(_assertion);
			Assert.Contains(_number.ToString(CultureInfo.InvariantCulture), ex.Message);
			Assert.Contains(RomanNumeral.MinValue.ToString(CultureInfo.InvariantCulture), ex.Message);
			Assert.Contains(RomanNumeral.MaxValue.ToString(CultureInfo.InvariantCulture), ex.Message);
		}
	}
}