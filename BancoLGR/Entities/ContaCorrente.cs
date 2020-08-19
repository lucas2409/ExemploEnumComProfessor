using System;
using System.Collections.Generic;
using System.Text;

namespace BancoLGR.Entities
{
    class ContaCorrente : Conta
    {
        public double Limite { get; set; }
        public List<ContaCorrente> Item = new List<ContaCorrente>();
        
        public ContaCorrente()
        {

        }
        public ContaCorrente(string Nome, string CPF, int NumConta, double Saldo, double Limite,
            double TarifaSaque) : base(Nome, CPF, NumConta, Saldo, TarifaSaque)
        {
            this.Limite = Limite;
        }
        public void AddConta(ContaCorrente cc)
        {
            this.Item.Add(cc);
        }
        public void RemoveConta(ContaCorrente cc)
        {
            this.Item.Remove(cc);
        }
        public override void Saque(double valor)
        {

            double vlr = valor + TarifaSaque;
            base.Saque(vlr);
        }
        public ContaCorrente PesquisaNumConta(int cc)
        {
            ContaCorrente c1 = new ContaCorrente();
            foreach (ContaCorrente c in Item)
            {
                if(c.NumConta == cc)
                {
                    c1 = c;
                }
            }         
            return c1;
        }
        public bool Transferencia(ContaCorrente ccenvia, ContaCorrente ccrecebe, double valor)
        {
            bool valida = false;
            foreach (ContaCorrente c1 in Item)
            {
                if (c1 == ccenvia)
                {
                    if (ccenvia.Saldo >= valor)
                    {
                        foreach (ContaCorrente c2 in Item)
                        {
                            if (c2 == ccrecebe)
                            {
                                if(ccenvia.Saldo >= valor)
                                {
                                    ccenvia.Saldo -= valor;
                                    ccrecebe.Saldo += valor;
                                    valida = true;
                                }
                                else
                                {
                                    valida = false;
                                }
                            }
                        }
                    }
                }
            }
            return valida;
        }
    }
}
