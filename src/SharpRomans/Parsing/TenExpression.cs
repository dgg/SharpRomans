namespace SharpRomans.Parsing
{
	// Ten checks for X, XL, L and XC
	internal sealed class TenExpression : Expression
	{
		public override string One => "X";

		public override string Four => "XL";

		public override string Five => "L";

		public override string Nine => "XC";

		public override ushort Multiplier => 10;
	}
}