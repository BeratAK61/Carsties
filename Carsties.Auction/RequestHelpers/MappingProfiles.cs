using AutoMapper;
using Carsties.Auction.DTOs;
using Carsties.Auction.Entities;

namespace Carsties.Auction.RequestHelpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Carsties.Auction.Entities.Auction, AuctionDto>().IncludeMembers(x => x.Item);

        CreateMap<Item, AuctionDto>();

        CreateMap<CreateAuctionDto, Carsties.Auction.Entities.Auction>()
            .ForMember(d => d.Item, o => o.MapFrom(s => s));

        CreateMap<CreateAuctionDto, Item>();
    }
}
