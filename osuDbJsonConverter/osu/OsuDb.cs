using System;
using System.Collections.Generic;
using System.IO;

namespace osuDbJsonConverter.osu
{
    public class OsuDb
    {
        public int OsuVersion { get; set; }
        public int FolderCount { get; set; }
        public bool AccountUnlocked { get; set; }
        public DateTime UnlockDateTime { get; set; }
        public string PlayerName { get; set; }
        public List<BeatmapInfo> Beatmaps { get; set; }
        public Permissions Permissions { get; set; }

        public void ReadFromStream(BinaryReader reader)
        {
            var osuVersion = reader.ReadInt32();
            if (osuVersion < 20140609)
            {
                throw new IOException($"ERROR: osu! db version too old to read reliably, got version {osuVersion}, need at least version 20140609");
            }

            OsuVersion = osuVersion;
            FolderCount = reader.ReadInt32();
            AccountUnlocked = reader.ReadBoolean();
            UnlockDateTime = reader.ReadDateTime();
            PlayerName = reader.ReadOsuString();
            Beatmaps = reader.ReadList<BeatmapInfo>(osuVersion);
            Permissions = (Permissions) reader.ReadInt32();
        }

        public void ReadFromFile(string path)
        {
            using var stream = File.OpenRead(path);
            using var reader = new BinaryReader(stream);
            ReadFromStream(reader);
        }
    }
}