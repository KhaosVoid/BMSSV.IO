using BMSSV.IO.MetroidDread.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Reflection;

namespace BMSSV.IO.Test.MetroidDread.PropertyTests
{
    [TestClass]
    public class StringIdPropertyTest : PropertyTest<StringIdProperty>
    {
        #region Properties

        public override string SampleFileResourceName
        {
            get => "BMSSV.IO.Test.MetroidDread.SampleFiles.Properties.StringIdProperty.bin";
        }

        #endregion Properties

        #region Methods

        public override void ValidateData(StringIdProperty property)
        {
            Assert.IsTrue(!string.IsNullOrEmpty(property.Name));
            Assert.IsTrue(!string.IsNullOrEmpty(property.Value));
        }

        #endregion Methods
    }
}
