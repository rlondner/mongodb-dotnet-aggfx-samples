using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDB.Samples.AggregationFramework.Library
{
    public class CensusArea
    {
        public string Id { get; set; }
        public double totalArea { get; set; }
        public double avgArea { get; set; }
        public int numStates { get; set; }
        public IEnumerable<string> states { get; set; }
    }
}
