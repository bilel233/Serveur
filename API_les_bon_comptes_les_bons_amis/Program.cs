using MongoDB.Driver;
using MongoDB.Bson;

MongoClient client = new MongoClient("mongodb+srv://BilelMajdoub:Mongodb1998%40@bdd.uquucse.mongodb.net/");

List<string> databases = client.ListDatabaseNames().ToList();

for (int i = 0; i < databases.Count; i++)
{
    string dbName = databases[i];
    Console.WriteLine(dbName);
}

// Obtenez une référence à la base de données 'sample_mflix'
var database = client.GetDatabase("sample_mflix");

// Obtenez une référence à la collection 'users'
var collection = database.GetCollection<BsonDocument>("users");

// Créez un filtre pour sélectionner tous les documents
var filter = new BsonDocument();

// Utilisez la méthode Find avec le filtre pour obtenir tous les documents de la collection
var documents = collection.Find(filter).ToList();

// Parcourez et imprimez tous les documents
foreach (var document in documents)
{
    Console.WriteLine(document.ToString());
}


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
