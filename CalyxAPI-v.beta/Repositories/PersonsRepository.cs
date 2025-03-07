using CalyxAPI_v.beta.Data;
using CalyxAPI_v.beta.DTOS.Persons.Mapper;
using CalyxAPI_v.beta.DTOS.Persons.Response;
using CalyxAPI_v.beta.Models;
using CalyxAPI_v.beta.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace CalyxAPI_v.beta.Repositories;



public sealed class PersonsRepository(CalyxDbContext ctx) : BaseRepository<Person>(ctx), IPersonRepository
{
    public async Task<List<PersonBasicResponse>> GetBasicsAsync()
    {
        var persons = await _ctx.Persons.
            Select(p => p.ToPersonBasic()).
            ToListAsync();

        return persons;
    }
    public async Task<PersonBasicResponse> GetBasicAsync(int id)
    {
        var person = await SingleDefault(id);
        return person.ToPersonBasic();
    }

    public async Task<List<PersonContactResponse>> GetContactsAsync()
    {
        var persons = await _ctx.Persons.
            Include(p => p.PersonContact).
            Select(p => p.ToPersonContact()).
            ToListAsync();

        return persons;
    }
    public async Task<PersonContactResponse> GetContactAsync(int id)
    {
        var person = await _ctx.Persons.
            Include(p => p.PersonContact).
            SingleDefault(id);

        return person!.ToPersonContact();
    }

    public async Task<List<PersonIdentityResponse>> GetIdentitiesAsync()
    {
        var persons = await _ctx.Persons.
            Include(p => p.PersonIdentity).
            Select(p => p.ToPersonIdentity()).
            ToListAsync();

        return persons;
    }
    public async Task<PersonIdentityResponse> GetIdentityAsync(int id)
    {
        var person = await _ctx.Persons.
            Include(p => p.PersonIdentity).
            Include(p => p.PersonIdentity!.IdentityType).
            SingleDefault(id);

        return person!.ToPersonIdentity();
    }

    public async Task<List<PersonLocationResponse>> GetLocationsAsync()
    {
        var persons = await _ctx.Persons.
            Include(p => p.PersonLocation).
            Select(p => p.ToPersonLocation()).
            ToListAsync();

        return persons;
    }
    public async Task<PersonLocationResponse> GetLocationAsync(int id)
    {
        var person = await _ctx.Persons.
            Include(p => p.PersonLocation).
            SingleDefault(id);

        return person!.ToPersonLocation();
    }
}
