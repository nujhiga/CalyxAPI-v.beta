using CalyxAPI_v.beta.DTOS.Persons.Response;
using CalyxAPI_v.beta.Models;

namespace CalyxAPI_v.beta.DTOS.Persons.Mapper;

public static class PersonsMapper
{
    private static readonly int _nowYear = DateTime.Now.Year;

    public static PersonBasicResponse ToPersonBasic(this Person person)
    {
        return new PersonBasicResponse
        {
            FirstName = person.FirstName,
            LastName = person.LastName,
            BirthDate = person.BirthDate,
            Gender = person.Gender,
            Age = _nowYear - person.BirthDate.Year
        };
    }
    public static PersonContactResponse ToPersonContact(this Person person)
    {
        if (person is null) return null!;

        return new PersonContactResponse
        {
            PersonName = person.FullName,
            PersonalNumber = person.PersonContact?.PersonalNumber ?? string.Empty,
            CellphoneNumber = person.PersonContact?.CellphoneNumber ?? string.Empty,
            PrimaryEmail = person.PersonContact?.PrimaryEmail ?? string.Empty,
            SecondaryEmail = person.PersonContact?.SecondaryEmail ?? string.Empty,
        };
    }
    public static PersonIdentityResponse ToPersonIdentity(this Person person)
    {
        if (person is null) return null!;

        var pidentity = person.PersonIdentity;

        return new PersonIdentityResponse
        {
            PersonName = person.FullName,
            Identity = person.GetIdentity()
        };
    }
    public static PersonLocationResponse ToPersonLocation(this Person person)
    {
        if (person is null) return null!;
        var plocation = person.PersonLocation;

        return new PersonLocationResponse
        {
            PersonName = person.FullName,
            CountryId = plocation?.CountryId ?? 0,
            StateId = plocation?.EstateId ?? 0,
            CityId = plocation?.CityId ?? 0,
            Address = plocation?.Address ?? string.Empty,
            Number = plocation?.Number ?? 0,
            PostalCode = plocation?.PostalCode ?? string.Empty,
        };
    }
    public static string GetIdentity(this Person person)
    {
        var pidentity = person.PersonIdentity;
        var identity = $"{pidentity?.IdentityType.ShortDescription ?? string.Empty} {pidentity?.IdentityNumber ?? string.Empty}";
        return identity;
    }
    public static string GetFullNameIdentity(this Person person)
    {
        var pidentity = person.PersonIdentity;
        var identity = $"{pidentity?.IdentityType.ShortDescription ?? string.Empty} {pidentity?.IdentityNumber ?? string.Empty}";
        return $"{person.FullName} ({identity})";
    }
}
