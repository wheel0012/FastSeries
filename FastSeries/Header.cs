using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastSeries
{
    static class Header
    {
        public static void WriteHeader(StreamWriter writer, string[] tableDescriptions)
        {
            writer.Write((UInt16)tableDescriptions.Length);
            foreach (var item in tableDescriptions) writer.Write(item);
        }

        public static List<string> ReadHeader(StreamReader reader)
        {
            UInt16 n;
            UInt16.TryParse(reader.ReadLine(), out n);
            List<string> result = new List<string>(n);
            for (int i = 0; i < n; i++) result.Add(reader.read());
            return result;
        }
    }
}
