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
    public class PenaImpuestaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMetodoPenaImpuesta _repositorio;

        public PenaImpuestaController(IMapper mapper, IMetodoPenaImpuesta repositorio)
        {
            _mapper = mapper;
            _repositorio = repositorio;
        }

        [HttpGet("Consulta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultarPenaimpuesta()
        {
            var _apiResponse = new ResponseAPI<List<PenaimpuestaDTO>>();

            try
            {
                List<Penaimpuestum> lista = await _repositorio.ListarPenaImpuesta();

                _apiResponse.Resultado = _mapper.Map<List<PenaimpuestaDTO>>(lista);
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
