using CalyxAPI_v.beta.Data;
using CalyxAPI_v.beta.DTOS.Persons.Mapper;
using CalyxAPI_v.beta.Models;
using CalyxAPI_v.beta.Repositories;
using CalyxAPI_v.beta.Repositories.Interfaces;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalyxAPI_v.beta.Controllers;

[Route("api/persons")]
[ApiController]
public class PersonsController(IPersonRepository repo) : ControllerBase
{
    private readonly IPersonRepository _repo = repo;

    [HttpGet("basic")]
    public async Task<IActionResult> GetPersonsBasic()
    {
        var persons = await _repo.GetBasicsAsync();
        return Ok(persons);
    }

    [HttpGet("basic/{id}")]
    public async Task<IActionResult> GetPersonBasic([FromRoute] int id)
    {
        var person = await _repo.GetBasicAsync(id);
        return person is null ? NotFound(id) : Ok(person);
    }

    [HttpGet("contact")]
    public async Task<IActionResult> GetPersonsContact()
    {
        var persons = await _repo.GetContactsAsync();
        return Ok(persons);
    }

    [HttpGet("contact/{id}")]
    public async Task<IActionResult> GetPersonContact([FromRoute] int id)
    {
        var person = await _repo.GetContactAsync(id);
        return person is null ? NotFound() : Ok(person);
    }

    [HttpGet("identity")]
    public async Task<IActionResult> GetPersonsIdentity()
    {
        var persons = await _repo.GetIdentitiesAsync();
        return Ok(persons);
    }

    [HttpGet("identity/{id}")]
    public async Task<IActionResult> GetPersonIdentity([FromRoute] int id)
    {
        var person = await _repo.GetIdentityAsync(id);
        return person is null ? NotFound() : Ok(person);
    }

    [HttpGet("location")]
    public async Task<IActionResult> GetPersonsLocation()
    {
        var persons = await _repo.GetLocationsAsync();
        return Ok(persons);
    }

    [HttpGet("location/{id}")]
    public async Task<IActionResult> GetPersonLocation([FromRoute] int id)
    {
        var person = await _repo.GetLocationAsync(id);
        return person is null ? NotFound() : Ok(person);
    }
}
