using InformacionCrud.Shared;
using System.Net;
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


        public async Task<InfraccionesDTO> Buscar(int id)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<InfraccionesDTO>>($"api/Infracciones/Obtener/{id}");

            if (result!.EsExitoso == true)
            {
                InfraccionesDTO infracciones = result.Resultado;

                return infracciones;
            }
            else
            {
                throw new Exception(result.MensajeError);
            }
        }


        public async Task<string> Guardar(InfraccionesDTO infracciones)
        {
            var result = await _http.PostAsJsonAsync("api/Infracciones/Agregar", infracciones);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.CodigoEstado == HttpStatusCode.Created && response!.EsExitoso == true)
                return response.Resultado!;
            else
                throw new Exception(response.MensajeError);
        }


        public async Task<string> Editar(InfraccionesDTO infracciones, int id)
        {
            var result = await _http.PutAsJsonAsync($"api/Infracciones/Editar/{id}", infracciones);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.CodigoEstado == HttpStatusCode.NoContent && response!.EsExitoso == true)
                return response.Resultado!;
            else
                throw new Exception(response.MensajeError);
        }


        public async Task<string> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/Infracciones/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.CodigoEstado == HttpStatusCode.NoContent && response!.EsExitoso == true)
                return response.Resultado;
            else
                throw new Exception(response.MensajeError);
        }

    }
}
