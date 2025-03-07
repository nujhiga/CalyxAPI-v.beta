using System.Text.Json.Serialization;

namespace CalyxAPI_v.beta.DTOS.Teachers.Response;

public class TeacherBasicResponse
{
    [JsonPropertyOrder(0)]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyOrder(1)]
    public string Identity { get; set; } = string.Empty;

    [JsonPropertyOrder(4)]
    public bool Enabled { get; set; }
}
