namespace CalyxAPI_v.beta.DTOS.Persons.Response;

public sealed class PersonContactResponse
{
    public string PersonName { get; set; } = string.Empty;
    public string? PersonalNumber { get; set; }
    public string? CellphoneNumber { get; set; }
    public string? PrimaryEmail { get; set; }
    public string? SecondaryEmail { get; set; }
}
