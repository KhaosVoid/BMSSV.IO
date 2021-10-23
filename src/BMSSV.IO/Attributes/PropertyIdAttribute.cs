using BMSSV.IO.MetroidDread.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSSV.IO.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class PropertyIdAttribute : Attribute
    {
        #region Properties

        public PropertyIds Id { get; }

        #endregion Properties

        #region Ctor

        public PropertyIdAttribute(PropertyIds id)
        {
            Id = id;
        }

        #endregion Ctor
    }
}
