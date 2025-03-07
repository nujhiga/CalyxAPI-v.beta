namespace CalyxAPI_v.beta.Models;

public partial class PersonContact
{
    public int PersonId { get; set; }

    public string? PersonalNumber { get; set; }

    public string? CellphoneNumber { get; set; }

    public string? PrimaryEmail { get; set; }

    public string? SecondaryEmail { get; set; }

    public virtual Person Person { get; set; } = null!;
}
