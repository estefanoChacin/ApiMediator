using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using ApiMediator.Application.DataTransferObjects;
using ApiMediator.Application.Features.Products.Commands;
using ApiMediator.Domain.Interfaces;
using ApiMediator.Domain.Model;
using ApiMediator.Response;
using MediatR;

namespace ApiMediator.Application.Features.Products.Handlers
{
    public class ListProductHandler(IDBRepository<ProductModel> repository) : IRequestHandler<ListProductComannd, HttpResponseServer<List<ProductDto>>>
    {
        private readonly IDBRepository<ProductModel> _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        public Task<HttpResponseServer<List<ProductDto>>> Handle(ListProductComannd request, CancellationToken cancellationToken)
        {
            var products = _repository.GetAllAsync().Result.Select(p => new ProductDto
            {
                Id= p.Id, 
                Description = p.Description, 
                Name = p.Name
            }).ToList();

            return Task.FromResult(new HttpResponseServer<List<ProductDto>>
            {
                Status = true,
                Message = "Products retrieved successfully.",
                Data = products
            });
        }
    }
}