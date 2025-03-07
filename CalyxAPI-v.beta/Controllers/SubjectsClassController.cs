namespace CalyxAPI_v.beta.Controllers;

using CalyxAPI_v.beta.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/subject_class")]
[ApiController]
public class SubjectsClassController(CalyxDbContext ctx) : ControllerBase
{
    private readonly CalyxDbContext _ctx = ctx;

    [HttpGet("basic")]
    public async Task<IActionResult> GetBasicModels()
    {
        var subjects = await _ctx.SubjectClasses.
            Include(s => s.Teacher).
            ThenInclude(s => s.Person).ThenInclude(s => s.PersonIdentity).ThenInclude(s => s.IdentityType).
            Include(s => s.Subject).
            Include(s => s.SubjectClassStudents).
            ThenInclude(s => s.Student).
            ThenInclude(s => s.Person).ThenInclude(s => s.PersonIdentity).ThenInclude(s => s.IdentityType).
            //Select(s => s.ToSubjectClass()).
            ToListAsync();  

        return Ok(subjects);
    }
}

