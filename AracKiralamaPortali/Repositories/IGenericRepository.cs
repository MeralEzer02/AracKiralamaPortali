namespace CarRentalPortal.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGenericRepository<T> where T : class
    {
        // CRUD (Create, Read, Update, Delete) :
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}