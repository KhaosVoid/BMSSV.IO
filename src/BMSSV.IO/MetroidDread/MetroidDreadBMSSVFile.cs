using BMSSV.IO.MetroidDread.Enums;
using BMSSV.IO.MetroidDread.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSSV.IO.MetroidDread
{
    public class MetroidDreadBMSSVFile
    {
        #region Properties

        public string FilePath { get; }
        public Dictionary<string, Section> Sections { get; set; }

        #endregion Properties

        #region Members

        private byte[] _header = null;
        private byte[] _footer = null;

        #endregion Members

        #region Ctor

        internal MetroidDreadBMSSVFile()
        {

        }

        public MetroidDreadBMSSVFile(string filePath)
        {
            FilePath = filePath;
        }

        #endregion Ctor

        #region File Methods

        public static MetroidDreadBMSSVFile OpenFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Could not find BMSSV.");

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                return ReadFile(path, fs);
        }

        public static void SaveFile(MetroidDreadBMSSVFile bmssvFile)
        {
            using (FileStream fs = new FileStream(bmssvFile.FilePath, FileMode.Create, FileAccess.Write))
                WriteFile(bmssvFile, fs);
        }

        #endregion Methods

        #region Read Methods

        internal static MetroidDreadBMSSVFile ReadFile(string path, Stream stream)
        {
            MetroidDreadBMSSVFile bmssvFile = new MetroidDreadBMSSVFile(path);
            Dictionary<string, Section> sections = new Dictionary<string, Section>();

            byte[] buffer = new byte[32];

            stream.Read(buffer, 0, buffer.Length);
            bmssvFile._header = buffer;

            buffer = new byte[sizeof(uint)];
            int sectionsLength;

            stream.Read(buffer, 0, buffer.Length);
            sectionsLength = BinaryNumericConverter.ToInt32(buffer);

            for (int s = 0; s < sectionsLength; s++)
            {
                var section = ReadSection(stream);
                sections.Add(section.Name, section);
            }

            bmssvFile.Sections = sections;

            buffer = new byte[12];

            stream.Read(buffer, 0, buffer.Length);
            bmssvFile._footer = buffer;

            return bmssvFile;
        }

        internal static Section ReadSection(Stream stream)
        {
            Section section;
            string name;
            DataTypes dataType;
            long lastPosition = stream.Position;
            int nameNullTerminatorIndex;
            byte[] buffer = new byte[1024];

            stream.Read(buffer, 0, buffer.Length);
            nameNullTerminatorIndex = Array.IndexOf(buffer, (byte)0x00);

            if (nameNullTerminatorIndex < 0)
                throw new InvalidOperationException(
                    $"Unable to parse name for {nameof(Section)}.");

            buffer = new byte[nameNullTerminatorIndex + 1];
            stream.Position = lastPosition;
            stream.Read(buffer, 0, buffer.Length);

            name = Encoding.UTF8.GetString(buffer).Trim((char)0x00);

            buffer = new byte[sizeof(DataTypes)];
            stream.Read(buffer, 0, buffer.Length);

            dataType = (DataTypes)BinaryNumericConverter.ToUInt64(buffer, true);

            if (dataType != DataTypes.Section)
                throw new InvalidOperationException(
                    $"DataType mismatch while parsing {nameof(Section)}.");

            section = new Section(name);

            buffer = new byte[sizeof(uint)];
            stream.Read(buffer, 0, buffer.Length);

            int propertyDictionariesLength = BinaryNumericConverter.ToInt32(buffer);

            if (propertyDictionariesLength != 1)
                throw new InvalidOperationException(
                    $"Expected 1 Property Dictionary. Encountered {propertyDictionariesLength}.");

            section.Properties = ReadPropertyDictionary(stream);

            return section;
        }

        internal static Dictionary<string, IProperty> ReadPropertyDictionary(Stream stream)
        {
            Dictionary<string, IProperty> properties;
            DataTypes dataType;
            byte[] buffer = new byte[sizeof(DataTypes)];

            stream.Read(buffer, 0, buffer.Length);

            dataType = (DataTypes)BinaryNumericConverter.ToUInt64(buffer, true);

            if (dataType != DataTypes.PropertyDictionary)
                throw new InvalidOperationException(
                    $"DataType mismatch while parsing {nameof(DataTypes.PropertyDictionary)}.");

            properties = new Dictionary<string, IProperty>();

            buffer = new byte[sizeof(uint)];
            stream.Read(buffer, 0, buffer.Length);

            int propertiesLength = BinaryNumericConverter.ToInt32(buffer);

            for (int d = 0; d < propertiesLength; d++)
            {
                IProperty property = ReadProperty(stream);
                properties.Add(property.Name, property); ;
            }

            return properties;
        }

        internal static IProperty ReadProperty(Stream stream)
        {
            string name;
            DataTypes dataType;
            long lastPosition = stream.Position;
            int nameNullTerminatorIndex;
            byte[] buffer = new byte[1024];

            stream.Read(buffer, 0, buffer.Length);
            nameNullTerminatorIndex = Array.IndexOf(buffer, (byte)0x00);

            if (nameNullTerminatorIndex < 0)
                throw new InvalidOperationException(
                    $"Unable to parse name for {nameof(IProperty)}.");

            buffer = new byte[nameNullTerminatorIndex + 1];
            stream.Position = lastPosition;
            stream.Read(buffer, 0, buffer.Length);

            name = Encoding.UTF8.GetString(buffer).Trim((char)0x00);

            buffer = new byte[sizeof(DataTypes)];
            stream.Read(buffer, 0, buffer.Length);

            dataType = (DataTypes)BinaryNumericConverter.ToUInt64(buffer, true);

            switch (dataType)
            {
                case DataTypes.MissionLogEntriesArray:
                    return new MissionLogEntriesArrayProperty(name, stream);

                case DataTypes.GlobalMapIconsArray:
                    return new GlobalMapIconsArrayProperty(name, stream);

                case DataTypes.AreaBox:
                    return new AreaBoxProperty(name, stream);

                case DataTypes.EnabledOccluderCollidersDictionary:
                    return new EnabledOccluderCollidersDictionaryProperty(name, stream);

                case DataTypes.LiquidVolumesDictionary:
                    return new LiquidVolumesDictionaryProperty(name, stream);

                case DataTypes.ActorTileStatesDictionary:
                    return new ActorTileStatesDictionaryProperty(name, stream);

                case DataTypes.OccluderVignettesDictionary:
                    return new OccluderVignettesDictionaryProperty(name, stream);

                case DataTypes.MinimapVisibilityArray:
                    return new MinimapVisibilityArrayProperty(name, stream);

                case DataTypes.CheckpointOffset:
                    return new CheckpointOffsetProperty(name, stream);

                case DataTypes.Vector2:
                    return new Vector2Property(name, stream);

                case DataTypes.StringArray:
                    return new StringArrayProperty(name, stream);

                case DataTypes.String256:
                    return new String256Property(name, stream);

                case DataTypes.StringId:
                    return new StringIdProperty(name, stream);

                case DataTypes.String:
                    return new StringProperty(name, stream);

                case DataTypes.MapTutorialTypesArray:
                    return new MapTutorialTypesArrayProperty(name, stream);

                case DataTypes.Float:
                    return new FloatProperty(name, stream);

                case DataTypes.UInt32:
                    return new UInt32Property(name, stream);

                case DataTypes.Int32:
                    return new Int32Property(name, stream);

                case DataTypes.Boolean:
                    return new BooleanProperty(name, stream);

                case DataTypes.BooleanArray:
                    return new BooleanArrayProperty(name, stream);

                default:
                    throw new InvalidOperationException(
                        $"Unrecognized DataType.");
            }
        }

        #endregion Read Methods

        #region Write Methods

        internal static void WriteFile(MetroidDreadBMSSVFile bmssvFile, Stream stream)
        {
            byte[] buffer;

            stream.Write(bmssvFile._header, 0, bmssvFile._header.Length);

            buffer = BinaryNumericConverter.GetBytes(bmssvFile.Sections.Count);

            stream.Write(buffer, 0, buffer.Length);

            for (int s = 0; s < bmssvFile.Sections.Count; s++)
                WriteSection(bmssvFile.Sections.Values.ElementAt(s), stream);

            stream.Write(bmssvFile._footer, 0, bmssvFile._footer.Length);

            stream.Flush();
        }

        internal static void WriteSection(Section section, Stream stream)
        {
            byte[] buffer;

            buffer = Encoding.UTF8.GetBytes(section.Name + (char)0x00);
            stream.Write(buffer, 0, buffer.Length);

            buffer = BinaryNumericConverter.GetBytes((ulong)section.DataType, true);
            stream.Write(buffer, 0, buffer.Length);

            buffer = BinaryNumericConverter.GetBytes(1);
            stream.Write(buffer, 0, buffer.Length);

            WritePropertyDictionary(section.Properties, stream);
        }

        internal static void WritePropertyDictionary(Dictionary<string, IProperty> propertyDictionary, Stream stream)
        {
            byte[] buffer;

            buffer = BinaryNumericConverter.GetBytes((ulong)DataTypes.PropertyDictionary, true);
            stream.Write(buffer, 0, buffer.Length);

            buffer = BinaryNumericConverter.GetBytes(propertyDictionary.Count);
            stream.Write(buffer, 0, buffer.Length);

            for (int d = 0; d < propertyDictionary.Count; d++)
                WriteProperty(propertyDictionary.Values.ElementAt(d), stream);
        }

        internal static void WriteProperty(IProperty property, Stream stream)
        {
            byte[] buffer;

            buffer = property.GetBytes();
            stream.Write(buffer, 0, buffer.Length);
        }

        #endregion Write Methods
    }
}
