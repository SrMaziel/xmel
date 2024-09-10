using InformacionCrud.Shared;
using System.Net;
using System.Net.Http.Json;

namespace InformacionCrud.Client.Services
{
    public class ArrestopolicialService : IArrestopolicialService
    {
        private readonly HttpClient _http;

        public ArrestopolicialService(HttpClient http)
        {
            _http = http;
        }


        public async Task<List<ArrestopolicialoDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<ArrestopolicialoDTO>>>("api/Arrestopolicial/Consulta");

            if (result!.EsExitoso == true)
            {
                List<ArrestopolicialoDTO> lista = result.Resultado;
                return lista;
            }
            else
            {
                throw new Exception(result.MensajeError);
            }
        }


        public async Task<ArrestopolicialoDTO> Buscar(int id)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<ArrestopolicialoDTO>>($"api/Arrestopolicial/Obtener/{id}");

            if (result!.EsExitoso == true)
            {
                ArrestopolicialoDTO arrestopolicialo = result.Resultado;

                return arrestopolicialo;
            }
            else
            {
                throw new Exception(result.MensajeError);
            }
        }


        public async Task<string> Guardar(ArrestopolicialoDTO arrestopolicialo)
        {
            var result = await _http.PostAsJsonAsync("api/Arrestopolicial/Agregar", arrestopolicialo);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.CodigoEstado == HttpStatusCode.Created && response!.EsExitoso == true)
                return response.Resultado!;
            else
                throw new Exception(response.MensajeError);
        }


        public async Task<string> Editar(ArrestopolicialoDTO arrestopolicialo, int id)
        {
            var result = await _http.PutAsJsonAsync($"api/Arrestopolicial/Editar/{id}", arrestopolicialo);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.CodigoEstado == HttpStatusCode.NoContent && response!.EsExitoso == true)
                return response.Resultado!;
            else
                throw new Exception(response.MensajeError);
        }


        public async Task<string> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/Arrestopolicial/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.CodigoEstado == HttpStatusCode.NoContent && response!.EsExitoso == true)
                return response.Resultado;
            else
                throw new Exception(response.MensajeError);
        }
    }
}
