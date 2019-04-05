using SuperDigital.Domain.Arguments;
using SuperDigital.Domain.Arguments.Conta;
using SuperDigital.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperDigital.Domain.Interfaces.Service
{
    public interface ILancamentoService
    {
        Task<OperacaoArgument> EfetuaLancamento(ContaArgument contaOrigem, ContaArgument contaDestino, TipoOperacao tipoOperacao, decimal valor);
    }
}
