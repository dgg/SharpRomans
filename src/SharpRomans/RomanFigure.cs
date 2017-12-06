using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpRomans
{
	public sealed class RomanFigure : IComparable<RomanFigure>, IEquatable<RomanFigure>, IValuable
	{
		public char Literal { get; }
		public ushort Value { get; }
		public string Name { get; }

		public bool IsSubstractive { get; }
		public bool IsRepeteable { get; }

		private readonly string _string;
		private RomanFigure(char literal, ushort value, string name, bool isSubstractive, bool isRepeteable)
		{
			Literal = literal;
			_string = literal.ToString();
			Value = value;
			Name = name;
			IsSubstractive = isSubstractive;
			IsRepeteable = isRepeteable;
		}

		public static readonly RomanFigure N = new RomanFigure('N', 0, "nulla", false, false);
		public static readonly RomanFigure I = new RomanFigure('I', 1, "unus", true, true);
		public static readonly RomanFigure V = new RomanFigure('V', 5, "quinque", false, false);
		public static readonly RomanFigure X = new RomanFigure('X', 10, "decem", true, true);
		public static readonly RomanFigure L = new RomanFigure('L', 50, "quinquaginta", false, false);
		public static readonly RomanFigure C = new RomanFigure('C', 100, "centum", true, true);
		public static readonly RomanFigure D = new RomanFigure('D', 500, "quingenti", false, false);
		public static readonly RomanFigure M = new RomanFigure('M', 1000, "mille", false, true);

		public static readonly IEnumerable<RomanFigure> All = new[] { N, I, V, X, L, C, D, M };

		public override string ToString()
		{
			return _string;
		}

		#region Parsing

		public static RomanFigure Parse(char figure)
		{
			if (!TryParse(figure, out var parsed))
			{
				throw new ArgumentException($"Requested value '{figure}' was not found", nameof(figure));
			}
			return parsed;
		}

		public static RomanFigure Parse(string figure)
		{
			return Parse(System.Convert.ToChar(figure));
		}

		public static bool TryParse(char figure, out RomanFigure parsed)
		{
			parsed = All.FirstOrDefault(f => f.Literal.Equals(figure));
			return parsed != null;
		}

		public static bool TryParse(string figure, out RomanFigure parsed)
		{
			bool success = false;
			parsed = null;
			if (char.TryParse(figure, out var character))
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
			catch (InvalidOperationException)
			{
				throw new ArgumentException($"Requested value '{value}' was not found", nameof(value));
			}
		}

		public static bool TryConvert(ushort value, out RomanFigure figure)
		{
			figure = All.SingleOrDefault(f => f.Value.Equals(value));
			return figure != null;
		}

		#endregion

		#region comparisons

		public int CompareTo(RomanFigure another)
		{
			return ReferenceEquals(another, null) ? 1 : Value.CompareTo(another.Value);
		}

		#region operators

		public static bool operator >(RomanFigure left, RomanFigure right)
		{
			return left != null && left.CompareTo(right) > 0;
		}

		public static bool operator >=(RomanFigure left, RomanFigure right)
		{
			return left == null ? right == null : left.CompareTo(right) >= 0;
		}

		public static bool operator <(RomanFigure left, RomanFigure right)
		{
			return left == null ? right != null : left.CompareTo(right) < 0;
		}

		public static bool operator <=(RomanFigure left, RomanFigure right)
		{
			return left == null || left.CompareTo(right) <= 0;
		}

		#endregion

		#endregion

		#region castings

		public static explicit operator char(RomanFigure figure)
		{
			if (figure == null) throw new ArgumentNullException(nameof(figure));

			return figure.Literal;
		}

		public static explicit operator ushort(RomanFigure figure)
		{
			if (figure == null) throw new ArgumentNullException(nameof(figure));

			return figure.Value;
		}

		public static explicit operator string(RomanFigure figure)
		{
			if (figure == null) return null;

			return figure._string;
		}

		#endregion

		#region equality

		public bool Equals(RomanFigure figure)
		{
			if (ReferenceEquals(null, figure)) return false;
			if (ReferenceEquals(this, figure)) return true;
			return figure.Value == Value;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;

			var a = obj as RomanFigure;
			if (a != null) return Equals(a);

			return false;
		}

		public override int GetHashCode()
		{
			return Value.GetHashCode();
		}

		public static bool operator ==(RomanFigure left, RomanFigure right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(RomanFigure left, RomanFigure right)
		{
			return !Equals(left, right);
		}

		#endregion
	}
}