namespace SharpRomans.Parsing
{
	// One checks for I, II, III, IV, V, VI, VI, VII, VIII, IX
	internal class OneExpression : Expression
	{
		public override string One
		{
			get { return "I"; }
		}

		public override string Four
		{
			get { return "IV"; }
		}

		public override string Five
		{
			get { return "V"; }
		}

		public override string Nine
		{
			get { return "IX"; }
		}

		public override ushort Multiplier
		{
			get { return 1; }
		}
	}
}