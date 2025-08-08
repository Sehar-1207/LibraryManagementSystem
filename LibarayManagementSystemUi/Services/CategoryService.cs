using Application.Dtos.Books;
using System.Net.Http.Json;

namespace LibarayManagementSystemUi.Services
{
    public class CategoryService
    {
        private readonly HttpClient _http;

        public CategoryService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<CategoryDto>> GetCategoriesAsync()
        {
            return await _http.GetFromJsonAsync<List<CategoryDto>>("https://localhost:7250/api/Category");
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<CategoryDto>($"https://localhost:7250/api/Category/{id}");
        }

        public async Task<HttpResponseMessage> AddCategoryAsync(CategoryDto category)
        {
            return await _http.PostAsJsonAsync("https://localhost:7250/api/Category", category);
        }

        public async Task<HttpResponseMessage> UpdateCategoryAsync(int id,CategoryDto category)
        {
            return await _http.PutAsJsonAsync($"https://localhost:7250/api/Category/{category.Id}", category);
        }

        public async Task<HttpResponseMessage> DeleteCategoryAsync(int id)
        {
            return await _http.DeleteAsync($"https://localhost:7250/api/Category/{id}");

        }

    }
}
