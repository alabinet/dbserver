using AutoMapper;
using SuperDigital.Domain.Arguments.Conta;
using SuperDigital.Domain.Entities;
using SuperDigital.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperDigital.Domain.Services
{
    public class ContaService : IContaService
    {
        public ContaService()
        {
        }

        public async Task<ContaArgument> Criar(ContaArgument conta)
        {
            if (conta == null)
                throw new ArgumentException("É necessário informar o nome do banco, agência, conta, dígito e o tipo de conta (corrente/poupança).");

            if (string.IsNullOrEmpty(conta.Banco))
                throw new ArgumentException("O nome do banco é requerido.");

            if (conta.Agencia < 0 || conta.Agencia.ToString().Length != 4)
                throw new ArgumentException("Número da agência esta inválido.");

            if (conta.ContaNumero < 0 || conta.ContaNumero.ToString().Length > 8)
                throw new ArgumentException("Número da conta esta inválido.");

            if (conta.Digito < 0 || conta.Digito.ToString().Length != 1)
                throw new ArgumentException("Número do digíto da conta esta inválido.");

            if (string.IsNullOrEmpty(conta.Tipo.ToString()))
                throw new ArgumentException("Deve ser informado o tipo de conta: Corrente ou Poupança.");

            return Mapper.Map<ContaArgument>( new Conta(conta.Banco,conta.Agencia,conta.ContaNumero,conta.Digito,conta.Tipo, conta.Saldo));

        }

        public async Task<ContaArgument> SetaSaldoInicial(ContaArgument conta, decimal valor)
        {
            conta.Saldo = valor;
            return conta;
        }

        public async Task<ContaArgument> Creditar(ContaArgument conta, decimal valor)
        {
            if (valor < 0)
                throw new ArgumentException("Não é permitido depósito com valor negativo.");

            conta.Saldo = conta.Saldo + valor;
            return conta;
        }

        public async Task<ContaArgument> Debitar(ContaArgument conta, decimal valor)
        {
            if (valor < 0)
                throw new ArgumentException("Não é permitido depósito com valor negativo.");

            conta.Saldo = conta.Saldo - valor;
            return conta;

        }
    }
}
