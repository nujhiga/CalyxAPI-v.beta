using CalyxAPI_v.beta.DTOS.Students.Response;

namespace CalyxAPI_v.beta.Repositories.Interfaces;

public interface IStudentsRepository
{
    Task<List<StudentCourseResponse>> GetStudentsCourseAsync();
    Task<StudentCourseResponse> GetStudentCourseAsync(int id);
}
