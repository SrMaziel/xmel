using InformacionCrud.Shared;
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
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<TiposdelitoDTO>>>("api/TiposDelitos/Consulta");

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
    }
}
