namespace CalyxAPI_v.beta.Models.Base;

public interface IBaseModel
{
    int Id { get; set; }
}

public abstract class BaseModel : IBaseModel
{
    public int Id { get; set; }
}
