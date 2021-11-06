using System;
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
        OccluderVignettesDictionary        = 0xCADF3A163B607F5B,
        MinimapVisibilityArray             = 0x1792BC17AD716D8D,
        CheckpointOffset                   = 0xBF8FE251F17EAD25,
        MinimapCustomMarkerDictionary      = 0xBF450D514E81EB1B,
        Vector2                            = 0xF46AD97DC54A9259,
        Vector3                            = 0xF99B092157337B0D,
        StringArray                        = 0x25E09478B1D26ACF,
        String256                          = 0x31B88BF33548DE26,
        StringId                           = 0xF6EA0DBA9BF734BF,
        String                             = 0xE0D4E713F7819779,
        MapTutorialTypesArray              = 0x7EC5E3B4F43F8724,
        Float                              = 0x518AD65EBA597493,
        UInt32                             = 0xD6AC6CD794D87CB9,
        Int32                              = 0x1D4F060F133F1E29,
        DoorLifeComponentState             = 0x2567850CE806D4F8,
        BooleanArray                       = 0x8873943D8EB9C629,
        Boolean                            = 0x2B1A8B33DE7B0C6A
    }

    public enum PropertyIds : ulong
    {
        MissionLogEntryType           = 0x72CFCC424A228498,
        MissionLogLabelText           = 0x31D90A80FF583FC1,
        MissionLogCaptionIds          = 0x8EF51A47A8CCA255,
        GlobalMapIconId               = 0xE926F01F5C4070D0,
        GlobalMapIconPosition         = 0x9A714C5BDFE4E50F,
        AreaBoxMin                    = 0x1296854B5C530FAF,
        AreaBoxMax                    = 0xD4A5EC5A593AE24D,
        ActorTileStateX               = 0xF9304C6C1D1D55FA,
        ActorTileStateY               = 0x966FEB6FA3517B49,
        ActorTileStateType            = 0xA086BDADD2CF1BE8,
        ActorTileStateState           = 0x7A64BDD1A5B7F7BF,
        CheckpointOffsetId            = 0xB7C1F0A2F08B8870,
        CheckpointOffsetPosition      = 0xAA8881F44964F0C2,
        CheckpointOffsetAngle         = 0xACCD3DDFD3D4567A,
        MinimapCustomMarkerId         = 0xF3A3EBFFF0077303,
        MinimapCustomMarkerType       = 0x79F31B83386F08A1,
        MinimapCustomMarkerPosition   = 0xD1A8336890B4BBDD,
        MinimapCustomMarkerTargetId   = 0xBFE26B06920280B2,
        MinimapCustomMarkerTargetSlot = 0x79C2F775BD2B3138
    }

    public enum OccluderColliderTypeIds : ulong
    {
        //collision
        Collision          = 0x256582A39FB5119F,

        //trapblockfinal
        TrapBlockFinal     = 0x7BABC0C8085511C2,

        //collision_opened
        CollisionOpened    = 0x2C15B41771891777,

        //collision_close
        CollisionClose     = 0xC1A3AFE60BD47C80,

        //collision_closed
        CollisionClosed    = 0x2F6D2F820BE625FA,

        //collision_box
        CollisionBox       = 0x1A9241A8743F4CAB,

        //collisions
        Collisions         = 0xE59D9C72946EE696,

        //collision_base
        CollisionBase      = 0x1ED58C7641EFCC2C,

        //collision_up
        CollisionUp        = 0xEC6670556EB06377,

        //collision012_DEBRIS
        Collision012DEBRIS = 0xDBEC65DF4FDE1A6D,

        //collision007_DEBRIS
        Collision007DEBRIS = 0x6FF3E71C57D6839C,

        //collision018
        Collision018       = 0x1DCF8BB14CF6E63A,

        //collision2
        Collision2         = 0x2B45F89AE0097E41,

        //collision_hit
        CollisionHit       = 0xAFE3B5CB55A6025B,

        //collision003
        Collision003       = 0x427DA2B93E7204DE,

        //collision006
        Collision006       = 0x1E7C8A4504FDFA16,

        //collision020
        Collision020       = 0x6C60E4ABF3FB7C30,

        //UnknownType1
        UnknownType1       = 0xD0742138FC74EC08,

        //UnknownType2
        UnknownType2       = 0x145D990A588908BB,

        //UnknownType3
        UnknownType3       = 0xE48BC693150E464F,

        //UnknownType4
        UnknownType4       = 0x40BAA540D530AA25,

        //UnknownType5
        UnknownType5       = 0x8DC2E7510FAB1F45,

        //UnknownType6
        UnknownType6       = 0x5A5804F9F1C3788C
    }
}
