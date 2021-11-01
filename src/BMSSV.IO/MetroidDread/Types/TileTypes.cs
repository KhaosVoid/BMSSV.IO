using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSSV.IO.MetroidDread.Types
{
    public enum TileTypes
    {
        Undefined = 0,
        Beam = 1,
        Bomb = 2,
        Missle = 3,
        SuperMissile = 4,
        PowerBomb = 5,
        ScrewAttack = 6,
        Crumble = 7,
        BabyHatchling = 8,
        SpeedBoost = 9,
        Invalid = int.MaxValue
    }
}
