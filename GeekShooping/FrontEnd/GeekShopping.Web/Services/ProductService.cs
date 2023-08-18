using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;

namespace GeekShopping.Web.Services {
    public class ProductService : IProductService {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/product";

        async Task<IEnumerable<ProductModel>> IProductService.FindAllProducts() {
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProductModel>>();
        }

        async Task<ProductModel> IProductService.FindProdctById(long id) {
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ProductModel>();
        }
        async Task<ProductModel> IProductService.CreateProduct(ProductModel model) {
            throw new NotImplementedException();
        }

        async Task<ProductModel> IProductService.UpdateProduct(ProductModel model) {
            throw new NotImplementedException();
        }

        async Task<bool> IProductService.DeleteProductById(long id) {
            throw new NotImplementedException();
        }

    }
}
