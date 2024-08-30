using Domain.Repositories;
using Service.Abstractions;

namespace Services;

public class UserService(IRepositoryManager repositoryManager) : IUserService
{
    private readonly IRepositoryManager _repositoryManager = repositoryManager;

    public Task AddUser()
    {
        throw new NotImplementedException();
    }
}
