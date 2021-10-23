using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSSV.IO
{
    public static class BinaryNumericConverter
    {
        public static ushort ToUInt16(byte[] value, bool isBigEndian = false)
        {
            if (isBigEndian)
                return BinaryPrimitives.ReadUInt16BigEndian(value);

            return BinaryPrimitives.ReadUInt16LittleEndian(value);
        }

        public static short ToInt16(byte[] value, bool isBigEndian = false)
        {
            if (isBigEndian)
                return BinaryPrimitives.ReadInt16BigEndian(value);

            return BinaryPrimitives.ReadInt16LittleEndian(value);
        }

        public static uint ToUInt32(byte[] value, bool isBigEndian = false)
        {
            if (isBigEndian)
                return BinaryPrimitives.ReadUInt32BigEndian(value);

            return BinaryPrimitives.ReadUInt32LittleEndian(value);
        }

        public static int ToInt32(byte[] value, bool isBigEndian = false)
        {
            if (isBigEndian)
                return BinaryPrimitives.ReadInt32BigEndian(value);

            return BinaryPrimitives.ReadInt32LittleEndian(value);
        }

        public static ulong ToUInt64(byte[] value, bool isBigEndian = false)
        {
            if (isBigEndian)
                return BinaryPrimitives.ReadUInt64BigEndian(value);

            return BinaryPrimitives.ReadUInt64LittleEndian(value);
        }

        public static long ToInt64(byte[] value, bool isBigEndian = false)
        {
            if (isBigEndian)
                return BinaryPrimitives.ReadInt64BigEndian(value);

            return BinaryPrimitives.ReadInt64LittleEndian(value);
        }

        public static float ToSingle(byte[] value, bool isBigEndian = false)
        {
            if (isBigEndian)
                return BinaryPrimitives.ReadSingleBigEndian(value);

            return BinaryPrimitives.ReadSingleLittleEndian(value);
        }

        public static double ToDouble(byte[] value, bool isBigEndian = false)
        {
            if (isBigEndian)
                return BinaryPrimitives.ReadDoubleBigEndian(value);
            
            return BinaryPrimitives.ReadDoubleLittleEndian(value);
        }

        public static byte[] GetBytes(ushort value, bool isBigEndian = false)
        {
            byte[] bytes = new byte[sizeof(ushort)];

            if (isBigEndian)
                BinaryPrimitives.WriteUInt16BigEndian(bytes, value);

            else
                BinaryPrimitives.WriteUInt16LittleEndian(bytes, value);

            return bytes;
        }

        public static byte[] GetBytes(short value, bool isBigEndian = false)
        {
            byte[] bytes = new byte[sizeof(short)];

            if (isBigEndian)
                BinaryPrimitives.WriteInt16BigEndian(bytes, value);

            else
                BinaryPrimitives.WriteInt16LittleEndian(bytes, value);

            return bytes;
        }

        public static byte[] GetBytes(uint value, bool isBigEndian = false)
        {
            byte[] bytes = new byte[sizeof(uint)];

            if (isBigEndian)
                BinaryPrimitives.WriteUInt32BigEndian(bytes, value);

            else
                BinaryPrimitives.WriteUInt32LittleEndian(bytes, value);

            return bytes;
        }

        public static byte[] GetBytes(int value, bool isBigEndian = false)
        {
            byte[] bytes = new byte[sizeof(int)];

            if (isBigEndian)
                BinaryPrimitives.WriteInt32BigEndian(bytes, value);

            else
                BinaryPrimitives.WriteInt32LittleEndian(bytes, value);

            return bytes;
        }

        public static byte[] GetBytes(ulong value, bool isBigEndian = false)
        {
            byte[] bytes = new byte[sizeof(ulong)];

            if (isBigEndian)
                BinaryPrimitives.WriteUInt64BigEndian(bytes, value);

            else
                BinaryPrimitives.WriteUInt64LittleEndian(bytes, value);

            return bytes;
        }

        public static byte[] GetBytes(long value, bool isBigEndian = false)
        {
            byte[] bytes = new byte[sizeof(long)];

            if (isBigEndian)
                BinaryPrimitives.WriteInt64BigEndian(bytes, value);

            else
                BinaryPrimitives.WriteInt64LittleEndian(bytes, value);

            return bytes;
        }

        public static byte[] GetBytes(float value, bool isBigEndian = false)
        {
            byte[] bytes = new byte[sizeof(float)];

            if (isBigEndian)
                BinaryPrimitives.WriteSingleBigEndian(bytes, value);

            else
                BinaryPrimitives.WriteSingleLittleEndian(bytes, value);

            return bytes;
        }

        public static byte[] GetBytes(double value, bool isBigEndian = false)
        {
            byte[] bytes = new byte[sizeof(double)];

            if (isBigEndian)
                BinaryPrimitives.WriteDoubleBigEndian(bytes, value);

            else
                BinaryPrimitives.WriteDoubleLittleEndian(bytes, value);

            return bytes;
        }
    }
}
