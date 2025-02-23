using System.Text.Json.Serialization;
using NEWMARK.Models;
using NEWMARK.DataHandlers;
using NEWMARK.Interfaces;

var builder = WebApplication.CreateSlimBuilder(args);
builder.Services.ConfigureHttpJsonOptions(static options =>
{
    options.SerializerOptions.TypeInfoResolver = AppJsonSerializerContext.Default;
});
builder.Services.AddSingleton<HttpClient>();
builder.Services.AddScoped<IDataHandler, DataHandler>();
builder.Services.AddScoped<IDataProcessor, PropertyDataProcessor>();
builder.Services.AddScoped<PropertyService>();
builder.Services.AddControllers();
var app = builder.Build();
app.MapControllers();
app.Run();

[JsonSerializable(typeof(Property[]))]
[JsonSerializable(typeof(Space[]))]
[JsonSerializable(typeof(RentRoll[]))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{
    
}