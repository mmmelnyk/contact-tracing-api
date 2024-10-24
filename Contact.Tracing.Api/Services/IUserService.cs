namespace Contact.Tracing.Api.Services;

public interface IUserService
{
    Task<string> CreateAsync(string phoneNumber, CancellationToken cancellationToken);
}
