using System.Text.Json.Serialization;

namespace CalyxAPI_v.beta.DTOS.Students.Response;

public class StudentBasicResponse
{
    [JsonPropertyOrder(0)]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyOrder(1)]
    public string Identity { get; set; } = string.Empty;

    [JsonPropertyOrder(4)]
    public string Mode { get; set; } = string.Empty;

    [JsonPropertyOrder(5)]
    public string Status { get; set; } = string.Empty;

    [JsonPropertyOrder(6)]
    public bool Enabled { get; set; }
}
