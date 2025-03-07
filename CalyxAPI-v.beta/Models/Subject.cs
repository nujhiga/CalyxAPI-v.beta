using System;
using System.Collections.Generic;

namespace CalyxAPI_v.beta.Models;

public partial class Subject
{
    public int SubjectId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    public virtual ICollection<SubjectClass> SubjectClasses { get; set; } = new List<SubjectClass>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
