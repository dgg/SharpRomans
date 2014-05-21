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
		public void AssignToChar()
		{
			new Story("assign to char")
				.InOrderTo("get the character of individual figures")
				.AsA("library user")
				.IWant("to be able to implicitely cast a roman figure")

				.WithScenario("character of a figure")
					.Given(aRomanFigure_, RomanFigure.N)
					.When(theFigureIsAssignedToChar)
					.Then(theCharacterIs_, 'N')

				.WithScenario("character of a figure")
					.Given(aRomanFigure_, RomanFigure.V)
					.When(theFigureIsAssignedToChar)
					.Then(theCharacterIs_, 'V')

				.WithScenario("character of null")
					.Given(aRomanFigure_, (RomanFigure)null)
					.When(theFigureIsAssignedToChar)
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

		[Test]
		public void AssignToNumber()
		{
			new Story("assign to number")
				.InOrderTo("get the value of individual figures")
				.AsA("library user")
				.IWant("to be able to implicitely cast a roman figure")

				.WithScenario("character of a figure")
					.Given(aRomanFigure_, RomanFigure.N)
					.When(theFigureIsAssignedToNumber)
					.Then(theNumberIs_, 0)

				.WithScenario("character of a figure")
					.Given(aRomanFigure_, RomanFigure.V)
					.When(theFigureIsAssignedToNumber)
					.Then(theNumberIs_, 5)

				.WithScenario("character of null")
					.Given(aRomanFigure_, (RomanFigure)null)
					.When(theFigureIsAssignedToNumber)
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

		private char _assignedChar;
		private void theFigureIsAssignedToChar()
		{
			_character = () => (_assignedChar = _subject);
		}

		private ushort _assignedNumber;
		private void theFigureIsAssignedToNumber()
		{
			_number = () => (_assignedNumber = _subject);
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