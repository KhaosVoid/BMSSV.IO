using BMSSV.IO.Attributes;
using BMSSV.IO.MetroidDread.Enums;
using BMSSV.IO.MetroidDread.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BMSSV.IO.MetroidDread.Properties
{
    public class AreaBoxProperty : Property<AreaBox>
    {
        #region Ctor

        public AreaBoxProperty(string name, AreaBox value = null)
            : base(name, DataTypes.AreaBox, value)
        {

        }

        internal AreaBoxProperty(string name, Stream stream)
            : base(name, DataTypes.AreaBox, stream)
        {

        }

        #endregion Ctor

        #region Methods

        protected override byte[] GetRawValue()
        {
            return Value.GetBytes();
        }

        protected override AreaBox GetValueFromStream(Stream stream)
        {
            return AreaBox.FromStream(stream);
        }

        #endregion Methods
    }
}
