namespace SharpRomans.Parsing
{
	// Thousand checks for the Roman Numeral M
	internal class ThousandExpression : Expression
	{
		public override string One
		{
			get { return "M"; }
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
			get { return 1000; }
		}
	}
}