using ApiMediator.Application.DataTransferObjects;
using ApiMediator.Response;
using MediatR;

namespace ApiMediator.Application.Features.Products.Commands
{
    public class ProductCreateCommand:IRequest<HttpResponseServer<ProductDto>>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}