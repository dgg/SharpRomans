using System;
using System.Linq.Expressions;

namespace SharpRomans.Tests.Spec.Support
{
	internal class Conv<T>
	{
		private readonly Expression<Func<T, object>> _exp;

		protected Conv(Expression<Func<T, object>> exp)
		{
			_exp = exp;
		}

		public object Execute(T x)
		{
			return _exp.Compile()(x);
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