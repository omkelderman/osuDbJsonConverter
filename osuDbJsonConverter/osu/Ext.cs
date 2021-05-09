using System;
using System.Collections.Generic;
using System.IO;

namespace osuDbJsonConverter.osu
{
    public static class Ext
    {
        public static string ReadOsuString(this BinaryReader reader)
        {
            var b = reader.ReadByte();
            return b switch
            {
                0x00 => null,
                0x0b => reader.ReadString(),
                _ => throw new IOException("invalid data")
            };
        }

        public static DateTime ReadDateTime(this BinaryReader reader)
        {
            var ticks = reader.ReadInt64();
            return new DateTime(ticks, DateTimeKind.Utc);
        }

        public static void ReadExpected(this BinaryReader reader, byte expected)
        {
            var b = reader.ReadByte();
            if (b == expected) return;
            throw new IOException($"Unexpected byte: got 0x{b:X}, expected 0x{expected:X}");
        }

        public static List<T> ReadList<T>(this BinaryReader reader, int osuVersion) where T : IOsuSerializable, new()
        {
            var count = reader.ReadInt32();
            if (count < 0) return null;
            var list = new List<T>(count);
            for (var i = 0; i < count; i++)
            {
                var t = new T();
                t.ReadFromStream(reader, osuVersion);
                list.Add(t);
            }

            return list;
        }

        public static List<T> ReadList<T>(this BinaryReader reader) where T : IOsuSerializableSimple, new()
        {
            var count = reader.ReadInt32();
            if (count < 0) return null;
            var list = new List<T>(count);
            for (var i = 0; i < count; i++)
            {
                var t = new T();
                t.ReadFromStream(reader);
                list.Add(t);
            }

            return list;
        }

        public static byte[] ReadByteArray(this BinaryReader reader)
        {
            var length = reader.ReadInt32();
            return length < 0 ? null : reader.ReadBytes(length);
        }
    }
}