using Microsoft.Extensions.Configuration;
using MongoDB.Samples.AggregationFramework.Library;
using System;
using System.IO;
using MongoDB.Bson.IO;
using System.Collections.Generic;
using MongoDB.Bson;

namespace MongoDB.Samples.AggregationFramework.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();

            var mdbSettings = new MongoDBSettings();
            configuration.GetSection("MongoDB").Bind(mdbSettings);

            Console.WriteLine($"Cluster Connection Uri is '{mdbSettings.ConnectionUri}'");
            Console.WriteLine($"DB Database Name is '{mdbSettings.DatabaseName}'");
            Console.WriteLine($"DB Collection Name is '{mdbSettings.CollectionName}'");

            DbManager dbMgr = new DbManager(mdbSettings.ConnectionUri, mdbSettings.DatabaseName);
            var collection = dbMgr.GetCollection(mdbSettings.CollectionName);
            var colStates = dbMgr.GetStatesCollection(mdbSettings.CollectionName);

            int index = (args != null && args.Length > 0) ? Int32.Parse(args[0]) : 1;
            string strMode = (args != null && args.Length > 1) ? args[1] : "bson";
            Console.WriteLine($"Command line parameter is '{index}'");

            string results = string.Empty;
            DateTime dtStart = DateTime.Now;
            DateTime dtEnd = DateTime.MinValue;

            if (strMode.ToLower() == "linq")
            {
                switch (index)
                {
                    case 1:
                        Console.WriteLine("Total US Area with average region area is:\r\n");
                        results = dbMgr.GetTotalUSArea(colStates);
                        break;
                    case 2:
                        Console.WriteLine("Area by US Census region (with states) are:\r\n");
                        dtStart = DateTime.Now;
                        List<CensusArea> censusAreas = dbMgr.GetAreaByRegion(colStates);
                        dtEnd = DateTime.Now;
                        results = censusAreas.ToJson(new JsonWriterSettings { Indent = true });
                        break;
                    case 3:
                        Console.WriteLine("Total US population by census year:\r\n");
                        results = dbMgr.GetPopulationByYear(collection);
                        break;
                    case 4:
                        Console.WriteLine("Southern States population by census year:\r\n");
                        results = dbMgr.GetSouthernStatesPopulationByYear(collection);
                        break;
                    case 5:
                        Console.WriteLine("Population delta between 1990 and 2010 by state:\r\n");
                        results = dbMgr.GetPopulationDeltaByState(collection);
                        break;
                    case 6:
                        Console.WriteLine("Population in states within 500 km of Memphis:\r\n");
                        results = dbMgr.GetPopulationByState500KmsAroundMemphis(collection);
                        break;
                    case 7:
                        Console.WriteLine("Population in states within 500 km of Memphis (stored in database collection):\r\n");
                        results = dbMgr.GetPopulationByState500KmsAroundMemphis(collection, "peopleNearMemphis");
                        break;
                    case 8:
                        Console.WriteLine("State population density comparison in 1990 and 2010 :\r\n");
                        results = dbMgr.GetPopulationDensityByState(collection);
                        break;
                    default:
                        results = dbMgr.GetTotalUSArea(collection);
                        break;
                }

            }
            else
            {
                switch (index)
                {
                    case 1:
                        Console.WriteLine("Total US Area with average region area is:\r\n");
                        results = dbMgr.GetTotalUSArea(collection);
                        break;
                    case 2:
                        Console.WriteLine("Area by US Census region (with states) are:\r\n");
                        List<BsonDocument> censusAreas = dbMgr.GetAreaByRegion(collection);
                        dtEnd = DateTime.Now;
                        results = censusAreas.ToJson(new JsonWriterSettings { Indent = true });
                        break;
                    case 3:
                        Console.WriteLine("Total US population by census year:\r\n");
                        results = dbMgr.GetPopulationByYear(collection);
                        break;
                    case 4:
                        Console.WriteLine("Southern States population by census year:\r\n");
                        results = dbMgr.GetSouthernStatesPopulationByYear(collection);
                        break;
                    case 5:
                        Console.WriteLine("Population delta between 1990 and 2010 by state:\r\n");
                        results = dbMgr.GetPopulationDeltaByState(collection);
                        break;
                    case 6:
                        Console.WriteLine("Population in states within 500 km of Memphis:\r\n");
                        results = dbMgr.GetPopulationByState500KmsAroundMemphis(collection);
                        break;
                    case 7:
                        Console.WriteLine("Population in states within 500 km of Memphis (stored in database collection):\r\n");
                        results = dbMgr.GetPopulationByState500KmsAroundMemphis(collection, "peopleNearMemphis");
                        break;
                    case 8:
                        Console.WriteLine("State population density comparison in 1990 and 2010 :\r\n");
                        results = dbMgr.GetPopulationDensityByState(collection);
                        break;
                    default:
                        results = dbMgr.GetTotalUSArea(collection);
                        break;
                }
            }
            dtEnd = DateTime.Now;
            Console.WriteLine(results);
            //Console.WriteLine(Newtonsoft.Json.Linq.JValue.Parse(results).ToString(Newtonsoft.Json.Formatting.Indented))   
            Console.WriteLine($"{strMode.ToUpperInvariant()} method took {(dtEnd - dtStart).TotalMilliseconds} ms");
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }
    }
}
