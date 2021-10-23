using BMSSV.IO.MetroidDread.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Numerics;
using System.Reflection;

namespace BMSSV.IO.Test.MetroidDread.PropertyTests
{
    [TestClass]
    public class AreaBoxPropertyTest : PropertyTest<AreaBoxProperty>
    {
        #region Properties

        public override string SampleFileResourceName
        {
            get => "BMSSV.IO.Test.MetroidDread.SampleFiles.Properties.AreaBoxProperty.bin";
        }

        #endregion Properties

        #region Methods

        public override void ValidateData(AreaBoxProperty property)
        {
            Assert.IsTrue(!string.IsNullOrEmpty(property.Name));
            Assert.IsNotNull(property.Value);
            Assert.IsNotNull(property.Value.Min);
            Assert.IsNotNull(property.Value.Max);
        }

        #endregion Methods
    }
}
