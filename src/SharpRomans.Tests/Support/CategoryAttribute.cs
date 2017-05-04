using System;
using Xunit.Sdk;

namespace SharpRomans.Tests.Support
{
	[TraitDiscoverer(CategoryDiscoverer.ClassName, CategoryDiscoverer.AssemblyName)]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
	class CategoryAttribute : Attribute, ITraitAttribute
	{
		public CategoryAttribute(string category) { }
	}
}