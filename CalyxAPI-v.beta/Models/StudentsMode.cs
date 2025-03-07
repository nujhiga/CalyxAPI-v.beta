using System;
using System.Collections.Generic;

namespace CalyxAPI_v.beta.Models;

public partial class StudentsMode
{
    public string Mode { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
