using InformacionCrud.Shared;
using System.Net;
using System.Net.Http.Json;

namespace InformacionCrud.Client.Services
{
    public class DocumentoCiudadanoService : IDocumentoCiudadanoService
    {
        private readonly HttpClient _http;

        public DocumentoCiudadanoService(HttpClient http)
        {
            _http = http;
        }


        public async Task<List<DocumentoCiudadanoDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<DocumentoCiudadanoDTO>>>("api/Documentociudadano/Consulta");

            if (result!.EsExitoso == true)
            {
                List<DocumentoCiudadanoDTO> lista = result.Resultado;
                return lista;
            }
            else
            {
                throw new Exception(result.MensajeError);
            }
        }


        public async Task<DocumentoCiudadanoDTO> Buscar(int id)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<DocumentoCiudadanoDTO>>($"api/Documentociudadano/Obtener/{id}");

            if (result!.EsExitoso == true)
            {
                DocumentoCiudadanoDTO documentociudadano = result.Resultado;

                return documentociudadano;
            }
            else
            {
                throw new Exception(result.MensajeError);
            }
        }


        public async Task<string> Guardar(DocumentoCiudadanoDTO documentociudadano)
        {
            var result = await _http.PostAsJsonAsync("api/Documentociudadano/Agregar", documentociudadano);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.CodigoEstado == HttpStatusCode.Created && response!.EsExitoso == true)
                return response.Resultado!;
            else
                throw new Exception(response.MensajeError);
        }


        public async Task<string> Editar(DocumentoCiudadanoDTO documentociudadano, int id)
        {
            var result = await _http.PutAsJsonAsync($"api/Documentociudadano/Editar/{id}", documentociudadano);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.CodigoEstado == HttpStatusCode.NoContent && response!.EsExitoso == true)
                return response.Resultado!;
            else
                throw new Exception(response.MensajeError);
        }


        public async Task<string> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/Documentociudadano/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.CodigoEstado == HttpStatusCode.NoContent && response!.EsExitoso == true)
                return response.Resultado;
            else
                throw new Exception(response.MensajeError);
        }
    }
}
