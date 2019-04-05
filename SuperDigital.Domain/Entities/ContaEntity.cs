using SuperDigital.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.Domain.Entities
{
    public class Conta : Base.EntityBase
    {
        public Conta(string banco, int agencia, int contaNumero, int digito, TipoConta tipo, decimal saldo)
        {
            Banco = banco;
            Agencia = agencia;
            ContaNumero = contaNumero;
            Digito = digito;
            Tipo = tipo;
            Saldo = saldo;
        }

        public string Banco { get; protected set; }

        public int Agencia { get; protected set; }

        public int ContaNumero { get; protected set; }

        public int Digito { get; protected set; }

        public TipoConta Tipo { get; protected set; }

        public decimal Saldo { get; protected set; }
    }
}
