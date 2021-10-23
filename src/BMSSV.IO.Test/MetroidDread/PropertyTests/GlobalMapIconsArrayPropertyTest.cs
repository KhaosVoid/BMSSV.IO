using BMSSV.IO.MetroidDread.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Numerics;
using System.Reflection;

namespace BMSSV.IO.Test.MetroidDread.PropertyTests
{
    [TestClass]
    public class GlobalMapIconsArrayPropertyTest : PropertyTest<GlobalMapIconsArrayProperty>
    {
        #region Properties

        public override string SampleFileResourceName
        {
            get => "BMSSV.IO.Test.MetroidDread.SampleFiles.Properties.GlobalMapIconsArrayProperty.bin";
        }

        #endregion Properties

        #region Methods

        public override void ValidateData(GlobalMapIconsArrayProperty property)
        {
            Assert.IsTrue(!string.IsNullOrEmpty(property.Name));
            Assert.IsNotNull(property.Value);
            Assert.IsTrue(property.Value.Length > 0);

            foreach (var icons in property.Value)
            {
                Assert.IsTrue(!string.IsNullOrEmpty(icons.AreaId));
                Assert.IsNotNull(icons.Items);
                Assert.IsTrue(icons.Items.Length > 0);

                foreach (var item in icons.Items)
                {
                    Assert.IsTrue(!string.IsNullOrEmpty(item.Id));
                    Assert.IsNotNull(item.Position);
                }
            }
        }

        #endregion Methods
    }
}
