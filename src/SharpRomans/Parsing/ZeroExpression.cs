namespace SharpRomans.Parsing
{
	internal sealed class ZeroExpression : Expression
	{
		public override string One => "N";

		public override string Four => " ";

		public override string Five => " ";

		public override string Nine => " ";

		public override ushort Multiplier => 0;

		public override byte MaxRepetitions => 1;
	}
}