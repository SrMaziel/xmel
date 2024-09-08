using InformacionCrud.Shared;
using System.Net.Http.Json;

namespace InformacionCrud.Client.Services
{
    public class TipoDocumentoService : ITipoDocumentoService
    {
        private readonly HttpClient _http;

        public TipoDocumentoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<TipodocumentoDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<TipodocumentoDTO>>>("api/TipoDocumento/Consulta");

            if (result!.EsExitoso == true)
            {
                List<TipodocumentoDTO> lista = result.Resultado;
                return lista;
            }
            else
            {
                throw new Exception(result.MensajeError);
            }
        }
    }
}
