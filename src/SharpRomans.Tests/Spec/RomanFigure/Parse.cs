using System;
using NUnit.Framework;
using StoryQ;

namespace SharpRomans.Tests.Spec.RomanFigure
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
					.Then(theFigure_Is, SharpRomans.RomanFigure.I)

				.WithScenario("parse an undefined figure")
					.Given(aCharacter_, 'W')
					.When(theCharIsParsed)
					.Then(throwsArgumentException)

				.WithScenario("figures are unique")
					.Given(aCharacter_, 'X')
					.When(theCharIsParsedAgain_, 'X')
					.Then(isTheSameFigure)

				.ExecuteWithReport();
		}

		[Test]
		public void ParseNumber()
		{
			new Story("parse a number")
				.InOrderTo("get a figure instance")
				.AsA("library user")
				.IWant("to be able to parse a short")

				.WithScenario("parse a defined figure")
					.Given(aNumber_, 1)
					.When(theNumberIsParsed)
					.Then(theFigure_Is, SharpRomans.RomanFigure.I)

				.WithScenario("parse an undefined figure")
					.Given(aNumber_, 3)
					.When(theNumberIsParsed)
					.Then(throwsArgumentException)

				.WithScenario("figures are unique")
					.Given(aNumber_, 10)
					.When(theNumberIsParsedAgain_, 10)
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
					.Then(theFigure_Is, SharpRomans.RomanFigure.I)

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
					.When(theStringIsParsedAgain_, "X")
					.Then(isTheSameFigure)

				.ExecuteWithReport();
		}

		char _character;
		private void aCharacter_(char character)
		{
			_character = character;
		}

		ushort _number;
		private void aNumber_(int number)
		{
			_number = (ushort)number;
		}

		string _string;
		private void aString_(string s)
		{
			_string = s;
		}

		Func<SharpRomans.RomanFigure> _figure;
		private void theCharIsParsed()
		{
			_figure = () => SharpRomans.RomanFigure.Parse(_character);
		}

		private void theNumberIsParsed()
		{
			_figure = () => SharpRomans.RomanFigure.Parse(_number);
		}

		private void theStringIsParsed()
		{
			_figure = () => SharpRomans.RomanFigure.Parse(_string);
		}

		private void theFigure_Is(SharpRomans.RomanFigure figure)
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

		private SharpRomans.RomanFigure _anotherFigure;
		private void theCharIsParsedAgain_(char c)
		{
			_anotherFigure = SharpRomans.RomanFigure.Parse(c);
		}

		private void theNumberIsParsedAgain_(int number)
		{
			_anotherFigure = SharpRomans.RomanFigure.Parse((ushort)number);
		}

		private void theStringIsParsedAgain_(string s)
		{
			_anotherFigure = SharpRomans.RomanFigure.Parse(s);
		}

		private void isTheSameFigure()
		{
			Assert.That(_figure(), Is.SameAs(_anotherFigure));
		}
	}
}