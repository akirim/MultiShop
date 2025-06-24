using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> GetAllCouponAsync();
        Task<List<CreatCouponDto>> CreateCouponAsync(List<CreatCouponDto> createCouponDtos);
        Task<List<UpdateCouponDto>> updateCouponDtos(List<UpdateCouponDto> updateCouponDtos);
        Task DeleteCouponAsync(int couponId);
        Task<GetByIdCouponDto> GetByIdCouponAsync(int couponId);
    }
}
