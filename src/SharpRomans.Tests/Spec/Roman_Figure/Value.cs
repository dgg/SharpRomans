using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec"), Category("RomanFigure"), Category("Value")]
	[Collection("bddfy")]
	[Story(
		SoThat = "I can get the integral values of individual figures",
		AsA = "library user",
		IWant = "to be able to invoke a property on a roman figure")]
	public class ValueTester
	{
		[Fact]
		
		public void Value()
		{
			this.WithTags("RomanFigure", "Value")
				.Given(_ => _.aRomanFigure_(RomanFigure.I))
				.When(_ => _.theValueIsObtained())
				.Then(_ => _.theValueIs_(1u))
				.BDDfy("value of a figure");

			this.WithTags("RomanFigure", "Value")
				.Given(_ => _.aRomanFigure_(RomanFigure.V))
				.When(_ => _.theValueIsObtained())
				.Then(_ => _.theValueIs_(5u))
				.BDDfy("value of a figure");

			this.WithTags("RomanFigure", "Value")
				.Given(_ => _.aRomanFigure_(RomanFigure.X))
				.When(_ => _.theValueIsObtained())
				.Then(_ => _.theValueIs_(10u))
				.BDDfy("value of a figure");

			this.WithTags("RomanFigure", "Value")
				.Given(_ => _.aRomanFigure_(RomanFigure.L))
				.When(_ => _.theValueIsObtained())
				.Then(_ => _.theValueIs_(50u))
				.BDDfy("value of a figure");

			this.WithTags("RomanFigure", "Value")
				.Given(_ => _.aRomanFigure_(RomanFigure.C))
				.When(_ => _.theValueIsObtained())
				.Then(_ => _.theValueIs_(100u))
				.BDDfy("value of a figure");

			this.WithTags("RomanFigure", "Value")
				.Given(_ => _.aRomanFigure_(RomanFigure.D))
				.When(_ => _.theValueIsObtained())
				.Then(_ => _.theValueIs_(500u))
				.BDDfy("value of a figure");

			this.WithTags("RomanFigure", "Value")
				.Given(_ => _.aRomanFigure_(RomanFigure.M))
				.When(_ => _.theValueIsObtained())
				.Then(_ => _.theValueIs_(1000u))
				.BDDfy("value of a figure");
		}

		RomanFigure _subject;
		private void aRomanFigure_(RomanFigure figure)
		{
			_subject = figure;
		}

		ushort _value;
		private void theValueIsObtained()
		{
			_value = _subject.Value;
		}

		private void theValueIs_(uint value)
		{
			Assert.Equal(value, _value);
		}
	}
}