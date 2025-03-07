using System;
using System.Collections.Generic;

namespace CalyxAPI_v.beta.Models;

public partial class PersonLocation
{
    public int PersonId { get; set; }

    public int? CountryId { get; set; }

    public int? EstateId { get; set; }

    public int? CityId { get; set; }

    public string? Address { get; set; }

    public short? Number { get; set; }

    public string? PostalCode { get; set; }

    public virtual Person Person { get; set; } = null!;
}
