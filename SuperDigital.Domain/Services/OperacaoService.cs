using AutoMapper;
using SuperDigital.Domain.Arguments;
using SuperDigital.Domain.Arguments.Conta;
using SuperDigital.Domain.Entities;
using SuperDigital.Domain.Interfaces.Service;
using System.Threading.Tasks;

namespace SuperDigital.Domain.Services
{
    public class OperacaoService : IOperacaoService
    {
        private readonly IContaService _contaService;
        private readonly ILancamentoService _lancamentoService;

        public OperacaoService(IContaService contaService, ILancamentoService lancamentoService)
        {
            _contaService = contaService;
            _lancamentoService = lancamentoService;

            try
            {
                Mapper.Initialize(cfg => {
                    cfg.CreateMap<Conta, ContaArgument>();
                    cfg.CreateMap<Operacao, OperacaoArgument>();
                });
            }
            catch (System.Exception)
            {
            }

        }

        public async Task<OperacaoArgument> RealizaTransacao(OperacaoArgument operacao)
        {
            var contaOrigem = await _contaService.SetaSaldoInicial(await _contaService.Criar(operacao.ContaOrigem), 1000);
            var contaDestino = await _contaService.SetaSaldoInicial(await _contaService.Criar(operacao.ContaDestino), 1500);

            return await _lancamentoService.EfetuaLancamento(contaOrigem, contaDestino, operacao.TipoOpercao, operacao.Valor);
        }

        

    }
}
