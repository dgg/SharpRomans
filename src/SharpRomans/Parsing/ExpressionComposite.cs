namespace SharpRomans.Parsing
{
	internal static class ExpressionComposite
	{
		private static readonly Expression[] _elements;
		static ExpressionComposite()
		{
			_elements = new Expression[]
			{
				new ZeroExpression(),
				new ThousandExpression(),
				new HundredExpression(),
				new TenExpression(),
				new OneExpression()
			};
		}

		public static ushort? Parse(string toBeParsed)
		{
			var context = new Context(toBeParsed);
			foreach (Expression exp in _elements)
			{
				exp.Interpret(context);
			}

			return context.GetValue();
		}
	}
}