using System;
using Xunit.Sdk;

namespace SharpRomans.Tests.Support
{
	[TraitDiscoverer(CategoryDiscoverer.ClassName, CategoryDiscoverer.AssemblyName)]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
	class CategoryAttribute : Attribute, ITraitAttribute
	{
		public CategoryAttribute(string category) { }

		public string Feature { get; set; }
		public string Subject { get; set; }

		public static string TraitName = "Category";

		public bool IsPopulated => !string.IsNullOrWhiteSpace(Feature) && 
			!string.IsNullOrWhiteSpace(Subject);
	}
}