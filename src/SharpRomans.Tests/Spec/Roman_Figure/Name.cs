using System.Collections.Generic;
using System.Linq;
using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec", Subject = "RomanFigure", Feature = "Name")]
	[Collection("bddfy")]
	[Story(
		Title = "names",
		AsA = "library user",
		IWant = "to be able to invoke a property on a roman figure",
		SoThat = "I can get its latin name"
	)]
	public class NameTester
	{
		public static readonly IEnumerable<object[]> Name_Data = RomanFigure.All
			.Select(f => new object[]{f});

		[Theory]
		[MemberData(nameof(Name_Data))]
		public void Name(RomanFigure figure)
		{
			this.WithTags("RomanFigure", "Name")
				.Given(_ => _.theFigure_DoesHaveAName(figure), "the figure {0} does have a name")
				.When(_ => _.theNameIsObtained())
				.Then(_ => _.theNameIsNotEmpty())
				.BDDfy("figures with names");
		}

		RomanFigure _subject;
		string _name;
		private void theNameIsObtained()
		{
			_name = _subject.Name;
		}

		private void theFigure_DoesHaveAName(RomanFigure figureWithName)
		{
			_subject = figureWithName;
		}

		private void theNameIsNotEmpty()
		{
			Assert.NotEqual(string.Empty, _name);
		}
	}
}