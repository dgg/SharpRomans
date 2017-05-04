using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace SharpRomans.Tests.Support
{
	public class CategoryDiscoverer : ITraitDiscoverer
	{
		/// <summary>
		/// Gets the trait values from the Category attribute.
		/// </summary>
		/// <param name="traitAttribute">The trait attribute containing the trait values.</param>
		/// <returns>The trait values.</returns>
		public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
		{
			var ctorArgs = traitAttribute.GetConstructorArguments().ToList();
			yield return new KeyValuePair<string, string>("Category", ctorArgs[0].ToString());
		}

		public const string AssemblyName = nameof(SharpRomans) + "." +
		                                   nameof(Tests);
	}
}