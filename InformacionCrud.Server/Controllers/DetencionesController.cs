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
    public class DetencionesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMetodoDetenciones _repositorio;

        public DetencionesController(IMapper mapper, IMetodoDetenciones repositorio)
        {
            _mapper = mapper;
            _repositorio = repositorio;
        }

        [HttpGet("Consulta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultarDetenciones()
        {
            var _apiResponse = new ResponseAPI<List<DetencionesDTO>>();

            try
            {
                List<Detencione> lista = await _repositorio.ListarDetenciones();

                _apiResponse.Resultado = _mapper.Map<List<DetencionesDTO>>(lista);
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
