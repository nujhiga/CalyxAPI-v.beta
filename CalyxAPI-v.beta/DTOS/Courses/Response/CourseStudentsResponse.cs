using CalyxAPI_v.beta.DTOS.Students.Response;

namespace CalyxAPI_v.beta.DTOS.Courses.Response;

public class CourseStudentsResponse
{
    public string CourseName { get; set; } = string.Empty;
    public short CourseYear { get; set; }
    public List<StudentBasicResponse> Students { get; set; } = [];
}
