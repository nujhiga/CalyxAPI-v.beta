using CalyxAPI_v.beta.Data;
using CalyxAPI_v.beta.DTOS.Subjects.Mapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalyxAPI_v.beta.Controllers;

[Route("api/subjects")]
[ApiController]
public class SubjectsController(CalyxDbContext ctx) : ControllerBase
{
    private readonly CalyxDbContext _ctx = ctx;

    [HttpGet("basic")]
    public async Task<IActionResult> GetBasicModels()
    {
        var subjects = await _ctx.Subjects.
            Select(s => s.ToSubjectBasic()).
            ToListAsync();

        return Ok(subjects);
    }

    [HttpGet("basic/{id}")]
    public async Task<IActionResult> GetBasicModel([FromRoute] int id)
    {
        var subject = await _ctx.Subjects.
            SingleOrDefaultAsync(s => s.SubjectId == id);
        
        if (subject is null) return NotFound();
     
        return Ok(subject.ToSubjectBasic());
    }

    [HttpGet("course")]
    public async Task<IActionResult> GetAllCourseSubjects()
    {
        var subjects = await _ctx.Subjects.
            Include(s => s.Courses).
            Select(s => s.ToSubjectCourses()).
            ToListAsync();

        return Ok(subjects);
    }

    [HttpGet("course/{id}")]
    public async Task<IActionResult> GetCourseSubjects([FromRoute] int id)
    {
        var subject = await _ctx.Subjects.
            Include(s => s.Courses).
            SingleOrDefaultAsync(s => s.SubjectId == id);
        if (subject is null) return NotFound();
        return Ok(subject.ToSubjectCourses());
    }

}
