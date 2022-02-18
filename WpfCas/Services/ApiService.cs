using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WpfCas.Models;
using WpfCas.ViewModels;

namespace WpfCas.Services
{
    public  class ApiService
    {
        private static HttpClient _httpClient = new HttpClient();

        static string baseUrl = "https://localhost:44339/api/";

        static ApiService()
        {
            _httpClient.BaseAddress = new Uri(baseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
        public async Task<List<Equipo>> GetEquipos()
        {
            var uri = "Equipo";

            var respString = await _httpClient.GetStringAsync(uri);
            var res = JsonSerializer.Deserialize<List<Equipo>>(respString, JsonOpt.options);
            
            return res;
        }
        public async Task AltaEquipo(Equipo request)
        {
            var uri = "Equipo";

            HttpResponseMessage response = await _httpClient.PostAsync(uri,
                new StringContent(JsonSerializer.Serialize(request), System.Text.Encoding.UTF8, "application/json"));

            var result = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                throw new Exception(
                    JsonSerializer.Deserialize<ErrorMessage>(result, JsonOpt.options).Message);

            response.EnsureSuccessStatusCode();
        }
        public async Task ModificarEquipo(Equipo request)
        {
            var uri = "Equipo/" + request.EquipoId.ToString();

            HttpResponseMessage response = await _httpClient.PutAsync(uri,
                new StringContent(JsonSerializer.Serialize(request), System.Text.Encoding.UTF8, "application/json"));

            var result = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                throw new Exception(
                    JsonSerializer.Deserialize<ErrorMessage>(result, JsonOpt.options).Message);

            response.EnsureSuccessStatusCode();
        }
        public async Task BorrarEquipo(long Id)
        {
            var uri = "Equipo/" + Id.ToString();
            HttpResponseMessage response = await _httpClient.DeleteAsync(uri);

            var result = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                throw new Exception(
                    JsonSerializer.Deserialize<ErrorMessage>(result, JsonOpt.options).Message);

            response.EnsureSuccessStatusCode();
        }

        


    }
}
