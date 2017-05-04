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
			yield return new KeyValuePair<string, string>(CategoryAttribute.TraitName, ctorArgs[0].ToString());

			foreach (var trait in propertyTrait(traitAttribute,
				nameof(CategoryAttribute.Feature),
				nameof(CategoryAttribute.Subject)))
			{
				yield return trait;
			}
		}

		private IEnumerable<KeyValuePair<string, string>> propertyTrait(IAttributeInfo traitAttribute, params string[] propertyNames)
		{
			foreach (var propertyName in propertyNames)
			{
				string propertyValue = traitAttribute.GetNamedArgument<string>(propertyName);
				if (!string.IsNullOrWhiteSpace(propertyValue))
				{
					yield return new KeyValuePair<string, string>(CategoryAttribute.TraitName, propertyValue);
					yield return new KeyValuePair<string, string>(propertyName, propertyValue);
				}
			}
		}

		public const string AssemblyName = nameof(SharpRomans) + "." +
			nameof(Tests);

		public const string ClassName = nameof(SharpRomans) + "." + 
			nameof(Tests) + "." + 
			nameof(Support) + "." +
			nameof(CategoryDiscoverer);
	}
}