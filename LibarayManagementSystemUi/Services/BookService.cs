using Application.Dtos.Books;
using System.Net.Http.Json;

namespace LibarayManagementSystemUi.Services
{
    public class BookService
    {
        private readonly HttpClient _http;

        public BookService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<BookDto>> GetBooksAsync()
        {
            return await _http.GetFromJsonAsync<List<BookDto>>("https://localhost:7250/api/Books");
        }

        public async Task<BookDto> GetBookByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<BookDto>($"https://localhost:7250/api/Books/{id}");
        }

        public async Task<HttpResponseMessage> AddBookAsync(BookDto book)
        {
            return await _http.PostAsJsonAsync("https://localhost:7250/api/Books", book);
        }

        public async Task<HttpResponseMessage> UpdateBookAsync(int id, BookDto book)
        {
            return await _http.PutAsJsonAsync($"https://localhost:7250/api/Books/{book.Id}", book);
        }

        public async Task<HttpResponseMessage> DeleteBookAsync(int id)
        {
            return await _http.DeleteAsync($"https://localhost:7250/api/Books/{id}");
        }

    }
}
