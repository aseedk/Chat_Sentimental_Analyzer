using System;
using System.Diagnostics;
using System.Windows;
using MongoDB.Driver;

namespace MongoDBTest
{
    public class MongoHelper
    {
        private static IMongoClient Client { get; set; }
        public static IMongoDatabase Database { get; set; }

        public static string MongoConnection =
            "mongodb+srv://ChatAnalyzerUser:ChatAnalyzerUser@chatsentimentalanalyzer.ell4m.mongodb.net/myFirstDatabase?retryWrites=true&w=majority";
        public static string MongoDatabase = "user_accounts";
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