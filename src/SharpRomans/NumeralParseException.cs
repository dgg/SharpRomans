using System;
using System.Runtime.Serialization;

namespace SharpRomans
{
	[Serializable]
	public class NumeralParseException : FormatException
	{
		public NumeralParseException() { }

		public NumeralParseException(string message) : base(message) { }

		public NumeralParseException(string message, Exception inner) : base(message, inner) { }

		protected NumeralParseException(SerializationInfo info, StreamingContext context) : base(info, context) { }

		internal static NumeralParseException Build(string toBeParsed)
		{
			string message = string.Format("An invalid roman numeral '{0}' was specified.", toBeParsed);
			var ex = new NumeralParseException(message);
			return ex;
		}
	}
}