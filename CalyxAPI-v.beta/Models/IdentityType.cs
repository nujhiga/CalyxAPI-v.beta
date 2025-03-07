using System;
using System.Collections.Generic;

namespace CalyxAPI_v.beta.Models;

public partial class IdentityType
{
    public int IdentityTypeId { get; set; }

    public string ShortDescription { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<PersonIdentity> PersonIdentities { get; set; } = new List<PersonIdentity>();
}
