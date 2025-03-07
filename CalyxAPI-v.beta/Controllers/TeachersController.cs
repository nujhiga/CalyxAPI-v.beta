using CalyxAPI_v.beta.Data;
using CalyxAPI_v.beta.DTOS.Teachers.Mapper;
using CalyxAPI_v.beta.Repositories.Interfaces;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalyxAPI_v.beta.Controllers;

[Route("api/teachers")]
[ApiController]
public class TeachersController(ITeachersRepository repo) : ControllerBase
{
    private readonly ITeachersRepository _repo = repo;

    [HttpGet("basic")]
    public async Task<IActionResult> GetBasicModels()
    {
        var teachers = await _repo.GetBasicsAsync();
        return Ok(teachers);
    }

    [HttpGet("basic/{id}")]
    public async Task<IActionResult> GetBasicModel([FromRoute] int id)
    {
        var teacher = await _repo.GetBasicAsync(id);
        return teacher is null ? NotFound(id) : Ok(teacher);
    }

    [HttpGet("course")]
    public async Task<IActionResult> GetAllCourseTeachers()
    {
        var teachers = await _repo.GetTeachersCourseAsync();
        return Ok(teachers);
    }

    [HttpGet("course/{id}")]
    public async Task<IActionResult> GetCourseTeachers([FromRoute] int id)
    {
        var teacher = await _repo.GetTeacherCourseAsync(id);
        return teacher is null ? NotFound(id) : Ok(teacher);
    }

}
