using System.Collections.Generic;
using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec", Subject = "RomanFigure", Feature = "Value")]
	[Collection("bddfy")]
	[Story(
		SoThat = "I can get the integral values of individual figures",
		AsA = "library user",
		IWant = "to be able to invoke a property on a roman figure")]
	public class ValueTester
	{
		public static IEnumerable<object[]> Value_Data = new[]
		{
			new object[]{RomanFigure.I, 1u},
			new object[]{RomanFigure.V, 5u},
			new object[]{RomanFigure.X, 10u},
			new object[]{RomanFigure.L, 50u},
			new object[]{RomanFigure.C, 100u},
			new object[]{RomanFigure.D, 500u},
			new object[]{RomanFigure.M, 1000u},
		};

		[Theory]
		[MemberData(nameof(Value_Data))]
		
		public void Value(RomanFigure figure, uint value)
		{
			this.WithTags("RomanFigure", "Value")
				.Given(_ => _.theRomanFigure(figure))
				.When(_ => _.theValueIsObtained())
				.Then(_ => _.theValueIs(value))
				.BDDfy("value of a figure");
		}

		RomanFigure _subject;
		private void theRomanFigure(RomanFigure figure)
		{
			_subject = figure;
		}

		ushort _value;
		private void theValueIsObtained()
		{
			_value = _subject.Value;
		}

		private void theValueIs(uint value)
		{
			Assert.Equal(value, _value);
		}
	}
}