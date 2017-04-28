using System;
using SharpRomans.Tests.Spec.Roman_Figure.Support;
using Xunit;

namespace SharpRomans.Tests.Spec.Roman_Figure
{
	public abstract class ConversionsBase
	{
		protected RomanFigure _subject;
		protected void TheRomanFigure_(RomanFigure subject)
		{
			_subject = subject;
		}

		protected Func<object> _conversion;
		internal void ConvertedTo_(Conv exp)
		{
			_conversion = () => exp.Execute(_subject);
		}

		protected void Is_<T>(T value)
		{
			Assert.Equal(value, _conversion());
		}

		protected void Overflows()
		{
			Assert.ThrowsAny<OverflowException>(_conversion);
		}
	}
}