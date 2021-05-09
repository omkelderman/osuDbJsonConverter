using System;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using osuDbJsonConverter.osu;

namespace osuDbJsonConverter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var osuDbPath = args.FirstOrDefault();
            while (string.IsNullOrEmpty(osuDbPath))
            {
                Console.Write("path to osu!.db file: ");
                osuDbPath = Console.ReadLine();
                if (osuDbPath == null) return;
                osuDbPath = osuDbPath.Trim();
            }

            osuDbPath = Path.GetFullPath(osuDbPath);

            var jsonPath = osuDbPath + ".json";
            var count = 1;
            while (File.Exists(jsonPath))
            {
                ++count;
                jsonPath = $"{osuDbPath} ({count}).json";
            }

            Console.WriteLine($"Reading osu!.db file ({osuDbPath})...");
            var db = new OsuDb();
            db.ReadFromFile(osuDbPath);
            Console.WriteLine("Done!");
            Console.WriteLine($"Writing out as a json file ({jsonPath})...");
            var jsonString = JsonSerializer.Serialize(db, new JsonSerializerOptions
            {
                Converters = {new JsonStringEnumConverter()},
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true
            });
            File.WriteAllText(jsonPath, jsonString);
            Console.WriteLine("Done!");
        }
    }
}