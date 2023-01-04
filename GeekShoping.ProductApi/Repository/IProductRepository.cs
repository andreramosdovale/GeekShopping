using GeekShoping.ProductApi.Data.ValueObject;

namespace GeekShoping.ProductApi.Repository;

public interface IProductRepository
{
    Task<IEnumerable<ProductDTO>> FindAll();
    Task<ProductDTO> FindById(long productId);
    Task<ProductDTO> Create(ProductDTO product);
    Task<ProductDTO> Update(ProductDTO product);
    Task<ProductDTO> DeleteById(long productId);
}
