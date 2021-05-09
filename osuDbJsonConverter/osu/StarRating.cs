using System.IO;

namespace osuDbJsonConverter.osu
{
    public class StarRating : IOsuSerializableSimple
    {
        public Mods Mods { get; set; }
        public double Stars { get; set; }

        public void ReadFromStream(BinaryReader reader)
        {
            reader.ReadExpected(0x08);
            Mods = (Mods) reader.ReadInt32();
            reader.ReadExpected(0x0D);
            Stars = reader.ReadDouble();
        }
    }
}