using CalyxAPI_v.beta.Data;
using CalyxAPI_v.beta.DTOS.Courses.Mapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalyxAPITest.Controllers;

[Route("api/courses")]
[ApiController]
public class CoursesController(CalyxDbContext ctx) : ControllerBase
{
    private readonly CalyxDbContext _ctx = ctx;

    [HttpGet("basic")]
    public async Task<IActionResult> GetBasicModels()
    {
        var courses = await _ctx.Courses.
            Select(c => c.ToCourseBasic()).
            ToListAsync();

        return Ok(courses);
    }

    [HttpGet("basic/{id}")]
    public async Task<IActionResult> GetBasicModel([FromRoute] int id)
    {
        var course = await _ctx.Courses.
            SingleOrDefaultAsync(c => c.Id == id);

        if (course is null) return NotFound();
        
        return Ok(course.ToCourseBasic());
    }

    [HttpGet("student")]
    public async Task<IActionResult> GetAllCourseStudents()
    {
        var courses = await _ctx.Courses.
            Include(c => c.Students).            
            ThenInclude(s => s.Person).
            ThenInclude(p => p.PersonIdentity).
            ThenInclude(i => i!.IdentityType).
            ToListAsync();

        return Ok(courses.ToCourseStudents());
    }

    [HttpGet("student/{id}")]
    public async Task<IActionResult> GetCourseStudents([FromRoute] int id)
    {
        var course = await _ctx.Courses.
            Include(c => c.Students).
            ThenInclude(s => s.Person).
            ThenInclude(p => p.PersonIdentity).
            ThenInclude(i => i.IdentityType).  
            SingleOrDefaultAsync(c => c.Id == id);

        if (course is null) return NotFound();

        return Ok(course.ToCourseStudents());
    }

    [HttpGet("subjects")]
    public async Task<IActionResult> GetAllCourseSubjects()
    {
        var courses = await _ctx.Courses.
            Include(c => c.Subjects).
            ToListAsync();

        return Ok(courses.ToCourseSubjects());
    }

    [HttpGet("subjects/{id}")]
    public async Task<IActionResult> GetCourseSubjects([FromRoute] int id)
    {
        var course = await _ctx.Courses.
            Include(c => c.Subjects).
            SingleOrDefaultAsync(c => c.Id == id);

        if (course is null) return NotFound();

        return Ok(course.ToCourseSubjects());
    }
}
