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
    public class DocumentoCiudadanoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMetodoDocumentoCiudadano _documentociudadano;

        public DocumentoCiudadanoController(IMapper mapper, IMetodoDocumentoCiudadano documentociudadano)
        {
            _mapper = mapper;
            _documentociudadano = documentociudadano;
        }



        [HttpGet("Consulta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultaDocumentos()
        {
            var _apiResponse = new ResponseAPI<List<DocumentoCiudadanoDTO>>();

            try
            {
                List<Documentosciudadano> listaDocumentociudadano = await _documentociudadano.ListarDocumentos();

                _apiResponse.Resultado = _mapper.Map<List<DocumentoCiudadanoDTO>>(listaDocumentociudadano);
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
        public async Task<IActionResult> BuscarDocumentos(int id)
        {
            var _apiResponse = new ResponseAPI<DocumentoCiudadanoDTO>();

            try
            {
                if (id == 0)
                {
                    _apiResponse.CodigoEstado = HttpStatusCode.BadRequest;
                    _apiResponse.EsExitoso = false;
                    return BadRequest(_apiResponse);
                }

                var documentociudadano = await _documentociudadano.BuscarDocumentos(id);

                if (documentociudadano == null)
                {
                    _apiResponse.CodigoEstado = HttpStatusCode.NotFound;
                    _apiResponse.EsExitoso = false;
                    return NotFound(_apiResponse);
                }

                _apiResponse.Resultado = _mapper.Map<DocumentoCiudadanoDTO>(documentociudadano);
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
        public async Task<IActionResult> CrearDocumentos(DocumentoCiudadanoDTO documentociudadanoDTO)
        {
            var _apiResponse = new ResponseAPI<string>();

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (documentociudadanoDTO == null)
                {
                    return BadRequest(documentociudadanoDTO);
                }

                Documentosciudadano documentosciudadano = _mapper.Map<Documentosciudadano>(documentociudadanoDTO);
                await _documentociudadano.CrearDocumentos(documentosciudadano);

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
        public async Task<IActionResult> EditarCiudadano(DocumentoCiudadanoDTO documentociudadanoDTO, int id)
        {
            var _apiResponse = new ResponseAPI<string>();

            try
            {

                if (documentociudadanoDTO == null || id != documentociudadanoDTO.Iddocumentosciudadanos)
                {
                    _apiResponse.CodigoEstado = HttpStatusCode.BadRequest;
                    _apiResponse.EsExitoso = false;
                    return BadRequest(documentociudadanoDTO);
                }

                Documentosciudadano documentosciudadano = _mapper.Map<Documentosciudadano>(documentociudadanoDTO);
                await _documentociudadano.EditarDocumentos(documentosciudadano);

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
        public async Task<IActionResult> EliminarDocumentos(int id)
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

                var documentosciudadano = await _documentociudadano.BuscarDocumentos(id);

                if (documentosciudadano == null)
                {
                    _apiResponse.CodigoEstado = HttpStatusCode.NotFound;
                    _apiResponse.EsExitoso = false;
                    return NotFound(_apiResponse);
                }

                await _documentociudadano.BorrarDocumentos(documentosciudadano);

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
