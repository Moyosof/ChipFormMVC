using ChipsForm.Data;

namespace ChipsForm.Repository.Implementation
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly AppDbContext _ctx;
        private IGenericRepository<T> __reepository;

        public UnitOfWork(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public IGenericRepository<T> Repository => __reepository ??= new GenericRepository<T>(_ctx);

        public async Task<bool> SaveAsync()
        {
            bool result = false;
            try
            {
                result = await _ctx.SaveChangesAsync() >= 0;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
