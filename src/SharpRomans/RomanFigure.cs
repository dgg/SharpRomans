using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SharpRomans
{
	public class RomanFigure : IComparable<RomanFigure>, IConvertible
	{
		public char Literal { get; private set; }
		public ushort Value { get; private set; }
		public string Name { get; private set; }

		public bool IsSubstractive { get; private set; }
		public bool IsRepeteable { get; private set; }

		private readonly string _string;
		private RomanFigure(char literal, ushort value, string name, bool isSubstractive, bool isRepeteable)
		{
			Literal = literal;
			_string = literal.ToString(CultureInfo.InvariantCulture);
			Value = value;
			Name = name;
			IsSubstractive = isSubstractive;
			IsRepeteable = isRepeteable;
		}

		public static readonly RomanFigure N = new RomanFigure('N', 0, "nulla", false, false);
		public static readonly RomanFigure I = new RomanFigure('I', 1, "unus", true, true);
		public static readonly RomanFigure V = new RomanFigure('V', 5, "quique", false, false);
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
			parsed = All.FirstOrDefault(f => f.Literal.Equals(figure));
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

		#region comparisons

		public int CompareTo(RomanFigure anotherFigure)
		{
			if (anotherFigure == null) return 1;
			return Value.CompareTo(anotherFigure.Value);
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

		#region IConvertible

		public TypeCode GetTypeCode()
		{
			return TypeCode.Object;
		}

		public bool ToBoolean(IFormatProvider provider)
		{
			return System.Convert.ToBoolean(Value, provider);
		}

		public char ToChar(IFormatProvider provider)
		{
			return System.Convert.ToChar(Literal, provider);
		}

		public sbyte ToSByte(IFormatProvider provider)
		{
			return System.Convert.ToSByte(Value, provider);
		}

		public byte ToByte(IFormatProvider provider)
		{
			return System.Convert.ToByte(Value, provider);
		}

		public short ToInt16(IFormatProvider provider)
		{
			return System.Convert.ToInt16(Value, provider);
		}

		public ushort ToUInt16(IFormatProvider provider)
		{
			return System.Convert.ToUInt16(Value, provider);
		}

		public int ToInt32(IFormatProvider provider)
		{
			return System.Convert.ToInt32(Value, provider);
		}

		public uint ToUInt32(IFormatProvider provider)
		{
			return System.Convert.ToUInt32(Value, provider);
		}

		public long ToInt64(IFormatProvider provider)
		{
			return System.Convert.ToInt64(Value, provider);
		}

		public ulong ToUInt64(IFormatProvider provider)
		{
			return System.Convert.ToUInt64(Value, provider);
		}

		public float ToSingle(IFormatProvider provider)
		{
			return System.Convert.ToSingle(Value, provider);
		}

		public double ToDouble(IFormatProvider provider)
		{
			return System.Convert.ToDouble(Value, provider);
		}

		public decimal ToDecimal(IFormatProvider provider)
		{
			return System.Convert.ToDecimal(Value, provider);
		}

		public DateTime ToDateTime(IFormatProvider provider)
		{
			throw invalidCast(typeof(DateTime));
		}

		private InvalidCastException invalidCast(Type other)
		{
			return new InvalidCastException(string.Format("Invalid cast from '{0}' to '{1}'", typeof(RomanFigure).Name, other.Name));
		}

		public string ToString(IFormatProvider provider)
		{
			return System.Convert.ToString(Literal, provider);
		}

		public object ToType(Type conversionType, IFormatProvider provider)
		{
			// only called when another CLR type is passed. So unless it is itself (weird) it cannot be converted
			if (conversionType == typeof(RomanFigure)) return this;
			throw invalidCast(conversionType);
		}

		#endregion

		#region castings

		public static implicit operator char(RomanFigure figure)
		{
			if (figure == null) throw new ArgumentNullException("figure");

			return figure.Literal;
		}

		#endregion
	}
}