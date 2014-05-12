using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SharpRomans
{
	public class RomanFigure
	{
		public char Figure { get; private set; }
		public ushort Value { get; private set; }
		public string Description { get; private set; }

		public bool IsSubstractive { get; private set; }
		public bool IsSingle { get; private set; }
		public bool IsRepeteable { get; private set; }

		private readonly string _string;
		private RomanFigure(char figure, ushort value, string description, bool isSubstractive, bool isSingle, bool isRepeteable)
		{
			Figure = figure;
			_string = figure.ToString(CultureInfo.InvariantCulture);
			Value = value;
			Description = description;
			IsSubstractive = isSubstractive;
			IsSingle = isSingle;
			IsRepeteable = isRepeteable;
		}

		public static readonly RomanFigure N = new RomanFigure('N', 0, "nulla", false, false, false);
		public static readonly RomanFigure I = new RomanFigure('I', 1, "unus", true, false, true);
		public static readonly RomanFigure V = new RomanFigure('V', 5, "quique", false, true, false);
		public static readonly RomanFigure X = new RomanFigure('X', 10, "decem", true, false, true);
		public static readonly RomanFigure L = new RomanFigure('L', 50, "quinquaginta", false, true, false);
		public static readonly RomanFigure C = new RomanFigure('C', 100, "centum", true, false, true);
		public static readonly RomanFigure D = new RomanFigure('D', 500, "quingenti", false, true, false);
		public static readonly RomanFigure M = new RomanFigure('M', 1000, "mille", false, false, true);

		public static readonly IEnumerable<RomanFigure> All = new[] { N, I, V, X, L, C, D, M };

		public override string ToString()
		{
			return _string;
		}

		#region Parsing

		public static RomanFigure Parse(char figure)
		{
			RomanFigure parsed;
			if (!TryParse(figure, out parsed))
			{
				throw new ArgumentException(string.Format("Requested value '{0}' was not found", figure), "figure");
			}
			return parsed;
		}

		public static RomanFigure Parse(string figure)
		{
			return Parse(char.Parse(figure));
		}

		public static bool TryParse(char figure, out RomanFigure parsed)
		{
			parsed = All.FirstOrDefault(f => f.Figure.Equals(figure));
			return parsed != null;
		}

		public static bool TryParse(string figure, out RomanFigure parsed)
		{
			bool success = false;
			parsed = null;
			char character;
			if (char.TryParse(figure, out character))
			{
				success = TryParse(character, out parsed);
			}
			return success;
		}

		#endregion

		#region Convert

		public static RomanFigure Convert(ushort value)
		{
			try
			{
				return All.Single(f => f.Value.Equals(value));
			}
			catch (InvalidOperationException ex)
			{
				throw new ArgumentException(string.Format("Requested value '{0}' was not found", value), "value", ex);
			}
		}

		public static bool TryConvert(ushort value, out RomanFigure figure)
		{
			figure = All.SingleOrDefault(f => f.Value.Equals(value));
			return figure != null;
		}

		#endregion

	}
}