using BMSSV.IO.MetroidDread;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Reflection;

namespace BMSSV.IO.Test.MetroidDread.SectionTests
{
    [TestClass]
    public class SectionTest : IDataTest<Section>
    {
        #region Properties

        public Assembly ExecutingAssembly
        {
            get => Assembly.GetExecutingAssembly();
        }

        public string SampleFileResourceName
        {
            get => "BMSSV.IO.Test.MetroidDread.SampleFiles.Sections.Section.bin";
        }

        #endregion Properties

        #region Methods

        [TestMethod]
        public void ReadData()
        {
            using (Stream stream = ExecutingAssembly.GetManifestResourceStream(SampleFileResourceName))
            {
                ValidateData(
                    section: ReadDataFromStream<Section>(stream));
            }
        }

        [TestMethod]
        public void WriteData()
        {
            using (Stream readStream = ExecutingAssembly.GetManifestResourceStream(SampleFileResourceName))
            using (Stream writeStream = new MemoryStream())
            {
                var section = ReadDataFromStream<Section>(readStream);

                MetroidDreadBMSSVFile.WriteSection(section, writeStream);

                writeStream.Flush();
                writeStream.Position = 0;

                ValidateData
                    (section: ReadDataFromStream<Section>(writeStream));
            }
        }

        public D ReadDataFromStream<D>(Stream stream) where D : Section
        {
            return (D)MetroidDreadBMSSVFile.ReadSection(stream);
        }

        public void ValidateData(Section section)
        {
            Assert.IsNotNull(section);
            Assert.IsTrue(!string.IsNullOrEmpty(section.Name));
            Assert.IsNotNull(section.Properties);
            Assert.IsTrue(section.Properties.Count > 0);
        }

        #endregion Methods
    }
}
