using InformacionCrud.Shared;
using System.Net.Http.Json;

namespace InformacionCrud.Client.Services
{
    public class TipoCiudadanoService : ITipoCiudadanoService
    {
        private readonly HttpClient _http;

        public TipoCiudadanoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<TiposciudadanoDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<TiposciudadanoDTO>>>("api/TipoCiudadano/Consulta");

            if (result!.EsExitoso == true)
            {
                List<TiposciudadanoDTO> lista = result.Resultado;
                return lista;
            }
            else
            {
                throw new Exception(result.MensajeError);
            }
        }
    }
}
