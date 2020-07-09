using System;
using ExemploEnumercao.Entities;
using ExemploEnumercao.Entities.Enums;

namespace ExemploEnumercao
{
    class Program
    {
        static void Main(string[] args)
        {
            // instanciando Classe Order
            Order order = new Order
            {
                Id = 1080,
                Moment = DateTime.Now,
                Status = OrderStatus.PendingPayment
            };

            Console.WriteLine(order);

            //convertendo uma enumeração para string
            string txt = OrderStatus.PendingPayment.ToString();
            Console.WriteLine(txt);

            //covertendo uma string para enumeração, 3 exemplos de converção
            //1
            OrderStatus os = Enum.Parse<OrderStatus>("Delivered");
            //2
            OrderStatus os1 = (OrderStatus)Enum.Parse(typeof(OrderStatus), "Delivered");
            //3
            OrderStatus os2;
            Enum.TryParse("Delivered", out os2);
            
            Console.WriteLine();
            Console.WriteLine(os);
            Console.WriteLine();
            Console.WriteLine(os1);
            Console.WriteLine();
            Console.WriteLine(os2);
        }
    }
}
