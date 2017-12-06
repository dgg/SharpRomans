using System;

namespace SharpRomans.Parsing
{
	internal sealed class Context
	{
		private string _input;
		private ushort _output;
		
		public Context(string input)
		{
			_input = input;
		}

		internal bool IsEmpty => string.IsNullOrWhiteSpace(_input);

		internal ushort? GetValue()
		{
			return string.IsNullOrWhiteSpace(_input) ? _output : default(ushort?);
		}

		internal bool StartsWith(string s)
		{
			return _input.StartsWith(s, StringComparison.OrdinalIgnoreCase);
		}

		internal void Trim(int numberOfCharacters)
		{
			_input = _input.Substring(numberOfCharacters);
		}

		public Context Plus(int factor, Expression expression)
		{
			_output += Convert.ToUInt16(factor * expression.Multiplier);
			return this;
		}
	}
}