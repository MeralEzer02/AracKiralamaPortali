using CarRentalPortal.Repositories;
using CarRentalPortal.Data;
using CarRentalPortal.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalPortal.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly CarRentalDbContext _context;

        public GenericRepository(CarRentalDbContext context)
        {
            _context = context;
        }

        // CREATE :
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            // Saves changes to the database.
            await _context.SaveChangesAsync();
        }

        // DELETE :
        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        // READ ALL :
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        // READ BY ID :
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        // UPDATE :
        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}