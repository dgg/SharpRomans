using TestStack.BDDfy.Configuration;
using Xunit;

namespace SharpRomans.Tests.Support
{
	public class BddfyFixture
	{
		public BddfyFixture()
		{
			System.Console.WriteLine("Configure BDDfy");
			Configurator.Processors.ConsoleReport.Disable();
			Configurator.BatchProcessors.HtmlReport.Disable();
			Configurator.BatchProcessors.HtmlMetroReport.Enable();
			Configurator.BatchProcessors.MarkDownReport.Enable();
		}
	}

	[CollectionDefinition("bddfy")]
	public class BddfyCollection : ICollectionFixture<BddfyFixture> { }
}