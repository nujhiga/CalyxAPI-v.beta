namespace CalyxAPI_v.beta.Repositories.Interfaces;

public interface IBaseRepository<TMDL> where TMDL : class, new()
{
    Task<TMDL> SingleDefault(int id);
    Task<TMDL> FirstDefault(int id);


}
