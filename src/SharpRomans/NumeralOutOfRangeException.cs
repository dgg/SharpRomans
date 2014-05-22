using System;
using System.Runtime.Serialization;
using SharpRomans.Support;

namespace SharpRomans
{
	[Serializable]
	public class NumeralOutOfRangeException : ArgumentOutOfRangeException
	{
		public NumeralOutOfRangeException() { }

		public NumeralOutOfRangeException(string message) : base(message) { }

		public NumeralOutOfRangeException(string message, Exception inner) : base(message, inner) { }

		protected NumeralOutOfRangeException(SerializationInfo info, StreamingContext context) : base(info, context) { }

		internal NumeralOutOfRangeException(string paramName, ushort value, Range<ushort> validity) :
			base(paramName, value, string.Format("Only numbers contained within {0} are allowed.", validity)) { }
	}
}