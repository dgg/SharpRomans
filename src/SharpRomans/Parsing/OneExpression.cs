namespace SharpRomans.Parsing
{
	// One checks for I, II, III, IV, V, VI, VI, VII, VIII, IX
	internal sealed class OneExpression : Expression
	{
		public override string One => "I";

		public override string Four => "IV";

		public override string Five => "V";

		public override string Nine => "IX";

		public override ushort Multiplier => 1;
	}
}