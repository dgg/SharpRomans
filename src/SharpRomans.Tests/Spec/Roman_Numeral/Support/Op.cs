using System;
using System.Linq.Expressions;

namespace SharpRomans.Tests.Spec.Roman_Numeral.Support
{
	internal class Op
	{
		private readonly Expression<Func<RomanNumeral, RomanNumeral, bool>> _exp;

		private Op(Expression<Func<RomanNumeral, RomanNumeral, bool>> exp)
		{
			_exp = exp;
		}

		public bool Execute(RomanNumeral x, RomanNumeral y)
		{
			return _exp.Compile()(x, y);
		}

		private const string ROCKET = "=>";
		public override string ToString()
		{
			string str = _exp.ToString();
			int index = str.IndexOf(ROCKET, StringComparison.OrdinalIgnoreCase);
			return str.Substring(index + ROCKET.Length).Trim()
				.Replace("(x", string.Empty)
				.Replace("y)", string.Empty)
				.Trim()
				;
		}

		public static Op Gt { get { return new Op((x, y) => x > y); } }

		public static Op GtE { get { return new Op((x, y) => x >= y); } }

		public static Op Lt { get { return new Op((x, y) => x < y); } }

		public static Op LtE { get { return new Op((x, y) => x <= y); } }
	}
}