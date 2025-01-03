using Domain.Repositories;
using MediatR;
using Presentation.Requests;
using Presentation.Responses;
using Domain.Entities;

namespace Services.Handlers
{
    public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.InsertAsync(
                new User
                {
                    Id = new Guid(),
                    DeviceId = request.DeviceId,
                }, 
                cancellationToken
            );
            
            return new CreateUserResponse
            {
                Id = result
            };
        }
    }
}