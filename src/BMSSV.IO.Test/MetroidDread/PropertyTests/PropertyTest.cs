using BMSSV.IO.MetroidDread;
using BMSSV.IO.MetroidDread.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BMSSV.IO.Test.MetroidDread.PropertyTests
{
    public abstract class PropertyTest<T> : IDataTest<T> where T : IProperty
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
                    property: ReadDataFromStream<T>(stream));
            }
        }

        [TestMethod]
        public void WriteData()
        {
            using (Stream readStream = ExecutingAssembly.GetManifestResourceStream(SampleFileResourceName))
            using (Stream writeStream = new MemoryStream())
            {
                var property = ReadDataFromStream<T>(readStream);

                MetroidDreadBMSSVFile.WriteProperty(property, writeStream);

                writeStream.Flush();
                writeStream.Position = 0;

                ValidateData(
                    property: ReadDataFromStream<T>(writeStream));
            }
        }

        public D ReadDataFromStream<D>(Stream stream) where D : T
        {
            return (D)MetroidDreadBMSSVFile.ReadProperty(stream);
        }

        public abstract void ValidateData(T property);

        #endregion Methods
    }
}
