using InformacionCrud.Shared;
using System.Net.Http.Json;

namespace InformacionCrud.Client.Services
{
    public class InfraccionesService : IInfraccionesService
    {
        private readonly HttpClient _http;

        public InfraccionesService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<InfraccionesDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<InfraccionesDTO>>>("api/Infracciones/Consulta");

            if (result!.EsExitoso == true)
            {
                List<InfraccionesDTO> lista = result.Resultado;
                return lista;
            }
            else
            {
                throw new Exception(result.MensajeError);
            }
        }
    }
}
