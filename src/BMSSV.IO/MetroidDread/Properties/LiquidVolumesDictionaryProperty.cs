using BMSSV.IO.MetroidDread.Enums;
using BMSSV.IO.MetroidDread.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSSV.IO.MetroidDread.Properties
{
    public class LiquidVolumesDictionaryProperty : Property<Dictionary<string, AreaBox>>
    {
        #region Ctor

        public LiquidVolumesDictionaryProperty(string name, Dictionary<string, AreaBox> value = null)
            : base(name, DataTypes.LiquidVolumesDictionary, value)
        {

        }

        public LiquidVolumesDictionaryProperty(string name, Stream stream)
            : base(name, DataTypes.LiquidVolumesDictionary, stream)
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
                rawValue.AddRange(Value.Values.ElementAt(i).GetBytes());
            }

            return rawValue.ToArray();
        }

        protected override Dictionary<string, AreaBox> GetValueFromStream(Stream stream)
        {
            Dictionary<string, AreaBox> liquidVolumesDictionary = new Dictionary<string, AreaBox>();
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

                liquidVolumesDictionary.Add(
                    key: key,
                    value: AreaBox.FromStream(stream));
            }

            return liquidVolumesDictionary;
        }

        #endregion Methods
    }
}
