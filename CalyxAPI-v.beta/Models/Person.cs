using CalyxAPI_v.beta.Models.Base;

namespace CalyxAPI_v.beta.Models;

public interface IPersonReference 
{
    Person Person { get; set; }
}

public partial class Person : BaseModel
{
    //public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string FullName => $"{FirstName}, {LastName}";

    public string? Gender { get; set; }

    public DateOnly BirthDate { get; set; }

    public virtual PersonContact? PersonContact { get; set; }

    public virtual PersonIdentity? PersonIdentity { get; set; }

    public virtual PersonLocation? PersonLocation { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
