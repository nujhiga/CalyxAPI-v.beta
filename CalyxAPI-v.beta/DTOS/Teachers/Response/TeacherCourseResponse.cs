using System.Text.Json.Serialization;

namespace CalyxAPI_v.beta.DTOS.Teachers.Response;


public class TeacherCourseResponse : TeacherBasicResponse
{
    [JsonPropertyOrder(2)]
    public string CourseName { get; set; } = string.Empty;
    [JsonPropertyOrder(3)]
    public int CourseYear { get; set; }
}
