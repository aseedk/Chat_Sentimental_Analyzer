using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
namespace MongoDBTest
{
    public class MongoHelper
    {
        private static IMongoClient Client { get; set; }
        public static IMongoDatabase Database { get; set; }

        public static string MongoConnection =
            "mongodb+srv://mongoDBTest:mongoDBTest@mongodbtestcluster.fmrug.mongodb.net/myFirstDatabase?retryWrites=true&w=majority";
        public static string MongoDatabase = "sample_training";
        
        public static IMongoCollection<UserAccount> user_collections { get; set; }
        internal static void ConnectToMongoService()
        {
            try
            {
                Client = new MongoClient(MongoConnection);
                Database = Client.GetDatabase(MongoDatabase);
                
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }
        }
    }
}