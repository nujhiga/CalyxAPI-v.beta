using CalyxAPI_v.beta.DTOS.Persons.Response;
using CalyxAPI_v.beta.Models;

namespace CalyxAPI_v.beta.Repositories.Interfaces;

public interface IPersonRepository : IBaseRepository<Person>
{
    Task<List<PersonBasicResponse>> GetBasicsAsync();
    Task<PersonBasicResponse> GetBasicAsync(int id);

    Task<List<PersonContactResponse>> GetContactsAsync();
    Task<PersonContactResponse> GetContactAsync(int id);

    Task<List<PersonIdentityResponse>> GetIdentitiesAsync();
    Task<PersonIdentityResponse> GetIdentityAsync(int id);

    Task<List<PersonLocationResponse>> GetLocationsAsync();
    Task<PersonLocationResponse> GetLocationAsync(int id);
}
