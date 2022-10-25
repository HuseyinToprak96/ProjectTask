using CoreLayer.Dtos;
using CoreLayer.Dtos.Herb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Identity.Web.Service
{
    public class HerbAPI
    {
        private readonly HttpClient _httpClient;
        public HerbAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<HerbDto>> List()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<HerbDto>>>("Herb/List");
            return response.Data;
        }
        public async Task<HerbDto> Find(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<HerbDto>>($"Herb/Find?id={id}");
            return response.Data;
        }
        public async Task<HerbDetailDto> HerbDetail(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<HerbDetailDto>>($"Herb/GetDetail?id={id}");
            return response.Data;
        }
        public async Task<HerbDto> Add(HerbDto herbDto)
        {
            var response = await _httpClient.PostAsJsonAsync("Herb/Add", herbDto);
            if (!response.IsSuccessStatusCode) return null;
            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<HerbDto>>();
            return responseBody.Data;
        }
        public async Task<bool> Delete(int id)
        {
            var response = await _httpClient.PutAsJsonAsync($"Herb/Delete?id={id}",id);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> Update(HerbDto herbDto)
        {
            var response = await _httpClient.PutAsJsonAsync("Herb/Update", herbDto);
            return response.IsSuccessStatusCode;
        }
    }
}
