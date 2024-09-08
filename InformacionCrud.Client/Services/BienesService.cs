using InformacionCrud.Shared;
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
    }
}
