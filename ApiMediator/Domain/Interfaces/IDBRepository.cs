
namespace ApiMediator.Domain.Interfaces
{
    public interface IDBRepository<T> where T : class
    {
        public Task<T> CreateAsync(T T);
        public Task<List<T>> GetAllAsync();
        public Task<T> GetByIdAsync(string id);
        public Task<T> UpdateAsync(string id, T TIn);
        public Task RemoveAsync(string id);
    }
}