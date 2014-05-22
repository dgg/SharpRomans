using System;
using System.Linq.Expressions;

namespace SharpRomans.Tests.Spec.Roman_Numeral.Support
{
	internal class Ins
	{
		private readonly Expression<Func<RomanNumeral>> _exp;

		private Ins(Expression<Func<RomanNumeral>> exp)
		{
			_exp = exp;
		}

		public RomanNumeral Execute()
		{
			return _exp.Compile()();
		}

		public static Ins tance(Expression<Func<RomanNumeral>> exp)
		{
			return new Ins(exp);
		}
		private const string DOT = ".";
		public override string ToString()
		{
			string str = _exp.ToString();
			int index = str.IndexOf(DOT, StringComparison.OrdinalIgnoreCase);
			return str.Substring(index + DOT.Length).Trim();
		}
	}
}