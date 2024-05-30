using LogsWithEfCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LogsWithEfCore.Infra;

public class HouseRepository : IHouseRepository
{
    private readonly ApplicationContext _context;

    public HouseRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<House> AddAsync(House house)
    {
        await _context.Houses.AddAsync(house);
        await _context.SaveChangesAsync();
        return house;
    }

    public async Task<House> DeleteAsync(House house)
    {
        _context.Houses.Remove(house);
        await _context.SaveChangesAsync();
        return house;
    }

    public async Task<IEnumerable<House>> GetAllAsync()
    {
        return await _context.Houses.ToListAsync();
    }

    public async Task<House> GetByIdAsync(long id)
    {
        return await _context.Houses.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<House> UpdateAsync(House house)
    {
        _context.Houses.Update(house);
        await _context.SaveChangesAsync();
        return house;
    }

    public async Task<House> UpdateAndSaveLogsAsync(House house, long updateByUserId)
    {
        _context.Houses.Update(house);
        await _context.GetAndSaveUpdateLogs<House>(updateByUserId);
        await _context.SaveChangesAsync();
        return house;
    }
}
