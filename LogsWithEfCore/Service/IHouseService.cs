using LogsWithEfCore.Model.Dto;

namespace LogsWithEfCore.Service;

public interface IHouseService
{
    Task<HouseResponse> AddAsync(HouseRequest request);
    Task<HouseResponse> UpdateAsync(long id, HouseRequest request);
}
