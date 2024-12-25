using System.Text.Json.Serialization;
using System.Text.Json;
using StronglyTypedKeyDemo3.Data;
using Microsoft.EntityFrameworkCore;
using StronglyTypedKeyDemo3.MappingProfiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add services to the container.
builder.Services.AddAutoMapper(System.Reflection.Assembly.GetAssembly(typeof(AuthorMappingProfile)));
builder.Services.AddAutoMapper(System.Reflection.Assembly.GetAssembly(typeof(BookMappingProfile)));
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
