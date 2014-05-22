using System;
using System.Linq.Expressions;
using SharpRomans.Tests.Spec.Support;

namespace SharpRomans.Tests.Spec.Roman_Numeral.Support
{
	internal class Conv : Conv<RomanNumeral>
	{
		private Conv(Expression<Func<RomanNumeral, object>> exp) : base(exp) { }

		public static Conv ert(Expression<Func<RomanNumeral, object>> exp)
		{
			return new Conv(exp);
		}
	}
}