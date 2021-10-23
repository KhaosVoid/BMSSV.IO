﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSSV.IO.MetroidDread.Enums
{
    public enum DataTypes : ulong
    {
        Section                            = 0xBD1406456F93A3F7,
        PropertyDictionary                 = 0xED21C62C3C8D27D7,
        MissionLogEntriesArray             = 0x4DE61CA471BEDCD2,
        GlobalMapIconsArray                = 0xF058F869AB5A36F9,
        AreaBox                            = 0xBDAA54365AE550F4,
        EnabledOccluderCollidersDictionary = 0x0C500CA1F3B54C26,
        LiquidVolumesDictionary            = 0xC897DE38447F5CF2,
        ActorTileStatesDictionary          = 0x1D492D17D698EA76,
        StringArray                        = 0x25E09478B1D26ACF,
        StringId                           = 0xF6EA0DBA9BF734BF,
        String                             = 0xE0D4E713F7819779,
        MapTutorialTypesArray              = 0x7EC5E3B4F43F8724,
        Float                              = 0x518AD65EBA597493,
        UInt32                             = 0xD6AC6CD794D87CB9,
        Int32                              = 0x1D4F060F133F1E29,
        BooleanArray                       = 0x8873943D8EB9C629,
        Boolean                            = 0x2B1A8B33DE7B0C6A
    }

    public enum PropertyIds : ulong
    {
        MissionLogEntryType   = 0x72CFCC424A228498,
        MissionLogLabelText   = 0x31D90A80FF583FC1,
        MissionLogCaptionIds  = 0x8EF51A47A8CCA255,
        GlobalMapIconId       = 0xE926F01F5C4070D0,
        GlobalMapIconPosition = 0x9A714C5BDFE4E50F,
        AreaBoxMin            = 0x1296854B5C530FAF,
        AreaBoxMax            = 0xD4A5EC5A593AE24D,
        ActorTileStateX       = 0xF9304C6C1D1D55FA,
        ActorTileStateY       = 0x966FEB6FA3517B49,
        ActorTileStateType    = 0xA086BDADD2CF1BE8,
        ActorTileStateState   = 0x7A64BDD1A5B7F7BF,
    }

    public enum OccluderColliderTypeIds : ulong
    {
        Collision      = 0x256582A39FB5119F,
        TrapBlockFinal = 0x7BABC0C8085511C2,
        UnknownType1   = 0x1A9241A8743F4CAB
    }
}