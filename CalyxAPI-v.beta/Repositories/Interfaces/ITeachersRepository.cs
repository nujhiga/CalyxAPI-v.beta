using CalyxAPI_v.beta.DTOS.Teachers.Response;
using CalyxAPI_v.beta.Models;

namespace CalyxAPI_v.beta.Repositories.Interfaces;

public interface ITeachersRepository : IBaseRepository<Teacher>
{
    Task<List<TeacherBasicResponse>> GetBasicsAsync();
    Task<TeacherBasicResponse> GetBasicAsync(int id);
    Task<List<TeacherCourseResponse>> GetTeachersCourseAsync();
    Task<TeacherCourseResponse> GetTeacherCourseAsync(int id);
}
