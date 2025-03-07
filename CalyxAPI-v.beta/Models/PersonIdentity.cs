using System;
using System.Collections.Generic;

namespace CalyxAPI_v.beta.Models;

public partial class PersonIdentity
{
    public int PersonId { get; set; }

    public int IdentityTypeId { get; set; }

    public string IdentityNumber { get; set; } = null!;

    public virtual IdentityType IdentityType { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;
}
