namespace CalyxAPI_v.beta.DTOS.Persons.Response;

public sealed class PersonBasicResponse
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateOnly BirthDate { get; set; }
    public int Age { get; set; }
    public string? Gender { get; set; }
}
