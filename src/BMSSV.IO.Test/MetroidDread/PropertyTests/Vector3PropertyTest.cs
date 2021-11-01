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
    public class Vector3PropertyTest : PropertyTest<Vector3Property>
    {
        #region Properties

        public override string SampleFileResourceName
        {
            get => "BMSSV.IO.Test.MetroidDread.SampleFiles.Properties.Vector3Property.bin";
        }

        #endregion Properties

        #region Methods

        public override void ValidateData(Vector3Property property)
        {
            Assert.IsTrue(!string.IsNullOrEmpty(property.Name));
        }

        #endregion Methods
    }
}
