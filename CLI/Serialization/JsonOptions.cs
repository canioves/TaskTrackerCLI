using System.Text.Json;
using System.Text.Json.Serialization;

namespace CLI.Serialization
{
    public static class JsonOptions
    {
        public static JsonSerializerOptions Default =>
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                AllowTrailingCommas = true,
                ReadCommentHandling = JsonCommentHandling.Skip,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                Converters = { new JsonStringEnumConverter() },
            };
    }
}
