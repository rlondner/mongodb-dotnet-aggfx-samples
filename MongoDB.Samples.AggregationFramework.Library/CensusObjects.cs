using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDB.Samples.AggregationFramework.Library
{
    public class CensusArea
    {
        public string Id { get; set; }

        [BsonElement("totalArea")]
        public double TotalArea { get; set; }

        [BsonElement("avgArea")]
        public double AverageArea { get; set; }

        [BsonElement("numStates")]
        public int StatesCount { get; set; }

        [BsonElement("states")]
        public IEnumerable<string> States { get; set; }
    }

    public class CensusData
    {
        [BsonElement("year")]
        public int Year { get; set; }

        [BsonElement("totalPop")]
        public int TotalPopulation { get; set; }

        [BsonElement("totalHouse")]
        public int TotalHouseholds { get; set; }

        [BsonElement("occHouse")]
        public int OccupiedHouseHolds { get; set; }
    }

    public class State
    {
        public ObjectId Id { get; set; }

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
