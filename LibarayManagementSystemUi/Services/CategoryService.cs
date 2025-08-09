using Application.Dtos.Books;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LibraryManagementSystemUi.Services
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
            var categories = await _http.GetFromJsonAsync<List<CategoryDto>>("api/Category");
            return categories ?? new List<CategoryDto>(); // Avoid returning null
        }

        public async Task<CategoryDto?> GetCategoryByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<CategoryDto?>($"api/Category/{id}");
        }

        public async Task<HttpResponseMessage> AddCategoryAsync(CategoryDto category)
        {
            return await _http.PostAsJsonAsync("api/Category", category);
        }

        public async Task<HttpResponseMessage> UpdateCategoryAsync(int id, CategoryDto category)
        {
            // Use the id parameter, not category.Id (to avoid mismatch)
            return await _http.PutAsJsonAsync($"api/Category/{id}", category);
        }

        public async Task<HttpResponseMessage> DeleteCategoryAsync(int id)
        {
            return await _http.DeleteAsync($"api/Category/{id}");
        }
    }
}
