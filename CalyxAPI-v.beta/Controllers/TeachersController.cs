using CalyxAPI_v.beta.Data;
using CalyxAPI_v.beta.DTOS.Teachers.Mapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalyxAPI_v.beta.Controllers;

[Route("api/teachers")]
[ApiController]
public class TeachersController(CalyxDbContext ctx) : ControllerBase
{
    private readonly CalyxDbContext _ctx = ctx;

    [HttpGet("basic")]
    public async Task<IActionResult> GetBasicModels()
    {
        var teachers = await _ctx.Teachers.
            Include(t => t.Person).
            Include(t => t.Person.PersonIdentity).
            Include(t => t.Person.PersonIdentity!.IdentityType).
            Select(t => t.ToTeacherBasic()).
            ToListAsync();

        return Ok(teachers);
    }

    [HttpGet("basic/{id}")]
    public async Task<IActionResult> GetBasicModel([FromRoute] int id)
    {
        var teacher = await _ctx.Teachers.
            Include(t => t.Person).
            Include(t => t.Person.PersonIdentity).
            Include(t => t.Person.PersonIdentity!.IdentityType).
            SingleOrDefaultAsync(t => t.Id == id);

        if (teacher is null) return NotFound();

        return Ok(teacher.ToTeacherBasic());
    }

    [HttpGet("course")]
    public async Task<IActionResult> GetAllCourseTeachers()
    {
        var teachers = await _ctx.Teachers.
            Include(t => t.Person).
            Include(t => t.Person.PersonIdentity).
            Include(t => t.Person.PersonIdentity!.IdentityType).
            Include(t => t.Course).
            Select(t => t.ToTeacherCourse()).
            ToListAsync();
        
        return Ok(teachers);
    }

    [HttpGet("course/{id}")]
    public async Task<IActionResult> GetCourseTeachers([FromRoute] int id)
    {
        var teacher = await _ctx.Teachers.
            Include(t => t.Person).
            Include(t => t.Person.PersonIdentity).
            Include(t => t.Person.PersonIdentity!.IdentityType).
            Include(t => t.Course).
            SingleOrDefaultAsync(t => t.Id == id);

        if (teacher is null) return NotFound();
        
        return Ok(teacher.ToTeacherCourse());
    }

}
