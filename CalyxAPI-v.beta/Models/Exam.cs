namespace CalyxAPI_v.beta.Models;

public partial class Exam
{
    public int Id { get; set; }

    public int SubjectId { get; set; }

    public int TeacherId { get; set; }

    public DateOnly Date { get; set; }

    public virtual ExamDetail? ExamDetail { get; set; }

    public virtual Subject Subject { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
