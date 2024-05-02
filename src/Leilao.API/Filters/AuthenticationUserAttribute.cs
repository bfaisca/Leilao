﻿using Leilao.API.Repositories;
using Leilao.API.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Leilao.API.Filters;

public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        try
        {

            var util = new Util();

            var token = util.TokenOnRequest(context.HttpContext);

            var reposiory = new LeilaoDbContext();

            var email = util.FromBase64String(token);

            var exist = reposiory.Users.Any(user => user.Email.Equals(email));

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
