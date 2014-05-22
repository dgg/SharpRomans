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
					.When(theFigureIsCastedToChar)
					.Then(theCharacterIs_, 'N')

				.WithScenario("character of a figure")
					.Given(aRomanFigure_, RomanFigure.X)
					.When(theFigureIsCastedToChar)
					.Then(theCharacterIs_, 'X')

				.WithScenario("character of null")
					.Given(aRomanFigure_, (RomanFigure)null)
					.When(theFigureIsCastedToChar)
					.Then(throwsArgumentException)

				.ExecuteWithReport();
		}

		[Test]
		public void CastToNumber()
		{
			new Story("casting to number")
				.InOrderTo("get the value of individual figures")
				.AsA("library user")
				.IWant("to be able to explicitely cast a roman figure")

				.WithScenario("character of a figure")
					.Given(aRomanFigure_, RomanFigure.N)
					.When(theFigureIsCastedToNumber)
					.Then(theNumberIs_, 0)

				.WithScenario("character of a figure")
					.Given(aRomanFigure_, RomanFigure.X)
					.When(theFigureIsCastedToNumber)
					.Then(theNumberIs_, 10)

				.WithScenario("character of null")
					.Given(aRomanFigure_, (RomanFigure)null)
					.When(theFigureIsCastedToNumber)
					.Then(throwsArgumentException)

				.ExecuteWithReport();
		}

		RomanFigure _subject;
		private void aRomanFigure_(RomanFigure figure)
		{
			_subject = figure;
		}

		Func<char> _character;
		private void theFigureIsCastedToChar()
		{
			_character = () => (char)_subject;
		}

		Func<ushort> _number;
		private void theFigureIsCastedToNumber()
		{
			_number = () => (ushort)_subject;
		}

		private void theCharacterIs_(char character)
		{
			Assert.That(_character(), Is.EqualTo(character));
		}

		private void theNumberIs_(int number)
		{
			Assert.That(_number(), Is.EqualTo(number));
		}

		private void throwsArgumentException()
		{
			TestDelegate cast = () => _character();
			Assert.That(cast, Throws.InstanceOf<ArgumentNullException>());
		}
	}
}