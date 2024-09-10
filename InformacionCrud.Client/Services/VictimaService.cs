using InformacionCrud.Shared;
using System.Net;
using System.Net.Http.Json;

namespace InformacionCrud.Client.Services
{
	public class VictimaService : IVictimaService
	{
		private readonly HttpClient _http;

		public VictimaService(HttpClient http)
		{
			_http = http;
		}

		public async Task<List<VictimaDTO>> Lista()
		{
			var result = await _http.GetFromJsonAsync<ResponseAPI<List<VictimaDTO>>>("api/Victima/Consulta");

			if (result!.EsExitoso == true)
			{
				List<VictimaDTO> lista = result.Resultado;
				return lista;
			}
			else
			{
				throw new Exception(result.MensajeError);
			}
		}

		public async Task<VictimaDTO> Buscar(int id)
		{
			var result = await _http.GetFromJsonAsync<ResponseAPI<VictimaDTO>>($"api/Victima/Obtener/{id}");

			if (result!.EsExitoso == true)
			{
				VictimaDTO victima = result.Resultado;
				return victima;
			}
			else
			{
				throw new Exception(result.MensajeError);
			}
		}

		public async Task<string> Guardar(VictimaDTO victima)
		{
			var result = await _http.PostAsJsonAsync("api/Victima/Agregar", victima);
			var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

			if (response!.CodigoEstado == HttpStatusCode.Created && response!.EsExitoso == true)
				return response.Resultado!;
			else
				throw new Exception(response.MensajeError);
		}

		public async Task<string> Editar(VictimaDTO victima, int id)
		{
			var result = await _http.PutAsJsonAsync($"api/Victima/Editar/{id}", victima);
			var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

			if (response!.CodigoEstado == HttpStatusCode.NoContent && response!.EsExitoso == true)
				return response.Resultado!;
			else
				throw new Exception(response.MensajeError);
		}

		public async Task<string> Eliminar(int id)
		{
			var result = await _http.DeleteAsync($"api/Victima/Eliminar/{id}");
			var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

			if (response!.CodigoEstado == HttpStatusCode.NoContent && response!.EsExitoso == true)
				return response.Resultado;
			else
				throw new Exception(response.MensajeError);
		}
	}
}