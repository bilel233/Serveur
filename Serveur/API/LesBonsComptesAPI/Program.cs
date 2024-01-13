using MongoDB.Bson;
using MongoDB.Driver;
using System;

class Program
{
    public static void Main(string[] args)
    {
        var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI");
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase("sample_mflix");

        var collection = database.GetCollection<BsonDocument>("users");

        Console.WriteLine("Connecté à MongoDB!");
    }
}
