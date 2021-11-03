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
    public class DoorLifeComponentStateProperty : Property<DoorLifeComponentStates>
    {
        #region Ctor

        public DoorLifeComponentStateProperty(string name, DoorLifeComponentStates value = default)
            : base(name, DataTypes.DoorLifeComponentState, value)
        {

        }

        internal DoorLifeComponentStateProperty(string name, Stream stream)
            : base(name, DataTypes.DoorLifeComponentState, stream)
        {

        }

        #endregion Ctor

        #region Methods

        protected override byte[] GetRawValue()
        {
            return BinaryNumericConverter.GetBytes((int)Value);
        }

        protected override DoorLifeComponentStates GetValueFromStream(Stream stream)
        {
            byte[] buffer = new byte[sizeof(DoorLifeComponentStates)];

            stream.Read(buffer, 0, buffer.Length);

            return (DoorLifeComponentStates)BinaryNumericConverter.ToInt32(buffer);
        }

        #endregion Methods
    }
}
