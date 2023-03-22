using KalikBank.Contas;
using KalikBank.ExceptionPersonalizada;
using KalikBank.Titular;
using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        List<ContaCorrente> contas = new List<ContaCorrente>();
        try
        {
            contas.Add(new ContaCorrente(new Cliente("Felipe Elias", "434.543.321-40", "Desenvolvedor"), "54376-5", 96, 2050));
            contas.Add(new ContaCorrente(new Cliente("Gilberto Key", "455.742.211-20", "Engenheiro"), "65123-4", 96, 4300));
            contas.Add(new ContaCorrente(new Cliente("Shayne Thompson", "434.776.765-60", "UX Designer"), "43265-2", -96, 150));
            contas.Add(new ContaCorrente(new Cliente("Margot Adams", "321.356.434-50", "Analista"), "96554-5", 96));
        }
        catch (ArgumentException e)
        {
            Console.WriteLine("Parâmetro de erro: " + e.ParamName);
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
        }

        bool flag = true;

        /*
        foreach (var i in contas)
        {
            Console.WriteLine(i + "\n\n");
        }
        */

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
                    try
                    {
                        origem.Deposito(valor);
                    }
                    catch (TransferenciaNegativaException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    Console.WriteLine($"\nConta:\n{origem}\n");

                }
                else if (opcoes == 2)
                {
                    try
                    {
                        origem.Saque(valor);
                    }
                    catch (SaldoInsuficienteException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (TransferenciaNegativaException e)
                    {
                        Console.WriteLine(e.Message);
                    }

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

                    try
                    {
                        origem.Transferencia(valor, destino);
                    }
                    catch (SaldoInsuficienteException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (TransferenciaNegativaException e)
                    {
                        Console.WriteLine(e.Message);
                    }

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