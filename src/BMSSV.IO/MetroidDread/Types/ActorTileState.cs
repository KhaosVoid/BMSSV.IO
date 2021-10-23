using BMSSV.IO.Attributes;
using BMSSV.IO.MetroidDread.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BMSSV.IO.MetroidDread.Types
{
    public class ActorTileState : IType<ActorTileState>
    {
        #region Properties

        [PropertyId(PropertyIds.ActorTileStateX)]
        public float X { get; set; }

        [PropertyId(PropertyIds.ActorTileStateY)]
        public float Y { get; set; }

        [PropertyId(PropertyIds.ActorTileStateType)]
        public TileTypes TileType { get; set; }

        [PropertyId(PropertyIds.ActorTileStateState)]
        public uint State { get; set; }

        #endregion Properties

        #region Methods

        byte[] IType<ActorTileState>.GetBytes()
        {
            return GetBytes();
        }

        internal byte[] GetBytes()
        {
            List<byte> bytes = new List<byte>();
            byte[] propertyIdsLength = BinaryNumericConverter.GetBytes(4);
            var xPropertyId = typeof(ActorTileState)
                .GetProperty(nameof(X))
                .GetCustomAttribute<PropertyIdAttribute>()
                .Id;
            var yPropertyId = typeof(ActorTileState)
                .GetProperty(nameof(Y))
                .GetCustomAttribute<PropertyIdAttribute>()
                .Id;
            var tileTypePropertyId = typeof(ActorTileState)
                .GetProperty(nameof(TileType))
                .GetCustomAttribute<PropertyIdAttribute>()
                .Id;
            var statePropertyId = typeof(ActorTileState)
                .GetProperty(nameof(State))
                .GetCustomAttribute<PropertyIdAttribute>()
                .Id;

            bytes.AddRange(propertyIdsLength);
            bytes.AddRange(BinaryNumericConverter.GetBytes((ulong)xPropertyId, true));
            bytes.AddRange(BinaryNumericConverter.GetBytes(X));
            bytes.AddRange(BinaryNumericConverter.GetBytes((ulong)yPropertyId, true));
            bytes.AddRange(BinaryNumericConverter.GetBytes(Y));
            bytes.AddRange(BinaryNumericConverter.GetBytes((ulong)tileTypePropertyId, true));
            bytes.AddRange(BinaryNumericConverter.GetBytes((int)TileType));
            bytes.AddRange(BinaryNumericConverter.GetBytes((ulong)statePropertyId, true));
            bytes.AddRange(BinaryNumericConverter.GetBytes(State));

            return bytes.ToArray();
        }

        ActorTileState IType<ActorTileState>.FromStream(Stream stream)
        {
            return FromStream(stream);
        }

        internal static ActorTileState FromStream(Stream stream)
        {
            ActorTileState breakableTile = new ActorTileState();
            byte[] buffer = new byte[sizeof(int)];

            stream.Read(buffer, 0, buffer.Length);

            int valuesLength = BinaryNumericConverter.ToInt32(buffer);

            for (int i = 0; i < valuesLength; i++)
            {
                buffer = new byte[sizeof(PropertyIds)];

                stream.Read(buffer, 0, buffer.Length);

                PropertyIds propertyId = (PropertyIds)BinaryNumericConverter.ToUInt64(buffer, true);
                
                switch (propertyId)
                {
                    case PropertyIds.ActorTileStateX:
                        buffer = new byte[sizeof(float)];
                        stream.Read(buffer, 0, buffer.Length);
                        breakableTile.X = BinaryNumericConverter.ToSingle(buffer);
                        break;

                    case PropertyIds.ActorTileStateY:
                        buffer = new byte[sizeof(float)];
                        stream.Read(buffer, 0, buffer.Length);
                        breakableTile.Y = BinaryNumericConverter.ToSingle(buffer);
                        break;

                    case PropertyIds.ActorTileStateType:
                        buffer = new byte[sizeof(TileTypes)];
                        stream.Read(buffer, 0, buffer.Length);
                        breakableTile.TileType = (TileTypes)BinaryNumericConverter.ToInt32(buffer);

                        if (!Enum.IsDefined(typeof(TileTypes), breakableTile.TileType))
                            throw new InvalidOperationException(
                                $"Unrecognized TileType");
                        break;

                    case PropertyIds.ActorTileStateState:
                        buffer = new byte[sizeof(uint)];
                        stream.Read(buffer, 0, buffer.Length);
                        breakableTile.State = BinaryNumericConverter.ToUInt32(buffer);
                        break;

                    default:
                        throw new InvalidOperationException(
                            $"Unrecognized PropertyId.");
                }
            }

            return breakableTile;
        }

        #endregion Methods
    }
}
