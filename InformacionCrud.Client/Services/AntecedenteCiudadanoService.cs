using InformacionCrud.Shared;
using System.Net;
using System.Net.Http.Json;

namespace InformacionCrud.Client.Services
{
    public class AntecedenteCiudadanoService : IAntecedenteCiudadanoService
    {
        private readonly HttpClient _http;

        public AntecedenteCiudadanoService(HttpClient http)
        {
            _http = http;
        }


        public async Task<List<AntecentesciudadanoDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<AntecentesciudadanoDTO>>>("api/Antecedenteciudadano/Consulta");

            if (result!.EsExitoso == true)
            {
                List<AntecentesciudadanoDTO> lista = result.Resultado;
                return lista;
            }
            else
            {
                throw new Exception(result.MensajeError);
            }
        }

        public async Task<List<AntecentesciudadanoDTO>> Busqueda(string data)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<AntecentesciudadanoDTO>>>($"api/Antecedenteciudadano/Busqueda/{data}");

            if (result!.EsExitoso == true)
            {
                List<AntecentesciudadanoDTO> lista = result.Resultado;
                return lista;
            }
            else
            {
                throw new Exception(result?.MensajeError);
            }
        }


        public async Task<AntecentesciudadanoDTO> Buscar(int id)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<AntecentesciudadanoDTO>>($"api/Antecedenteciudadano/Obtener/{id}");

            if (result!.EsExitoso == true)
            {
                AntecentesciudadanoDTO antecentesciudadano = result.Resultado;

                return antecentesciudadano;
            }
            else
            {
                throw new Exception(result.MensajeError);
            }
        }


        public async Task<string> Guardar(AntecentesciudadanoDTO antecentesciudadano)
        {
            var result = await _http.PostAsJsonAsync("api/Antecedenteciudadano/Agregar", antecentesciudadano);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.CodigoEstado == HttpStatusCode.Created && response!.EsExitoso == true)
                return response.Resultado!;
            else
                throw new Exception(response.MensajeError);
        }


        public async Task<string> Editar(AntecentesciudadanoDTO antecentesciudadano, int id)
        {
            var result = await _http.PutAsJsonAsync($"api/Antecedenteciudadano/Editar/{id}", antecentesciudadano);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.CodigoEstado == HttpStatusCode.NoContent && response!.EsExitoso == true)
                return response.Resultado!;
            else
                throw new Exception(response.MensajeError);
        }


        public async Task<string> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/Antecedenteciudadano/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.CodigoEstado == HttpStatusCode.NoContent && response!.EsExitoso == true)
                return response.Resultado;
            else
                throw new Exception(response.MensajeError);
        }
    }
}
