

using ApiMediator.Application.DataTransferObjects;
using ApiMediator.Response;
using MediatR;

namespace ApiMediator.Application.Features.Products.Commands
{
    public class ListProductComannd:IRequest<HttpResponseServer<List<ProductDto>>>
    {
        
    }
}