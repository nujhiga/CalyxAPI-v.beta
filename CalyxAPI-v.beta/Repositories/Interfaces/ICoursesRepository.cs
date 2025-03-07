using CalyxAPI_v.beta.DTOS.Courses.Response;

namespace CalyxAPI_v.beta.Repositories.Interfaces;

public interface ICoursesRepository
{
    Task<List<CourseBasicResponse>> GetBasicsAsync();
    Task<CourseBasicResponse> GetBasicAsync(int id);
    Task<List<CourseStudentsResponse>> GetStudentsAsync();
    Task<CourseStudentsResponse> GetStudentAsync(int id);
    Task<List<CourseSubjectsResponse>> GetSubjectsAsync();
    Task<CourseSubjectsResponse> GetSubjectAsync(int id);
}
