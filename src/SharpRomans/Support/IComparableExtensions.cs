using System;

namespace SharpRomans.Support
{
	internal static class IComparableExtensions
	{
		public static bool IsMoreThan<T>(this T instance, T value) where T : IComparable<T>
		{
			return instance.CompareTo(value) > 0;
		}

		public static bool IsAtLeast<T>(this T instance, T value) where T : IComparable<T>
		{
			return instance.CompareTo(value) >= 0;
		}

		public static bool IsAtMost<T>(this T instance, T value) where T : IComparable<T>
		{
			return instance.CompareTo(value) <= 0;
		}
	}
}