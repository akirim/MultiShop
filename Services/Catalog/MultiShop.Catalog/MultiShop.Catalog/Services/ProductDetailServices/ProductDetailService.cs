using System.Net.WebSockets;
using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> _productDetailCollection;
        private readonly IMapper _mapper;
        public ProductDetailService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productDetailCollection = database.GetCollection<ProductDetail>(databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }
        public Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var values =_mapper.Map<ProductDetail>(createProductDetailDto);
            return _productDetailCollection.InsertOneAsync(values);
        }

        public async Task DeleteProductDetailAsync(string productDetailId)
        {
            await _productDetailCollection.DeleteOneAsync(x => x.ProductDetailId == productDetailId);
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var values = _productDetailCollection.Find(x => x.ProductDetailId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDto>(values);
        }

        public async Task<List<ResultProductDetailDto>> GetResultProductDetailDtosAsync()
        {
            var values = await _productDetailCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(values);
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var values = _mapper.Map<ProductDetail>(updateProductDetailDto);
            await _productDetailCollection.FindOneAndReplaceAsync(x => x.ProductDetailId == updateProductDetailDto.ProductDetailId, values);
        }
    }
}
