using System;

namespace Football.DAL.Entities
{
    [Flags]
    public enum Position
    {
        GK,
        RB,
        CB,
        LB,
        RM,
        CM,
        LM,
        RW,
        LW,
        ST
    }
}
