namespace CalyxAPI_v.beta.DTOS.Courses.Response;

public class CourseBasicResponse
{
    public string CourseName { get; set; } = string.Empty;
    public short CourseYear { get; set; }
    public string? Description { get; set; }
}
