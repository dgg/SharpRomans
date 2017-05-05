using System.Linq;
using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Numeral
{
	[Category("Spec", Subject = "RomanNumeral", Feature = "Figures")]
	[Collection("bddfy")]
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
				.Given(_ => _.theArabicNumeral(0))
				.When(_ => _.theRomanNumeralIsInstantiated())
				.Then(_ => _.isARomanNumeralWithFigures("N"))
				.BDDfy("zero");

			this.WithTags("RomanNumeral", "Figures")
				.Given(_ => _.theArabicNumeral(50))
				.When(_ => _.theRomanNumeralIsInstantiated())
				.Then(_ => _.isARomanNumeralWithFigures("L"))
				.BDDfy("single-figure");

			this.WithTags("RomanNumeral", "Figures")
				.Given(_ => _.theArabicNumeral(75))
				.When(_ => _.theRomanNumeralIsInstantiated())
				.Then(_ => _.isARomanNumeralWithFigures("LXXV"))
				.BDDfy("multiple-figures");
		}

		ushort _number;
		private void theArabicNumeral(int number)
		{
			_number = (ushort)number;
		}

		RomanNumeral _subject;
		private void theRomanNumeralIsInstantiated()
		{
			_subject = new RomanNumeral(_number);
		}

		private void isARomanNumeralWithFigures(string figures)
		{
			RomanFigure[] list = figures
				.Select(RomanFigure.Parse)
				.ToArray();

			Assert.Equal(list, _subject.Figures);
			Assert.Equal(figures, _subject.ToString());
		}
	}
}