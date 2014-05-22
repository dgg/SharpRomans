using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using SharpRomans.Support;

namespace SharpRomans
{
	public sealed class RomanNumeral : IComparable<RomanNumeral>, IEquatable<RomanNumeral>, IConvertible
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
			if (!CheckRange(value)) throw new NumeralOutOfRangeException("value", value, _validity);
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

		#region IConvertible

		public TypeCode GetTypeCode()
		{
			throw new NotImplementedException();
		}

		public bool ToBoolean(IFormatProvider provider)
		{
			return Convert.ToBoolean(Value, provider);
		}

		public char ToChar(IFormatProvider provider)
		{
			return Convert.ToChar(_figures, provider);
		}

		public sbyte ToSByte(IFormatProvider provider)
		{
			return Convert.ToSByte(Value, provider);
		}

		public byte ToByte(IFormatProvider provider)
		{
			return Convert.ToByte(Value, provider);
		}

		public short ToInt16(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public ushort ToUInt16(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public int ToInt32(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public uint ToUInt32(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public long ToInt64(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public ulong ToUInt64(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public float ToSingle(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public double ToDouble(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public decimal ToDecimal(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public DateTime ToDateTime(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public string ToString(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public object ToType(Type conversionType, IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
