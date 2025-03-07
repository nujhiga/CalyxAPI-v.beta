using CalyxAPI_v.beta.Models.Base;

using System;
using System.Collections.Generic;

namespace CalyxAPI_v.beta.Models;

public partial class Course : BaseModel
{
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public short CourseYear { get; set; }

    public virtual ICollection<Student> Students { get; set; } = [];

    public virtual ICollection<Teacher> Teachers { get; set; } = [];

    public virtual ICollection<Subject> Subjects { get; set; } = [];
}
