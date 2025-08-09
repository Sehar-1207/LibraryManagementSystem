using Application.Dtos.Books;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http.Json;

namespace LibraryManagementSystemUi.Services
{
    public class BookService
    {
        private readonly HttpClient _http;
        private readonly ILogger<BookService> _logger;

        public BookService(HttpClient http, ILogger<BookService> logger)
        {
            _http = http;
            _logger = logger;

            // Configure base address in Program.cs instead of hardcoding
            // _http.BaseAddress = new Uri("https://localhost:7250");
        }

        public async Task<List<BookDto>> GetBooksAsync()
        {
            try
            {
                _logger.LogInformation("Fetching books from API");
                var response = await _http.GetAsync("api/Books");

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return new List<BookDto>();
                }

                response.EnsureSuccessStatusCode();

                var books = await response.Content.ReadFromJsonAsync<List<BookDto>>();
                _logger.LogInformation("Successfully retrieved {Count} books", books?.Count);
                return books ?? new List<BookDto>();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error fetching books");
                throw new ApplicationException("Unable to fetch books. Please try again later.", ex);
            }
        }

        public async Task<BookDto?> GetBookByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("Fetching book with ID {BookId}", id);
                var response = await _http.GetAsync($"api/Books/{id}");

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }

                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<BookDto>();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error fetching book with ID {BookId}", id);
                throw new ApplicationException($"Unable to fetch book with ID {id}. Please try again later.", ex);
            }
        }

        public async Task<bool> AddBookAsync(BookDto book)
        {
            try
            {
                _logger.LogInformation("Adding new book: {BookTitle}", book.Title);
                var response = await _http.PostAsJsonAsync("api/Books", book);

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Successfully added book with ID {BookId}", book.Id);
                    return true;
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                _logger.LogError("Failed to add book. Status: {StatusCode}, Error: {Error}",
                    response.StatusCode, errorContent);
                return false;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error adding book: {BookTitle}", book.Title);
                throw new ApplicationException("Unable to add book. Please try again later.", ex);
            }
        }

        public async Task<bool> UpdateBookAsync(int id, BookDto book)
        {
            try
            {
                if (id != book.Id)
                {
                    throw new ArgumentException("ID mismatch between route and book object");
                }

                _logger.LogInformation("Updating book with ID {BookId}", id);
                var response = await _http.PutAsJsonAsync($"api/Books/{id}", book);

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Successfully updated book with ID {BookId}", id);
                    return true;
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                _logger.LogError("Failed to update book. Status: {StatusCode}, Error: {Error}",
                    response.StatusCode, errorContent);
                return false;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error updating book with ID {BookId}", id);
                throw new ApplicationException($"Unable to update book with ID {id}. Please try again later.", ex);
            }
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            try
            {
                _logger.LogInformation("Deleting book with ID {BookId}", id);
                var response = await _http.DeleteAsync($"api/Books/{id}");

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Successfully deleted book with ID {BookId}", id);
                    return true;
                }

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    _logger.LogWarning("Book with ID {BookId} not found for deletion", id);
                    return false;
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                _logger.LogError("Failed to delete book. Status: {StatusCode}, Error: {Error}",
                    response.StatusCode, errorContent);
                return false;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error deleting book with ID {BookId}", id);
                throw new ApplicationException($"Unable to delete book with ID {id}. Please try again later.", ex);
            }
        }
    }
}