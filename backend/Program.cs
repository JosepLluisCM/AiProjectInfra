using System;
using System.IO;
using DotNetEnv;
using Google.Cloud.Firestore;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

string credentialsPath = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS");
Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialsPath);

string projectId = builder.Configuration["Firestore:ProjectId"] ?? Environment.GetEnvironmentVariable("GOOGLE_PROJECT_ID");
builder.Services.AddSingleton(provider =>
{
    FirestoreDb db = FirestoreDb.Create(projectId);
    return db;
});


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

//app.UseRouting();

app.MapControllers();



app.Run();

try
{
    FirestoreDb db = FirestoreDb.Create(projectId);
    Console.WriteLine("Successfully connected to Firestore.");

    // Optionally, perform a simple operation
    var collections = await db.ListRootCollectionsAsync().ToListAsync();
    Console.WriteLine("Root collections:");
    foreach (var collection in collections)
    {
        Console.WriteLine($"- {collection.Id}");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error connecting to Firestore: {ex.Message}");
    throw; // Re-throw the exception to prevent the app from starting
}
