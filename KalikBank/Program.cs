using KalikBank;
using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        List<ContaCorrente> contas = new List<ContaCorrente>();
        contas.Add(new ContaCorrente("Felipe Elias", "54376-5", 96, 2050));
        contas.Add(new ContaCorrente("Gilberto Key", "65123-4", 96, 14000));
        contas.Add(new ContaCorrente("Shayne Thompson", "43265-2", 96, 150));
        contas.Add(new ContaCorrente("Margot Adams", "96554-5", 96, 650));

        bool flag = true;

        while (flag)
        {
            Console.WriteLine("\n--- Kalik Bank ---");
            Console.WriteLine("1 - Depositar");
            Console.WriteLine("2 - Sacar");
            Console.WriteLine("3 - Tranferência");
            Console.WriteLine("4 - Limpar");
            Console.Write("5 - Sair\n> ");
            int opcoes = int.Parse(Console.ReadLine());

            if (opcoes == 5)
            {
                flag = false;
            }
            else if (opcoes == 4)
            {
                Console.Clear();
            }
            else if (opcoes != 1 && opcoes != 2 && opcoes != 3)
            {
                Console.WriteLine("Opção inválida");
            }
            else
            {
                Console.WriteLine("Informe a sua conta");
                ContaCorrente origem = getConta(contas);

                Console.Write("\nValor da movimentação: ");
                double valor = double.Parse(Console.ReadLine());

                if (opcoes == 1)
                {
                    origem.Deposito(valor);
                    Console.WriteLine($"\nConta:\n{origem}\n");

                }
                else if (opcoes == 2)
                {
                    origem.Saque(valor);
                    Console.WriteLine($"\nConta:\n{origem}\n");

                }
                else if (opcoes == 3)
                {
                    Console.WriteLine("Informe a conta de destino: ");
                    ContaCorrente destino = getConta(contas);
                    while (destino.Conta == origem.Conta)
                    {
                        Console.WriteLine("Números das contas iguais, digite uma diferente!");
                        Console.WriteLine("Informe a conta de destino: ");
                        destino = getConta(contas);
                    }


                    origem.Transferencia(valor, destino);
                    Console.WriteLine($"\nConta Origem:\n{origem}");
                    Console.WriteLine($"\nConta Destino:\n{destino}");

                }
            }

        }
    }

    static ContaCorrente getConta(List<ContaCorrente> list)
    {
        Console.Write("Digite a conta: ");
        string numeroConta = Console.ReadLine();

        ContaCorrente conta = list.Find(x => x.Conta == numeroConta);

        while (conta == null)
        {
            Console.WriteLine("Conta Inválida!");

            Console.Write("Digite a conta: ");
            numeroConta = Console.ReadLine();

            conta = list.Find(x => x.Conta == numeroConta);
        }

        return conta;
    }
}