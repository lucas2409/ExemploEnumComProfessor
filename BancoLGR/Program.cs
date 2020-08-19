using System;
using System.Globalization;
using BancoLGR.Entities;

namespace BancoLGR
{
    class Program
    {
        static void Main(string[] args)
        {
            int validador = 1;
            
            ContaCorrente cc = new ContaCorrente();

            while (validador == 1)
            {
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                Console.WriteLine("------------------------------- Bem vindo ao LGR Bank - Terminal ------------------------------------");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                Console.WriteLine("Digite 1 para administrador ou 2 para cliente:");
                int tipoAcesso = int.Parse(Console.ReadLine());
                
               
                //tudo o que for pertinente ao banco
                if (tipoAcesso == 1)
                {
                    Console.WriteLine("Qual operação deseja fazer?");
                    Console.WriteLine("1 - Criar conta");
                    Console.WriteLine("2 - Excluir conta");
                    int oper = int.Parse(Console.ReadLine());
                    if (oper == 1)
                    {
                        Console.WriteLine("Informe quantas contas irá criar");
                        int cont = int.Parse(Console.ReadLine());

                        for (int i = 0; i < cont; i++)
                        {
                            Console.Write("Digite o Nome: ");
                            string nome = Console.ReadLine();
                            Console.Write("Digite o CPF: ");
                            string cpf = Console.ReadLine();
                            Console.Write("Digite o Número da Conta: ");
                            int conta = int.Parse(Console.ReadLine());
                            Console.Write("Digite o Saldo: ");
                            double saldo = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                            Console.Write("Digite o Limite: ");
                            double limite = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                            Console.Write("Digite a Tarifa do Saque: ");
                            double tarifa = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                            ContaCorrente c1 = new ContaCorrente(nome, cpf, conta, saldo, limite, tarifa);

                            cc.AddConta(c1);
                        }
                    }
                    else if (oper == 2)
                    {
                        Console.WriteLine("Digite a conta que deseja excluir: ");
                        int conta = int.Parse(Console.ReadLine());

                        ContaCorrente c1 = cc.PesquisaNumConta(conta);

                        if (c1.NumConta == conta)
                        {
                            cc.RemoveConta(c1);
                            Console.WriteLine("Conta excluída");
                        }
                        else
                        {
                            Console.WriteLine("Erro: Conta Não localizada");
                        }
                    }
                }
                //tudo o que for pertinente ao cliente
                else if (tipoAcesso == 2)
                {
                    Console.WriteLine("Digite o Número da operação desejada: ");
                    Console.WriteLine("1 - para Saque");
                    Console.WriteLine("2 - para Transferência");
                    Console.WriteLine("3 - para depósito");
                    int oper = int.Parse(Console.ReadLine());
                    if (oper == 1)
                    {
                        Console.Write("Digite o número da Conta: ");
                        int conta = int.Parse(Console.ReadLine());
                        Console.Write("Digite o valor do saque: ");
                        double valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                        ContaCorrente c1 = cc.PesquisaNumConta(conta);
                        Console.WriteLine("Saldo Anterior ao saque: " + c1.Saldo.ToString("F2", CultureInfo.InvariantCulture));

                        if(c1.NumConta == conta)
                        {
                            c1.Saque(valor);
                            Console.WriteLine("Saldo após o saque: " + c1.Saldo.ToString("F2", CultureInfo.InvariantCulture));
                        }
                        else
                        {
                            Console.WriteLine("Erro: Conta não localizada.");
                        }
                    }
                    else if (oper == 2)
                    {
                        Console.Write("Digite o numero da conta que irá transferir: ");
                        int contaenv = int.Parse(Console.ReadLine());
                        Console.Write("Digite o número da conta que irá receber: ");
                        int contarec = int.Parse(Console.ReadLine());
                        Console.Write("Digite o valor a ser enviado: ");
                        double valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                        ContaCorrente c1 = cc.PesquisaNumConta(contaenv);
                        ContaCorrente c2 = cc.PesquisaNumConta(contarec);

                        if (c1.NumConta == contaenv && c2.NumConta == contarec)
                        {
                            Console.WriteLine("Saldo conta que irá transferir: " + c1.Saldo);
                            Console.WriteLine("Saldo conta que irá receber: " + c2.Saldo);

                            bool confirmar = cc.Transferencia(c1, c2, valor);

                            if (confirmar == true)
                            {
                                Console.WriteLine("Valor transferido entre contas!");
                                Console.WriteLine("Novo Saldo conta que irá transferir: " + c1.Saldo.ToString("F2"), CultureInfo.InvariantCulture);
                                Console.WriteLine("Novo Saldo conta que irá receber: " + c2.Saldo.ToString("F2"), CultureInfo.InvariantCulture);
                            }
                            else
                            {
                                Console.WriteLine("Erro ao transferir. Valide os valores");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Erro ao transferir. Conta não localizada");
                        }
                    }
                    else if (oper == 3)
                    {
                        Console.WriteLine("Digite o número da conta");
                        int conta = int.Parse(Console.ReadLine());
                        Console.WriteLine("Qual o valor a ser depositado?");
                        double valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                        ContaCorrente c = new ContaCorrente();

                        c = cc.PesquisaNumConta(conta);

                        if (conta == c.NumConta)
                        {
                            c.Deposito(valor);
                            Console.WriteLine("Valor depositado");
                            Console.WriteLine("Valor atual da conta: R$ " + c.Saldo);
                        }
                        else
                        {
                            Console.WriteLine("Erro: Conta não localizada");
                            Console.WriteLine("Valor não depositado");
                        }
                    }
                }
                Console.WriteLine("Digite 1 para continuar ou 2 para encerrar.");
                validador = int.Parse(Console.ReadLine());
                Console.Clear();
            }
            Console.WriteLine("Tecle qualquer tecla para encerrar");
        }
    }
}
