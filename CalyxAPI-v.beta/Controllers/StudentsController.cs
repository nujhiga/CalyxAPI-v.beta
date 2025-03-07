using CalyxAPI_v.beta.Data;
using CalyxAPI_v.beta.DTOS.Students.Mapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalyxAPI_v.beta.Controllers;

[Route("api/students")]
[ApiController]
public class StudentsController(CalyxDbContext ctx) : ControllerBase
{
    private readonly CalyxDbContext _ctx = ctx;

    [HttpGet("course")]
    public async Task<IActionResult> GetAllBasicModels()
    {
        var students = await _ctx.Students.
            Include(s => s.Person).
            Include(s => s.Person.PersonIdentity).
            Include(s => s.Person.PersonIdentity!.IdentityType).
            Include(s => s.ModeNavigation).
            Include(s => s.StatusNavigation).
            Include(s => s.Course).
            Select(s => s.ToStudentCourse(true)).
            ToListAsync();

        return Ok(students);
    }

    [HttpGet("course/{id}")]
    public async Task<IActionResult> GetBasicModel([FromRoute] int id)
    {
        var student = await _ctx.Students.
            Include(s => s.Person).
            Include(s => s.Person.PersonIdentity).
            Include(s => s.Person.PersonIdentity!.IdentityType).
            Include(s => s.ModeNavigation).
            Include(s => s.StatusNavigation).
            Include(s => s.Course).
            SingleOrDefaultAsync(s => s.Id == id);

        if (student is null) return NotFound();

        return Ok(student.ToStudentCourse());
    }


}

