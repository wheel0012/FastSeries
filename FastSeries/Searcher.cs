using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastSeries
{
    public class Searcher
    { 
        public List<Data> TimeSearch(List<Data> arr, params DateTime[] cdtn)
        {
            int curser = arr.Count/2;
            List<Data> core = new List<Data>();
            for(int i = 0; i<arr.Count; i++)
            {
                DateTime tempDate = DateTime.Parse(arr[curser].CTime);
                if (tempDate > cdtn[0])
                {
                    curser /= 2;
                }
                else if(tempDate < cdtn[0])
                {
                    curser += (curser / 2);
                }
            }
            return arr;
        }
    }
}
