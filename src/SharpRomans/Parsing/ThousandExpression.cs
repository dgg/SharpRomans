namespace SharpRomans.Parsing
{
	// Thousand checks for the Roman Numeral M
	internal sealed class ThousandExpression : Expression
	{
		public override string One => "M";

		public override string Four => " ";

		public override string Five => " ";

		public override string Nine => " ";

		public override ushort Multiplier => 1000;
	}
}