using CalyxAPI_v.beta.Data;
using CalyxAPI_v.beta.DTOS.Courses.Mapper;
using CalyxAPI_v.beta.DTOS.Courses.Response;
using CalyxAPI_v.beta.Models;
using CalyxAPI_v.beta.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace CalyxAPI_v.beta.Repositories;

public class CoursesRespository(CalyxDbContext ctx) : BaseRepository<Course>(ctx), ICoursesRepository
{
    public async Task<CourseBasicResponse> GetBasicAsync(int id)
    {
        var course = await SingleDefault(id);
        return course.ToCourseBasic();
    }
    public async Task<List<CourseBasicResponse>> GetBasicsAsync()
    {
        var courses = await _ctx.Courses.
            Select(c => c.ToCourseBasic()).
            ToListAsync();

        return courses;
    }

    public async Task<CourseStudentsResponse> GetStudentAsync(int id)
    {
        var student = await _ctx.Courses.
            Include(c => c.Students).
            ThenInclude(s => s.Person).
            ThenInclude(p => p.PersonIdentity).
            ThenInclude(i => i!.IdentityType).
            SingleDefaultAsync(id);

        return student.ToCourseStudents();
    }
    public async Task<List<CourseStudentsResponse>> GetStudentsAsync()
    {
        var students = await _ctx.Courses.
            Include(c => c.Students).
            ThenInclude(s => s.Person).
            ThenInclude(p => p.PersonIdentity).
            ThenInclude(i => i!.IdentityType).
            Select(c => c.ToCourseStudents()).
            ToListAsync();

        return students;
    }

    public async Task<CourseSubjectsResponse> GetSubjectAsync(int id)
    {
        var subject = await _ctx.Courses.
            Include(c => c.Subjects).
            SingleDefaultAsync(id);

        return subject.ToCourseSubjects();
    }
    public async Task<List<CourseSubjectsResponse>> GetSubjectsAsync()
    {
        var subjects = await _ctx.Courses.
            Include(c => c.Subjects).
            Select(c => c.ToCourseSubjects()).
            ToListAsync();

        return subjects;
    }
}
