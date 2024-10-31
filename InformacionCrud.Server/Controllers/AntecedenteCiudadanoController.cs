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
    public class AntecedenteCiudadanoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMetodoAntecedenteCiudadano _antecedenteciudadano;

        public AntecedenteCiudadanoController(IMapper mapper, IMetodoAntecedenteCiudadano antecedenteciudadano)
        {
            _mapper = mapper;
            _antecedenteciudadano = antecedenteciudadano;
        }



        [HttpGet("Consulta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultaCiudadano()
        {
            var _apiResponse = new ResponseAPI<List<AntecentesciudadanoDTO>>();

            try
            {
                List<Antecedentesciudadano> listaAntecedentesciudadano = await _antecedenteciudadano.ListarAntecedenteCiudadano();

                _apiResponse.Resultado = _mapper.Map<List<AntecentesciudadanoDTO>>(listaAntecedentesciudadano);
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
       
        
        [HttpGet("Busqueda/{data}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> BusquedaAntecedentes(string data)
        {
            var _apiResponse = new ResponseAPI<List<AntecentesciudadanoDTO>>();

            try
            {
                List<Antecedentesciudadano> listaAntecedenteciudadano = await _antecedenteciudadano.ListarAntecedentesPorBusqueda(data);

                _apiResponse.Resultado = _mapper.Map<List<AntecentesciudadanoDTO>>(listaAntecedenteciudadano);
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
        public async Task<IActionResult> BuscarAntecedenteCiudadano(int id)
        {
            var _apiResponse = new ResponseAPI<AntecentesciudadanoDTO>();

            try
            {
                if (id == 0)
                {
                    _apiResponse.CodigoEstado = HttpStatusCode.BadRequest;
                    _apiResponse.EsExitoso = false;
                    return BadRequest(_apiResponse);
                }

                var antecedentesciudadano = await _antecedenteciudadano.BuscarAntecedenteCiudadano(id);

                if (antecedentesciudadano == null)
                {
                    _apiResponse.CodigoEstado = HttpStatusCode.NotFound;
                    _apiResponse.EsExitoso = false;
                    return NotFound(_apiResponse);
                }

                _apiResponse.Resultado = _mapper.Map<AntecentesciudadanoDTO>(antecedentesciudadano);
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
        public async Task<IActionResult> CrearAntecedenteCiudadano(AntecentesciudadanoDTO antecentesciudadanoDTO)
        {
            var _apiResponse = new ResponseAPI<string>();

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (antecentesciudadanoDTO == null)
                {
                    return BadRequest(antecentesciudadanoDTO);
                }

                Antecedentesciudadano antecedentesciudadano = _mapper.Map<Antecedentesciudadano>(antecentesciudadanoDTO);
                await _antecedenteciudadano.CrearAntecedenteCiudadano(antecedentesciudadano);

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
        public async Task<IActionResult> EditarAntecedenteCiudadano(AntecentesciudadanoDTO antecentesciudadanoDTO, int id)
        {
            var _apiResponse = new ResponseAPI<string>();

            try
            {

                if (antecentesciudadanoDTO == null || id != antecentesciudadanoDTO.Idantecedentesciudadano)
                {
                    _apiResponse.CodigoEstado = HttpStatusCode.BadRequest;
                    _apiResponse.EsExitoso = false;
                    return BadRequest(antecentesciudadanoDTO);
                }

                Antecedentesciudadano antecedentesciudadano = _mapper.Map<Antecedentesciudadano>(antecentesciudadanoDTO);
                await _antecedenteciudadano.EditarAntecedenteCiudadano(antecedentesciudadano);

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
        public async Task<IActionResult> BorrarAntecedenteCiudadano(int id)
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

                var antecedentesciudadano = await _antecedenteciudadano.BuscarAntecedenteCiudadano(id);

                if (antecedentesciudadano == null)
                {
                    _apiResponse.CodigoEstado = HttpStatusCode.NotFound;
                    _apiResponse.EsExitoso = false;
                    return NotFound(_apiResponse);
                }

                await _antecedenteciudadano.BorrarAntecedenteCiudadano(antecedentesciudadano);

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
