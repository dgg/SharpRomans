namespace SharpRomans.Parsing
{
	// to prevent concurrency problems, make it transient since expression hold state
	internal class ExpressionComposite
	{
		private readonly Expression[] _elements;
		internal ExpressionComposite()
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

		public ushort? Parse(string toBeParsed)
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