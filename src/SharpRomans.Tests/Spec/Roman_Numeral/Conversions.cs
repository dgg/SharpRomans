using System;
using NUnit.Framework;
using SharpRomans.Tests.Spec.Roman_Numeral.Support;
using StoryQ;

namespace SharpRomans.Tests.Spec.Roman_Numeral
{
	[TestFixture, Category("Spec"), Category("RomanNumeral"), Category("Conversions")]
	public class ConversionsTester
	{
		[Test]
		public void ConvertToBoolean()
		{
			new Story("convert to Boolean")
				.InOrderTo("convert a roman numeral to boolean whenever possible")
				.AsA("library user")
				.IWant("Convert() to a roman numeral")

			.WithScenario("zero")
				.Given(TheRomanNumeral_, RomanNumeral.Zero)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToBoolean(f)))
				.Then(Is_, false)

			.WithScenario("one")
				.Given(TheRomanNumeral_, new RomanNumeral(1))
				.When(ConvertedTo_, Conv.ert(f => Convert.ToBoolean(f)))
				.Then(Is_, true)

			.WithScenario("more than one")
				.Given(TheRomanNumeral_, new RomanNumeral(51))
				.When(ConvertedTo_, Conv.ert(f => Convert.ToBoolean(f)))
				.Then(Is_, true)

			.WithScenario("max")
				.Given(TheRomanNumeral_, RomanNumeral.Max)
				.When(ConvertedTo_, Conv.ert(f => Convert.ToBoolean(f)))
				.Then(Is_, true)

			.ExecuteWithReport();
		}

		RomanNumeral _subject;
		private void TheRomanNumeral_(RomanNumeral subject)
		{
			_subject = subject;
		}

		Func<object> _conversion;
		private void ConvertedTo_(Conv exp)
		{
			_conversion = () => exp.Execute(_subject);
		}

		private void Is_<T>(T value)
		{
			Assert.That(_conversion(), Is.EqualTo(value));
		}
	}
}