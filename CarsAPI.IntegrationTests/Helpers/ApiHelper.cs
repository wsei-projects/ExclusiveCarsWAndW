using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CarsAPI.IntegrationTests.Helpers;

public partial class ApiHelper
{
    private static readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    public ApiHelper(HttpClient httpClient)
    {
        Client = httpClient;
    }

    public HttpClient Client { get; }

    public static async Task<T> Deserialize<T>(HttpResponseMessage httpResponseMessage)
    {
        return JsonSerializer.Deserialize<T>(await httpResponseMessage.Content.ReadAsStringAsync(), _jsonSerializerOptions)!;
    }

    private static StringContent Serialize<T>(T payload)
    {
        return new(JsonSerializer.Serialize(payload, _jsonSerializerOptions), Encoding.UTF8, "application/json");
    }
}