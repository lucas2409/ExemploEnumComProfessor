using System;
using System.Collections.Generic;
using System.Text;

namespace BancoLGR.Entities
{
    class ContaPoupanca : Conta 
    {
        public double Juros { get; set; }

        public ContaPoupanca()
        {

        }

        public ContaPoupanca(string Nome, string CPF, int NumConta, double Saldo, double Juros, double TarifaSaque)
            : base(Nome, CPF, NumConta, Saldo, TarifaSaque)
        {
            this.Juros = Juros;
        }

        public void Redimentos()
        {
            Saldo = Saldo * Juros;
        }

    }
}
