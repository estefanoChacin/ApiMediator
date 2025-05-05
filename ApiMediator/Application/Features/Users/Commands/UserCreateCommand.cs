
using ApiMediator.Application.DataTransferObjects;
using ApiMediator.Response;
using MediatR;

namespace ApiMediator.Application.Command
{
    public class UserCreateCommand: IRequest<HttpResponseServer<UserDto>>
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ProductLastFour { get; set; } = string.Empty;
    }
}