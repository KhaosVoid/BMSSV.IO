using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSSV.IO.Test.MetroidDread.FileTests
{
    //NOTE: This test is disabled as samus.bmssv has not been fully implemented.
    //[TestClass]
    public class SamusBMSSVFileTest : BMSSVFileTest
    {
        #region Properties

        public override string SampleFileResourceName
        {
            get => "BMSSV.IO.Test.MetroidDread.SampleFiles.BMSSV.samus.bmssv";
        }

        #endregion Properties
    }
}
