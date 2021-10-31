using BMSSV.IO.MetroidDread.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSSV.IO.MetroidDread.Properties
{
    public class OccluderVignettesDictionaryProperty : Property<Dictionary<string, bool>>
    {
        #region Ctor

        public OccluderVignettesDictionaryProperty(string name, Dictionary<string, bool> value)
            : base(name, DataTypes.OccluderVignettesDictionary, value)
        {

        }

        public OccluderVignettesDictionaryProperty(string name, Stream stream)
            : base(name, DataTypes.OccluderVignettesDictionary, stream)
        {

        }

        #endregion Ctor

        #region Methods

        protected override byte[] GetRawValue()
        {
            List<byte> rawValue = new List<byte>();

            rawValue.AddRange(BinaryNumericConverter.GetBytes(Value.Count));

            for (int i = 0; i < Value.Count; i++)
            {
                rawValue.AddRange(Encoding.UTF8.GetBytes(Value.Keys.ElementAt(i) + (char)0x00));
                rawValue.AddRange(BitConverter.GetBytes(Value.Values.ElementAt(i)));
            }

            return rawValue.ToArray();
        }

        protected override Dictionary<string, bool> GetValueFromStream(Stream stream)
        {
            Dictionary<string, bool> occluderVignettesDictionary = new Dictionary<string, bool>();
            int itemsLength;
            long lastPosition;
            byte[] buffer = new byte[sizeof(int)];

            stream.Read(buffer, 0, buffer.Length);
            itemsLength = BinaryNumericConverter.ToInt32(buffer);

            for (int i = 0; i < itemsLength; i++)
            {
                string key;
                lastPosition = stream.Position;
                int keyNullTerminatorIndex;
                buffer = new byte[1024];

                stream.Read(buffer, 0, buffer.Length);

                keyNullTerminatorIndex = Array.IndexOf(buffer, (byte)0x00);
                buffer = new byte[keyNullTerminatorIndex + 1];
                stream.Position = lastPosition;

                stream.Read(buffer, 0, buffer.Length);

                key = Encoding.UTF8.GetString(buffer).Trim((char)0x00);

                buffer = new byte[sizeof(bool)];

                stream.Read(buffer, 0, buffer.Length);

                bool value = BitConverter.ToBoolean(buffer);

                occluderVignettesDictionary.Add(key, value);
            }

            return occluderVignettesDictionary;
        }

        #endregion Methods
    }
}
