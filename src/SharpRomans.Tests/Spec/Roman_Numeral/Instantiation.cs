using System;
using System.Globalization;
using SharpRomans.Tests.Spec.Roman_Numeral.Support;
using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Numeral
{
	[Category("Spec", Subject = "RomanNumeral", Feature = "Instantiation")]
	[Collection("bddfy")]
	[Story(
		Title = "creation of roman numerals",
		AsA = "library user",
		IWant = "to be able to create an instance of a roman numeral from an arabic number or have direct access to peculiar numerals",
		SoThat = "I can have an instance of a roman numeral"
	)]
	public class InstantiationTester
	{
		[Fact]
		public void Instantiation()
		{

			this.WithTags("RomanNumeral", "Creation", "Outside range")
				.Given(_ => _.theArabicNumeral(-20))
				.When(_ => _.theRomanNumeralIsInstantiating())
				.Then(_ => _.aRangeExceptionIsThrown())
				.BDDfy("negative number");

			this.WithTags("RomanNumeral", "Creation", "Outside range")
				.Given(_ => _.theArabicNumeral(4001))
				.When(_ => _.theRomanNumeralIsInstantiating())
				.Then(_ => _.aRangeExceptionIsThrown())
				.BDDfy("overflowing number");

			this.WithTags("RomanNumeral", "Creation", "Within range")
				.Given(_ => _.theArabicNumeral(0))
				.When(_ => _.theRomanNumeralIsInstantiated())
				.Then(_ => _.isARomanNumeralWithValue(0))
				.BDDfy("zero");

			this.WithTags("RomanNumeral", "Creation", "Within range")
				.Given(_ => _.theArabicNumeral(50))
				.When(_ => _.theRomanNumeralIsInstantiated())
				.Then(_ => _.isARomanNumeralWithValue(50))
				.BDDfy("single-figure");

			this.WithTags("RomanNumeral", "Creation", "Within range")
				.Given(_ => _.theArabicNumeral(75))
				.When(_ => _.theRomanNumeralIsInstantiated())
				.Then(_ => _.isARomanNumeralWithValue(75))
				.BDDfy("multiple-figures");
		}

		[Fact]
		public void Instances()
		{
			this.WithTags("RomanNumeral", "Creation", "Peculiar")
				.Given(_ => _.the_RomanNumeral(Ins.tance(() => RomanNumeral.Zero)), "the '{0}' roman numeral")
				.When(_ => _.itIsAccessed())
				.Then(_ => _.isARomanNumeralWithValue(0))
				.BDDfy("zero");

			this.WithTags("RomanNumeral", "Creation", "Peculiar")
				.Given(_ => _.the_RomanNumeral(Ins.tance(() => RomanNumeral.Min)), "the '{0}' roman numeral")
				.When(_ => _.itIsAccessed())
				.Then(_ => _.isARomanNumeralWithValue(RomanNumeral.MinValue))
				.BDDfy("min");

			this.WithTags("RomanNumeral", "Creation", "Peculiar")
				.Given(_ => _.the_RomanNumeral(Ins.tance(() => RomanNumeral.Max)), "the '{0}' roman numeral")
				.When(_ => _.itIsAccessed())
				.Then(_ => _.isARomanNumeralWithValue(RomanNumeral.MaxValue))
				.BDDfy("max");
		}

		ushort _number;
		private void theArabicNumeral(int number)
		{
			_number = (ushort)number;
		}

		Action _instantiation;
		private void theRomanNumeralIsInstantiating()
		{
			_instantiation = () => new RomanNumeral(_number);
		}

		RomanNumeral _subject;
		private void theRomanNumeralIsInstantiated()
		{
			_subject = new RomanNumeral(_number);
		}

		private void the_RomanNumeral(Ins instance)
		{
			_subject = instance.Execute();
		}

		private void itIsAccessed() { }

		private void aRangeExceptionIsThrown()
		{
			var ex = Assert.ThrowsAny<NumeralOutOfRangeException>(_instantiation);
			Assert.Contains(_number.ToString(CultureInfo.InvariantCulture), ex.Message);
			Assert.Contains(RomanNumeral.MinValue.ToString(CultureInfo.InvariantCulture), ex.Message);
			Assert.Contains(RomanNumeral.MaxValue.ToString(CultureInfo.InvariantCulture), ex.Message);
		}

		private void isARomanNumeralWithValue(int value)
		{
			Assert.Equal(value, _subject.Value);
		}
	}
}
