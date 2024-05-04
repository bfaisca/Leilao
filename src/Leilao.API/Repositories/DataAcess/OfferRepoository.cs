using Leilao.API.Contracts;
using Leilao.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Leilao.API.Repositories.DataAcess;

public class OfferRepoository : IOfferRepository
{
    private readonly AuctionDbContext _dbContext;

    public OfferRepoository(AuctionDbContext dbContext) => _dbContext = dbContext;

    public void Add(Offer offer)
    {
        _dbContext.Offers.Add(offer);

        _dbContext.SaveChanges();
    }
}
