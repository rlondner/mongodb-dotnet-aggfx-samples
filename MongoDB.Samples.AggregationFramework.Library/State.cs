using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDB.Samples.AggregationFramework.Library
{
    public class State
    {
        public string Id { get; set; }
        public string name { get; set; }
        public string region { get; set; }
        public string division { get; set; }
        public IEnumerable<CensusData> data { get; set; }
        public double areaM { get; set; }
    }
}
