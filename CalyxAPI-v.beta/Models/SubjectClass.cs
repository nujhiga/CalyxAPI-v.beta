namespace CalyxAPI_v.beta.Models;

public partial class SubjectClass
{
    public int ClassId { get; set; }

    public int SubjectId { get; set; }

    public int TeacherId { get; set; }

    public DateTime Date { get; set; }

    public virtual Subject Subject { get; set; } = null!;

    public virtual ICollection<SubjectClassStudent> SubjectClassStudents { get; set; } = new List<SubjectClassStudent>();

    public virtual Teacher Teacher { get; set; } = null!;
}
