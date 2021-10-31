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
    public class ActorTileStatesDictionaryProperty : Property<Dictionary<string, ActorTileState[]>>
    {
        #region Ctor

        public ActorTileStatesDictionaryProperty(string name, Dictionary<string, ActorTileState[]> value = null)
            : base(name, DataTypes.ActorTileStatesDictionary, value)
        {

        }

        public ActorTileStatesDictionaryProperty(string name, Stream stream)
            : base(name, DataTypes.ActorTileStatesDictionary, stream)
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
                    rawValue.AddRange(Value.Values.ElementAt(i)[v].GetBytes());
            }

            return rawValue.ToArray();
        }

        protected override Dictionary<string, ActorTileState[]> GetValueFromStream(Stream stream)
        {
            Dictionary<string, ActorTileState[]> actorTileStatesDictionary = new Dictionary<string, ActorTileState[]>();
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
                ActorTileState[] actorTileStates = new ActorTileState[valuesLength];

                for (int v = 0; v < valuesLength; v++)
                    actorTileStates[v] = ActorTileState.FromStream(stream);

                actorTileStatesDictionary.Add(
                    key: key,
                    value: actorTileStates);
            }

            return actorTileStatesDictionary;
        }

        #endregion Methods
    }
}
