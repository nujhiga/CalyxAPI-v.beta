using CalyxAPI_v.beta.Data;
using CalyxAPI_v.beta.Models;
using CalyxAPI_v.beta.Models.Base;
using CalyxAPI_v.beta.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

using System.Linq.Expressions;

namespace CalyxAPI_v.beta.Repositories;

public abstract class BaseRepository<TMDL>(CalyxDbContext ctx) : IBaseRepository<TMDL> where TMDL : class, IBaseModel, new()
{
    protected readonly CalyxDbContext _ctx = ctx;

    public virtual async Task<TMDL> FirstDefault(int id)
    {
        var mdl = await _ctx.Set<TMDL>().FirstOrDefaultAsync(m => m.Id == id);
        return mdl!;
    }

    public virtual async Task<TMDL> SingleDefault(int id)
    {
        var mdl = await _ctx.Set<TMDL>().SingleOrDefaultAsync(m => m.Id == id);
        return mdl!;
    }

    public virtual async Task<TMDL> SingleDefault(Expression<Func<TMDL, bool>> predicate)
    {
        var mdl = await _ctx.Set<TMDL>().SingleOrDefaultAsync(predicate);
        return mdl!;
    }

    public virtual async Task<TMDL> FirstDefault(Expression<Func<TMDL, bool>> predicate)
    {
        var mdl = await _ctx.Set<TMDL>().FirstOrDefaultAsync(predicate);
        return mdl!;
    }
}

public static class RepositoryExtensions
{
    public static async Task<TMDL> SingleDefault<TMDL>(this IQueryable<TMDL> source, int id) where TMDL : class, IBaseModel
    {
        var mdl = await source.SingleOrDefaultAsync(m => m.Id == id);
        return mdl!;
    }

    public static async Task<TMDL> SingleDefault<TMDL>(this IQueryable<TMDL> source, Expression<Func<TMDL, bool>> predicate) where TMDL : class, IBaseModel, new()
    {
        var mdl = await source.SingleOrDefaultAsync(predicate);
        return mdl!;
    }
    public static async Task<TMDL> FirstDefault<TMDL>(this IQueryable<TMDL> source, int id) where TMDL : class, IBaseModel, new()
    {
        var mdl = await source.FirstOrDefaultAsync(m => m.Id == id);
        return mdl!;
    }
    public static async Task<TMDL> FirstDefault<TMDL>(this IQueryable<TMDL> source, Expression<Func<TMDL, bool>> predicate) where TMDL : class, IBaseModel, new()
    {
        var mdl = await source.FirstOrDefaultAsync(predicate);
        return mdl!;
    }
}