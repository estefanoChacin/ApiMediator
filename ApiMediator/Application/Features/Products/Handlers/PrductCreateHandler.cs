using ApiMediator.Application.DataTransferObjects;
using ApiMediator.Application.Features.Products.Commands;
using ApiMediator.Domain.Interfaces;
using ApiMediator.Domain.Model;
using ApiMediator.Response;
using MediatR;

namespace ApiMediator.Application.Features.Products.Handlers
{
    public class PrductCreateHandler(IDBRepository<ProductModel> repository) : IRequestHandler<ProductCreateCommand, HttpResponseServer<ProductDto>>
    {
        private readonly IDBRepository<ProductModel> _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        
        public async Task<HttpResponseServer<ProductDto>> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            if(request == null)
                throw new ArgumentNullException(nameof(request), "Request cannot be null.");
            var productCreated = await _repository.CreateAsync(new ProductModel
            {
                Name = request.Name,
                Description = request.Description
            }).ConfigureAwait(false);

            if (productCreated == null)
                throw new Exception("Error creating product.");
            
            return new ()
            {
                Status = true,
                Message = "Product created successfully.",
                Data = new ProductDto
                {
                    Id = productCreated.Id,
                    Name = productCreated.Name,
                    Description = productCreated.Description
                }
            };
        }
    }
}