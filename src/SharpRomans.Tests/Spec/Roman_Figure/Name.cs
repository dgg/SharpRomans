using SharpRomans.Tests.Support;
using TestStack.BDDfy;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	[Category("Spec"), Category("RomanFigure"), Category("Name")]
	[Collection("bddfy")]
	[Story(
		Title = "names",
		AsA = "library user",
		IWant = "to be able to invoke a property on a roman figure",
		SoThat = "I can get its latin name"
	)]
	public class NameTester
	{
		[Fact]
		public void Name()
		{
			this.WithTags("RomanFigure", "Name")
				.Given(_ => _.theFigure_DoesHaveAName(RomanFigure.N))
				.When(_=>_.theNameIsObtained())
				.Then(_ => _.theNameIsNotEmpty())
				.BDDfy("zero");

			this.WithTags("RomanFigure", "Name")

				.Given(_ => _.theFigure_DoesHaveAName(RomanFigure.I))
				.When(_=>_.theNameIsObtained())
				.Then(_ => _.theNameIsNotEmpty())
				.BDDfy("one");

			this.WithTags("RomanFigure", "Name")

				.Given(_ => _.theFigure_DoesHaveAName(RomanFigure.V))
				.When(_=>_.theNameIsObtained())
				.Then(_ => _.theNameIsNotEmpty())
				.BDDfy("five");

			this.WithTags("RomanFigure", "Name")

				.Given(_ => _.theFigure_DoesHaveAName(RomanFigure.X))
				.When(_=>_.theNameIsObtained())
				.Then(_ => _.theNameIsNotEmpty())
				.BDDfy("ten");

			this.WithTags("RomanFigure", "Name")

				.Given(_ => _.theFigure_DoesHaveAName(RomanFigure.L))
				.When(_=>_.theNameIsObtained())
				.Then(_ => _.theNameIsNotEmpty())
				.BDDfy("figures with names");

			this.WithTags("RomanFigure", "Name")

				.Given(_ => _.theFigure_DoesHaveAName(RomanFigure.C))
				.When(_=>_.theNameIsObtained())
				.Then(_ => _.theNameIsNotEmpty())
				.BDDfy("figures with names");

			this.WithTags("RomanFigure", "Name")

				.Given(_ => _.theFigure_DoesHaveAName(RomanFigure.D))
				.When(_=>_.theNameIsObtained())
				.Then(_ => _.theNameIsNotEmpty())
				.BDDfy("figures with names");

			this.WithTags("RomanFigure", "Name")
				.Given(_ => _.theFigure_DoesHaveAName(RomanFigure.M))
				.When(_=>_.theNameIsObtained())
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