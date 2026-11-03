using OrderServices.Clients;
using System.Net;

namespace OrderServices.Clients
{
    public class ProductServiceClient
    {
        private readonly HttpClient _httpClient;

        public ProductServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ProductServiceProductDTO?> GetProductByIdAsync(
            int productId)
        {
            var response = await _httpClient.GetAsync(
                $"api/products/{productId}");

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content
                .ReadFromJsonAsync<ProductServiceProductDTO>();
        }
    }
}