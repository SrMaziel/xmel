using InformacionCrud.Shared;
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
    }
}


