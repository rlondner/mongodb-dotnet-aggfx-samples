using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDB.Samples.AggregationFramework.Library
{
    public class State
    {
        public string Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("region")]
        public string Region { get; set; }
        [BsonElement("division")]
        public string Division { get; set; }
        [BsonElement("data")]
        public IEnumerable<CensusData> Data { get; set; }
        [BsonElement("areaM")]
        public double AreaSquareMiles { get; set; }
        [BsonElement("areaKM")]
        public double AreaSquareKilometers { get; set; }
    }
}
