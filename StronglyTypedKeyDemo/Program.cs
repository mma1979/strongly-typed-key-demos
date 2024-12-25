
using System.Text.Json;
using System.Text.Json.Serialization;
using StronglyTypedKeyDemo.Data;
using StronglyTypedKeyDemo.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            // Ignore cycles during serialization
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        
            // Optional: Configure other common JSON settings
            options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            options.JsonSerializerOptions.WriteIndented = true; // Pretty printing (development only)
        
            options.JsonSerializerOptions.AddStronglyTypedIdConverters();
        });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();