using AutoMapper;
using GeekShoping.ProductApi.Data.ProductDTO;
using GeekShoping.ProductApi.Model;

namespace GeekShoping.ProductApi.Config;

public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<ProductDTO, Product>();
            config.CreateMap<Product, ProductDTO>();
        });

        return mappingConfig;
    }
}
