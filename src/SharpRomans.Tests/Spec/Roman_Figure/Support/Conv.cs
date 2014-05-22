using System;
using System.Linq.Expressions;
using SharpRomans.Tests.Spec.Support;

namespace SharpRomans.Tests.Spec.Roman_Figure.Support
{
	internal class Conv : Conv<RomanFigure>
	{
		private Conv(Expression<Func<RomanFigure, object>> exp) : base(exp) { }

		public static Conv ert(Expression<Func<RomanFigure, object>> exp)
		{
			return new Conv(exp);
		}
	}
}