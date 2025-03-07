using CalyxAPI_v.beta.DTOS.Students.Response;

namespace CalyxAPI_v.beta.DTOS.Subjects.Response;

public class SubjectClassResponse
{
    public string SubjectName { get; set; } = string.Empty;
    public string TeacherName { get; set; } = string.Empty;
    public DateTime SubjectDate { get; set; }
    public List<StudentSubjectClassResponse> Students { get; set; } = [];
}
