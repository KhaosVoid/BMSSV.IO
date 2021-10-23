using BMSSV.IO.MetroidDread;
using BMSSV.IO.MetroidDread.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace BMSSV.IO.Test.MetroidDread.PropertyDictionaryTests
{
    [TestClass]
    public class PropertyDictionaryTest : IDataTest<Dictionary<string, IProperty>>
    {
        #region Properties

        public Assembly ExecutingAssembly
        {
            get => Assembly.GetExecutingAssembly();
        }

        public string SampleFileResourceName
        {
            get => "BMSSV.IO.Test.MetroidDread.SampleFiles.PropertyDictionaries.PropertyDictionary.bin";
        }

        #endregion Properties

        #region Methods

        [TestMethod]
        public void ReadData()
        {
            using (Stream stream = ExecutingAssembly.GetManifestResourceStream(SampleFileResourceName))
            {
                ValidateData(
                    propertyDictionary: ReadDataFromStream<Dictionary<string, IProperty>>(stream));
            }
        }

        [TestMethod]
        public void WriteData()
        {
            using (Stream readStream = ExecutingAssembly.GetManifestResourceStream(SampleFileResourceName))
            using (Stream writeStream = new MemoryStream())
            {
                var propertyDictionary = ReadDataFromStream<Dictionary<string, IProperty>>(readStream);

                MetroidDreadBMSSVFile.WritePropertyDictionary(propertyDictionary, writeStream);

                writeStream.Flush();
                writeStream.Position = 0;

                ValidateData
                    (propertyDictionary: ReadDataFromStream<Dictionary<string, IProperty>>(writeStream));
            }
        }

        public D ReadDataFromStream<D>(Stream stream) where D : Dictionary<string, IProperty>
        {
            return (D)MetroidDreadBMSSVFile.ReadPropertyDictionary(stream);
        }

        public void ValidateData(Dictionary<string, IProperty> propertyDictionary)
        {
            Assert.IsNotNull(propertyDictionary);
            Assert.IsTrue(propertyDictionary.Count > 0);
        }

        #endregion Methods
    }
}
