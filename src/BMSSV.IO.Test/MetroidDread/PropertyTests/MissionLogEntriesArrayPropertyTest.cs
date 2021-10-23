using BMSSV.IO.MetroidDread.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Reflection;

namespace BMSSV.IO.Test.MetroidDread.PropertyTests
{
    [TestClass]
    public class MissionLogEntriesArrayPropertyTest : PropertyTest<MissionLogEntriesArrayProperty>
    {
        #region Properties

        public override string SampleFileResourceName
        {
            get => "BMSSV.IO.Test.MetroidDread.SampleFiles.Properties.MissionLogEntriesArrayProperty.bin";
        }

        #endregion Properties

        #region Methods

        public override void ValidateData(MissionLogEntriesArrayProperty property)
        {
            Assert.IsTrue(!string.IsNullOrEmpty(property.Name));
            Assert.IsNotNull(property.Value);
            Assert.IsTrue(property.Value.Length > 0);

            foreach (var entry in property.Value)
            {
                Assert.IsTrue(!string.IsNullOrEmpty(entry.LabelText));
                Assert.IsNotNull(entry.CaptionIds);
                Assert.IsTrue(entry.CaptionIds.Length > 0);
            }
        }

        #endregion Methods
    }
}
