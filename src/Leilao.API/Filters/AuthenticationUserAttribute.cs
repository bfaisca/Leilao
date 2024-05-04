using Leilao.API.Contracts;
using Leilao.API.Repositories;
using Leilao.API.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Leilao.API.Filters;

public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    public IUserRepository _repository;

    public AuthenticationUserAttribute(IUserRepository repository) => _repository = repository;
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        try
        {
            var util = new Util();

            var token = util.TokenOnRequest(context.HttpContext);

            var email = util.FromBase64String(token);

            var exist = _repository.ExistUserWithEmail(email);

            if (exist == false)
            {
                context.Result = new UnauthorizedObjectResult("E-mail not Valid");
            }

        }
        catch (Exception ex)
        {
            context.Result = new UnauthorizedObjectResult(ex.Message);
        }
    }
}
