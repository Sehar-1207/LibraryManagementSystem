using Application.Dtos.Books;
using Application.Features.Reservation.Command;
using LibraryManagementSystemUi.Services;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace LibraryManagementSystemUi.Services
{
    public class ReservationService
    {
        private readonly HttpClient _http;

        public ReservationService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ServiceResponse<int>> AddReservationAsync(AddReservationCommand command)
        {
            var response = await _http.PostAsJsonAsync("api/reservation/add", command);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        }

        public async Task<ServiceResponse<int>> CancelReservationAsync(int reservationId)
        {
            var response = await _http.DeleteAsync($"api/reservation/cancel/{reservationId}");
            return await response.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        }

        public async Task<ServiceResponse<int>> CompleteReservationAsync(int reservationId)
        {
            var response = await _http.PutAsync($"api/reservation/complete/{reservationId}", null);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        }

        public async Task<ServiceResponse<IEnumerable<ReservationDto>>> GetAllReservationsAsync()
        {
            var response = await _http.GetAsync("api/reservation/all");
            return await response.Content.ReadFromJsonAsync<ServiceResponse<IEnumerable<ReservationDto>>>();
        }

        public async Task<ServiceResponse<ReservationDto>> GetReservationByIdAsync(int id)
        {
            var response = await _http.GetAsync($"api/reservation/{id}");
            return await response.Content.ReadFromJsonAsync<ServiceResponse<ReservationDto>>();
        }

        public async Task<ServiceResponse<IEnumerable<ReservationDto>>> GetReservationsByBookAsync(int bookId)
        {
            var response = await _http.GetAsync($"api/reservation/by-book/{bookId}");
            return await response.Content.ReadFromJsonAsync<ServiceResponse<IEnumerable<ReservationDto>>>();
        }

        public async Task<ServiceResponse<IEnumerable<ReservationDto>>> GetReservationsByMemberAsync(int memberId)
        {
            var response = await _http.GetAsync($"api/reservation/by-member/{memberId}");
            return await response.Content.ReadFromJsonAsync<ServiceResponse<IEnumerable<ReservationDto>>>();
        }


    }
}
