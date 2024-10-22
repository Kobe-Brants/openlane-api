using AutoMapper;
using BikeAuctionIntegration.Core.Mapper.DTOs.Bike.Response;
using BikeAuctionIntegration.Domain;

namespace BikeAuctionIntegration.Core.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        MapBike();
    }

    private void MapBike()
    {
        CreateMap<Bike, BikeResponse>();
    }
}