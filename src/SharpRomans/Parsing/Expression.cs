namespace SharpRomans.Parsing
{
	internal abstract class Expression
	{
		public void Interpret(Context context)
		{
			if (context.IsEmpty) return;

			bool alreadyApplied = false;
			if (context.StartsWith(Nine))
			{
				context.Plus(9, this).Trim(2);
				alreadyApplied = true;
			}

			else if (context.StartsWith(Four))
			{
				context.Plus(4, this).Trim(2);
			}

			else if (context.StartsWith(Five))
			{
				context.Plus(5, this).Trim(1);
			}

			byte repetition = 0;
			while (context.StartsWith(One) && (repetition++ < MaxRepetitions) && !alreadyApplied)
			{
				context.Plus(1, this).Trim(1);
			}
		}

		public abstract string One { get; }

		public abstract string Four { get; }

		public abstract string Five { get; }

		public abstract string Nine { get; }

		public abstract ushort Multiplier { get; }

		public virtual byte MaxRepetitions { get { return 3; } }
	}
}