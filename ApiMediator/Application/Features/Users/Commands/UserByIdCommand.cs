
using ApiMediator.Application.DataTransferObjects;
using ApiMediator.Response;
using MediatR;

namespace ApiMediator.Application.Command
{
    public class UserByIdCommand:IRequest<HttpResponseServer<UserDto>>
    {
        public string? UserId { get; set; } 
    }
}