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
    public class EnabledOccluderCollidersDictionaryProperty : Property<Dictionary<string, OccluderColliderTypeIds[]>>
    {
        #region Ctor

        public EnabledOccluderCollidersDictionaryProperty(string name, Dictionary<string, OccluderColliderTypeIds[]> value = null)
            : base(name, DataTypes.EnabledOccluderCollidersDictionary, value)
        {

        }

        internal EnabledOccluderCollidersDictionaryProperty(string name, Stream stream)
            : base(name, DataTypes.EnabledOccluderCollidersDictionary, stream)
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
                rawValue.AddRange(BinaryNumericConverter.GetBytes(Value.Values.ElementAt(i).Length));

                for (int v = 0; v < Value.Values.ElementAt(i).Length; v++)
                {
                    rawValue.AddRange(
                        BinaryNumericConverter.GetBytes((ulong)Value.Values.ElementAt(i)[v], true));
                }
            }

            return rawValue.ToArray();
        }

        protected override Dictionary<string, OccluderColliderTypeIds[]> GetValueFromStream(Stream stream)
        {
            Dictionary<string, OccluderColliderTypeIds[]> enabledOccluderCollidersDictionary = new Dictionary<string, OccluderColliderTypeIds[]>();
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

                int valuesLength;
                buffer = new byte[sizeof(int)];

                stream.Read(buffer, 0, buffer.Length);

                valuesLength = BinaryNumericConverter.ToInt32(buffer);
                OccluderColliderTypeIds[] occluderColliderTypeIds = new OccluderColliderTypeIds[valuesLength];

                for (int v = 0; v < valuesLength; v++)
                {
                    buffer = new byte[sizeof(OccluderColliderTypeIds)];

                    stream.Read(buffer, 0, buffer.Length);

                    occluderColliderTypeIds[v] = (OccluderColliderTypeIds)BinaryNumericConverter.ToUInt64(buffer, true);

                    if (!Enum.IsDefined(typeof(OccluderColliderTypeIds), occluderColliderTypeIds[v]))
                        throw new InvalidOperationException(
                            $"Unrecognized OccluderColliderTypeId.");
                }

                enabledOccluderCollidersDictionary.Add(
                    key: key,
                    value: occluderColliderTypeIds);
            }

            return enabledOccluderCollidersDictionary;
        }

        #endregion Methods
    }
}
