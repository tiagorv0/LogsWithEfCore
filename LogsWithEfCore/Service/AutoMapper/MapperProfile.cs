using AutoMapper;
using LogsWithEfCore.Model;
using LogsWithEfCore.Model.Dto;

namespace LogsWithEfCore.Service.AutoMapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<House, HouseResponse>();
        CreateMap<HouseRequest, House>();
    }
}
