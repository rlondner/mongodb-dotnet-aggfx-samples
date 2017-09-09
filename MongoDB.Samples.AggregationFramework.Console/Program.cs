using Microsoft.Extensions.Configuration;
using MongoDB.Samples.AggregationFramework.Library;
using System;
using System.IO;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDB.Samples.AggregationFramework.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

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

            //int colCount = collection.Count();

            Console.ReadLine();
        }
    }
}
