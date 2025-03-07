using CalyxAPI_v.beta.Data;
using CalyxAPI_v.beta.DTOS.Teachers.Mapper;
using CalyxAPI_v.beta.DTOS.Teachers.Response;
using CalyxAPI_v.beta.Models;
using CalyxAPI_v.beta.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace CalyxAPI_v.beta.Repositories;

public class TeacherRepository(CalyxDbContext ctx) : BaseRepository<Teacher>(ctx), ITeachersRepository
{
    public async Task<TeacherBasicResponse> GetBasicAsync(int id)
    {
        var teacher = await _ctx.Teachers.
            IncludePersonIdentityQuery().
            SingleDefaultAsync(id);

        return teacher.ToTeacherBasic();
    }
    public async Task<List<TeacherBasicResponse>> GetBasicsAsync()
    {
        var teachers = await _ctx.Teachers.
            IncludePersonIdentityQuery().
            Select(t => t.ToTeacherBasic()).
            ToListAsync();

        return teachers;
    }

    public async Task<TeacherCourseResponse> GetTeacherCourseAsync(int id)
    {
        var teacher = await _ctx.Teachers.
            IncludePersonIdentityQuery().
            Include(t => t.Course).
            SingleDefaultAsync(id);

        return teacher.ToTeacherCourse();
    }
    public async Task<List<TeacherCourseResponse>> GetTeachersCourseAsync()
    {
        var teachers = await _ctx.Teachers.
            IncludePersonIdentityQuery().
            Include(t => t.Course).
            Select(t => t.ToTeacherCourse()).
            ToListAsync();
        return teachers;
    }
}
