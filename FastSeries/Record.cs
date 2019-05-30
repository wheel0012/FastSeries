using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastSeries
{
    class Record
    {
        public UInt16 TableID { get; set; }
        public TimeSpan Time { get; set; }

        
        public Data Values;
        public static Record FromStream(StreamReader reader)
        {
            var tableID = (ushort)0;
            ushort.TryParse(reader.ReadLine(), out tableID);
            var ticks = (long)0;
            long.TryParse(reader.ReadLine(),out ticks);
            var time = new TimeSpan(ticks);
            Data values = new Data { };
            var ID = 0;
            int.TryParse(reader.ReadLine(), out ID);
            values.ID = ID;
            values.CTime = reader.ReadLine();
            values.Name = reader.ReadLine();
            values.TYPE = reader.ReadLine().ToCharArray()[0];
            values.VALUE_STR = reader.ReadLine();
            var value_Num = 0.0;
            double.TryParse(reader.ReadLine(), out value_Num);
            values.VALUE_NUM = value_Num; 
            values.VALUE_RAW = reader.ReadLine();
           
            return new Record { Time = time, TableID = tableID, Values = values};
        }

        public async void  WriteToStream(BinaryWriter writer)
        {
             await BinaryWrite(writer);
        }
        private async Task BinaryWrite(BinaryWriter writer)
        {
            await Task.Run(() =>
            {
                writer.Write(TableID);
                writer.Write(Time.Ticks);
                writer.Write(Values.ID);
                writer.Write(Values.CTime);
                writer.Write(Values.Name);
                writer.Write(Values.TYPE);
                writer.Write(Values.VALUE_STR);
                writer.Write(Values.VALUE_NUM);
                writer.Write(Values.VALUE_RAW);
            });
        }
    }
    
}
