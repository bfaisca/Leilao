using Leilao.API.Communication.Requests;
using Leilao.API.Contracts;
using Leilao.API.Entities;
using Leilao.API.Repositories;
using Leilao.API.Services;

namespace Leilao.API.UseCases.Offers.Createoffer;

public class CreateOfferUseCase
{
    private readonly ILoggedUser _loggedUser;
    public readonly IOfferRepository _repository;
    public CreateOfferUseCase(ILoggedUser loggedUser, IOfferRepository repository)
    {
        _loggedUser = loggedUser;
        _repository = repository;
    }
    public int Execute(int itemId, RequestCreateOfferJson request)
    {
        var user = _loggedUser.User();

        var offer = new Offer
        {
            CreatedOn = DateTime.Now,
            ItemId = itemId,
            Price = request.Price,
            UserId = user.Id
        };

        _repository.Add(offer);


        return offer.Id;

    }
}
