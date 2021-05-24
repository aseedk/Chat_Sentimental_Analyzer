using System;

namespace MongoDBTest
{
    public class UserAccount
    {
        public Object _id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}