using Leilao.API.Contracts;
using Leilao.API.Entities;
using Leilao.API.Repositories;
using Leilao.API.Utils;

namespace Leilao.API.Services;

public class LoggedUser : ILoggedUser
{
    private readonly IHttpContextAccessor _httpContextAcceor;
    private readonly IUserRepository _repository;
    public LoggedUser(IHttpContextAccessor httpContext, IUserRepository repository)
    {
        _httpContextAcceor = httpContext;
        _repository = repository;
    }
    public User User()
    {
        var util = new Util();

        var token = util.TokenOnRequest(_httpContextAcceor.HttpContext!);

        var email = util.FromBase64String(token);

        return _repository.GetUserByEmail(email);
    }
}
