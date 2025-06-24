namespace MultiShop.Discount.Dtos
{
    public class GetByIdCouponDto
    {
        public int CouponId { get; set; }
        public string Code { get; set; }
        public int Rate { get; set; }
        public bool Isactive { get; set; }
        public DateTime VaildDate { get; set; }
    }
}
