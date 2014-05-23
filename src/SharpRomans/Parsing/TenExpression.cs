namespace SharpRomans.Parsing
{
	// Ten checks for X, XL, L and XC
	internal class TenExpression : Expression
	{
		public override string One
		{
			get { return "X"; }
		}

		public override string Four
		{
			get { return "XL"; }
		}

		public override string Five
		{
			get { return "L"; }
		}

		public override string Nine
		{
			get { return "XC"; }
		}

		public override ushort Multiplier
		{
			get { return 10; }
		}
	}
}