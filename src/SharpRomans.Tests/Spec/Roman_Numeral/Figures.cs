using System.Linq;
using NUnit.Framework;
using StoryQ;

namespace SharpRomans.Tests.Spec.Roman_Numeral
{
	[TestFixture, Category("Spec"), Category("RomanNumeral"), Category("Figures")]
	public class FiguresTester
	{
		[Test]
		public void Figures()
		{
			new Story("roman numeral figures")
				.InOrderTo("convert an arabic numeral to a roman numeral")
				.AsA("library user")
				.IWant("to access a list of the figures that make up the roman numeral.")

				.WithScenario("zero")
					.Given(anArabicNumeral_, 0)
					.When(theRomanNumeralIsInstantiated)
					.Then(isARomanNumeralWithFigures_, "N")

				.WithScenario("single-figure")
					.Given(anArabicNumeral_, 50)
					.When(theRomanNumeralIsInstantiated)
					.Then(isARomanNumeralWithFigures_, "L")

				.WithScenario("multiple-figures")
					.Given(anArabicNumeral_, 75)
					.When(theRomanNumeralIsInstantiated)
					.Then(isARomanNumeralWithFigures_, "LXXV")

				.ExecuteWithReport();
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

			Assert.That(_subject.Figures, Is.EqualTo(list));
		}
	}
}