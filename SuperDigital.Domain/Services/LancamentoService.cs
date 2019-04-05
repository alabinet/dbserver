using AutoMapper;
using SuperDigital.Domain.Arguments;
using SuperDigital.Domain.Arguments.Conta;
using SuperDigital.Domain.Entities;
using SuperDigital.Domain.Enums;
using SuperDigital.Domain.Interfaces.Repository;
using SuperDigital.Domain.Interfaces.Service;
using System;
using System.Threading.Tasks;

namespace SuperDigital.Domain.Services
{
    public class LancamentoService : ILancamentoService
    {
        private readonly IContaService _contaService;
        private readonly ILancamentoRepository _lancamentoRepository;

        public LancamentoService(IContaService contaService, ILancamentoRepository lancamentoRepository)
        {
            _contaService = contaService;
            _lancamentoRepository = lancamentoRepository;
        }

        public async Task<OperacaoArgument> EfetuaLancamento(ContaArgument contaOrigem, ContaArgument contaDestino, TipoOperacao tipoOperacao, decimal valor)
        {
            ContaArgument origem = new ContaArgument();
            ContaArgument destino = new ContaArgument();

            if (contaOrigem.Agencia == contaDestino.Agencia && contaOrigem.ContaNumero == contaDestino.ContaNumero)
                throw new ArgumentException("Agencia de origem não pode ser a mesma de destino");

            if (tipoOperacao == TipoOperacao.Credito)
            {
               origem =  await _contaService.Creditar(contaOrigem, valor);
               destino = await _contaService.Debitar(contaDestino, valor);
            }

            if (tipoOperacao == TipoOperacao.Debito)
            {
                origem= await _contaService.Debitar(contaOrigem, valor);
                destino= await _contaService.Creditar(contaDestino, valor);
            }

            var operacao = new Operacao
            {
                ContaOrigem = Mapper.Map<Conta>(origem),
                ContaDestino = Mapper.Map<Conta>(destino),
                DataRegistroOperacao = DateTime.Now,
                Tipo = tipoOperacao
            };


            await _lancamentoRepository.RegistraLancamento(operacao);

            return Mapper.Map<OperacaoArgument>(operacao);

        }
    }
}
