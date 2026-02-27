using kipas_Odev.Models;

namespace kipas_Odev.Services
{
    public interface IPersonelService
    {
        Task<List<Personel>> GetAllAsync(string? search);
        Task<Personel?> GetByIdAsync(int id);
        Task AddAsync(Personel personel);
        Task UpdateAsync(Personel personel);
        Task DeleteAsync(int id);
    }
}