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
    public class TipoCiudadanoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMetodoTipoCiudadano _repositorio;

        public TipoCiudadanoController(IMapper mapper, IMetodoTipoCiudadano repositorio)
        {
            _mapper = mapper;
            _repositorio = repositorio;
        }

        [HttpGet("Consulta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultaTipoCiudadano()
        {
            var _apiResponse = new ResponseAPI<List<TiposciudadanoDTO>>();

            try
            {
                List<Tiposciudadano> lista = await _repositorio.ListarTipoCiudadano();

                _apiResponse.Resultado = _mapper.Map<List<TiposciudadanoDTO>>(lista);
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
