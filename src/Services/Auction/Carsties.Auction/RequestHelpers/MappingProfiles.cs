using AutoMapper;
using Carsties.Auction.DTOs;
using Carsties.Auction.Entities;
using Carsties.Contracts;

namespace Carsties.Auction.RequestHelpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Entities.Auction, AuctionDto>().IncludeMembers(x => x.Item);

        CreateMap<Item, AuctionDto>();

        CreateMap<CreateAuctionDto, Entities.Auction>()
            .ForMember(d => d.Item, o => o.MapFrom(s => s));

        CreateMap<CreateAuctionDto, Item>();

        CreateMap<AuctionDto, AuctionCreated>();

        CreateMap<CreateAuctionDto, AuctionDto>();

        CreateMap<Entities.Auction, AuctionUpdated>().IncludeMembers(a => a.Item);

        CreateMap<Item, AuctionUpdated>();
    }
}
