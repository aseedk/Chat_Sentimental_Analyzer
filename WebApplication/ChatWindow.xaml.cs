using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDBTest
{
    public partial class ChatWindow : Window
    {
        public string Username { get; set; }
        public ChatWindow(string username)
        {
            InitializeComponent();
            Welcome.Content = "Hello " + username;
            MongoHelper.ConnectToMongoService();
            var collections = MongoHelper.Database.GetCollection<BsonDocument>("Users");
            var documents = collections.Find(new BsonDocument()).ToList();
            foreach (BsonDocument doc in documents)
            {
                FriendsList.Items.Add(doc[1]+ " " + doc[2]);
            }

        }

        
    }
}