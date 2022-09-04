using Application.Features.Products.Dtos;
using Application.Features.Products.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<CreatedProductDto>
    {
        public string Name { get; set; }
        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreatedProductDto>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;
            private readonly ProductBusinessRules _productBusinessRules;

            public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper,
                                             ProductBusinessRules productBusinessRules)
            {
                _productRepository = productRepository;
                _mapper = mapper;
                _productBusinessRules = productBusinessRules;
            }

            public async Task<CreatedProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                await _productBusinessRules.ProductNameCanNotBeDuplicatedWhenInserted(request.Name);

                Product mappedProduct = _mapper.Map<Product>(request);
                Product createdProduct = await _productRepository.AddAsync(mappedProduct);
                CreatedProductDto createdproductDto = _mapper.Map<CreatedProductDto>(createdProduct);
                return createdproductDto;
            }
        }
    }
}
