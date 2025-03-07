using CalyxAPI_v.beta.DTOS.Subjects.Response;

namespace CalyxAPI_v.beta.DTOS.Courses.Response;

public class CourseSubjectsResponse
{
    public string CourseName { get; set; } = string.Empty;
    public short CourseYear { get; set; }
    public List<SubjectBasicResponse> Subjects { get; set; } = [];
}
