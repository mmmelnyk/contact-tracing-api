using Moq;
using MediatR;
using Presentation.Requests;
using Services.Handlers;
using Domain.Repositories;
using Domain.Entities;

namespace ContactTracingAPI.Tests;

public class UserTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task CreateUserRequest_UserCreatedInDbAsync()
    {
        // Arrange
        var mediator = new  Mock<IMediator>();
        var userRepoMoq = new Mock<IUserRepository>();
        var request = new CreateUserRequest
        {
            DeviceId = "someDeviceId",
            LastLogin = DateTime.Now.ToString()
        };
        var handler = new CreateUserRequestHandler(userRepoMoq.Object);

        // Act
        var response = await handler.Handle(request, new System.Threading.CancellationToken());
        
        // Assert
        userRepoMoq.Verify(x => x.InsertAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()));
    }
}