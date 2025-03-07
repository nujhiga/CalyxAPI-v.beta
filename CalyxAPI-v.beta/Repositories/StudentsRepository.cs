using CalyxAPI_v.beta.Data;
using CalyxAPI_v.beta.DTOS.Students.Mapper;
using CalyxAPI_v.beta.DTOS.Students.Response;
using CalyxAPI_v.beta.Models;
using CalyxAPI_v.beta.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace CalyxAPI_v.beta.Repositories;

public class StudentsRepository(CalyxDbContext ctx) : BaseRepository<Student>(ctx), IStudentsRepository
{
    public async Task<StudentCourseResponse> GetStudentCourseAsync(int id)
    {
        var student = await _ctx.Students.
            IncludePersonIdentityQuery().
            Include(s => s.Course).
            Include(s => s.ModeNavigation).
            Include(s => s.StatusNavigation).
            SingleDefaultAsync(id);

        return student.ToStudentCourse();
    }
    public async Task<List<StudentCourseResponse>> GetStudentsCourseAsync()
    {
        var students = await _ctx.Students.
            IncludePersonIdentityQuery().
            Include(s => s.Course).
            Include(s => s.ModeNavigation).
            Include(s => s.StatusNavigation).
            Select(s => s.ToStudentCourse(false)).
            ToListAsync();

        return students;
    }
}
