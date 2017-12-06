using System.Collections.ObjectModel;
using SharpRomans.Tests.Support;
using Xunit;

namespace SharpRomans.Tests
{
	[Category("Exploration")]
	[Collection("bddfy")]
	public class Quickstart
	{
		[Fact]
		public void RomanNumeral_()
		{
			// from arabic to roman numeral
			var thirty = new RomanNumeral(30);
			ReadOnlyCollection<RomanFigure> xxx = thirty.Figures;
			string XXX = thirty.ToString();
			
			// getting an instance from shortcut
			RomanNumeral zero = RomanNumeral.Zero;

			// parsing a roman representation
			RomanNumeral nineteenTwentyEight = RomanNumeral.Parse("MCMXXVIII");
			bool _true = RomanNumeral.TryParse("MCMXXVIII", out nineteenTwentyEight);
			ushort _1928 = nineteenTwentyEight.Value;

			// comparisons
			int lessThanZero = thirty.CompareTo(nineteenTwentyEight);
			_true = thirty < nineteenTwentyEight;
			_true = nineteenTwentyEight >= thirty;

			bool _false = nineteenTwentyEight.Equals(thirty);
			_false = thirty == nineteenTwentyEight;

			// castings
			_1928 = (ushort) nineteenTwentyEight;
			XXX = (string) thirty;

			// arithmetic
			RomanNumeral sixty = thirty.Plus(thirty);
			thirty = sixty.Minus(thirty);

			sixty = thirty + thirty;
			thirty = sixty - thirty;
		}

		[Fact]
		public void RomanFigure_()
		{
			// getting and instance from a shortcut
			RomanFigure fromAccesor = RomanFigure.L;

			// parse a char
			RomanFigure ten = RomanFigure.Parse('X');
			bool _true = RomanFigure.TryParse('X', out ten);
			
			// parse a string
			RomanFigure five = RomanFigure.Parse("V");
			_true = RomanFigure.TryParse("V", out five);

			// convert a number
			var one = RomanFigure.Convert(1);
			RomanFigure.TryConvert(1, out one);

			// getting information
			ushort _5 = five.Value;
			char V = five.Literal;
			string quinque = five.Name;

			// comparisons
			int lessThanZero = five.CompareTo(ten);
			_true = five < ten;
			_true = five >= one;

			bool _false = five.Equals(ten);
			_false = ten == five;

			// castings
			_5 = (ushort) five;
			V = (char) five;		
		}
	}
}