using Application.Dtos.Books;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LibraryManagementSystemUi.Services
{
    public class BorrowBookService
    {
        private readonly HttpClient _http;

        public BorrowBookService(HttpClient http)
        {
            _http = http;
        }

        // ✅ Get all borrow records
        public async Task<List<BorrowRecordDto>> GetBorrowRecordsAsync()
        {
            try
            {
                var response = await _http.GetFromJsonAsync<ServiceResponse<List<BorrowRecordDto>>>(
                    "https://localhost:7250/api/BorrowBookRecord"
                );

                return response?.Data ?? new List<BorrowRecordDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching borrow records: {ex.Message}");
                return new List<BorrowRecordDto>();
            }
        }

        // ✅ Get a single borrow record by ID
        public async Task<BorrowRecordDto?> GetBorrowRecordByIdAsync(int id)
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<BorrowRecordDto>>(
                $"https://localhost:7250/api/BorrowBookRecord/{id}"
            );
            return response?.Data;
        }

        // ✅ Create a new borrow record
        public async Task<HttpResponseMessage> CreateBorrowRecordAsync(BorrowRecordDto borrowRecord)
        {
            return await _http.PostAsJsonAsync("https://localhost:7250/api/BorrowBookRecord", borrowRecord);
        }

        // ✅ Update an existing borrow record
        public async Task<HttpResponseMessage> UpdateBorrowRecordAsync(int id, BorrowRecordDto borrowRecord)
        {
            return await _http.PutAsJsonAsync($"https://localhost:7250/api/BorrowBookRecord/{id}", borrowRecord);
        }

        // ✅ Delete a borrow record
        public async Task<HttpResponseMessage> DeleteBorrowRecordAsync(int id)
        {
            return await _http.DeleteAsync($"https://localhost:7250/api/BorrowBookRecord/{id}");
        }
    }

    // ✅ Add the same ServiceResponse class structure that your backend uses
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
