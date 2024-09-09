using AutoMapper;
using InformacionCrud.Server.Models;
using InformacionCrud.Server.Repositorio.Interface;
using InformacionCrud.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InformacionCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfraccionesCiudadanoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMetodoInfraccionesCiudadano _infraccionesciudadano;

        public InfraccionesCiudadanoController(IMapper mapper, IMetodoInfraccionesCiudadano infraccionesciudadano)
        {
            _mapper = mapper;
            _infraccionesciudadano = infraccionesciudadano;
        }



        [HttpGet("Consulta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultaInfraccionesCiudadano()
        {
            var _apiResponse = new ResponseAPI<List<InfraccionesCiudadanoDTO>>();

            try
            {
                List<Infraccionesciudadano> listaInfraccionesCiudadano = await _infraccionesciudadano.ListarInfracciones();
                _apiResponse.Resultado = _mapper.Map<List<InfraccionesCiudadanoDTO>>(listaInfraccionesCiudadano);
                _apiResponse.CodigoEstado = HttpStatusCode.OK;
                _apiResponse.EsExitoso = true;

            }
            catch (Exception ex)
            {
                _apiResponse.EsExitoso = false;
                _apiResponse.MensajesError = new List<string>() { ex.ToString() };
                _apiResponse.MensajeError = ex.Message;
            }

            return Ok(_apiResponse);
        }

        //----------------------------------------------------------------------------------------------------

        [HttpGet("Obtener/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuscarInfracciones(int id)
        {
            var _apiResponse = new ResponseAPI<InfraccionesCiudadanoDTO>();

            try
            {
                if (id == 0)
                {
                    _apiResponse.CodigoEstado = HttpStatusCode.BadRequest;
                    _apiResponse.EsExitoso = false;
                    return BadRequest(_apiResponse);
                }

                var infraccionesciudadano = await _infraccionesciudadano.BuscarInfracciones(id);

                if (infraccionesciudadano == null)
                {
                    _apiResponse.CodigoEstado = HttpStatusCode.NotFound;
                    _apiResponse.EsExitoso = false;
                    return NotFound(_apiResponse);
                }

                _apiResponse.Resultado = _mapper.Map<InfraccionesCiudadanoDTO>(infraccionesciudadano);
                _apiResponse.CodigoEstado = HttpStatusCode.OK;
                _apiResponse.EsExitoso = true;

            }
            catch (Exception ex)
            {
                _apiResponse.EsExitoso = false;
                _apiResponse.MensajesError = new List<string>() { ex.ToString() };
                _apiResponse.MensajeError = ex.Message;
            }

            return Ok(_apiResponse);
        }

        //----------------------------------------------------------------------------------------------------

        [HttpPost("Agregar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CrearInfracciones(InfraccionesCiudadanoDTO infraccionesciudadanoDTO)
        {
            var _apiResponse = new ResponseAPI<string>();

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (infraccionesciudadanoDTO == null)
                {
                    return BadRequest(infraccionesciudadanoDTO);
                }

                Infraccionesciudadano infraccionesciudadano = _mapper.Map<Infraccionesciudadano>(infraccionesciudadanoDTO);
                await _infraccionesciudadano.CrearInfracciones(infraccionesciudadano);

                _apiResponse.Resultado = "Ejecucion Correcta";
                _apiResponse.CodigoEstado = HttpStatusCode.Created;
                _apiResponse.EsExitoso = true;

            }
            catch (Exception ex)
            {
                _apiResponse.EsExitoso = false;
                _apiResponse.MensajesError = new List<string>() { ex.ToString() };
                _apiResponse.MensajeError = ex.Message;
            }

            return Ok(_apiResponse);

        }

        //----------------------------------------------------------------------------------------------------

        [HttpPut("Editar/{id:int}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EditarInfracciones(InfraccionesCiudadanoDTO infraccionesciudadanoDTO, int id)
        {
            var _apiResponse = new ResponseAPI<string>();

            try
            {

                if (infraccionesciudadanoDTO == null || id != infraccionesciudadanoDTO.Idinfraccionesciudadano)
                {
                    _apiResponse.CodigoEstado = HttpStatusCode.BadRequest;
                    _apiResponse.EsExitoso = false;
                    return BadRequest(infraccionesciudadanoDTO);
                }

                Infraccionesciudadano infraccionesciudadano= _mapper.Map<Infraccionesciudadano>(infraccionesciudadanoDTO);
                await _infraccionesciudadano.EditarInfracciones(infraccionesciudadano);

                _apiResponse.Resultado = "Ejecucion Correcta";
                _apiResponse.CodigoEstado = HttpStatusCode.NoContent;
                _apiResponse.EsExitoso = true;

                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.EsExitoso = false;
                _apiResponse.MensajesError = new List<string>() { ex.ToString() };
                _apiResponse.MensajeError = ex.Message;
            }

            return BadRequest(_apiResponse);

        }

        //----------------------------------------------------------------------------------------------------

        [HttpDelete("Eliminar/{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BorrarInfracciones(int id)
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

                var infraccionesciudadano = await _infraccionesciudadano.BuscarInfracciones(id);

                if (infraccionesciudadano == null)
                {
                    _apiResponse.CodigoEstado = HttpStatusCode.NotFound;
                    _apiResponse.EsExitoso = false;
                    return NotFound(_apiResponse);
                }

                await _infraccionesciudadano.BorrarInfracciones(infraccionesciudadano);

                _apiResponse.Resultado = "Ejecucion Correcta";
                _apiResponse.CodigoEstado = HttpStatusCode.NoContent;
                _apiResponse.EsExitoso = true;

                return Ok(_apiResponse);

            }
            catch (Exception ex)
            {
                _apiResponse.EsExitoso = false;
                _apiResponse.MensajesError = new List<string>() { ex.ToString() };
                _apiResponse.MensajeError = ex.Message;
            }

            return BadRequest(_apiResponse);
        }
    }
}
