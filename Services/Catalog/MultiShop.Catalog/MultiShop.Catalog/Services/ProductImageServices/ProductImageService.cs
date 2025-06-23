using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMongoCollection<ProductImage> _productImageCollection;
        private readonly IMapper _mapper;
        public ProductImageService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productImageCollection = database.GetCollection<ProductImage>(databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
        }
        public Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var values = _mapper.Map<ProductImage>(createProductImageDto);
            return _productImageCollection.InsertOneAsync(values);
        }

        public async Task DeleteProductImageAsync(string productImageId)
        {
            await _productImageCollection.DeleteOneAsync(x => x.ProductImageId == productImageId);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImagesAsync()
        {
            var values = await _productImageCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(values);
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            var values = await _productImageCollection.Find(x => x.ProductImageId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(values);
        }

        public Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            var values = _mapper.Map<ProductImage>(updateProductImageDto);
            return _productImageCollection.FindOneAndReplaceAsync(x => x.ProductImageId == updateProductImageDto.ProductImageId, values);
        }
    }
}
