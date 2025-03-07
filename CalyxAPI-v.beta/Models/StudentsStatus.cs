namespace CalyxAPI_v.beta.Models;

public partial class StudentsStatus
{
    public string Status { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
