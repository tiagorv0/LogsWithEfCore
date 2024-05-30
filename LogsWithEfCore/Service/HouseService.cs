using AutoMapper;
using LogsWithEfCore.Infra;
using LogsWithEfCore.Model;
using LogsWithEfCore.Model.Dto;

namespace LogsWithEfCore.Service;

public class HouseService : IHouseService
{
    private readonly IHouseRepository _houseRepository;
    private readonly IMapper _mapper;

    public HouseService(IHouseRepository houseRepository, IMapper mapper)
    {
        _houseRepository = houseRepository;
        _mapper = mapper;
    }

    public async Task<HouseResponse> AddAsync(HouseRequest request)
    {
        var house = _mapper.Map<House>(request);

        await _houseRepository.AddAsync(house);

        return _mapper.Map<House, HouseResponse>(house);
    }

    public async Task<HouseResponse> UpdateAsync(long id, HouseRequest request)
    {
        var house = await _houseRepository.GetByIdAsync(id);

        if (house == null) 
            throw new Exception("House not found");

        _mapper.Map(request, house);

        var idLoggedUser = 1;
        await _houseRepository.UpdateAndSaveLogsAsync(house, idLoggedUser);

        return _mapper.Map<House, HouseResponse>(house);
    }
}
