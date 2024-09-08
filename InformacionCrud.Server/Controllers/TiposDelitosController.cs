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
        private readonly IMetodoTiposDelito _repositorio;

        public TiposDelitosController(IMapper mapper, IMetodoTiposDelito repositorio)
        {
            _mapper = mapper;
            _repositorio = repositorio;
        }

        [HttpGet("Consulta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultaTipoDocumento()
        {
            var _apiResponse = new ResponseAPI<List<TiposdelitoDTO>>();

            try
            {
                List<Tiposdelito> lista = await _repositorio.ListarTiposDelitos();

                _apiResponse.Resultado = _mapper.Map<List<TiposdelitoDTO>>(lista);
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

