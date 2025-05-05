using ApiMediator.Application.Features.Users.Commands;
using ApiMediator.Domain.Interfaces;
using ApiMediator.Infrastructure.Model;
using ApiMediator.Response;
using MediatR;

namespace ApiMediator.Application.Features.Users.Handlers
{
    public class UserDeleteHandler(IDBRepository<UserModel> _repository) : IRequestHandler<UserDeleteCommand, HttpResponseServer<bool>>
    {
        private readonly IDBRepository<UserModel> _repository = _repository ?? throw new ArgumentNullException(nameof(_repository));
        
        public async Task<HttpResponseServer<bool>> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if(request.Id == null || request.Id == string.Empty)
                throw new ArgumentNullException(nameof(request.Id), "UserId cannot be null or empty.");

            await _repository.RemoveAsync(request.Id).ConfigureAwait(false);
            return new HttpResponseServer<bool>
            {
                Status = true,
                Message = "User deleted successfully.",
                Data = true
            };
            }
            catch (Exception)
            {
                return new HttpResponseServer<bool>
                {
                    Status = false,
                    Message = "Error deleting user.",
                    Data = false
                };
            }
        }
    }
}