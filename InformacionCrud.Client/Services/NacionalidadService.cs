using InformacionCrud.Shared;
using System.Net.Http.Json;

namespace InformacionCrud.Client.Services
{
    public class NacionalidadService : INacionalidadService
    {
        private readonly HttpClient _http;

        public NacionalidadService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<NacionalidadDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<NacionalidadDTO>>>("api/Nacionalidad/Consulta");

            if (result!.EsExitoso == true)
            {
                List<NacionalidadDTO> lista = result.Resultado;
                return lista;
            }
            else
            {
                throw new Exception(result.MensajeError);
            }
        }
    }
}
