using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;
using System.Reflection;

namespace BMSSV.IO.Test.MetroidDread.FileTests
{
    [TestClass]
    public class CommonBMSSVFileTest : BMSSVFileTest
    {
        #region Properties

        public override string SampleFileResourceName
        {
            get => "BMSSV.IO.Test.MetroidDread.SampleFiles.BMSSV.common.bmssv";
        }

        #endregion Properties
    }
}
