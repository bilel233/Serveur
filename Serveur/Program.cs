using MongoDB.Bson;
using MongoDB.Driver;
using System;

class Program
{
   public static void Main(string[] args)
    {
        var connectionString = "mongodb+srv://BilelMajdoub:Mongodb1998%40@bdd.uquucse.mongodb.net/"; 
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase("sample_mflix");

        var collection = database.GetCollection<BsonDocument>("users"); 

        Console.WriteLine("Connecté à MongoDB!");
    }
}




