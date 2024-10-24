
namespace Contact.Tracing.Api.Services;

public class UserService : IUserService
{
    public async Task<string> CreateAsync(string phoneNumber, CancellationToken cancellationToken)
    {
        return "test";
    }
}
