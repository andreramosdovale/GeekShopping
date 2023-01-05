using AutoMapper;
using GeekShoping.ProductApi.Data.ProductDTO;
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

    public async Task<ProductDTO> Create(ProductDTO productDTO)
    {
        Product newProduct = _mapper.Map<Product>(productDTO);
        _context.Products.Add(newProduct);
        await _context.SaveChangesAsync();

        return _mapper.Map<ProductDTO>(newProduct);
    }

    public async Task<ProductDTO> Update(ProductDTO productDTO)
    {
        Product updatedProduct = _mapper.Map<Product>(productDTO);
        _context.Products.Update(updatedProduct);
        await _context.SaveChangesAsync();

        return _mapper.Map<ProductDTO>(updatedProduct);
    }

    public async Task<bool> DeleteById(long productId)
    {
        try
        {
            Product product = await _context.Products.Where(p => p.id == productId).FirstOrDefaultAsync();
            
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception)
        {

            return false;
        }
    }
}
