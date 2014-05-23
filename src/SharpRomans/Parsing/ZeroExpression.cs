namespace SharpRomans.Parsing
{
	internal class ZeroExpression : Expression
	{
		public override string One
		{
			get { return "N"; }
		}

		public override string Four
		{
			get { return " "; }
		}

		public override string Five
		{
			get { return " "; }
		}

		public override string Nine
		{
			get { return " "; }
		}

		public override ushort Multiplier
		{
			get { return 0; }
		}

		public override byte MaxRepetitions { get { return 1; } }
	}
}