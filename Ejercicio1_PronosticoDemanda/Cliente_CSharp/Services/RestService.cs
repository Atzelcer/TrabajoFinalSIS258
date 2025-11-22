using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PronosticoDemandaCliente.Models;

namespace PronosticoDemandaCliente.Services
{
    public class RestService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public RestService(string baseUrl = "http://localhost:8000/api")
        {
            _baseUrl = baseUrl;
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(_baseUrl)
            };
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<List<Pronostico>> ObtenerTodosAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("/pronosticos");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<List<Pronostico>>>(content);

                return apiResponse?.Data ?? new List<Pronostico>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener pronósticos: {ex.Message}");
            }
        }

        public async Task<Pronostico?> ObtenerPorIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/pronosticos/{id}");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<Pronostico>>(content);

                return apiResponse?.Data;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener pronóstico: {ex.Message}");
            }
        }

        public async Task<Pronostico?> CrearAsync(string fecha, int cantidadEstimada)
        {
            try
            {
                var data = new
                {
                    fecha = fecha,
                    cantidad_estimada = cantidadEstimada
                };

                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/pronosticos", content);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<Pronostico>>(responseContent);

                return apiResponse?.Data;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear pronóstico: {ex.Message}");
            }
        }

        public async Task<Pronostico?> ActualizarAsync(int id, string fecha, int cantidadEstimada)
        {
            try
            {
                var data = new
                {
                    fecha = fecha,
                    cantidad_estimada = cantidadEstimada
                };

                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"/pronosticos/{id}", content);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<Pronostico>>(responseContent);

                return apiResponse?.Data;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar pronóstico: {ex.Message}");
            }
        }

        public async Task<bool> EliminarAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/pronosticos/{id}");
                response.EnsureSuccessStatusCode();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar pronóstico: {ex.Message}");
            }
        }
    }
}
