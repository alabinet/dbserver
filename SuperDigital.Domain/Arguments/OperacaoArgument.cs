using SuperDigital.Domain.Arguments.Conta;
using SuperDigital.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.Domain.Arguments
{
    public class OperacaoArgument
    {
        public ContaArgument ContaOrigem { get; set; }
        public ContaArgument ContaDestino { get; set; }
        public TipoOperacao TipoOpercao { get; set; }
        public decimal Valor { get; set; }
    }
}
