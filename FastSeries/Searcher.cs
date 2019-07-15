using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastSeries
{
    class Searcher
    {
        public List<Data> TimeSearch(List<Data> arr, Data value, int left, int right)
        {
            int middle = (left + right) / 2;
            if (arr[middle].Time > value.Time)return TimeSearch(arr, value, left, right);

            return null;
        }
    }
}
