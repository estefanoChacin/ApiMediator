using ApiMediator.Application.Command;
using ApiMediator.Application.DataTransferObjects;
using ApiMediator.Domain.Interfaces;
using ApiMediator.Infrastructure.Model;
using ApiMediator.Response;
using MediatR;

namespace ApiMediator.Application.Handlers
{
    public class UserByIdHandler(IDBRepository<UserModel> repository):IRequestHandler<UserByIdCommand, HttpResponseServer<UserDto>>
    {
        private readonly IDBRepository<UserModel> _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        public async Task<HttpResponseServer<UserDto>> Handle(UserByIdCommand request, CancellationToken cancellationToken)
        {
            if(request.UserId == null || request.UserId == string.Empty)
                throw new ArgumentNullException(nameof(request.UserId), "UserId cannot be null or empty.");
            
            var user = await _repository.GetByIdAsync(request.UserId).ConfigureAwait(false);

            if (user == null)
                throw new KeyNotFoundException($"User with ID {request.UserId} not found.");
            
            return new HttpResponseServer<UserDto>
            {
                Status = true,
                Message = "User retrieved successfully.",
                Data = new UserDto
                {
                    Id = user.Id ?? string.Empty,
                    UserName = user.UserName,
                    Password = user.Password,
                    Email = user.Email,
                    ProductLastFour = user.ProductLastFour
                }
            };
        }
        
    }
}