using ApiMediator.Response;
using MediatR;

namespace ApiMediator.Application.Features.Users.Commands
{
    public class UserDeleteCommand: IRequest<HttpResponseServer<bool>>
    {
        public string Id { get; set; } = string.Empty;
    }
}