using SuperDigital.Domain.Arguments;
using SuperDigital.Domain.Arguments.Conta;
using SuperDigital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperDigital.Domain.Interfaces.Service
{
    public interface IOperacaoService
    {
        Task<OperacaoArgument> RealizaTransacao(OperacaoArgument argument);
    }
}
