using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NativeTunes.API.Models.Marketplace;
using NativeTunes.Application.Marketplace.Command.CreateProduct;
using NativeTunes.Application.Marketplace.Command.DeleteProduct;
using NativeTunes.Application.Marketplace.Query.GetProductDetail;
using NativeTunes.Application.Marketplace.Query;

namespace NativeTunes.API.Controllers
{
    [Route("api/marketplace")]
    public class MarketplaceController : ApiControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public MarketplaceController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        [HttpPost("products")]
        [ProducesResponseType(typeof(ProductDto), statusCode: StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProduct([FromForm] ProductForCreationDto product)
        {
            var command = new CreateProductCommand(product.Title, product.Description, product.Price, product.Image);
            var result = await _mediator.Send(command);

            if (result.IsFailure)
                return Problem(result.Error);

            ProductDto productToReturn = _mapper.Map<ProductDto>(result.Value);
            return CreatedAtRoute("GetProductById", new { productId = productToReturn.Id }, productToReturn);
        }

        [HttpGet("products")]
        [ProducesResponseType(typeof(List<ProductDto>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProducts()
        {
            var query = new GetProductListQuery();
            var result = await _mediator.Send(query);
            if (result.IsFailure)
                return Problem(result.Error);

            List<ProductDto> products = _mapper.Map<List<ProductDto>>(result.Value);
            return Ok(products);
        }

        [HttpGet("products/{productId}", Name = "GetProductById")]
        [ProducesResponseType(typeof(ProductDto), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductDetail([FromRoute] string productId)
        {
            var query = new GetProductDetailQuery(productId);
            var result = await _mediator.Send(query);
            if (result.IsFailure)
                return Problem(result.Error);

            ProductDto product = _mapper.Map<ProductDto>(result.Value);
            return Ok(product);
        }

        [HttpDelete("products/{productId}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] string productId)
        {
            var command = new DeleteProductCommand(productId);
            var result = await _mediator.Send(command);
            if (result.IsFailure)
                return Problem(result.Error);

            return NoContent();
        }
    }
}
