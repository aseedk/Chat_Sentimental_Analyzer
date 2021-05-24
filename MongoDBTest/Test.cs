using MongoDB.Bson;

namespace MongoDBTest
{
    public static class Test
    {
        public static void Main()
        {
            MongoHelper.ConnectToMongoService();
            var collections = MongoHelper.Database.GetCollection<BsonDocument>("grades");
            /*var document = new BsonDocument { { "student_id", 10200 }, {
                    "scores",
                    new BsonArray {
                        new BsonDocument { { "type", "exam" }, { "score", 88.12334193287023 } },
                        new BsonDocument { { "type", "quiz" }, { "score", 74.92381029342834 } },
                        new BsonDocument { { "type", "homework" }, { "score", 89.97929384290324 } },
                        new BsonDocument { { "type", "homework" }, { "score", 82.12931030513218 } }
                    }
                }, { "class_id", 480 }
            };
            collections.InsertOneAsync(document);
            collections = MongoHelper.Database.GetCollection<BsonDocument>("grades");
            var filter = Builders<BsonDocument>.Filter.Eq("student_id", 10200);
            var firstDocument = collections.Find(filter).FirstOrDefault();
            Console.WriteLine(firstDocument.ToString());
            // var documents = collection.Find(new BsonDocument()).ToList();
            /*foreach(BsonDocument doc in documents)
            {
                Console.WriteLine(doc.ToString());
            } */
            /*var highExamScoreFilter = Builders<BsonDocument>.Filter.ElemMatch<BsonValue>(
                "scores", new BsonDocument { { "type", "exam" },
                    { "score", new BsonDocument { { "$gte", 95 } } }
                });
            var highExamScores = collection.Find(highExamScoreFilter).ToList();
            var sort = Builders<BsonDocument>.Sort.Descending("student_id");
            var highExamScoreFilter = Builders<BsonDocument>.Filter.ElemMatch<BsonValue>(
                "scores", new BsonDocument { { "type", "exam" },
                    { "score", new BsonDocument { { "$gte", 99 } } }
                });
            //var highExamScores = collections.Find(highExamScoreFilter).ToList();
            var highestScores = collections.Find(highExamScoreFilter).Sort(sort);
            foreach (var VARIABLE in highestScores.ToList())
            {
                Console.WriteLine(VARIABLE);
            }
            var highestScore = collections.Find(highExamScoreFilter).Sort(sort).First();
            Console.WriteLine("****************************");
            Console.WriteLine(highestScore);
            collections = MongoHelper.Database.GetCollection<BsonDocument>("grades");
            var filter = Builders<BsonDocument>.Filter.Eq("student_id", 10000);
            collections.DeleteOne(filter);
            var firstDocument = collections.Find(filter).FirstOrDefault();
            if (firstDocument == null)
            {
                Console.WriteLine("Jani NULL");
            }
            filter = Builders<BsonDocument>.Filter.Eq("student_id", 10000);
            var update = Builders<BsonDocument>.Update.Set("class_id", 485);
            collections.UpdateOne(filter, update);
            filter = Builders<BsonDocument>.Filter.Eq("student_id", 10000); 
            firstDocument = collections.Find(filter).FirstOrDefault();
            Console.WriteLine(firstDocument.ToString());
            var deleteLowExamFilter = Builders<BsonDocument>.Filter.ElemMatch<BsonValue>("scores",
            new BsonDocument { { "type", "exam" }, {"score", new BsonDocument { { "$lt", 60 }}}    
            });
            collection.DeleteMany(deleteLowExamFilter);
            */
            
        }
    }
}