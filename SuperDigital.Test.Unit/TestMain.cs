using AutoMapper;
using SuperDigital.Domain.Arguments;
using SuperDigital.Domain.Arguments.Conta;
using SuperDigital.Domain.Entities;
using SuperDigital.Domain.Enums;
using SuperDigital.Domain.Interfaces.Repository;
using SuperDigital.Domain.Interfaces.Service;
using SuperDigital.Domain.Services;
using SuperDigital.Infra;
using System;
using System.Threading.Tasks;
using Xunit;

namespace SuperDigital.Test.Unit
{
    public class MainTest
    {
        private readonly IContaService _contaService;
        private readonly ILancamentoService _lancamentoService;
        private readonly ILancamentoRepository _lancamentoRepository;

        private ContaArgument _dadosContaOrigem;
        private ContaArgument _dadosContaDestino;

        public MainTest()
        {
            try
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Conta, ContaArgument>();
                    cfg.CreateMap<Operacao, OperacaoArgument>();
                });
            }
            catch (InvalidOperationException)
            {
                //Mapper já inicializado!!! Segue a vida!
            }

            _lancamentoRepository = new LancamentoRepository();
            _contaService = new ContaService();
            _lancamentoService = new LancamentoService(_contaService, _lancamentoRepository);


            //CRIA AS CONTAS E GERA UM SALDO INICIAL PARA TESTE
            _dadosContaOrigem = CriaConta("Santander", 2300, 10000001, 1, TipoConta.Corrente, 1000);
            _dadosContaDestino = CriaConta("Santander", 2300, 20000002, 3, TipoConta.Corrente, 1500);

        }

      
        //VALIDA DEPÓSITO DE 500 NA CONTA ORIGEM
        //SALDO INICIAL CONTA ORIGEM: 1000, CONTA DESTINO: 1500, DEVE CREDITAR 500 NA ORIGEM E RETIRAR 500 NO DESTINO
        [Fact]
        public async Task TestaOperacaoCredito()
        {
            var contaOrigem = await _contaService.Criar(_dadosContaOrigem);
            var contaDestino = await _contaService.Criar(_dadosContaDestino);
            var resultOperacao = await _lancamentoService.EfetuaLancamento(contaOrigem, contaDestino, TipoOperacao.Credito, 500);

            Assert.Equal(1500, resultOperacao.ContaOrigem.Saldo);
            Assert.Equal(1000, resultOperacao.ContaDestino.Saldo);
        }


        //VALIDA DÉBITO DE 500 NA CONTA ORIGEM
        //SALDO INICIAL CONTA ORIGEM: 1000, CONTA DESTINO: 1500, DEVE DEBITAR 500 NA ORIGEM E CREDITAR 500 NO DESTINO
        [Fact]
        public async Task TestaOperacaoDebito()
        {
            var contaOrigem = await _contaService.Criar(_dadosContaOrigem);
            var contaDestino = await _contaService.Criar(_dadosContaDestino);
            var resultOperacao = await _lancamentoService.EfetuaLancamento(contaOrigem, contaDestino, TipoOperacao.Debito, 500);

            Assert.Equal(500, resultOperacao.ContaOrigem.Saldo);
            Assert.Equal(2000, resultOperacao.ContaDestino.Saldo);
        }

        private ContaArgument CriaConta(string banco, int agencia, int contaNumero, int digito, TipoConta tipo, decimal saldo)
        {
            return new ContaArgument
            {
                Banco = banco,
                Agencia = agencia,
                ContaNumero = contaNumero,
                Digito = digito,
                Tipo = tipo,
                Saldo = saldo
            };
        }

    }
}
