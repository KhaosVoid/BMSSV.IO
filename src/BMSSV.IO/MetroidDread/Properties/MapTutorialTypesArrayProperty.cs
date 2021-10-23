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
    public class MapTutorialTypesArrayProperty : Property<MapTutorialTypes[]>
    {
        #region Ctor

        public MapTutorialTypesArrayProperty(string name, MapTutorialTypes[] value = null)
            : base(name, DataTypes.MapTutorialTypesArray, value)
        {

        }

        internal MapTutorialTypesArrayProperty(string name, Stream stream)
            : base(name, DataTypes.MapTutorialTypesArray, stream)
        {

        }

        #endregion Ctor

        #region Methods

        protected override byte[] GetRawValue()
        {
            List<byte> rawValue = new List<byte>();

            rawValue.AddRange(BinaryNumericConverter.GetBytes(Value.Length));

            for (int i = 0; i < Value.Length; i++)
                rawValue.AddRange(BinaryNumericConverter.GetBytes((int)Value[i]));

            return rawValue.ToArray();
        }

        protected override MapTutorialTypes[] GetValueFromStream(Stream stream)
        {
            List<MapTutorialTypes> values = new List<MapTutorialTypes>();
            int valuesLength;
            byte[] buffer = new byte[sizeof(int)];

            stream.Read(buffer, 0, buffer.Length);
            valuesLength = BinaryNumericConverter.ToInt32(buffer);

            for (int i = 0; i < valuesLength; i++)
            {
                stream.Read(buffer, 0, buffer.Length);

                var mapTutorialType = (MapTutorialTypes)BinaryNumericConverter.ToInt32(buffer);

                if (!Enum.IsDefined(typeof(MapTutorialTypes), mapTutorialType))
                    throw new InvalidOperationException(
                        $"Unrecognized MapTutorialType.");

                values.Add(mapTutorialType);
            }

            return values.ToArray();
        }

        #endregion Methods
    }
}
