using ApiMediator.Application.DataTransferObjects;
using ApiMediator.Response;
using MediatR;

namespace ApiMediator.Application.Command
{
    public class ListUserCommand:IRequest<HttpResponseServer<List<UserDto>>>
    {
    }
}