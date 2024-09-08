using InformacionCrud.Shared;
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
    }

}