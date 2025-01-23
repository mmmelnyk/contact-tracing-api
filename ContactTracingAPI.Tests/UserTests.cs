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
        };
        var handler = new CreateUserRequestHandler(userRepoMoq.Object);

        // Act
        var response = await handler.Handle(request, new CancellationToken());
        
        // Assert
        userRepoMoq.Verify(x => x.InsertAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()));
    }

    [Test]
    public async Task DeleteUserRequest_UserDeletedInDbAsync()
    {
        // Arrange
        var mediator = new  Mock<IMediator>();
        var userRepoMoq = new Mock<IUserRepository>();
        var request = new DeleteUserRequest
        {
            Id = new Guid(),
        };
        var handler = new DeleteUserRequestHandler(userRepoMoq.Object);

        // Act
        var response = await handler.Handle(request, new CancellationToken());
        
        // Assert
        userRepoMoq.Verify(x => x.RemoveAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()));
    }

    [Test]
    public async Task UpdateUserRequest_UserUpdatedInDbAsync()
    {
        // Arrange
        var mediator = new  Mock<IMediator>();
        var userRepoMoq = new Mock<IUserRepository>();
        var request = new UpdateUserRequest
        {
            Id = new Guid(),
            DeviceId = "someDeviceId",
            LastLogin = DateTime.UtcNow.ToString("o")
        };
        var handler = new UpdateUserRequestHandler(userRepoMoq.Object);

        // Act
        var response = await handler.Handle(request, new CancellationToken());
        
        // Assert
        userRepoMoq.Verify(x => x.UpdateAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()));
    }

    [Test]
    public async Task GetUserRequest_UserReturned_FromDbAsync()
    {
        // Arrange
        var mediator = new  Mock<IMediator>();
        var userRepoMoq = new Mock<IUserRepository>();
        var request = new GetUserRequest
        {
            Id = new Guid()
        };
        var handler = new GetUserRequestHandler(userRepoMoq.Object);

        // Act
        var response = await handler.Handle(request, new CancellationToken());
        
        // Assert
        userRepoMoq.Verify(x => x.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()));
    }
}