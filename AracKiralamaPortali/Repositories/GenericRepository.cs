using AracKiralamaPortali.Data; 
using AracKiralamaPortali.Repositories; 
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AracKiralamaPortali.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AracKiralamaDbContext _context;

        public GenericRepository(AracKiralamaDbContext context)
        {
            _context = context;
        }

        // EKLEME İŞLEMİ :
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);

            await _context.SaveChangesAsync();
        }

        // SİLME İŞLEMİ :
        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity); 
            await _context.SaveChangesAsync(); 
        }

        // TÜMÜNÜ GETİRME İŞLEMİ :
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        // ID İLE TEK KAYIT GETİRME İŞLEMİ :
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        // GÜNCELLEME İŞLEMİ :
        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(); 
        }
    }
}