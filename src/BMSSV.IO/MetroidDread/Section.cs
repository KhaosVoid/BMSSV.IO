using BMSSV.IO.MetroidDread.Enums;
using BMSSV.IO.MetroidDread.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSSV.IO.MetroidDread
{
    public class Section
    {
        #region Properties

        public string Name { get; }
        public DataTypes DataType { get; } = DataTypes.Section;
        public IReadOnlyDictionary<string, IProperty> Properties { get; set; }

        #endregion Properties

        #region Ctor

        public Section(string name)
        {
            Name = name;
        }

        #endregion Ctor

        #region Methods

        public T TryGetProperty<T>(string name) where T : class, IProperty
        {
            Properties.TryGetValue(name, out IProperty property);

            return property as T;
        }

        #endregion Methods
    }
}
