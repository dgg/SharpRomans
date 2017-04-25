using System;
using SharpRomans.Tests.Support;
using StoryQ;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec"), Category("RomanFigure"), Category("Castings")]
	public class CastingsTester
	{
		[Fact]
		public void CastToChar()
		{
			new Story("casting to char")
				.InOrderTo("get the character of individual figures")
				.AsA("library user")
				.IWant("to be able to explicitely cast a roman figure")

				.WithScenario("character of a figure")
					.Given(aRomanFigure_, RomanFigure.N)
					.When(isCastedToChar)
					.Then(theCharacterIs_, 'N')

				.WithScenario("character of a figure")
					.Given(aRomanFigure_, RomanFigure.X)
					.When(isCastedToChar)
					.Then(theCharacterIs_, 'X')

				.WithScenario("character of null")
					.Given(aRomanFigure_, (RomanFigure)null)
					.When(isCastedToChar)
					.Then(throwsArgumentException)

				.ExecuteWithReport();
		}

		[Fact]
		public void CastToNumber()
		{
			new Story("casting to number")
				.InOrderTo("get the value of individual figures")
				.AsA("library user")
				.IWant("to be able to explicitely cast a roman figure")

				.WithScenario("number of a figure")
					.Given(aRomanFigure_, RomanFigure.N)
					.When(isCastedToNumber)
					.Then(theNumberIs_, 0)

				.WithScenario("number of a figure")
					.Given(aRomanFigure_, RomanFigure.X)
					.When(isCastedToNumber)
					.Then(theNumberIs_, 10)

				.WithScenario("number of null")
					.Given(aRomanFigure_, (RomanFigure)null)
					.When(isCastedToNumber)
					.Then(throwsArgumentException)

				.ExecuteWithReport();
		}

		[Fact]
		public void CastToString()
		{
			new Story("casting to string")
				.InOrderTo("get the text of individual figures")
				.AsA("library user")
				.IWant("to be able to explicitely cast a roman figure")

				.WithScenario("string of a figure")
					.Given(aRomanFigure_, RomanFigure.N)
					.When(isCastedToString)
					.Then(theStringIs_, "N")

				.WithScenario("string of a figure")
					.Given(aRomanFigure_, RomanFigure.X)
					.When(isCastedToString)
					.Then(theStringIs_, "X")

				.WithScenario("number of null")
					.Given(aRomanFigure_, (RomanFigure)null)
					.When(isCastedToString)
					.Then(theStringIs_, (string)null)

				.ExecuteWithReport();
		}

		RomanFigure _subject;
		private void aRomanFigure_(RomanFigure figure)
		{
			_subject = figure;
		}

		Func<char> _character;
		private void isCastedToChar()
		{
			_character = () => (char)_subject;
		}

		Func<ushort> _number;
		private void isCastedToNumber()
		{
			_number = () => (ushort)_subject;
		}

		Func<string> _string;
		private void isCastedToString()
		{
			_string = () => (string)_subject;
		}

		private void theCharacterIs_(char character)
		{
			Assert.Equal(character, _character());
		}

		private void theNumberIs_(int number)
		{
			Assert.Equal(number, _number());
		}

		private void theStringIs_(string numeral)
		{
			Assert.Equal(numeral, _string());
		}

		private void throwsArgumentException()
		{
			Action cast = () => _character();
			Assert.ThrowsAny<ArgumentNullException>(cast);
		}
	}
}