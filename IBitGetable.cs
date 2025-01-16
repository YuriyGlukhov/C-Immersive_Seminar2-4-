using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace С_Immersive_Seminar3_5_
{
    internal interface IBitGetable
    {
        bool GetBitByIndex(byte index);
        void SetBitByIndex(byte index, bool value);
    }

    internal class Bits : IBitGetable
    {
        public long Value { get; private set; }

        public Bits(long value)
        {
            Value = value;
        }

        public Bits()
        {
        }

        public bool GetBitByIndex(byte index)
        {
            return (Value & (1L << index)) != 0;
        }

        public void SetBitByIndex(byte index, bool value)
        {
            if (value)
            {
                Value |= (1L << index);
            }
            else
            {
                Value &= ~(1L << index);
            }
        }

        public bool this[byte index]
        {
            get => GetBitByIndex(index);
            set => SetBitByIndex(index, value);
        }

        public static implicit operator Bits(long value) => new(value);
        public static implicit operator Bits(int value) => new(value);
        public static implicit operator Bits(byte value) => new(value);

        public static explicit operator long(Bits bits) => bits.Value;
        public static explicit operator int(Bits bits) => (int)bits.Value;
        public static explicit operator short(Bits bits) => (short)bits.Value;
        public static explicit operator byte(Bits bits) => (byte)bits.Value;
    }
}

