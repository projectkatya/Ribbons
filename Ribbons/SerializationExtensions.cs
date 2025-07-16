using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ribbons;

public static class SerializationExtensions
{
	private static readonly JsonSerializerOptions SerializerOptions = new()
	{
		WriteIndented = false,
		Converters = { new JsonStringEnumConverter() }
	};

	private static readonly JsonSerializerOptions SerializerOptionsIndented = new()
	{
		WriteIndented = true,
		Converters = 
		{ 
			new JsonStringEnumConverter()
		}
	};

	public static string ToJson(this object obj, bool indent = false)
	{
		return JsonSerializer.Serialize(obj, indent ? SerializerOptionsIndented : SerializerOptions);
	}
}
