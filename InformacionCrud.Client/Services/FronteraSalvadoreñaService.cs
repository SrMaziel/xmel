using InformacionCrud.Shared;
using System.Net.Http.Json;

namespace InformacionCrud.Client.Services
{
    public class FronteraSalvadoreñaService : IFronteraSalvadoreñaService
    {
        private readonly HttpClient _http;

        public FronteraSalvadoreñaService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<FronterasalvadoreñaDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<FronterasalvadoreñaDTO>>>("api/FronteraSalvadoreña/Consulta");

            if (result!.EsExitoso == true)
            {
                List<FronterasalvadoreñaDTO> lista = result.Resultado;
                return lista;
            }
            else
            {
                throw new Exception(result.MensajeError);
            }
        }
    }
}
