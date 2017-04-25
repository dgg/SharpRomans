﻿using System;
using SharpRomans.Tests.Support;
using StoryQ;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Numeral
{
	[Category("Spec"), Category("RomanNumeral"), Category("Castings")]
	public class CastingsTester
	{
		[Fact]
		public void CastToNumber()
		{
			new Story("casting to number")
				.InOrderTo("get the value of numerals")
				.AsA("library user")
				.IWant("to be able to explicitely cast a roman numeral")

				.WithScenario("number of a numeral")
					.Given(aRomanNumeral_, RomanNumeral.Zero)
					.When(isCastedToNumber)
					.Then(theNumberIs_, 0)

				.WithScenario("number of a numeral")
					.Given(aRomanNumeral_, new RomanNumeral(11))
					.When(isCastedToNumber)
					.Then(theNumberIs_, 11)

				.WithScenario("number of null")
					.Given(aRomanNumeral_, (RomanNumeral)null)
					.When(isCastedToNumber)
					.Then(throwsArgumentException)

				.ExecuteWithReport();
		}

		[Fact]
		public void CastToString()
		{
			new Story("casting to string")
				.InOrderTo("get the figures of numerals")
				.AsA("library user")
				.IWant("to be able to explicitely cast a roman numeral")

				.WithScenario("string of a numeral")
					.Given(aRomanNumeral_, RomanNumeral.Zero)
					.When(isCastedToString)
					.Then(theStringIs_, "N")

				.WithScenario("string of a numeral")
					.Given(aRomanNumeral_, new RomanNumeral(11))
					.When(isCastedToString)
					.Then(theStringIs_, "XI")

				.WithScenario("string of null")
					.Given(aRomanNumeral_, (RomanNumeral)null)
					.When(isCastedToString)
					.Then(theStringIs_, (string)null)

				.ExecuteWithReport();
		}

		RomanNumeral _subject;
		private void aRomanNumeral_(RomanNumeral numeral)
		{
			_subject = numeral;
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
			Action cast = () =>_number();
			Assert.ThrowsAny<ArgumentNullException>(cast);
		}
	}
}
