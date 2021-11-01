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
    public class CheckpointOffsetPropertyTest : PropertyTest<CheckpointOffsetProperty>
    {
        #region Properties

        public override string SampleFileResourceName
        {
            get => "BMSSV.IO.Test.MetroidDread.SampleFiles.Properties.CheckpointOffsetProperty.bin";
        }

        #endregion Properties

        #region Methods

        public override void ValidateData(CheckpointOffsetProperty property)
        {
            Assert.IsTrue(!string.IsNullOrEmpty(property.Name));
            Assert.IsNotNull(property.Value);
            Assert.IsNotNull(!string.IsNullOrEmpty(property.Value.Id));
            Assert.IsNotNull(property.Value.Position);
            Assert.IsNotNull(property.Value.Angle);
        }

        #endregion Methods
    }
}
