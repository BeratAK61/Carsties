using AutoMapper;
using Carsties.Contracts;
using Carsties.Search.Models;

namespace Carsties.Search.RequestHelpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AuctionCreated, Item>();
    }
}
