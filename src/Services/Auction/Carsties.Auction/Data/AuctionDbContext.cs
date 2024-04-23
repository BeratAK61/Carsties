using Carsties.Auction.Entities;
using Microsoft.EntityFrameworkCore;

namespace Carsties.Auction.Data;

public class AuctionDbContext : DbContext
{
    public AuctionDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Carsties.Auction.Entities.Auction> Auctions { get; set; }

    //public DbSet<Item> Items { get; set; }


}
