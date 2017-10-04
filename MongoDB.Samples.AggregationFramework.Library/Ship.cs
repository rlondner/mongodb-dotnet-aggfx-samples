using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace MongoDB.Samples.AggregationFramework.Library
{
    public class Ship
    {
        //public string Id { get; set; }

        public Bson.ObjectId Id { get; set; }

        public string Name { get; set; }

        public int Built { get; set; }

        [BsonElement("Length overall (m)")]
        public double Length { get; set; }

        [BsonElement("Beam (m)")]
        public double BeamLength { get; set; }

        [BsonElement("Maximum TEU")]
        public int MaximumTEU { get; set; }

        [BsonElement("GT")]
        public int GrossTonnage { get; set; }

        public string Owner { get; set; }

        public string Country { get; set; }

        public DateTime EAT { get; set; }

        [BsonElement("route")]
        public Route Route { get; set; }

        [BsonElement("location")]
        public GeoData Location { get; set; }

    }

    public class Route
    {
        [BsonElement("origin")]
        public Location Origin { get; set; }

        [BsonElement("destination")]
        public Location Destination { get; set; }
    }

    public class Location
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }

    public class GeoData
    {
        [BsonElement("coordinates")]
        public IEnumerable<double> Coordinates { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

    }
}
