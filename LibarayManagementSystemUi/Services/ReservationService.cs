using Application.Dtos.Books;
using Application.Services;
using System.Net.Http.Json;

namespace LibraryManagementSystemUi.Services
{
    public class ReservationService
    {
        private readonly HttpClient _http;

        public ReservationService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<ReservationDto>> GetAll()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<ReservationDto>>>("api/Reservation/all");
            return response?.Data ?? new List<ReservationDto>();
        }

        public async Task<ReservationDto?> GetById(int id)
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<ReservationDto>>($"api/Reservation/{id}");
            return response?.Data;
        }

        public async Task<bool> Add(ReservationDto dto)
        {
            var response = await _http.PostAsJsonAsync("api/Reservation/add", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Update(int id, ReservationDto dto)
        {
            var response = await _http.PutAsJsonAsync($"api/Reservation/edit/{id}", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await _http.DeleteAsync($"api/Reservation/delete/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Cancel(int id)
        {
            var response = await _http.DeleteAsync($"api/Reservation/cancel/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Complete(int id)
        {
            var response = await _http.PutAsync($"api/Reservation/complete/{id}", null);
            return response.IsSuccessStatusCode;
        }
    }
}
