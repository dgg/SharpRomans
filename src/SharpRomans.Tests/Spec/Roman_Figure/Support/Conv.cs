using System;
using System.Linq.Expressions;

namespace SharpRomans.Tests.Spec.Roman_Figure.Support
{
	internal class Conv
	{
		private readonly Expression<Func<RomanFigure, object>> _exp;

		private Conv(Expression<Func<RomanFigure, object>> exp)
		{
			_exp = exp;
		}

		public object Execute(RomanFigure x)
		{
			return _exp.Compile()(x);
		}

		public static Conv ert(Expression<Func<RomanFigure, object>> exp)
		{
			return new Conv(exp);
		}

		public override string ToString()
		{
			var unary = _exp.Body as UnaryExpression;
			if (unary != null)
			{
				return unary.Operand.Type.ToString();
			}
			var call = _exp.Body as MethodCallExpression;
			if (call != null)
			{
				return call.Type.ToString();
			}
			throw new NotSupportedException(_exp.Body.GetType().Name);
		}
	}
}