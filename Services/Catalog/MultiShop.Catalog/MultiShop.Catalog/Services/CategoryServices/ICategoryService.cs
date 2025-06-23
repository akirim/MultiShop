using MultiShop.Catalog.Dtos.CategoryDtos;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategorysAsync();
        Task CreatCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(string categoryId);
        Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id);
    }
}
