using System;
using System.Linq.Expressions;

namespace SharpRomans.Tests.Spec.Roman_Figure.Support
{
	internal class Op
	{
		private readonly Expression<Func<RomanFigure, RomanFigure, bool>> _exp;

		private Op(Expression<Func<RomanFigure, RomanFigure, bool>> exp)
		{
			_exp = exp;
		}

		public bool Execute(RomanFigure x, RomanFigure y)
		{
			return _exp.Compile()(x, y);
		}

		private const string ROCKET = "=>";
		public override string ToString()
		{
			string str = _exp.ToString();
			int index =  str.IndexOf(ROCKET, StringComparison.OrdinalIgnoreCase);
			return str.Substring(index + ROCKET.Length).Trim()
				.Replace("(x", string.Empty)
				.Replace("y)", string.Empty)
				.Trim()
				;
		}

		public static Op Gt { get { return new Op((x, y) => x > y); } }

		public static Op GtOE { get { return new Op((x, y) => x >= y); } }

		public static Op Lt { get { return new Op((x, y) => x < y); } }

		public static Op LtOE { get { return new Op((x, y) => x <= y); } }
	}
}