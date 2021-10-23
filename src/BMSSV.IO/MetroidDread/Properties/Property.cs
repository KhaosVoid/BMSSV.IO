using BMSSV.IO.MetroidDread.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSSV.IO.MetroidDread.Properties
{
    public abstract class Property<T> : IProperty
    {
        #region Properties

        public string Name { get; }
        public DataTypes DataType { get; }
        public T Value { get; set; }

        #endregion Properties

        #region Ctor

        protected Property(string name, DataTypes dataType, T value)
        {
            Name = name;
            DataType = dataType;
            Value = value;
        }

        internal Property(string name, DataTypes dataType, Stream stream)
        {
            Name = name;
            DataType = dataType;
            Value = GetValueFromStream(stream);
        }

        #endregion Ctor

        #region Methods

        protected abstract byte[] GetRawValue();
        protected abstract T GetValueFromStream(Stream stream);

        byte[] IProperty.GetBytes()
        {
            return GetBytes();
        }

        internal byte[] GetBytes()
        {
            List<byte> entryBytes = new List<byte>();
            byte[] nameBytes = Encoding.UTF8.GetBytes(Name + (char)0x00);
            byte[] dataTypeBytes = BinaryNumericConverter.GetBytes((ulong)DataType, true);
            byte[] rawValue = GetRawValue();

            entryBytes.AddRange(nameBytes);
            entryBytes.AddRange(dataTypeBytes);
            entryBytes.AddRange(rawValue);
            
            return entryBytes.ToArray();
        }

        #endregion Methods
    }
}
