using System;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections;

namespace MongoDB.Samples.AggregationFramework.Library
{
    public class DbManager
    {

        private volatile IMongoCollection<BsonDocument> m_collection;
        private static object syncRoot = new Object();

        private string m_ConnectionUri;
        private string m_DatabaseName;

        private DbManager() { }

        public DbManager(string strConnectionUri, string strDatabaseName)
        {
            m_ConnectionUri = strConnectionUri;
            m_DatabaseName = strDatabaseName;
        }

        public IMongoCollection<BsonDocument> GetCollection(string collectionName)
        {
            if (m_collection == null)
            {
                lock (syncRoot)
                {
                    if (m_collection == null)
                    {
                        var client = new MongoClient(m_ConnectionUri);
                        var db = client.GetDatabase(m_DatabaseName);
                        m_collection = db.GetCollection<BsonDocument>(collectionName);
                    }
                }
            }
            return m_collection;

        }
    }
}
