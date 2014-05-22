using System;
using System.Linq.Expressions;

namespace SharpRomans.Tests.Spec.Support
{
	internal class Op<T>
	{
		private readonly Expression<Func<T, T, bool>> _exp;

		protected Op(Expression<Func<T, T, bool>> exp)
		{
			_exp = exp;
		}

		public bool Execute(T x, T y)
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
				.Trim();
		}
	}
}