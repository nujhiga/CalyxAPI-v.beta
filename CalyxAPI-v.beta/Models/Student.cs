using CalyxAPI_v.beta.Models.Base;

namespace CalyxAPI_v.beta.Models;

public partial class Student : BaseModel, IPersonReference
{
    //public int Id { get; set; }

    public int PersonId { get; set; }

    public int CourseId { get; set; }

    public string Mode { get; set; } = null!;

    public string Status { get; set; } = null!;

    public bool Enabled { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<ExamDetail> ExamDetails { get; set; } = new List<ExamDetail>();

    public virtual StudentsMode ModeNavigation { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;

    public virtual StudentsStatus StatusNavigation { get; set; } = null!;

    public virtual ICollection<SubjectClassStudent> SubjectClassStudents { get; set; } = new List<SubjectClassStudent>();
}
