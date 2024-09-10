using AutoMapper;
using InformacionCrud.Server.Models;
using InformacionCrud.Server.Repositorio.Interface;
using InformacionCrud.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InformacionCrud.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VictimaController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IMetodoVictima _Victima;

		public VictimaController(IMapper mapper, IMetodoVictima Victima)
		{
			_mapper = mapper;
			_Victima = Victima;
		}

		[HttpGet("Consulta")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> ConsultaVictima()
		{
			var _apiResponse = new ResponseAPI<List<VictimaDTO>>();

			try
			{
				List<Victima> listaVictima = await _Victima.ListarVictima();

				_apiResponse.Resultado = _mapper.Map<List<VictimaDTO>>(listaVictima);
				_apiResponse.CodigoEstado = HttpStatusCode.OK;
				_apiResponse.EsExitoso = true;
			}
			catch (Exception ex)
			{
				_apiResponse.EsExitoso = false;
				_apiResponse.MensajesError = new List<string> { ex.ToString() };
				_apiResponse.MensajeError = ex.Message;
			}

			return Ok(_apiResponse);
		}

		[HttpGet("Obtener/{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> BuscarVictima(int id)
		{
			var _apiResponse = new ResponseAPI<VictimaDTO>();

			try
			{
				if (id == 0)
				{
					_apiResponse.CodigoEstado = HttpStatusCode.BadRequest;
					_apiResponse.EsExitoso = false;
					return BadRequest(_apiResponse);
				}

				var victima = await _Victima.BuscarVictima(id);

				if (victima == null)
				{
					_apiResponse.CodigoEstado = HttpStatusCode.NotFound;
					_apiResponse.EsExitoso = false;
					return NotFound(_apiResponse);
				}

				_apiResponse.Resultado = _mapper.Map<VictimaDTO>(victima);
				_apiResponse.CodigoEstado = HttpStatusCode.OK;
				_apiResponse.EsExitoso = true;
			}
			catch (Exception ex)
			{
				_apiResponse.EsExitoso = false;
				_apiResponse.MensajesError = new List<string> { ex.ToString() };
				_apiResponse.MensajeError = ex.Message;
			}

			return Ok(_apiResponse);
		}

		[HttpPost("Agregar")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> CrearCiudadano(VictimaDTO victimaDTO)
		{
			var _apiResponse = new ResponseAPI<string>();

			try
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}

				if (victimaDTO == null)
				{
					return BadRequest(victimaDTO);
				}

				Victima victima = _mapper.Map<Victima>(victimaDTO);
				await _Victima.CrearVictima(victima);

				_apiResponse.Resultado = "Ejecucion Correcta";
				_apiResponse.CodigoEstado = HttpStatusCode.Created;
				_apiResponse.EsExitoso = true;
			}
			catch (Exception ex)
			{
				_apiResponse.EsExitoso = false;
				_apiResponse.MensajesError = new List<string> { ex.ToString() };
				_apiResponse.MensajeError = ex.Message;
			}

			return Ok(_apiResponse);
		}

		[HttpPut("Editar/{id:int}")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> EditarVictima(VictimaDTO victimaDTO, int id)
		{
			var _apiResponse = new ResponseAPI<string>();

			try
			{
				if (victimaDTO == null || id != victimaDTO.Idvictimas)
				{
					_apiResponse.CodigoEstado = HttpStatusCode.BadRequest;
					_apiResponse.EsExitoso = false;
					return BadRequest(victimaDTO);
				}

				Victima victima = _mapper.Map<Victima>(victimaDTO);
				await _Victima.EditarVictima(victima);

				_apiResponse.Resultado = "Ejecucion Correcta";
				_apiResponse.CodigoEstado = HttpStatusCode.NoContent;
				_apiResponse.EsExitoso = true;

				return Ok(_apiResponse);
			}
			catch (Exception ex)
			{
				_apiResponse.EsExitoso = false;
				_apiResponse.MensajesError = new List<string> { ex.ToString() };
				_apiResponse.MensajeError = ex.Message;
			}

			return BadRequest(_apiResponse);
		}

		[HttpDelete("Eliminar/{id:int}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> EliminarVictima(int id)
		{
			var _apiResponse = new ResponseAPI<string>();

			try
			{
				if (id == 0)
				{
					_apiResponse.CodigoEstado = HttpStatusCode.BadRequest;
					_apiResponse.EsExitoso = false;
					return BadRequest(_apiResponse);
				}

				var victima = await _Victima.BuscarVictima(id);

				if (victima == null)
				{
					_apiResponse.CodigoEstado = HttpStatusCode.NotFound;
					_apiResponse.EsExitoso = false;
					return NotFound(_apiResponse);
				}

				await _Victima.BorrarVictima(victima);

				_apiResponse.Resultado = "Ejecucion Correcta";
				_apiResponse.CodigoEstado = HttpStatusCode.NoContent;
				_apiResponse.EsExitoso = true;

				return Ok(_apiResponse);
			}
			catch (Exception ex)
			{
				_apiResponse.EsExitoso = false;
				_apiResponse.MensajesError = new List<string> { ex.ToString() };
				_apiResponse.MensajeError = ex.Message;
			}

			return BadRequest(_apiResponse);
		}
	}
}

