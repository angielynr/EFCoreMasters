namespace EFCoreAssignment.Data.Services
{
    public class ProductService : IProductService
    {

        public ProductService() { }

        public async Task<List<ProductDto>> GetProducts()
        {
            // TODO get products
            throw new NotImplementedException();
        }

        public async Task<ProductDto> GetProduct(int id)
        {
            // TODO get product
            throw new NotImplementedException();
        }

        public async Task<int> CreateProduct(CreateProductDto productForCreation)
        {
            // TODO create a product
            throw new NotImplementedException();
        }

        public async Task UpdateProduct(UpdateProductDto productForUpdate)
        {
            //TODO update a product
            throw new NotImplementedException();
        }

        public async Task DeleteProduct(int id)
        {
            //TODO delete a product
            throw new NotImplementedException();
        }

    }

    public interface IProductService
    {
        Task<List<ProductDto>> GetProducts();
        Task<ProductDto> GetProduct(int id);
        Task<int> CreateProduct(CreateProductDto productForCreation);
        Task UpdateProduct(UpdateProductDto productForUpdate);
        Task DeleteProduct(int id);
    }

    public record ProductDto(int Id, string Name, int ShopId);
    public record CreateProductDto(string Name, int ShopId);
    public record UpdateProductDto(int Id, string Name, int ShopId);
}