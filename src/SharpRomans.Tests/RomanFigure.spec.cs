using System;
using NUnit.Framework;
using StoryQ;

namespace SharpRomans.Tests
{
	[TestFixture]
	public class RomanFigureSpec
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
					.Then(theFigure_Is, RomanFigure.I)

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

		char _character;
		private void aCharacter_(char character)
		{
			_character = character;
		}

		Func<RomanFigure> _figure;
		private void theCharIsParsed()
		{
			_figure = () => RomanFigure.Parse(_character);
		}

		private void theFigure_Is(RomanFigure figure)
		{
			Assert.That(_figure(), Is.EqualTo(figure));
		}

		private void throwsArgumentException()
		{
			TestDelegate cast = () => _figure();
			Assert.That(cast, Throws.ArgumentException);
		}

		private RomanFigure _anotherFigure;
		private void theCharIsParsedAgain_(char c)
		{
			_anotherFigure = RomanFigure.Parse(c);
		}

		private void isTheSameFigure()
		{
			Assert.That(_figure(), Is.SameAs(_anotherFigure));
		}
	}
}