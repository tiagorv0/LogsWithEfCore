using LogsWithEfCore.Model;

namespace LogsWithEfCore.Infra;

public interface IHouseRepository
{
    Task<House> AddAsync(House house);
    Task<House> UpdateAsync(House house);
    Task<House> GetByIdAsync(long id);
    Task<IEnumerable<House>> GetAllAsync();
    Task<House> DeleteAsync(House house);
    Task<House> UpdateAndSaveLogsAsync(House house, long updateByUserId);
}
