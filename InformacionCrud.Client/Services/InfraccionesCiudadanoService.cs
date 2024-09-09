using InformacionCrud.Shared;
using System.Net;
using System.Net.Http.Json;

namespace InformacionCrud.Client.Services
{
    public class InfraccionesCiudadanoService : IInfraccionesCiudadanoService
    {
        private readonly HttpClient _http;

        public InfraccionesCiudadanoService(HttpClient http)
        {
            _http = http;
        }


        public async Task<List<InfraccionesCiudadanoDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<InfraccionesCiudadanoDTO>>>("api/Infraccionesciudadano/Consulta");

            if (result!.EsExitoso == true)
            {
                List<InfraccionesCiudadanoDTO> lista = result.Resultado;
                return lista;
            }
            else
            {
                throw new Exception(result.MensajeError);
            }
        }


        public async Task<InfraccionesCiudadanoDTO> Buscar(int id)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<InfraccionesCiudadanoDTO>>($"api/Infraccionesciudadano/Obtener/{id}");

            if (result!.EsExitoso == true)
            {
                InfraccionesCiudadanoDTO infraccionesciudadano = result.Resultado;

                return infraccionesciudadano;
            }
            else
            {
                throw new Exception(result.MensajeError);
            }
        }


        public async Task<string> Guardar(InfraccionesCiudadanoDTO infraccionesciudadano)
        {
            var result = await _http.PostAsJsonAsync("api/Infraccionesciudadano/Agregar", infraccionesciudadano);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.CodigoEstado == HttpStatusCode.Created && response!.EsExitoso == true)
                return response.Resultado!;
            else
                throw new Exception(response.MensajeError);
        }


        public async Task<string> Editar(InfraccionesCiudadanoDTO infraccionesciudadano, int id)
        {
            var result = await _http.PutAsJsonAsync($"api/Infraccionesciudadano/Editar/{id}", infraccionesciudadano);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.CodigoEstado == HttpStatusCode.NoContent && response!.EsExitoso == true)
                return response.Resultado!;
            else
                throw new Exception(response.MensajeError);
        }


        public async Task<string> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/Infraccionesciudadano/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.CodigoEstado == HttpStatusCode.NoContent && response!.EsExitoso == true)
                return response.Resultado;
            else
                throw new Exception(response.MensajeError);
        }
    }
}
