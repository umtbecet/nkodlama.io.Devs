using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProductCommand createProductCommand)
        {
            CreatedProductDto result = await Mediator.Send(createProductCommand);
            return Created("", result);
        }


    }
}
