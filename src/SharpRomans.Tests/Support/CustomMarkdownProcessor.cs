using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TestStack.BDDfy;
using TestStack.BDDfy.Reporters;
using TestStack.BDDfy.Reporters.MarkDown;
using TestStack.BDDfy.Reporters.Writers;

namespace SharpRomans.Tests.Support
{
	public class CustomMarkdownProcessor : IBatchProcessor
	{
		private readonly IReportWriter _writer;
		private readonly MarkDownReportBuilder _builder;

		public CustomMarkdownProcessor()
		{
			_writer = new FileWriter();
			_builder = new MarkDownReportBuilder();
		}

		/// <summary>
		/// Writes as many mardown reports as categorized stories come.
		/// </summary>
		/// <remarks><paramref name="stories"/> collection come with as many elements as scenarios (each story contains exactly one scenario), so before passing the model to the builder
		/// we need to aggregate the scenarios for the story.</remarks>
		/// <param name="stories"></param>
		public void Process(IEnumerable<Story> stories)
		{
			var aggregatedStories = stories.GroupBy(s => s.Metadata.Type)
				.Select(g =>
				{
					Story paradigm = g.First();
					Story aggregated = new Story(paradigm.Metadata,
						g.SelectMany(s => s.Scenarios).ToArray());
					return aggregated;
				})
				.ToReportModel().Stories;

			foreach (var story in aggregatedStories)
			{
				string fileName = this.fileName(story.Metadata);
				if (fileName != null)
				{
					var reportModel = new ReportModel();
					reportModel.Stories.Add(story);

					var report = _builder.CreateReport(new FileReportModel(reportModel));

					_writer.OutputReport(report, fileName + ".md");
				}
			}
		}

		private string fileName(ReportModel.StoryMetadata story)
		{
			var category = story.Type
#if !NET
				.GetTypeInfo()
#endif
				.GetCustomAttributes<CategoryAttribute>()
				.FirstOrDefault();

			return category != null && category.IsPopulated ?
				category.Subject + "." + category.Feature :
				null;
		}
	}
}