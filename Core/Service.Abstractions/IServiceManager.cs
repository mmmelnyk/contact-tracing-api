namespace Service.Abstractions;

public interface IServiceManager
{
    IUserService UserService { get; }
}
