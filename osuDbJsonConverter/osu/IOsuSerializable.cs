using System.IO;

namespace osuDbJsonConverter.osu
{
    public interface IOsuSerializable
    {
        void ReadFromStream(BinaryReader reader, int osuVersion);
    }

    public interface IOsuSerializableSimple
    {
        void ReadFromStream(BinaryReader reader);
    }
}