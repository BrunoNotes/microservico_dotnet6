using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;

namespace GeekShopping.Web.Services {
    public class ProductService : IProductService {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/product";

        public ProductService(HttpClient client) {
            _client = client ?? throw new ArgumentNullException(nameof(client));

        }

        async Task<IEnumerable<ProductModel>> IProductService.FindAllProducts() {
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProductModel>>();
        }

        async Task<ProductModel> IProductService.FindProdctById(long id) {
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ProductModel>();
        }
        async Task<ProductModel> IProductService.CreateProduct(ProductModel model) {
            var response = await _client.PostAsJson(BasePath, model);

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductModel>();
            else
                throw new Exception("Something went wrong when calling API");
        }

        async Task<ProductModel> IProductService.UpdateProduct(ProductModel model) {
            var response = await _client.PutAsJson(BasePath, model);

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductModel>();
            else
                throw new Exception("Something went wrong when calling API");
        }

        async Task<bool> IProductService.DeleteProductById(long id) {
            var response = await _client.DeleteAsync($"{BasePath}/{id}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else
                throw new Exception("Something went wrong when calling API");
        }

    }
}
