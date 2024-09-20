using InformacionCrud.Shared;
using System.Net;
using System.Net.Http.Json;


namespace InformacionCrud.Client.Services
{
    public class PenaImpuestaService : IPenaImpuestaService
    {

        private readonly HttpClient _http;

        public PenaImpuestaService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<PenaimpuestaDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<PenaimpuestaDTO>>>("api/Penaimpuesta/Consulta");

            if (result!.EsExitoso == true)
            {
                List<PenaimpuestaDTO> lista = result.Resultado;
                return lista;
            }
            else
            {
                throw new Exception(result.MensajeError);
            }
        }


        public async Task<PenaimpuestaDTO> Buscar(int id)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<PenaimpuestaDTO>>($"api/Penaimpuesta/Obtener/{id}");

            if (result!.EsExitoso == true)
            {
                PenaimpuestaDTO penaimpuesta = result.Resultado;

                return penaimpuesta;
            }
            else
            {
                throw new Exception(result.MensajeError);
            }
        }


        public async Task<string> Guardar(PenaimpuestaDTO PenaimpuestaDTO)
        {
            var result = await _http.PostAsJsonAsync("api/Penaimpuesta/Agregar", PenaimpuestaDTO);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.CodigoEstado == HttpStatusCode.Created && response!.EsExitoso == true)
                return response.Resultado!;
            else
                throw new Exception(response.MensajeError);
        }


        public async Task<string> Editar(PenaimpuestaDTO penaimpuesta, int id)
        {
            var result = await _http.PutAsJsonAsync($"api/Penaimpuesta/Editar/{id}", penaimpuesta);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.CodigoEstado == HttpStatusCode.NoContent && response!.EsExitoso == true)
                return response.Resultado!;
            else
                throw new Exception(response.MensajeError);
        }


        public async Task<string> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/Penaimpuesta/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.CodigoEstado == HttpStatusCode.NoContent && response!.EsExitoso == true)
                return response.Resultado;
            else
                throw new Exception(response.MensajeError);
        }

    }
}


