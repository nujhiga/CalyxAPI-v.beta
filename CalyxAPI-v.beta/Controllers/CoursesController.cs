using CalyxAPI_v.beta.Data;
using CalyxAPI_v.beta.DTOS.Courses.Mapper;
using CalyxAPI_v.beta.Repositories.Interfaces;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalyxAPITest.Controllers;

[Route("api/courses")]
[ApiController]
public class CoursesController(ICoursesRepository repo) : ControllerBase
{
    private readonly ICoursesRepository _repo = repo;

    [HttpGet("basic")]
    public async Task<IActionResult> GetBasicModels()
    {
        var courses = await _repo.GetBasicsAsync();
        return Ok(courses);
    }

    [HttpGet("basic/{id}")]
    public async Task<IActionResult> GetBasicModel([FromRoute] int id)
    {
        var course = await _repo.GetBasicAsync(id);
        return course is null ? NotFound(id) : Ok(course);
    }

    [HttpGet("student")]
    public async Task<IActionResult> GetAllCourseStudents()
    {
        var courses = await _repo.GetStudentsAsync();
        return Ok(courses);
    }

    [HttpGet("student/{id}")]
    public async Task<IActionResult> GetCourseStudents([FromRoute] int id)
    {
        var course = await _repo.GetStudentAsync(id);
        return course is null ? NotFound(id) : Ok(course);
    }

    [HttpGet("subjects")]
    public async Task<IActionResult> GetAllCourseSubjects()
    {
        var courses = await _repo.GetSubjectsAsync();
        return Ok(courses);
    }

    [HttpGet("subjects/{id}")]
    public async Task<IActionResult> GetCourseSubjects([FromRoute] int id)
    {
        var course = await _repo.GetSubjectAsync(id);
        return course is null ? NotFound(id) : Ok(course);
    }
}
