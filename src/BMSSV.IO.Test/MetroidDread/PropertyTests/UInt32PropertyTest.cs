using BMSSV.IO.MetroidDread.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Reflection;

namespace BMSSV.IO.Test.MetroidDread.PropertyTests
{
    [TestClass]
    public class UInt32PropertyTest : PropertyTest<UInt32Property>
    {
        #region Properties

        public override string SampleFileResourceName
        {
            get => "BMSSV.IO.Test.MetroidDread.SampleFiles.Properties.UInt32Property.bin";
        }

        #endregion Properties

        #region Methods

        public override void ValidateData(UInt32Property property)
        {
            Assert.IsTrue(!string.IsNullOrEmpty(property.Name));
        }

        #endregion Methods
    }
}
