using Application.Dtos.Books;
using Application.Features.Reservation.Command;
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

        // ✅ Add a reservation
        public async Task<ServiceResponse<int>> AddReservationAsync(ReservationDto dto)
        {
            var command = new AddReservationCommand
            {
                //ReservationDto = dto
            };

            var response = await _http.PostAsJsonAsync("api/Reservation/add", command);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        }

        // ✅ Cancel a reservation
        public async Task<ServiceResponse<int>> CancelReservationAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/Reservation/cancel/{id}");
            return await response.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        }

        // ✅ Complete a reservation
        public async Task<ServiceResponse<int>> CompleteReservationAsync(int id)
        {
            var response = await _http.PutAsync($"api/Reservation/complete/{id}", null);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        }

        // ✅ Get reservations by book
        public async Task<ServiceResponse<IEnumerable<ReservationDto>>> GetReservationsByBookAsync(int bookId)
        {
            return await _http.GetFromJsonAsync<ServiceResponse<IEnumerable<ReservationDto>>>($"api/Reservation/by-book/{bookId}");
        }

        // ✅ Get reservations by member
        public async Task<ServiceResponse<IEnumerable<ReservationDto>>> GetReservationsByMemberAsync(int memberId)
        {
            return await _http.GetFromJsonAsync<ServiceResponse<IEnumerable<ReservationDto>>>($"api/Reservation/by-member/{memberId}");
        }

        // ✅ Get next reservation for a book
        public async Task<ServiceResponse<ReservationDto>> GetNextReservationAsync(int bookId)
        {
            return await _http.GetFromJsonAsync<ServiceResponse<ReservationDto>>($"api/Reservation/next/{bookId}");
        }
    }
}
