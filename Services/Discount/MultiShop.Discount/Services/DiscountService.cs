using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;
        public DiscountService(DapperContext context)
        {
            _context = context;
        }
        public Task CreateCouponAsync(CreatCouponDto createCouponDto)
        {
            string query = "INSERT INTO Coupons (Code, Rate, IsActive, VaildDate) VALUES (@code, @rate, @isActive, @vaildDate)";
            var paramters = new DynamicParameters();
            paramters.Add("code", createCouponDto.Code);
            paramters.Add("rate", createCouponDto.Rate);
            paramters.Add("isActive", createCouponDto.Isactive);
            paramters.Add("vaildDate", createCouponDto.VaildDate);
            using (var connection = _context.CreateConnection())
            {
                return connection.ExecuteAsync(query, paramters);
            }
        }

        public async Task DeleteCouponAsync(int id)
        {
            string query = "DELETE FROM Coupons WHERE CouponId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("CouponId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCouponDto>> GetAllCouponAsync()
        {
            string query = "SELECT * FROM Coupons";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdCouponDto> GetByIdCouponAsync(int id)
        {
            var query = "SELECT * FROM Coupons WHERE CouponId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("couponId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdCouponDto>(query);
                return values;
            }
        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            string query = "UPDATE Coupons SET Code = @code, Rate = @rate, IsActive = @isActive, VaildDate = @vaildDate WHERE CouponId = @couponId";
            var paramters = new DynamicParameters();
            paramters.Add("code", updateCouponDto.Code);
            paramters.Add("ate", updateCouponDto.Rate);
            paramters.Add("isActive", updateCouponDto.Isactive);
            paramters.Add("vaildDate", updateCouponDto.VaildDate);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramters);
            }
        }
    }
}        
