using SuperDigital.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.Domain.Entities
{
    public class Operacao
    {
        public Conta ContaOrigem { get; set; }

        public Conta ContaDestino { get; set; }

        public TipoOperacao Tipo { get; set; }

        public DateTime DataRegistroOperacao { get; set; }
    }
}
