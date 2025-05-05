using ApiMediator.Application.Command;
using ApiMediator.Application.DataTransferObjects;
using ApiMediator.Domain.Interfaces;
using ApiMediator.Infrastructure.Model;
using ApiMediator.Response;
using MediatR;

namespace ApiMediator.Application.Handlers
{
    public class ListUserHandler(IDBRepository<UserModel> repository): IRequestHandler<ListUserCommand, HttpResponseServer<List<UserDto>>>
    {
        private readonly IDBRepository<UserModel> _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        public async Task<HttpResponseServer<List<UserDto>>> Handle(ListUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userList = (await _repository.GetAllAsync()).Select(user => new UserDto
                {
                    Id = user.Id ?? string.Empty,
                    UserName = user.UserName,
                    Password = user.Password,
                    Email = user.Email,
                    ProductLastFour = user.ProductLastFour
                }).ToList();

                return new HttpResponseServer<List<UserDto>>
                {
                    Status = true,
                    Message = "User list retrieved successfully.",
                    Data = userList
                };
            }
            catch (System.Exception)
            {
                throw new Exception("Error retrieving user list.");
            }
        }
    }
}