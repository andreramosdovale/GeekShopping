using GeekShoping.ProductApi.Data.ProductDTO;
using GeekShoping.ProductApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShoping.ProductApi.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private IProductRepository _repository;

    public ProductController(IProductRepository repository)
    {
        _repository = repository ?? throw new ArgumentException(nameof(repository));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> FindAll()
    {
        var products = await _repository.FindAll();

        if (products == null) return NotFound();

        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDTO>> FindById(long id)
    {
        ProductDTO product = await _repository.FindById(id);

        if (product == null) return NotFound();

        return Ok(product);
    }
}
