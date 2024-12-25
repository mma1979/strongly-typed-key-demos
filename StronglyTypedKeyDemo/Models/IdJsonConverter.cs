using System.Text.Json;
using System.Text.Json.Serialization;

namespace StronglyTypedKeyDemo.Models;

public interface IId
{
    int Value { get; }
}

public abstract record  StronglyTypedId(int Value) : IId;

public class IdJsonConverter<T>: JsonConverter<T> where T:IId
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(T);
    }


    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return (T?) Activator.CreateInstance(typeof(T),reader.GetInt32());
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Value.ToString());
    }
}

public static class StronglyTypedIdJsonConverterExtensions
{
    public static void AddStronglyTypedIdConverters(this JsonSerializerOptions options)
    {
        // Get all types that implement IStronglyTypedId
        var idTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(t => t is { IsClass: true, IsAbstract: false } && typeof(IId).IsAssignableFrom(t));

        foreach (var idType in idTypes)
        {
            var converterType = typeof(IdJsonConverter<>).MakeGenericType(idType);
            var converter = (JsonConverter)Activator.CreateInstance(converterType)!;
            options.Converters.Add(converter);
        }
    }
}