namespace SharpRomans.Parsing
{
	// checks C, CD, D or CM
	internal class HundredExpression : Expression
	{
		public override string One
		{
			get { return "C"; }
		}

		public override string Four
		{
			get { return "CD"; }
		}

		public override string Five
		{
			get { return "D"; }
		}

		public override string Nine
		{
			get { return "CM"; }
		}

		public override ushort Multiplier
		{
			get { return 100; }
		}
	}
}