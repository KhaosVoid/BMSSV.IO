using BMSSV.IO.MetroidDread.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Reflection;

namespace BMSSV.IO.Test.MetroidDread.PropertyTests
{
    [TestClass]
    public class MapTutorialTypesArrayPropertyTest : PropertyTest<MapTutorialTypesArrayProperty>
    {
        #region Properties

        public override string SampleFileResourceName
        {
            get => "BMSSV.IO.Test.MetroidDread.SampleFiles.Properties.MapTutorialTypesArrayProperty.bin";
        }

        #endregion Properties

        #region Methods

        public override void ValidateData(MapTutorialTypesArrayProperty property)
        {
            Assert.IsTrue(!string.IsNullOrEmpty(property.Name));
            Assert.IsNotNull(property.Value);
            Assert.IsTrue(property.Value.Length > 0);
        }

        #endregion Methods
    }
}
