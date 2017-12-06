namespace SharpRomans.Parsing
{
	// checks C, CD, D or CM
	internal sealed class HundredExpression : Expression
	{
		public override string One => "C";

		public override string Four => "CD";

		public override string Five => "D";

		public override string Nine => "CM";

		public override ushort Multiplier => 100;
	}
}