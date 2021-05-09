using System;
using System.Collections.Generic;
using System.IO;

namespace osuDbJsonConverter.osu
{
    public class BeatmapInfo : IOsuSerializable
    {
        public string Artist { get; set; }
        public string ArtistUnicode { get; set; }
        public string Title { get; set; }
        public string TitleUnicode { get; set; }
        public string Creator { get; set; }
        public string Version { get; set; }
        public string AudioFilename { get; set; }
        public string BeatmapMd5 { get; set; }
        public string Filename { get; set; }
        public SubmissionStatus SubmissionStatus { get; set; }
        public ushort CountCircles { get; set; }
        public ushort CountSliders { get; set; }
        public ushort CountSpinners { get; set; }
        public DateTime DateModified { get; set; }
        public float ApproachRate { get; set; }
        public float CircleSize { get; set; }
        public float HpDrainRate { get; set; }
        public float OverallDifficulty { get; set; }
        public double SliderMultiplier { get; set; }
        public List<StarRating> OsuStars { get; set; }
        public List<StarRating> TaikoStars { get; set; }
        public List<StarRating> CatchStars { get; set; }
        public List<StarRating> ManiaStars { get; set; }
        public int DrainTime { get; set; }
        public int TotalTime { get; set; }
        public int PreviewTime { get; set; }
        public List<ControlPoint> ControlPoints { get; set; }
        public int BeatmapId { get; set; }
        public int BeatmapSetId { get; set; }
        public int ForumThreadId { get; set; }
        public Grade OsuGrade { get; set; }
        public Grade TaikoGrade { get; set; }
        public Grade CatchGrade { get; set; }
        public Grade ManiaGrade { get; set; }
        public short LocalBeatmapOffset { get; set; }
        public float StackLeniency { get; set; }
        public GameMode GameMode { get; set; }
        public string Source { get; set; }
        public string Tags { get; set; }
        public short OnlineOffset { get; set; }
        public string OnlineTitleFont { get; set; }
        public bool UnPlayed { get; set; }
        public DateTime LastPlayed { get; set; }
        public bool IsOsz2 { get; set; }
        public string FolderName { get; set; }
        public DateTime LastTimeOnlineChecked { get; set; }
        public bool IgnoreBeatmapSounds { get; set; }
        public bool IgnoreBeatmapSkin { get; set; }
        public bool DisableStoryboard { get; set; }
        public bool DisableVideo { get; set; }
        public bool VisualOverride { get; set; }
        public int EditorPosition { get; set; }
        public byte ManiaScrollSpeed { get; set; }

        public void ReadFromStream(BinaryReader reader, int osuVersion)
        {
            if (osuVersion >= 20160408 && osuVersion < 20191106)
            {
                var bytes = reader.ReadByteArray();
                using var memStream = new MemoryStream(bytes);
                using var subReader = new BinaryReader(memStream);
                ReadFromStreamRaw(subReader);
            }
            else
            {
                ReadFromStreamRaw(reader);
            }
        }

        public void ReadFromStreamRaw(BinaryReader reader)
        {
            Artist = reader.ReadOsuString();
            ArtistUnicode = reader.ReadOsuString();
            Title = reader.ReadOsuString();
            TitleUnicode = reader.ReadOsuString();
            Creator = reader.ReadOsuString();
            Version = reader.ReadOsuString();
            AudioFilename = reader.ReadOsuString();
            BeatmapMd5 = reader.ReadOsuString();
            Filename = reader.ReadOsuString();
            SubmissionStatus = (SubmissionStatus) reader.ReadByte();
            CountCircles = reader.ReadUInt16();
            CountSliders = reader.ReadUInt16();
            CountSpinners = reader.ReadUInt16();
            DateModified = reader.ReadDateTime();
            ApproachRate = reader.ReadSingle();
            CircleSize = reader.ReadSingle();
            HpDrainRate = reader.ReadSingle();
            OverallDifficulty = reader.ReadSingle();
            SliderMultiplier = reader.ReadDouble();
            OsuStars = reader.ReadList<StarRating>();
            TaikoStars = reader.ReadList<StarRating>();
            CatchStars = reader.ReadList<StarRating>();
            ManiaStars = reader.ReadList<StarRating>();
            DrainTime = reader.ReadInt32();
            TotalTime = reader.ReadInt32();
            PreviewTime = reader.ReadInt32();
            ControlPoints = reader.ReadList<ControlPoint>();
            BeatmapId = reader.ReadInt32();
            BeatmapSetId = reader.ReadInt32();
            ForumThreadId = reader.ReadInt32();
            OsuGrade = (Grade) reader.ReadByte();
            TaikoGrade = (Grade) reader.ReadByte();
            CatchGrade = (Grade) reader.ReadByte();
            ManiaGrade = (Grade) reader.ReadByte();
            LocalBeatmapOffset = reader.ReadInt16();
            StackLeniency = reader.ReadSingle();
            GameMode = (GameMode) reader.ReadByte();
            Source = reader.ReadOsuString();
            Tags = reader.ReadOsuString();
            OnlineOffset = reader.ReadInt16();
            OnlineTitleFont = reader.ReadOsuString();
            UnPlayed = reader.ReadBoolean();
            LastPlayed = reader.ReadDateTime();
            IsOsz2 = reader.ReadBoolean();
            FolderName = reader.ReadOsuString();
            LastTimeOnlineChecked = reader.ReadDateTime();
            IgnoreBeatmapSounds = reader.ReadBoolean();
            IgnoreBeatmapSkin = reader.ReadBoolean();
            DisableStoryboard = reader.ReadBoolean();
            DisableVideo = reader.ReadBoolean();
            VisualOverride = reader.ReadBoolean();
            EditorPosition = reader.ReadInt32();
            ManiaScrollSpeed = reader.ReadByte();
        }
    }
}