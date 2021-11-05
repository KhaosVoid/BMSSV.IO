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
    public class DoorLifeComponentStatePropertyTest : PropertyTest<DoorLifeComponentStateProperty>
    {
        #region Properties

        public override string SampleFileResourceName
        {
            get => "BMSSV.IO.Test.MetroidDread.SampleFiles.Properties.DoorLifeComponentStateProperty.bin";
        }

        #endregion Properties

        #region Methods

        public override void ValidateData(DoorLifeComponentStateProperty property)
        {
            Assert.IsTrue(!string.IsNullOrEmpty(property.Name));
        }

        #endregion Methods
    }
}
