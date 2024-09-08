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
    public class TipoDocumentoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMetodoTipoDocumento _repositorio;

        public TipoDocumentoController(IMapper mapper, IMetodoTipoDocumento repositorio)
        {
            _mapper = mapper;
            _repositorio = repositorio;
        }

        [HttpGet("Consulta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultaTipoDocumento()
        {
            var _apiResponse = new ResponseAPI<List<TipodocumentoDTO>>();

            try
            {
                List<Tipodocumento> lista = await _repositorio.ListarTipoDocumento();

                _apiResponse.Resultado = _mapper.Map<List<TipodocumentoDTO>>(lista);
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
    }
}
