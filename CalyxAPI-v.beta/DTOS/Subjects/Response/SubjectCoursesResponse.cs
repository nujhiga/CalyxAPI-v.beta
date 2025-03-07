using CalyxAPI_v.beta.DTOS.Courses.Response;

namespace CalyxAPI_v.beta.DTOS.Subjects.Response;

public class SubjectCoursesResponse
{
    public string SubjectName { get; set; } = null!;
    public string? Description { get; set; }
    public List<CourseBasicResponse> Courses { get; set; } = [];
}
