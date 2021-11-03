using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSSV.IO.MetroidDread.Types
{
    public enum DoorLifeComponentStates
    {
        None = 0,
        Opened = 1,
        Closed = 2,
        Locked = 3,
        Invalid = int.MaxValue
    }
}
