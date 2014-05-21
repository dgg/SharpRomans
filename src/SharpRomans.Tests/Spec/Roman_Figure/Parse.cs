using System;
using NUnit.Framework;
using StoryQ;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[TestFixture, Category("Spec"), Category("RomanFigure")]
	public class ParseTester
	{
		[Test]
		public void ParseChar()
		{
			new Story("parse a char")
				.InOrderTo("get a figure instance")
				.AsA("library user")
				.IWant("to be able to parse a char")

				.WithScenario("parse a defined figure")
					.Given(aCharacter_, 'I')
					.When(theCharIsParsed)
					.Then(theFigureIs_, RomanFigure.I)

				.WithScenario("parse an undefined figure")
					.Given(aCharacter_, 'W')
					.When(theCharIsParsed)
					.Then(throwsArgumentException)

				.WithScenario("figures are unique")
					.Given(aCharacter_, 'X')
					.When(theChar_IsParsedAgain, 'X')
					.Then(isTheSameFigure)

				.ExecuteWithReport();
		}

		[Test]
		public void ParseString()
		{
			new Story("parse a string")
				.InOrderTo("get a figure instance")
				.AsA("library user")
				.IWant("to be able to parse a string")

				.WithScenario("parse a defined figure")
					.Given(aString_, "I")
					.When(theStringIsParsed)
					.Then(theFigureIs_, RomanFigure.I)

				.WithScenario("parse an undefined figure")
					.Given(aString_, "W")
					.When(theStringIsParsed)
					.Then(throwsArgumentException)

				.WithScenario("parse a multiple character string")
					.Given(aString_, "XI")
					.When(theStringIsParsed)
					.Then(throwsFormatException)

				.WithScenario("figures are unique")
					.Given(aString_, "X")
					.When(theString_IsParsedAgain, "X")
					.Then(isTheSameFigure)

				.ExecuteWithReport();
		}

		char _character;
		private void aCharacter_(char character)
		{
			_character = character;
		}

		string _string;
		private void aString_(string s)
		{
			_string = s;
		}

		Func<RomanFigure> _figure;
		private void theCharIsParsed()
		{
			_figure = () => RomanFigure.Parse(_character);
		}

		private void theStringIsParsed()
		{
			_figure = () => RomanFigure.Parse(_string);
		}

		private void theFigureIs_(RomanFigure figure)
		{
			Assert.That(_figure(), Is.EqualTo(figure));
		}

		private void throwsArgumentException()
		{
			TestDelegate cast = () => _figure();
			Assert.That(cast, Throws.ArgumentException);
		}

		private void throwsFormatException()
		{
			TestDelegate cast = () => _figure();
			Assert.That(cast, Throws.InstanceOf<FormatException>());
		}

		private RomanFigure _anotherFigure;
		private void theChar_IsParsedAgain(char c)
		{
			_anotherFigure = RomanFigure.Parse(c);
		}

		private void theString_IsParsedAgain(string s)
		{
			_anotherFigure = RomanFigure.Parse(s);
		}

		private void isTheSameFigure()
		{
			Assert.That(_figure(), Is.SameAs(_anotherFigure));
		}
	}
}