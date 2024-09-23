using System;
using System.IO;
using DotNetEnv;
using Google.Cloud.Firestore;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

// Register FirestoreService as a singleton
builder.Services.AddSingleton<FirestoreService>();



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

/**/