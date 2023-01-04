using AutoMapper;
using GeekShoping.ProductApi.Data.ValueObject;
using GeekShoping.ProductApi.Model;
using GeekShoping.ProductApi.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShoping.ProductApi.Repository;

public class ProductRepository : IProductRepository
{
    private readonly MysqlContext _context;
    private readonly IMapper _mapper;

    public ProductRepository(MysqlContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDTO>> FindAll()
    {
        List<Product> products = await _context.Products.ToListAsync();

        return _mapper.Map<List<ProductDTO>>(products);
    }

    public async Task<ProductDTO> FindById(long productId)
    {
        Product product = await _context.Products.Where(p => p.id == productId).FirstOrDefaultAsync();

        return _mapper.Map<ProductDTO>(product);
    }

    public async Task<ProductDTO> Create(ProductDTO product)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductDTO> Update(ProductDTO product)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductDTO> DeleteById(long productId)
    {
        throw new NotImplementedException();
    }
}
