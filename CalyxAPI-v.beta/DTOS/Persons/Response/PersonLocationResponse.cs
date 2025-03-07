namespace CalyxAPI_v.beta.DTOS.Persons.Response;

public class PersonLocationResponse
{
    public string PersonName { get; set; } = string.Empty;
    public int? CountryId { get; set; }
    public int? StateId { get; set; }
    public int? CityId { get; set; }
    public string? Address { get; set; }
    public short Number { get; set; }
    public string? PostalCode { get; set; }
}
