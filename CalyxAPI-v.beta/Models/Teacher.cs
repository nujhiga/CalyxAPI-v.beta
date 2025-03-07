using CalyxAPI_v.beta.Models.Base;

namespace CalyxAPI_v.beta.Models;

public partial class Teacher : BaseModel, IPersonReference
{
    //public int Id { get; set; }

    public int PersonId { get; set; }

    public int CourseId { get; set; }

    public bool Enabled { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    public virtual Person Person { get; set; } = null!;

    public virtual ICollection<SubjectClass> SubjectClasses { get; set; } = new List<SubjectClass>();
}
