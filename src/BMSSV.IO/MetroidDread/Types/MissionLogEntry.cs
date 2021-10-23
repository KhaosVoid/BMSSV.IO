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
    public class MissionLogEntry : IType<MissionLogEntry>
    {
        #region Properties

        [PropertyId(PropertyIds.MissionLogEntryType)]
        public uint EntryType { get; set; }

        [PropertyId(PropertyIds.MissionLogLabelText)]
        public string LabelText { get; set; }

        [PropertyId(PropertyIds.MissionLogCaptionIds)]
        public string[] CaptionIds { get; set; }

        #endregion Properties

        #region Methods

        byte[] IType<MissionLogEntry>.GetBytes()
        {
            return GetBytes();
        }

        internal byte[] GetBytes()
        {
            List<byte> bytes = new List<byte>();
            byte[] propertyIdsLength = BinaryNumericConverter.GetBytes(3);
            var entryTypePropertyId = typeof(MissionLogEntry)
                .GetProperty(nameof(EntryType))
                .GetCustomAttribute<PropertyIdAttribute>()
                .Id;
            var labelTextPropertyId = typeof(MissionLogEntry)
                .GetProperty(nameof(LabelText))
                .GetCustomAttribute<PropertyIdAttribute>()
                .Id;
            var captionIdsPropertyId = typeof(MissionLogEntry)
                .GetProperty(nameof(CaptionIds))
                .GetCustomAttribute<PropertyIdAttribute>()
                .Id;

            bytes.AddRange(propertyIdsLength);
            bytes.AddRange(BinaryNumericConverter.GetBytes((ulong)entryTypePropertyId, true));
            bytes.AddRange(BinaryNumericConverter.GetBytes(EntryType));
            bytes.AddRange(BinaryNumericConverter.GetBytes((ulong)labelTextPropertyId, true));
            bytes.AddRange(Encoding.UTF8.GetBytes(LabelText + (char)0x00));
            bytes.AddRange(BinaryNumericConverter.GetBytes((ulong)captionIdsPropertyId, true));
            bytes.AddRange(BinaryNumericConverter.GetBytes(CaptionIds.Length));

            for (int c = 0; c < CaptionIds.Length; c++)
                bytes.AddRange(Encoding.UTF8.GetBytes(CaptionIds[c] + (char)0x00));

            return bytes.ToArray();
        }

        MissionLogEntry IType<MissionLogEntry>.FromStream(Stream stream)
        {
            return FromStream(stream);
        }

        internal static MissionLogEntry FromStream(Stream stream)
        {
            MissionLogEntry missionLogEntry = new MissionLogEntry();
            long lastPosition;
            byte[] buffer = new byte[sizeof(int)];

            stream.Read(buffer, 0, buffer.Length);

            int propertyIdsLength = BinaryNumericConverter.ToInt32(buffer);

            for (int v = 0; v < propertyIdsLength; v++)
            {
                buffer = new byte[sizeof(PropertyIds)];

                stream.Read(buffer, 0, buffer.Length);

                PropertyIds propertyId = (PropertyIds)BinaryNumericConverter.ToUInt64(buffer, true);

                switch (propertyId)
                {
                    case PropertyIds.MissionLogEntryType:
                        buffer = new byte[sizeof(uint)];
                        stream.Read(buffer, 0, buffer.Length);
                        missionLogEntry.EntryType = BinaryNumericConverter.ToUInt32(buffer);
                        break;

                    case PropertyIds.MissionLogLabelText:
                        lastPosition = stream.Position;
                        int nameNullTerminatorIndex;
                        buffer = new byte[1024];

                        stream.Read(buffer, 0, buffer.Length);

                        nameNullTerminatorIndex = Array.IndexOf(buffer, (byte)0x00);
                        buffer = new byte[nameNullTerminatorIndex + 1];
                        stream.Position = lastPosition;

                        stream.Read(buffer, 0, buffer.Length);
                        missionLogEntry.LabelText = Encoding.UTF8.GetString(buffer).Trim((char)0x00);
                        break;

                    case PropertyIds.MissionLogCaptionIds:
                        int dialogPagesLength;
                        buffer = new byte[sizeof(uint)];

                        stream.Read(buffer, 0, buffer.Length);

                        dialogPagesLength = BinaryNumericConverter.ToInt32(buffer);
                        missionLogEntry.CaptionIds = new string[dialogPagesLength];

                        for (int p = 0; p < dialogPagesLength; p++)
                        {
                            lastPosition = stream.Position;
                            int pageNullTerminatorIndex;
                            buffer = new byte[1024];

                            stream.Read(buffer, 0, buffer.Length);

                            pageNullTerminatorIndex = Array.IndexOf(buffer, (byte)0x00);

                            buffer = new byte[pageNullTerminatorIndex + 1];
                            stream.Position = lastPosition;

                            stream.Read(buffer, 0, buffer.Length);
                            missionLogEntry.CaptionIds[p] = Encoding.UTF8.GetString(buffer).Trim((char)0x00);
                        }
                        break;

                    default:
                        throw new InvalidOperationException(
                            $"Unrecognized PropertyId.");
                }
            }

            return missionLogEntry;
        }

        #endregion Methods
    }
}
