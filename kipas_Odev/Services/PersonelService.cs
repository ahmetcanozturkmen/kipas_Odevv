using kipas_Odev.Data;
using kipas_Odev.Models;
using Microsoft.EntityFrameworkCore;

namespace kipas_Odev.Services
{
    public class PersonelService : IPersonelService
    {
        private readonly AppDbContext _context;

        public PersonelService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Personel>> GetAllAsync(string? search)
        {
            var query = _context.Personels.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim().ToLower();

                query = query.Where(p =>
                    (p.FirstName + " " + p.LastName).ToLower().Contains(search) ||
                    p.FirstName.ToLower().Contains(search) ||
                    p.LastName.ToLower().Contains(search)
                );
            }

            return await query.ToListAsync();
        }

        public async Task<Personel?> GetByIdAsync(int id)
        {
            return await _context.Personels.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Personel personel)
        {
            _context.Personels.Add(personel);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Personel personel)
        {
            _context.Personels.Update(personel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Personels.FindAsync(id);
            if (entity != null)
            {
                _context.Personels.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}