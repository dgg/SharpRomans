using System.Linq;
using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Numeral
{
	[Category("Spec"), Category("RomanNumeral"), Category("Figures")]
	[Story(
		Title = "creation of roman numerals",
		AsA = "library user",
		IWant = "to access a list of the figures that make up the roman numeral.",
		SoThat = "I can convert an arabic numeral to a roman numeral"
	)]
	public class FiguresTester
	{
		[Fact]
		public void Figures()
		{
			this.WithTags("RomanNumeral", "Figures")
				.Given(_ => _.anArabicNumeral_(0))
				.When(_ => _.theRomanNumeralIsInstantiated())
				.Then(_ => _.isARomanNumeralWithFigures_("N"))
				.BDDfy("zero");

			this.WithTags("RomanNumeral", "Figures")
				.Given(_ => _.anArabicNumeral_(50))
				.When(_ => _.theRomanNumeralIsInstantiated())
				.Then(_ => _.isARomanNumeralWithFigures_("L"))
				.BDDfy("single-figure");

			this.WithTags("RomanNumeral", "Figures")
				.Given(_ => _.anArabicNumeral_(75))
				.When(_ => _.theRomanNumeralIsInstantiated())
				.Then(_ => _.isARomanNumeralWithFigures_("LXXV"))
				.BDDfy("multiple-figures");
		}

		ushort _number;
		private void anArabicNumeral_(int number)
		{
			_number = (ushort)number;
		}

		RomanNumeral _subject;
		private void theRomanNumeralIsInstantiated()
		{
			_subject = new RomanNumeral(_number);
		}

		private void isARomanNumeralWithFigures_(string figures)
		{
			RomanFigure[] list = figures
				.Select(RomanFigure.Parse)
				.ToArray();

			Assert.Equal(list, _subject.Figures);
			Assert.Equal(figures, _subject.ToString());
		}
	}
}