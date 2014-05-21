using System;
using NUnit.Framework;
using StoryQ;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[TestFixture, Category("Spec"), Category("RomanFigure")]
	public class CastingsTester
	{
		[Test]
		public void CastToChar()
		{
			new Story("casting to char")
				.InOrderTo("get the character of individual figures")
				.AsA("library user")
				.IWant("to be able to explicitely cast a roman figure")

				.WithScenario("character of a figure")
					.Given(aRomanFigure_, RomanFigure.N)
					.When(theFigureIsCasted)
					.Then(theCharacterIs_, 'N')

				.WithScenario("character of a figure")
					.Given(aRomanFigure_, RomanFigure.I)
					.When(theFigureIsCasted)
					.Then(theCharacterIs_, 'I')

				.WithScenario("character of a figure")
					.Given(aRomanFigure_, RomanFigure.V)
					.When(theFigureIsCasted)
					.Then(theCharacterIs_, 'V')

				.WithScenario("character of a figure")
					.Given(aRomanFigure_, RomanFigure.X)
					.When(theFigureIsCasted)
					.Then(theCharacterIs_, 'X')

				.WithScenario("character of a figure")
					.Given(aRomanFigure_, RomanFigure.L)
					.When(theFigureIsCasted)
					.Then(theCharacterIs_, 'L')

				.WithScenario("character of a figure")
					.Given(aRomanFigure_, RomanFigure.C)
					.When(theFigureIsCasted)
					.Then(theCharacterIs_, 'C')

				.WithScenario("character of a figure")
					.Given(aRomanFigure_, RomanFigure.D)
					.When(theFigureIsCasted)
					.Then(theCharacterIs_, 'D')

				.WithScenario("character of a figure")
					.Given(aRomanFigure_, RomanFigure.M)
					.When(theFigureIsCasted)
					.Then(theCharacterIs_, 'M')

				.WithScenario("character of null")
					.Given(aRomanFigure_, (RomanFigure)null)
					.When(theFigureIsCasted)
					.Then(throwsArgumentException)

				.ExecuteWithReport();
		}

		[Test]
		public void AssignToChar()
		{
			new Story("assign to char")
				.InOrderTo("get the character of individual figures")
				.AsA("library user")
				.IWant("to be able to implicitely cast a roman figure")

				.WithScenario("character of a figure")
					.Given(aRomanFigure_, RomanFigure.N)
					.When(theFigureIsAssigned)
					.Then(theCharacterIs_, 'N')

				.WithScenario("character of a figure")
					.Given(aRomanFigure_, RomanFigure.V)
					.When(theFigureIsAssigned)
					.Then(theCharacterIs_, 'V')

				.WithScenario("character of null")
					.Given(aRomanFigure_, (RomanFigure)null)
					.When(theFigureIsAssigned)
					.Then(throwsArgumentException)

				.ExecuteWithReport();
		}

		RomanFigure _subject;
		private void aRomanFigure_(RomanFigure figure)
		{
			_subject = figure;
		}

		Func<char> _character;
		private void theFigureIsCasted()
		{
			_character = () => (char)_subject;
		}

		private char _assigned;
		Func<char> _assignation;

		private void theFigureIsAssigned()
		{
			_character = () => (_assigned = _subject);
		}

		private void theCharacterIs_(char character)
		{
			Assert.That(_character(), Is.EqualTo(character));
		}

		private void throwsArgumentException()
		{
			TestDelegate cast = () => _character();
			Assert.That(cast, Throws.InstanceOf<ArgumentNullException>());
		}
	}
}