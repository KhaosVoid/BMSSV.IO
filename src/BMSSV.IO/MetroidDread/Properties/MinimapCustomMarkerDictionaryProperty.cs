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
    public class MinimapCustomMarkerDictionaryProperty : Property<Dictionary<int, MinimapCustomMarker>>
    {
        #region Ctor

        public MinimapCustomMarkerDictionaryProperty(string name, Dictionary<int, MinimapCustomMarker> value = null)
            : base(name, DataTypes.MinimapCustomMarkerDictionary, value)
        {

        }

        internal MinimapCustomMarkerDictionaryProperty(string name, Stream stream)
            : base(name, DataTypes.MinimapCustomMarkerDictionary, stream)
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
                rawValue.AddRange(BinaryNumericConverter.GetBytes(Value.Keys.ElementAt(i)));
                rawValue.AddRange(Value.Values.ElementAt(i).GetBytes());
            }

            return rawValue.ToArray();
        }

        protected override Dictionary<int, MinimapCustomMarker> GetValueFromStream(Stream stream)
        {
            Dictionary<int, MinimapCustomMarker> minimapCustomMarkerDictionary = new Dictionary<int, MinimapCustomMarker>();
            int itemsLength;
            byte[] buffer = new byte[sizeof(int)];

            stream.Read(buffer, 0, buffer.Length);
            itemsLength = BinaryNumericConverter.ToInt32(buffer);

            for (int i = 0; i < itemsLength; i++)
            {
                buffer = new byte[sizeof(int)];

                stream.Read(buffer, 0, buffer.Length);

                int key = BinaryNumericConverter.ToInt32(buffer);
                MinimapCustomMarker minimapCustomMarker = MinimapCustomMarker.FromStream(stream);

                minimapCustomMarkerDictionary.Add(key, minimapCustomMarker);
            }

            return minimapCustomMarkerDictionary;
        }

        #endregion Methods
    }
}
