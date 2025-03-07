using System.Text.Json.Serialization;

namespace CalyxAPI_v.beta.DTOS.Students.Response;

public class StudentCourseResponse : StudentBasicResponse
{
    [JsonPropertyOrder(2)]
    public string CourseName { get; set; } = string.Empty;
    [JsonPropertyOrder(3)]
    public int CourseYear { get; set; }
}
