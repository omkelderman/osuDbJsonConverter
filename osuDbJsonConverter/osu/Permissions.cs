using System;

namespace osuDbJsonConverter.osu
{
    [Flags]
    public enum Permissions
    {
        None = 0,
        Normal = 1,
        Bat = 2,
        Supporter = 4,
        Friend = 8,
        Peppy = 16,
        Tournament = 32
    }
}