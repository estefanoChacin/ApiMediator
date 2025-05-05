using ApiMediator.Application.DataTransferObjects;
using ApiMediator.Domain.Interfaces;
using ApiMediator.Infrastructure.Model;
using ApiMediator.Response;
using MediatR;

namespace ApiMediator.Application.Command
{
    public class UserCreateHandler(IDBRepository<UserModel> repository) : IRequestHandler<UserCreateCommand, HttpResponseServer<UserDto>>
    {
        private readonly IDBRepository<UserModel> _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        
        public Task<HttpResponseServer<UserDto>> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = new UserModel
                {
                    UserName = request.UserName,
                    Password = request.Password,
                    Email = request.Email,
                    ProductLastFour = request.ProductLastFour
                };
                
                _repository.CreateAsync(user);
                
                return Task.FromResult(new HttpResponseServer<UserDto>
                {
                    Status = true,
                    Message = "User created successfully.",
                    Data = new UserDto
                    {
                        Id = user.Id ?? string.Empty,
                        UserName = user.UserName,
                        Password = user.Password,
                        Email = user.Email,
                        ProductLastFour = user.ProductLastFour
                    }
                });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating user: {ex.Message}", ex);
            }
        }
    }
}