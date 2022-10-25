using CoreLayer.Dtos;
using CoreLayer.Dtos.Complaint;
using CoreLayer.Dtos.Herb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Identity.Web.Service
{
    public class ComplaintAPI
    {
        private readonly HttpClient _httpClient;
        public ComplaintAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ComplaintDto>> List()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<ComplaintDto>>>("Complaint/List");
            return response.Data;
        }
        public async Task<ComplaintDto> Find(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<ComplaintDto>>($"Complaint/Find?id={id}");
            return response.Data;
        }
        public async Task<ComplaintDto> HerbDetail(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<ComplaintDto>>($"Complaint/ComplaintDetail?id={id}");
            return response.Data;

        }

        public async Task<ComplaintDto> Add(ComplaintDto complaintDto)
        {
            var response = await _httpClient.PostAsJsonAsync("Complaint/Add", complaintDto);
            if (!response.IsSuccessStatusCode) return null;
            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<ComplaintDto>>();
            return responseBody.Data;
        }
        public async Task<bool> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"Complaint/Delete?id={id}");
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> Update(ComplaintDto complaintDto)
        {
            var response = await _httpClient.PutAsJsonAsync("Complaint/Update", complaintDto);
            return response.IsSuccessStatusCode;
        }
    }
}