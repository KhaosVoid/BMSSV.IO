using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSSV.IO.Test.MetroidDread.FileTests
{
    [TestClass]
    public class PkprflBMSSVFileTest : BMSSVFileTest
    {
        #region Properties

        public override string SampleFileResourceName
        {
            get => "BMSSV.IO.Test.MetroidDread.SampleFiles.BMSSV.pkprfl.bmssv";
        }

        #endregion Properties
    }
}
