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
    public class String256PropertyTest : PropertyTest<String256Property>
    {
        #region Properties

        public override string SampleFileResourceName
        {
            get => "BMSSV.IO.Test.MetroidDread.SampleFiles.Properties.String256Property.bin";
        }

        #endregion Properties

        #region Methods

        public override void ValidateData(String256Property property)
        {
            Assert.IsTrue(!string.IsNullOrEmpty(property.Name));
            Assert.IsNotNull(property.Value);
            Assert.IsTrue(property.Value.Length <= 256);
        }

        #endregion Methods
    }
}
