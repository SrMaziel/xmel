using InformacionCrud.Shared;
using System.Net.Http.Json;

namespace InformacionCrud.Client.Services
{
    public class DetencionService : IDetencionService
    {
        private readonly HttpClient _http;

        public DetencionService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<DetencionesDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<DetencionesDTO>>>("api/Detenciones/Consulta");

            if (result!.EsExitoso == true)
            {
                List<DetencionesDTO> lista = result.Resultado;
                return lista;
            }
            else
            {
                throw new Exception(result.MensajeError);
            }
        }
    }
}
