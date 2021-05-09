using System.IO;

namespace osuDbJsonConverter.osu
{
    public class ControlPoint : IOsuSerializableSimple
    {
        public double MsPerBeat { get; set; }
        public double Offset { get; set; }
        public bool IsTimingPoint { get; set; }

        public void ReadFromStream(BinaryReader reader)
        {
            MsPerBeat = reader.ReadDouble();
            Offset = reader.ReadDouble();
            IsTimingPoint = reader.ReadBoolean();
        }
    }
}