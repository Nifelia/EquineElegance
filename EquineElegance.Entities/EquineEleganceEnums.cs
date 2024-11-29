using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquineElegance.Entities
{
    public enum Gender
    {
        Male,
        Female
    }

    public enum PantsSize
    {
        Size32 = 32,
        Size34 = 34,
        Size36 = 36,
        Size38 = 38,
        Size40 = 40,
        Size42 = 42,
        Size44 = 44,
        Size46 = 46,
        Size48 = 48,
        Size50 = 50,
        Size52 = 52
    }

    public enum CapSize
    {
        XS,
        S,
        M,
        L,
        XL
    }

    public enum Color
    {
        White,
        Black,
        Blue,
        Brown,
        Beige,
        Denim,
        Yellow,
        Grey,
        Green,
        Orange,
        Purple,
        Red,
        Pink
    }

    public enum HorseSize
    {
        Shet,
        Pony,
        Cob,
        Full
    }

    public enum SaddlePadType
    {
        Dressage,
        Jumping,
        AllPurpose
    }

    public enum BlanketType
    {
        RainBlanket,
        WinterBlanket,
        EczemaBlanket
    }

    public enum TackRoomHangerType
    {
        BridleHanger,
        SaddlePadHanger,
        SaddleHanger
    }

    public enum ProductType
    {
        Blanket,
        Cap,
        Feeder,
        RidingPant,
        SaddlePad,
        TackRoom
    }
}
