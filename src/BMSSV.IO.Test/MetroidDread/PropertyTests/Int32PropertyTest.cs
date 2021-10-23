using BMSSV.IO.MetroidDread.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Reflection;

namespace BMSSV.IO.Test.MetroidDread.PropertyTests
{
    [TestClass]
    public class Int32PropertyTest : PropertyTest<Int32Property>
    {
        #region Properties

        public override string SampleFileResourceName
        {
            get => "BMSSV.IO.Test.MetroidDread.SampleFiles.Properties.Int32Property.bin";
        }

        #endregion Properties

        #region Methods

        public override void ValidateData(Int32Property property)
        {
            Assert.IsTrue(!string.IsNullOrEmpty(property.Name));
        }

        #endregion Methods
    }
}
