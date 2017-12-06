using System;
using SharpRomans.Support;

namespace SharpRomans
{
	public partial class NumeralOutOfRangeException : ArgumentOutOfRangeException
	{
		public NumeralOutOfRangeException() { }

		public NumeralOutOfRangeException(string message) : base(message) { }

		public NumeralOutOfRangeException(string message, Exception inner) : base(message, inner) { }

		private NumeralOutOfRangeException(string paramName, string message) : base(paramName, message) { }

		internal static NumeralOutOfRangeException Build(string paramName, ushort value, Range<ushort> validity)
		{
			string message = $"Only numbers contained within {validity} are allowed.\nActual value was '{value}'";
			var ex = new NumeralOutOfRangeException(paramName, message);
			return ex;
		}
	}
}