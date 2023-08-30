using ChipsForm.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ChipsForm.Repository.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _ctx;
        private DbSet<T> table;

        public GenericRepository(AppDbContext ctx)
        {
            _ctx = ctx;
            table = _ctx.Set<T>();
        }

        public async Task Add(T entity)
        {
            //await CreateSavePointAsync("New Afiari Save Point");
            await table.AddAsync(entity);
        }

        public async Task AddRange(IList<T> entity)
        {
            //await CreateSavePointAsync("New Afiari Save Point");
            await table.AddRangeAsync(entity);
        }

        public async Task Delete(Guid EntityId)
        {
            var entity = await ReadSingle(EntityId);
            table.Remove(entity);
        }

        public void DeleteEntity(T Entity)
        {
            table.Remove(Entity);
        }

        public void DeleteRange(IList<T> entity)
        {
            table.RemoveRange(entity);
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await table.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> ReadAll()
        {
            return await table.ToListAsync();
        }

        public IQueryable<T> ReadAllQuery()
        {
            return table.AsQueryable();
        }

        public async Task<T> ReadSingle(Guid EntityId)
        {
            return await table.FindAsync(EntityId);
        }

        public void Update(T Entity)
        {
            //table.Update(Entity);
            table.Attach(Entity);
            _ctx.Entry(Entity).State = EntityState.Modified;
        }

        public void UpdateRange(IList<T> entities)
        {
            table.UpdateRange(entities);
        }
    }
}
