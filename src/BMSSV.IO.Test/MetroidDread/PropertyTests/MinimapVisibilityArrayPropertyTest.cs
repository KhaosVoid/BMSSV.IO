using BMSSV.IO.MetroidDread.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSSV.IO.Test.MetroidDread.PropertyTests
{
    [TestClass]
    public class MinimapVisibilityArrayPropertyTest : PropertyTest<MinimapVisibilityArrayProperty>
    {
        #region Properties

        public override string SampleFileResourceName
        {
            get => "BMSSV.IO.Test.MetroidDread.SampleFiles.Properties.MinimapVisibilityArrayProperty.bin";
        }

        #endregion Properties

        #region Methods

        public override void ValidateData(MinimapVisibilityArrayProperty property)
        {
            Assert.IsTrue(!string.IsNullOrEmpty(property.Name));
            Assert.IsNotNull(property.Value);
            Assert.IsTrue(property.Value.Length > 0);

            foreach (var minimapVisibility in property.Value)
                Assert.IsTrue(!string.IsNullOrEmpty(minimapVisibility.Value));
        }

        #endregion Methods
    }
}
