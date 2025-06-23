using MultiShop.Catalog.Dtos.ProductDetailDtos;
namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetResultProductDetailDtosAsync();
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteProductDetailAsync(string productDetailId);
        Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id);
    }
}
