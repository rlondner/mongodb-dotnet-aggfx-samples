using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Collections.Generic;

using MongoDB.Bson;
using MongoDB.Bson.IO;

using MongoDB.Samples.AggregationFramework.Library;

namespace MongoDB.Samples.AggregationFramework.ConsoleApp2
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
            var colShips = dbMgr.GetShipsCollection(mdbSettings.CollectionName);
            var colContainers = dbMgr.GetContainersCollection("containers");

            //int index = (args != null && args.Length > 0) ? Int32.Parse(args[0]) : 1;
            string strMode = (args != null && args.Length > 1) ? args[1] : "bson";
            //Console.WriteLine($"Command line parameter is '{index}'");

            List<BsonDocument> resData = new List<BsonDocument>();
            string results = string.Empty;
            DateTime dtStart = DateTime.Now;


            results = dbMgr.GetShipsCargos(colShips, colContainers);

            DateTime dtEnd = DateTime.Now;
            if (resData.Count > 0)
            {
                results = resData.ToJson(new JsonWriterSettings { Indent = true });
            }
            Console.WriteLine(results);
            Console.WriteLine($"{strMode.ToUpperInvariant()} method took {(dtEnd - dtStart).TotalMilliseconds} ms");
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }
    }
}
