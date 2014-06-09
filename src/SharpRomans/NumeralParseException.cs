using System;

namespace SharpRomans
{
	public partial class NumeralParseException : FormatException
	{
		public NumeralParseException() { }

		public NumeralParseException(string message) : base(message) { }

		public NumeralParseException(string message, Exception inner) : base(message, inner) { }

		internal static NumeralParseException Build(string toBeParsed)
		{
			string message = string.Format("An invalid roman numeral '{0}' was specified.", toBeParsed);
			var ex = new NumeralParseException(message);
			return ex;
		}
	}	
}