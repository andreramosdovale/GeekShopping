using GeekShoping.ProductApi.Data.ProductDTO;
using GeekShoping.ProductApi.Model;
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

    [HttpPost]
    public async Task<ActionResult<ProductDTO>> Create(ProductDTO newProduct)
    {
        if (newProduct == null) return BadRequest();

        var product = await _repository.Create(newProduct);

        return Ok(product);
    }

    [HttpPut()]
    public async Task<ActionResult<ProductDTO>> Update(ProductDTO product)
    {
        ProductDTO productUpdated = await _repository.Update(product);

        if (productUpdated == null) return BadRequest();

        return Ok(productUpdated);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ProductDTO>> Delete(long id)
    {
        var status = await _repository.DeleteById(id);

        if (!status) return BadRequest();

        return Ok();
    }
}
