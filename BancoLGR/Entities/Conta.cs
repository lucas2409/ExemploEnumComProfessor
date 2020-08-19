using System;
using System.Collections.Generic;
using System.Text;

namespace BancoLGR.Entities
{
    class Conta : Pessoa
    {
        public int NumConta { get; set; }
        public double Saldo { get; protected set; }
        public double TarifaSaque { get; set; }


        public Conta() { }

        public Conta(string Nome, string CPF, int NumConta, double Saldo, double TarifaSaque) : base(Nome, CPF)
        {
            this.NumConta = NumConta;
            this.Saldo = Saldo;
            this.TarifaSaque = TarifaSaque;
        }
        public void Deposito(double valor)
        {
            Saldo += valor;
        }
        public virtual void Saque(double valor)
        {
            Saldo -= valor;
        }

    }
}
