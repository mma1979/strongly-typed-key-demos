using Microsoft.EntityFrameworkCore;

using StronglyTypedKeyDemo2;
using StronglyTypedKeyDemo2.Data;

using System.Text.Json.Serialization;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(System.Reflection.Assembly.GetAssembly(typeof(MapperProfile)));
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        //options.SerializerSettings.ContractResolver = new DefaultContractResolver();
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        options.SerializerSettings.MaxDepth = 2;
    })
    .AddJsonOptions(options =>
    {
        // Ignore cycles during serialization
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;

        // Optional: Configure other common JSON settings
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        options.JsonSerializerOptions.WriteIndented = builder.Environment.IsDevelopment(); // Pretty printing (development only)

        options.JsonSerializerOptions.MaxDepth = 2;
    });

builder.Services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
