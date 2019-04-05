using SuperDigital.Domain.Arguments.Conta;
using SuperDigital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperDigital.Domain.Interfaces.Service
{
    public interface IContaService
    {
        Task<ContaArgument> Criar(ContaArgument conta);
        Task<ContaArgument> Creditar(ContaArgument conta, decimal valor);
        Task<ContaArgument> Debitar(ContaArgument conta, decimal valor);
        Task<ContaArgument> SetaSaldoInicial(ContaArgument conta, decimal valor);
    }
}
