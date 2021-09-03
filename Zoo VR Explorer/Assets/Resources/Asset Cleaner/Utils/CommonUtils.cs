using System;
using System.IO;

namespace Asset_Cleaner {
    static class CommonUtils {
        static string[] _suffix = {"B", "KB", "MB", "GB", "TB"};

        public static string BytesToString(long byteCount) {
            if (byteCount == 0)
                return $"0 {_suffix[0]}";

            var bytes = Math.Abs(byteCount);
            var place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num;
            if (place == 0 || place == 1) { // display B, KB in MB
                num = Math.Round(bytes / Math.Pow(1024, 2), 4);
                return $"{Math.Sign(byteCount) * num:N} {_suffix[2]}";
            }

            num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return $"{Math.Sign(byteCount) * num:F0} {_suffix[place]}";
        }

        // todo
        public static long Size(string path) {
            return TryGetSize(path, out var res) ? res : 0L;
        }

        public static bool TryGetSize(string path, out long result) {
            if (!File.Exists(path)) {
                result = default;
                return false;
            }

            var fi = new FileInfo(path);
            result = fi.Length;
            return true;
        }
    }
}