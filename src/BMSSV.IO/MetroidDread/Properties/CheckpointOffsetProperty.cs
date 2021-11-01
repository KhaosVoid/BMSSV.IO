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
    public class CheckpointOffsetProperty : Property<CheckpointOffset>
    {
        #region Ctor

        public CheckpointOffsetProperty(string name, CheckpointOffset value = null)
            : base(name, DataTypes.CheckpointOffset, value)
        {

        }

        internal CheckpointOffsetProperty(string name, Stream stream)
            : base(name, DataTypes.CheckpointOffset, stream)
        {

        }

        #endregion Ctor

        #region Methods

        protected override byte[] GetRawValue()
        {
            return Value.GetBytes();
        }

        protected override CheckpointOffset GetValueFromStream(Stream stream)
        {
            return CheckpointOffset.FromStream(stream);
        }

        #endregion Methods
    }
}
