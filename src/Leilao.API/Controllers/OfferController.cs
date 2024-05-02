using Leilao.API.Communication.Requests;
using Leilao.API.Filters;
using Leilao.API.UseCases.Offers.Createoffer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Leilao.API.Controllers;

[ServiceFilter(typeof(AuthenticationUserAttribute))]
public class OfferController : LeilaoBaseController
{
    [HttpPost]
    [Route("{Itemid}")]

    public IActionResult CreateOffer([FromRoute]int itemid, [FromBody] RequestCreateOfferJson request, [FromServices] CreateOfferUseCase useCase)
    {
        var id = useCase.Execute(itemid, request);
        return Created(string.Empty,id);
    }
}
