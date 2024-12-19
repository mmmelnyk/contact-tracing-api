using ContactTracingAPI.Interaction.Requests;
using Domain.Repositories;
using MediatR;

namespace ContactTracingAPI.Interaction.Handlers
{
    public class AddUserHandler : IRequestHandler<AddUserRequest, int>
    {
        private readonly IUserRepository _userRepository;

        public AddUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            return await _userRepository.InsertAsync(new User
            {
                Id = request.Id,
                DeviceId = request.DeviceId,
                LastLogin = request.LastLogin
            }, cancellationToken);
        }
    }
}