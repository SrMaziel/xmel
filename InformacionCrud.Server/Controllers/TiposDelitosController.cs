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
    public class TiposDelitosController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMetodoTiposDelito _tiposdelitos;

        public TiposDelitosController(IMapper mapper, IMetodoTiposDelito tiposdelito)
        {
            _mapper = mapper;
            _tiposdelitos = tiposdelito;
        }



        [HttpGet("Consulta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultaTiposdelitos()
        {
            var _apiResponse = new ResponseAPI<List<TiposdelitoDTO>>();

            try
            {
                List<Tiposdelito> listaTiposdelitos = await _tiposdelitos.ListarTiposdelitos();

                _apiResponse.Resultado = _mapper.Map<List<TiposdelitoDTO>>(listaTiposdelitos);
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
        public async Task<IActionResult> BuscarTiposdelitos(int id)
        {
            var _apiResponse = new ResponseAPI<TiposdelitoDTO>();

            try
            {
                if (id == 0)
                {
                    _apiResponse.CodigoEstado = HttpStatusCode.BadRequest;
                    _apiResponse.EsExitoso = false;
                    return BadRequest(_apiResponse);
                }

                var tiposdelito = await _tiposdelitos.BuscarTiposdelitos(id);

                if (tiposdelito == null)
                {
                    _apiResponse.CodigoEstado = HttpStatusCode.NotFound;
                    _apiResponse.EsExitoso = false;
                    return NotFound(_apiResponse);
                }

                _apiResponse.Resultado = _mapper.Map<TiposdelitoDTO>(tiposdelito);
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
        public async Task<IActionResult> Creartipodelito(TiposdelitoDTO tiposdelitoDTO)
        {
            var _apiResponse = new ResponseAPI<string>();

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (tiposdelitoDTO == null)
                {
                    return BadRequest(tiposdelitoDTO);
                }

                Tiposdelito tiposdelito = _mapper.Map<Tiposdelito>(tiposdelitoDTO);
                await _tiposdelitos.CrearTiposdelitos(tiposdelito);

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
        public async Task<IActionResult> Editartiposdelito(TiposdelitoDTO tiposdelitoDTO, int id)
        {
            var _apiResponse = new ResponseAPI<string>();

            try
            {

                if (tiposdelitoDTO == null || id != tiposdelitoDTO.Idtiposdelitos)
                {
                    _apiResponse.CodigoEstado = HttpStatusCode.BadRequest;
                    _apiResponse.EsExitoso = false;
                    return BadRequest(tiposdelitoDTO);
                }

                Tiposdelito tiposdelito = _mapper.Map<Tiposdelito>(tiposdelitoDTO);
                await _tiposdelitos.EditarTiposdelitos(tiposdelito);

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
        public async Task<IActionResult> EliminarCiudadano(int id)
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

                var tipodelito = await _tiposdelitos.BuscarTiposdelitos(id);

                if (tipodelito == null)
                {
                    _apiResponse.CodigoEstado = HttpStatusCode.NotFound;
                    _apiResponse.EsExitoso = false;
                    return NotFound(_apiResponse);
                }

                await _tiposdelitos.BorrarTiposdelitos(tipodelito);

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

