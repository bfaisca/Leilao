using Leilao.API.Contracts;
using Leilao.API.Entities;

namespace Leilao.API.Repositories.DataAcess;

public class UserRepository : IUserRepository
{
    private readonly AuctionDbContext _dbContext;

    public UserRepository(AuctionDbContext dbContext) => _dbContext = dbContext;

    public bool ExistUserWithEmail(string email)
    {
        return _dbContext.Users.Any(user => user.Email.Equals(email));
    }

    public User GetUserByEmail(string email)
    {
        return _dbContext.Users.First(user => user.Email.Equals(email));
    }
}
