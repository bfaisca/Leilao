using Bogus;
using FluentAssertions;
using Leilao.API.Communication.Requests;
using Leilao.API.Contracts;
using Leilao.API.Entities;
using Leilao.API.Services;
using Leilao.API.UseCases.Auctions.GetCurrent;
using Leilao.API.UseCases.Offers.Createoffer;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Test.Offers.CreateOffer;
public class CreateOfferUseCaseTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void Success(int itemId)
    {
        //Arrange

        var request = new Faker<RequestCreateOfferJson>()
            .RuleFor(request => request.Price, f => f.Random.Decimal(100, 7000)).Generate();

        var offerRepository = new Mock<IOfferRepository>();
        var loggedUser = new Mock<ILoggedUser>();
        loggedUser.Setup(i => i.User()).Returns(new User());

        var useCase = new CreateOfferUseCase(loggedUser.Object,offerRepository.Object);

        //ACt
        var act = () => useCase.Execute(itemId,request);

        //Assert

        act.Should().NotThrow();


    }
}
