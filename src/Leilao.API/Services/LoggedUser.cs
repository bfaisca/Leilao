using Leilao.API.Entities;
using Leilao.API.Repositories;
using Leilao.API.Utils;

namespace Leilao.API.Services;

public class LoggedUser
{
    private readonly IHttpContextAccessor _httpContextAcceor;
    public LoggedUser(IHttpContextAccessor httpContext)
    {
        _httpContextAcceor = httpContext;
    }
    public User User()
    {
        var util = new Util();

        var repository = new LeilaoDbContext();

        var token = util.TokenOnRequest(_httpContextAcceor.HttpContext!);

        var email = util.FromBase64String(token);

        return repository.Users.First(user => user.Email.Equals(email));
    }
}
