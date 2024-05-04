using Leilao.API.Contracts;
using Leilao.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Leilao.API.Repositories.DataAcess;

public class AuctionRepository : IAuctionRepository
{
    private readonly AuctionDbContext _leilaoDbContext;

    public AuctionRepository(AuctionDbContext leilaoDbContext) => _leilaoDbContext = leilaoDbContext;

    public Auction? GetCurrent()
    {
        var today = DateTime.Now;

        return _leilaoDbContext
            .Auctions
            .Include(auction => auction.Items)
            .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
    }

}
