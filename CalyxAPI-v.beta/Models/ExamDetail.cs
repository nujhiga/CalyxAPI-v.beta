namespace CalyxAPI_v.beta.Models;

public partial class ExamDetail
{
    public int ExamId { get; set; }

    public int StudentId { get; set; }

    public decimal Grade { get; set; }

    public string Attendance { get; set; } = null!;

    public virtual Exam Exam { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
