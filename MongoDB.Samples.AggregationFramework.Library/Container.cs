using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB.Samples.AggregationFramework.Library
{
    public class Container
    {
        public ObjectId Id { get; set; }

        [BsonElement("container_id")]
        public string ContainerId { get; set; }

        [BsonElement("cargo")]
        public string Cargo { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

        public int Tons { get; set; }

        [BsonElement("shipName")]
        public string ShipName { get; set; }

        [BsonElement("location")]
        public GeoData Location { get; set; }
    }
}
