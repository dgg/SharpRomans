using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using SharpRomans.Parsing;
using SharpRomans.Support;

namespace SharpRomans
{
	public sealed class RomanNumeral : IComparable<RomanNumeral>, IEquatable<RomanNumeral>, IValuable
	{
		public static readonly ushort MinValue = default(ushort);
		public static readonly ushort MaxValue = 3999;
		private static readonly Range<ushort> _validity = new Range<ushort>(MinValue, MaxValue);

		public ushort Value { get; private set; }
		public ReadOnlyCollection<RomanFigure> Figures { get; private set; }
		private readonly string _figures;
		public RomanNumeral(ushort number)
		{
			AssertRange(number);

			Value = number;

			Figures = number.Equals(0) ? NumeralFigures.Zero : NumeralFigures.Calculate(number);

			_figures = Figures.Aggregate(
				new StringBuilder(NumeralFigures.MaxLength),
				(sb, f) => sb.Append(f),
				sb => sb.ToString());
		}

		public static void AssertRange(ushort value)
		{
			if (!CheckRange(value)) throw NumeralOutOfRangeException.Build("value", value, _validity);
		}

		public static bool CheckRange(ushort value)
		{
			return _validity.Contains(value);
		}

		public static readonly RomanNumeral Min = new RomanNumeral(MinValue);
		public static readonly RomanNumeral Max = new RomanNumeral(MaxValue);
		public static readonly RomanNumeral Zero = new RomanNumeral(0);

		public override string ToString()
		{
			return _figures;
		}

		#region comparisons

		public int CompareTo(RomanNumeral other)
		{
			return ReferenceEquals(other, null) ? 1 : Value.CompareTo(other.Value);
		}

		#region operators

		public static bool operator >(RomanNumeral left, RomanNumeral right)
		{
			return left != null && left.CompareTo(right) > 0;
		}

		public static bool operator >=(RomanNumeral left, RomanNumeral right)
		{
			return left == (RomanNumeral)null ? right == null : left.CompareTo(right) >= 0;
		}

		public static bool operator <(RomanNumeral left, RomanNumeral right)
		{
			return left == (RomanNumeral)null ? right != null : left.CompareTo(right) < 0;
		}

		public static bool operator <=(RomanNumeral left, RomanNumeral right)
		{
			return left == null || left.CompareTo(right) <= 0;
		}

		#endregion

		#endregion

		#region equality

		public bool Equals(RomanNumeral other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Value == other.Value;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;

			var a = obj as RomanNumeral;
			if (a != null) return Equals(a);

			return false;
		}

		public override int GetHashCode()
		{
			return Value.GetHashCode();
		}

		public static bool operator ==(RomanNumeral left, RomanNumeral right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(RomanNumeral left, RomanNumeral right)
		{
			return !Equals(left, right);
		}

		#endregion

		#region castings

		public static explicit operator ushort(RomanNumeral numeral)
		{
			if (numeral == null) throw new ArgumentNullException("numeral");

			return numeral.Value;
		}

		public static explicit operator string(RomanNumeral numeral)
		{
			if (numeral == null) return null;

			return numeral._figures;
		}

		#endregion

		#region arithmetic

		public RomanNumeral Plus(RomanNumeral numeral)
		{
			return withValue(numeral, (value, valuable) => (ushort)(value + valuable.Value));
		}

		public RomanNumeral Plus(RomanFigure figure)
		{
			return withValue(figure, (value, valuable) => (ushort)(value + valuable.Value));
		}

		public RomanNumeral Minus(RomanNumeral numeral)
		{
			return withValue(numeral, (value, valuable) => (ushort)(value - valuable.Value));
		}

		public RomanNumeral Minus(RomanFigure figure)
		{
			return withValue(figure, (value, valuable) => (ushort)(value - valuable.Value));
		}

		private RomanNumeral withValue(IValuable valuable, Func<ushort, IValuable, ushort> op)
		{
			if (valuable == null) return this;

			var result = op(Value, valuable);

			AssertRange(result);
			return new RomanNumeral(result);
		}

		#region operators

		public static RomanNumeral operator +(RomanNumeral left, RomanNumeral right)
		{
			return left == null ? right : left.Plus(right);
		}

		public static RomanNumeral operator +(RomanNumeral left, RomanFigure right)
		{
			return left == null ?
				(right == null ? null : new RomanNumeral(right.Value)) :
				left.Plus(right);
		}

		public static RomanNumeral operator -(RomanNumeral left, RomanNumeral right)
		{
			return left == null ? right : left.Minus(right);
		}

		public static RomanNumeral operator -(RomanNumeral left, RomanFigure right)
		{
			return left == null ?
				(right == null ? null : new RomanNumeral(right.Value)) :
				left.Minus(right);
		}

		#endregion

		#endregion

		public static RomanNumeral Parse(string numeral)
		{
			assertInput(numeral);

			ushort? parsed = new ExpressionComposite().Parse(numeral);

			assertParsing(numeral, parsed);

			return new RomanNumeral(parsed.GetValueOrDefault());
		}

		private static void assertInput(string numeral)
		{
			if (numeral == null) throw new ArgumentNullException("numeral");
			if (string.IsNullOrWhiteSpace(numeral)) throw new ArgumentException(null, "numeral");
		}

		private static bool checkInput(string numeral)
		{
			return !string.IsNullOrWhiteSpace(numeral);
		}

		private static void assertParsing(string numeral, ushort? parsed)
		{
			if (!parsed.HasValue)
			{
				throw NumeralParseException.Build(numeral);
			}
		}

		public static bool TryParse(string numeral, out RomanNumeral result)
		{
			result = null;
			bool success = false;

			if (checkInput(numeral))
			{
				ushort? parsed = new ExpressionComposite().Parse(numeral);

				if (parsed.HasValue)
				{
					result = new RomanNumeral(parsed.Value);
					success = true;
				}
			}

			return success;
		}
	}
}
