using CalyxAPI_v.beta.Data;
using CalyxAPI_v.beta.DTOS.Students.Mapper;
using CalyxAPI_v.beta.Repositories.Interfaces;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalyxAPI_v.beta.Controllers;

[Route("api/students")]
[ApiController]
public class StudentsController(IStudentsRepository repo) : ControllerBase
{
    private readonly IStudentsRepository _repo = repo;

    [HttpGet("course")]
    public async Task<IActionResult> GetStudentsCourse()
    {
        var students = await _repo.GetStudentsCourseAsync();
        return Ok(students);
    }

    [HttpGet("course/{id}")]
    public async Task<IActionResult> GetStudentCourse([FromRoute] int id)
    {
        var student = await _repo.GetStudentCourseAsync(id);
        return student is null ? NotFound(id) : Ok(student);
    }
}

