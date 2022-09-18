using Application.Features.Products.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.GetListProduct
{
    public class GetListProductQuery: IRequest<ProductListModel> 
    { 

        public PageRequest PageRequest { get; set; }
        public class GetListProductQueryHandler: IRequestHandler<GetListProductQuery, ProductListModel>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public GetListProductQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<ProductListModel>Handle(GetListProductQuery request, CancellationToken cancellationToken)
            {
               IPaginate<Product> Product = await _productRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
               
                ProductListModel _mappedProductListModel = _mapper.Map<ProductListModel>(Product);
                return _mappedProductListModel;
            }
        }

    }
}
