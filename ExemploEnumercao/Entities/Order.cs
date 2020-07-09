using System;
using ExemploEnumercao.Entities.Enums;

namespace ExemploEnumercao.Entities
{
    class Order
    {
        public int Id { get; set; }
        public DateTime Moment { get; set; }
        //Enumeração, trabalhando com diversas atributos que representam o mesmo status
        //Exemplo dias: segunda, terça, quarta etc..
        //Exemplo pedido: pagamento pendente, processando, enviado, entregue
        //Exemplo FutIngresso: jogo disponivel, jogo indisponivel 
        public OrderStatus Status { get; set; }

        public override string ToString()
        {
            return Id + ", " + Moment + ", " + Status;
        }
    }
}
