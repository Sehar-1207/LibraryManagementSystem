using Application.Dtos;
using Application.Services;
using System.Net.Http.Json;

namespace LibraryManagementSystemUi.Services
{
    public class MemberService
    {
        private readonly HttpClient _http;
        public MemberService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<MemberDto>> GetAll()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<MemberDto>>>("api/member");
            return response?.Data ?? new List<MemberDto>();
        }

        public async Task<MemberDto?> GetById(int id)
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<MemberDto>>($"api/member/{id}");
            return response?.Data;
        }

        public async Task<bool> Add(MemberDto member)
        {
            var result = await _http.PostAsJsonAsync("api/member", member);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> Update(int id,MemberDto member)
        {
            var result = await _http.PutAsJsonAsync($"api/member/{id}", member);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _http.DeleteAsync($"api/member/{id}");
            return result.IsSuccessStatusCode;
        }
    }
}
