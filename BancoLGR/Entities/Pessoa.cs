using System;
using System.Collections.Generic;
using System.Text;

namespace BancoLGR.Entities
{
    class Pessoa
    {
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public Pessoa()
        {

        }
        public Pessoa(string Nome, string CPF)
        {
            this.Nome = Nome;
            this.CPF = CPF;
        }

    }
}
