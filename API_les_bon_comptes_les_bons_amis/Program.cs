using MongoDB.Driver;
using MongoDB.Bson;

MongoClient client = new MongoClient("mongodb+srv://BilelMajdoub:Mongodb1998%40@bdd.uquucse.mongodb.net/");

List<string> databases = client.ListDatabaseNames().ToList();

for (int i = 0; i < databases.Count; i++)
{
    string dbName = databases[i];
    Console.WriteLine(dbName);
}

// Obtenez une r�f�rence � la base de donn�es 'sample_mflix'
var database = client.GetDatabase("sample_mflix");

// Obtenez une r�f�rence � la collection 'users'
var collection = database.GetCollection<BsonDocument>("users");

// Cr�ez un filtre pour s�lectionner tous les documents
var filter = new BsonDocument();

// Utilisez la m�thode Find avec le filtre pour obtenir tous les documents de la collection
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
