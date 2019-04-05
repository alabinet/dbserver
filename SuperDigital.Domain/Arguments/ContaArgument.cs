using SuperDigital.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.Domain.Arguments.Conta
{
    public class ContaArgument
    {
        public string Banco { get; set; }
        public int Agencia { get; set; }
        public int ContaNumero { get; set; }
        public int Digito { get; set; }
        public TipoConta Tipo { get; set; }
        public decimal Saldo { get; set; }
    }
}
