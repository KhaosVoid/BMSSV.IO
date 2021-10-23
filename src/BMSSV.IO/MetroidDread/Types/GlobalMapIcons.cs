using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSSV.IO.MetroidDread.Types
{
    public class GlobalMapIcons : IType<GlobalMapIcons>
    {
        #region Properties

        public string AreaId { get; set; }
        public GlobalMapIcon[] Items { get; set; }

        #endregion Properties

        #region Methods

        byte[] IType<GlobalMapIcons>.GetBytes()
        {
            return GetBytes();
        }

        internal byte[] GetBytes()
        {
            List<byte> bytes = new List<byte>();

            bytes.AddRange(Encoding.UTF8.GetBytes(AreaId + (char)0x00));
            bytes.AddRange(BinaryNumericConverter.GetBytes(Items.Length));

            for (int i = 0; i < Items.Length; i++)
                bytes.AddRange(Items[i].GetBytes());

            return bytes.ToArray();
        }

        GlobalMapIcons IType<GlobalMapIcons>.FromStream(Stream stream)
        {
            return FromStream(stream);
        }

        internal static GlobalMapIcons FromStream(Stream stream)
        {
            GlobalMapIcons globalMapIcons = new GlobalMapIcons();
            long lastPosition = stream.Position;
            int nameNullTerminatorIndex;
            byte[] buffer = new byte[1024];

            stream.Read(buffer, 0, buffer.Length);

            nameNullTerminatorIndex = Array.IndexOf(buffer, (byte)0x00);

            buffer = new byte[nameNullTerminatorIndex + 1];
            stream.Position = lastPosition;

            stream.Read(buffer, 0, buffer.Length);

            globalMapIcons.AreaId = Encoding.UTF8.GetString(buffer).Trim((char)0x00);

            int itemsLength;

            buffer = new byte[sizeof(int)];

            stream.Read(buffer, 0, buffer.Length);

            itemsLength = BinaryNumericConverter.ToInt32(buffer);
            globalMapIcons.Items = new GlobalMapIcon[itemsLength];

            for (int l = 0; l < itemsLength; l++)
                globalMapIcons.Items[l] = GlobalMapIcon.FromStream(stream);

            return globalMapIcons;
        }

        #endregion Methods
    }
}
