using BMSSV.IO.MetroidDread.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Reflection;

namespace BMSSV.IO.Test.MetroidDread.PropertyTests
{
    [TestClass]
    public class BooleanPropertyTest : PropertyTest<BooleanProperty>
    {
        #region Properties

        public override string SampleFileResourceName
        {
            get => "BMSSV.IO.Test.MetroidDread.SampleFiles.Properties.BooleanProperty.bin";
        }

        #endregion Properties

        #region Methods

        public override void ValidateData(BooleanProperty property)
        {
            Assert.IsTrue(!string.IsNullOrEmpty(property.Name));
        }

        #endregion Methods
    }
}
