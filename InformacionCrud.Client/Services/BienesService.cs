using InformacionCrud.Shared;
using System.Net;
using System.Net.Http.Json;

namespace InformacionCrud.Client.Services
{
    public class BienesService : IBienesService
    {
        private readonly HttpClient _http;

        public BienesService(HttpClient http)
        {
            _http = http;
        }


        public async Task<List<BienesDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<BienesDTO>>>("api/Bienes/Consulta");

            if (result!.EsExitoso == true)
            {
                List<BienesDTO> lista = result.Resultado;
                return lista;
            }
            else
            {
                throw new Exception(result.MensajeError);
            }
        }


        public async Task<BienesDTO> Buscar(int id)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<BienesDTO>>($"api/Bienes/Obtener/{id}");

            if (result!.EsExitoso == true)
            {
                BienesDTO bienes = result.Resultado;

                return bienes;
            }
            else
            {
                throw new Exception(result.MensajeError);
            }
        }


        public async Task<string> Guardar(BienesDTO bienes)
        {
            var result = await _http.PostAsJsonAsync("api/Bienes/Agregar", bienes);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.CodigoEstado == HttpStatusCode.Created && response!.EsExitoso == true)
                return response.Resultado!;
            else
                throw new Exception(response.MensajeError);
        }


        public async Task<string> Editar(BienesDTO bienes, int id)
        {
            var result = await _http.PutAsJsonAsync($"api/Bienes/Editar/{id}", bienes);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.CodigoEstado == HttpStatusCode.NoContent && response!.EsExitoso == true)
                return response.Resultado!;
            else
                throw new Exception(response.MensajeError);
        }


        public async Task<string> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/Bienes/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.CodigoEstado == HttpStatusCode.NoContent && response!.EsExitoso == true)
                return response.Resultado;
            else
                throw new Exception(response.MensajeError);
        }

    }
}

