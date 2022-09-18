using Application.Features.Products.Dtos;
using Application.Features.Products.Models;
using Application.Features.Products.Queries.GetListProduct;
using Application.Features.Products.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.GetByIdProduct
{
    public class GetByIdProductQuery: IRequest<ProductGetByIdDto>
    {
        public int Id { get; set; }
        public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, ProductGetByIdDto>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;
            private readonly ProductBusinessRules _productBusinessRules;

            public GetByIdProductQueryHandler(IProductRepository productRepository, IMapper mapper, ProductBusinessRules productBusinessRules)
            {
                _productRepository = productRepository;
                _mapper = mapper;
                _productBusinessRules = productBusinessRules;
            }

            public async Task<ProductGetByIdDto> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
            {

                Product? product = await _productRepository.GetAsync(b => b.Id == request.Id);

                _productBusinessRules.ProductShouldExistWhenRequested(product);
                ProductGetByIdDto productGetByIdDto = _mapper.Map<ProductGetByIdDto>(product);
                return productGetByIdDto;   
            }
        }
    }
}
