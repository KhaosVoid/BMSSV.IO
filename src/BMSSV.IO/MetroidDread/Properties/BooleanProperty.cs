using BMSSV.IO.MetroidDread.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSSV.IO.MetroidDread.Properties
{
    public class BooleanProperty : Property<bool>
    {
        #region Ctor

        public BooleanProperty(string name, bool value = default)
            : base(name, DataTypes.Boolean, value)
        {

        }

        internal BooleanProperty(string name, Stream stream)
            : base(name, DataTypes.Boolean, stream)
        {

        }

        #endregion Ctor

        #region Methods

        protected override byte[] GetRawValue()
        {
            return BitConverter.GetBytes(Value);
        }

        protected override bool GetValueFromStream(Stream stream)
        {
            byte[] buffer = new byte[sizeof(bool)];

            stream.Read(buffer, 0, buffer.Length);

            return BitConverter.ToBoolean(buffer);
        }

        #endregion Methods
    }
}
