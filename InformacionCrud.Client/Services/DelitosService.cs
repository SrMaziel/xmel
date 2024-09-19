using InformacionCrud.Shared;
using System.Net;
using System.Net.Http.Json;

namespace InformacionCrud.Client.Services
{
    public class DelitosService : IDelitosService
    {
        private readonly HttpClient _http;

        public DelitosService(HttpClient http)
        {
            _http = http;
        }


        public async Task<List<DelitosDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<DelitosDTO>>>("api/Delitos/Consulta");

            if (result!.EsExitoso == true)
            {
                List<DelitosDTO> lista = result.Resultado;
                return lista;
            }
            else
            {
                throw new Exception(result.MensajeError);
            }
        }


        public async Task<DelitosDTO> Buscar(int id)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<DelitosDTO>>($"api/Delitos/Obtener/{id}");

            if (result!.EsExitoso == true)
            {
                DelitosDTO delitos = result.Resultado;

                return delitos;
            }
            else
            {
                throw new Exception(result.MensajeError);
            }
        }


        public async Task<string> Guardar(DelitosDTO delitos)
        {
            var result = await _http.PostAsJsonAsync("api/Delitos/Agregar", delitos);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.CodigoEstado == HttpStatusCode.Created && response!.EsExitoso == true)
                return response.Resultado!;
            else
                throw new Exception(response.MensajeError);
        }


        public async Task<string> Editar(DelitosDTO delitos, int id)
        {
            var result = await _http.PutAsJsonAsync($"api/Delitos/Editar/{id}", delitos);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.CodigoEstado == HttpStatusCode.NoContent && response!.EsExitoso == true)
                return response.Resultado!;
            else
                throw new Exception(response.MensajeError);
        }


        public async Task<string> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/Delitos/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.CodigoEstado == HttpStatusCode.NoContent && response!.EsExitoso == true)
                return response.Resultado;
            else
                throw new Exception(response.MensajeError);
        }

    }
}
