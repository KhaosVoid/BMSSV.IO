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
    public class OccluderVignettesDictionaryPropertyTest : PropertyTest<OccluderVignettesDictionaryProperty>
    {
        #region Properties

        public override string SampleFileResourceName
        {
            get => "BMSSV.IO.Test.MetroidDread.SampleFiles.Properties.OccluderVignettesDictionaryProperty.bin";
        }

        #endregion Properties

        #region Methods

        public override void ValidateData(OccluderVignettesDictionaryProperty property)
        {
            Assert.IsTrue(!string.IsNullOrEmpty(property.Name));
            Assert.IsNotNull(property.Value);
            Assert.IsTrue(property.Value.Count > 0);
        }

        #endregion Methods
    }
}
