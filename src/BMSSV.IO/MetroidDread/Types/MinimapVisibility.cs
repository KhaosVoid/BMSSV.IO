using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSSV.IO.MetroidDread.Types
{
    public class MinimapVisibility : IType<MinimapVisibility>
    {
        #region Properties

        public int Index { get; set; }
        public string Value { get; set; } //TODO: Parse this further

        #endregion Properties

        #region Methods

        byte[] IType<MinimapVisibility>.GetBytes()
        {
            return GetBytes();
        }

        internal byte[] GetBytes()
        {
            List<byte> bytes = new List<byte>();
            bytes.AddRange(BinaryNumericConverter.GetBytes(Index));
            bytes.AddRange(Encoding.UTF8.GetBytes(Value + (char)0x00));

            return bytes.ToArray();
        }

        MinimapVisibility IType<MinimapVisibility>.FromStream(Stream stream)
        {
            return FromStream(stream);
        }

        internal static MinimapVisibility FromStream(Stream stream)
        {
            MinimapVisibility minimapVisibilityMap = new MinimapVisibility();
            long lastPosition;
            byte[] buffer = new byte[sizeof(int)];

            stream.Read(buffer, 0, buffer.Length);

            minimapVisibilityMap.Index = BinaryNumericConverter.ToInt32(buffer);

            lastPosition = stream.Position;
            int valueNullTerminatorIndex;
            buffer = new byte[1024];

            stream.Read(buffer, 0, buffer.Length);

            valueNullTerminatorIndex = Array.IndexOf(buffer, (byte)0x00);
            buffer = new byte[valueNullTerminatorIndex + 1];
            stream.Position = lastPosition;

            stream.Read(buffer, 0, buffer.Length);

            minimapVisibilityMap.Value = Encoding.UTF8.GetString(buffer).Trim((char)0x00);

            return minimapVisibilityMap;
        }

        #endregion Methods
    }
}
