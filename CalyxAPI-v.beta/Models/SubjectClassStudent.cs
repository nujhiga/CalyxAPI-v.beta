namespace CalyxAPI_v.beta.Models;

public partial class SubjectClassStudent
{
    public int ClassId { get; set; }

    public int StudentId { get; set; }

    public string Attendance { get; set; } = null!;

    public virtual SubjectClass Class { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
