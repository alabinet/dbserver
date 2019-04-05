using Microsoft.AspNetCore.Mvc;
using SuperDigital.Domain.Arguments;
using SuperDigital.Domain.Interfaces.Service;
using System;
using System.Threading.Tasks;

namespace SuperDigital.Api.Controllers
{
    [Route("Conta")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly IOperacaoService _operacaoService ;

        public ContaController(IOperacaoService contaService)
        {
            _operacaoService = contaService;
        }

        [HttpPost("EfetuaLancamento")]
        public async Task<IActionResult> EfetuaLancamento([FromBody] OperacaoArgument operacao)
        {
            try
            {
                await _operacaoService.RealizaTransacao(operacao);
                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }

}