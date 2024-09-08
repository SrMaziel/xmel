using InformacionCrud.Shared;
using System.Net;
using System.Net.Http.Json;

namespace InformacionCrud.Client.Services
{
    public class DenunciaService : IDenunciaService
    {
        private readonly HttpClient _http;

        public DenunciaService(HttpClient http)
        {
            _http = http;
        }



        public async Task<List<DenunciaDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<DenunciaDTO>>>("api/Denuncia/Consulta");

            if (result!.EsExitoso == true)
            {
                List<DenunciaDTO> lista = result.Resultado;
                return lista;
            }
            else
            {
                throw new Exception(result.MensajeError);
            }
        }





        public async Task<DenunciaDTO> Buscar(int id)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<DenunciaDTO>>($"api/Denuncia/Obtener/{id}");

            if (result!.EsExitoso == true)
            {
                DenunciaDTO denuncia = result.Resultado;

                return denuncia;
            }
            else
            {
                throw new Exception(result.MensajeError);
            }
        }





        public async Task<string> Guardar(DenunciaDTO denuncia)
        {
            var result = await _http.PostAsJsonAsync("api/Denuncia/Agregar", denuncia);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.CodigoEstado == HttpStatusCode.Created && response!.EsExitoso == true)
                return response.Resultado!;
            else
                throw new Exception(response.MensajeError);
        }





        public async Task<string> Editar(DenunciaDTO denuncia, int id)
        {
            var result = await _http.PutAsJsonAsync($"api/Denuncia/Editar/{id}", denuncia);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.CodigoEstado == HttpStatusCode.NoContent && response!.EsExitoso == true)
                return response.Resultado!;
            else
                throw new Exception(response.MensajeError);
        }





        public async Task<string> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/Denuncia/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.CodigoEstado == HttpStatusCode.NoContent && response!.EsExitoso == true)
                return response.Resultado;
            else
                throw new Exception(response.MensajeError);
        }

    }
}
