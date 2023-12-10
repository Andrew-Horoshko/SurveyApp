using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly SurveyAppDbContext Context;
    protected readonly DbSet<TEntity> EntitySet;

    public BaseRepository(SurveyAppDbContext context)
    {
        Context = context;
        EntitySet = context.Set<TEntity>();
    }
    public async Task<TEntity?> GetByIdAsync(object ids)
    {
        return await Context.FindAsync<TEntity>(ids);
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        var createdEntry = await Context.AddAsync(entity);
        await Context.SaveChangesAsync();
        return createdEntry.Entity;
    }

    public async Task UpdateAsync(TEntity entity)
    {
        EntitySet.Attach(entity);
        Context.Entry(entity).State = EntityState.Modified;
        await Context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entityToRemove = await Context.FindAsync<TEntity>(id);

        if(entityToRemove != null)
        {
            EntitySet.Remove(entityToRemove);
        }

        await Context.SaveChangesAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await EntitySet.ToListAsync();
    }
}