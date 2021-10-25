using BMSSV.IO.MetroidDread;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BMSSV.IO.Test.MetroidDread.FileTests
{
    public abstract class BMSSVFileTest : IDataTest<MetroidDreadBMSSVFile>
    {
        #region Properties

        public Assembly ExecutingAssembly
        {
            get => Assembly.GetExecutingAssembly();
        }

        public abstract string SampleFileResourceName { get; }

        #endregion Properties

        #region Methods

        [TestMethod]
        public void ReadData()
        {
            using (Stream stream = ExecutingAssembly.GetManifestResourceStream(SampleFileResourceName))
            {
                ValidateData(
                    bmssv: ReadDataFromStream<MetroidDreadBMSSVFile>(stream));
            }
        }

        [TestMethod]
        public void WriteData()
        {
            using (Stream readStream = ExecutingAssembly.GetManifestResourceStream(SampleFileResourceName))
            using (Stream writeStream = new MemoryStream())
            {
                var bmssv = ReadDataFromStream<MetroidDreadBMSSVFile>(readStream);

                MetroidDreadBMSSVFile.WriteFile(bmssv, writeStream);

                writeStream.Flush();
                writeStream.Position = 0;

                ValidateData
                    (bmssv: ReadDataFromStream<MetroidDreadBMSSVFile>(writeStream));
            }
        }

        public D ReadDataFromStream<D>(Stream stream) where D : MetroidDreadBMSSVFile
        {
            return (D)MetroidDreadBMSSVFile.ReadFile(@"C:\FakePath\data.bmssv", stream);
        }

        public void ValidateData(MetroidDreadBMSSVFile bmssv)
        {
            Assert.IsNotNull(bmssv);
            Assert.IsNotNull(bmssv.FilePath);
            Assert.IsNotNull(bmssv.Sections);
            Assert.IsTrue(bmssv.Sections.Count > 0);

            for (int s = 0; s < bmssv.Sections.Count; s++)
            {
                Assert.IsNotNull(bmssv.Sections.Values.ElementAt(s).Name);
                Assert.IsNotNull(bmssv.Sections.Values.ElementAt(s).Properties);
                Assert.IsTrue(bmssv.Sections.Values.ElementAt(s).Properties.Count > 0);
            }
        }

        #endregion Methods
    }
}
