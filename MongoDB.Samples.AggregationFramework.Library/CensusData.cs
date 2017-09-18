using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDB.Samples.AggregationFramework.Library
{
    public class CensusData
    {
        public int year { get; set; }
        public int totalPop { get; set; }
        public int totalHouse { get; set; }
        public int occHouse { get; set; }
    }
}
