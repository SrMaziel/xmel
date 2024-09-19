using InformacionCrud.Shared;
using System.Net;
using System.Net.Http.Json;

namespace InformacionCrud.Client.Services
{
    public class TiposDelitoService : ITiposDelitoService

    {
        private readonly HttpClient _http;

        public TiposDelitoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<TiposdelitoDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<TiposdelitoDTO>>>("api/Tiposdelitos/Consulta");

            if (result!.EsExitoso == true)
            {
                List<TiposdelitoDTO> lista = result.Resultado;
                return lista;
            }
            else
            {
                throw new Exception(result.MensajeError);
            }
        }


        public async Task<TiposdelitoDTO> Buscar(int id)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<TiposdelitoDTO>>($"api/Tiposdelitos/Obtener/{id}");

            if (result!.EsExitoso == true)
            {
                TiposdelitoDTO tiposdelito = result.Resultado;

                return tiposdelito;
            }
            else
            {
                throw new Exception(result.MensajeError);
            }
        }


        public async Task<string> Guardar(TiposdelitoDTO tiposdelito)
        {
            var result = await _http.PostAsJsonAsync("api/Tiposdelitos/Agregar", tiposdelito);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.CodigoEstado == HttpStatusCode.Created && response!.EsExitoso == true)
                return response.Resultado!;
            else
                throw new Exception(response.MensajeError);
        }


        public async Task<string> Editar(TiposdelitoDTO tiposdelito, int id)
        {
            var result = await _http.PutAsJsonAsync($"api/Tiposdelitos/Editar/{id}", tiposdelito);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.CodigoEstado == HttpStatusCode.NoContent && response!.EsExitoso == true)
                return response.Resultado!;
            else
                throw new Exception(response.MensajeError);
        }


        public async Task<string> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/Tiposdelitos/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.CodigoEstado == HttpStatusCode.NoContent && response!.EsExitoso == true)
                return response.Resultado;
            else
                throw new Exception(response.MensajeError);
        }

    }
}
