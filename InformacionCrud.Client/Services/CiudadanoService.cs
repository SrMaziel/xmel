using InformacionCrud.Shared;
using System.Net;
using System.Net.Http.Json;

namespace InformacionCrud.Client.Services
{
    public class CiudadanoService : ICiudadanoService
    {
        private readonly HttpClient _http;

        public CiudadanoService(HttpClient http)
        {
            _http = http;
        }


        public async Task<List<CiudadanoDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<CiudadanoDTO>>>("api/Ciudadano/Consulta");

            if (result!.EsExitoso == true)
            {
                List<CiudadanoDTO> lista = result.Resultado;
                return lista;
            }
            else
            {
                throw new Exception(result.MensajeError);
            }
        }


        public async Task<CiudadanoDTO> Buscar(int id)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<CiudadanoDTO>>($"api/Ciudadano/Obtener/{id}");

            if (result!.EsExitoso == true)
            {
                CiudadanoDTO ciudadano = result.Resultado;

                return ciudadano;
            }
            else
            {
                throw new Exception(result.MensajeError);
            }
        }


        public async Task<string> Guardar(CiudadanoDTO ciudadano)
        {
            var result = await _http.PostAsJsonAsync("api/Ciudadano/Agregar", ciudadano);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.CodigoEstado == HttpStatusCode.Created && response!.EsExitoso == true)
                return response.Resultado!;
            else
                throw new Exception(response.MensajeError);
        }


        public async Task<string> Editar(CiudadanoDTO ciudadano, int id)
        {
            var result = await _http.PutAsJsonAsync($"api/Ciudadano/Editar/{id}", ciudadano);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.CodigoEstado == HttpStatusCode.NoContent && response!.EsExitoso == true)
                return response.Resultado!;
            else
                throw new Exception(response.MensajeError);
        }


        public async Task<string> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/Ciudadano/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.CodigoEstado == HttpStatusCode.NoContent && response!.EsExitoso == true)
                return response.Resultado;
            else
                throw new Exception(response.MensajeError);
        }
       
    }
}
