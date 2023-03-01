using KalikBank.Titular;

namespace KalikBank.Contas
{
    public class ContaCorrente
    {
        private static int _totalContas { get; set; }
        public int Id { get; set; }
        public Cliente Titular { get; set; }
        public string Senha { get; set; }
        public string Conta { get; set; }
        public int Agencia { get; set; }
        public int Senha4 { get; set; }
        public double Saldo { get; private set; }
        public double Caixa { get; set; }

        public ContaCorrente(Cliente titular, string conta, int agencia)
        {
            Titular = titular;
            Conta = conta;
            Agencia = agencia;
            Id = ++_totalContas;
        }

        public ContaCorrente(Cliente titular, string conta, int agencia, double saldo) : this(titular, conta, agencia)
        {
            if (saldo < 0)
            {
                saldo = 0;
            }
            Saldo = saldo;
        }

        public void Deposito(double valor)
        {
            if (valor <= 0)
            {
                Console.WriteLine("Valor Inválido");
            }
            else
            {
                Saldo += valor;
            }
        }

        public void Saque(double valor)
        {
            if (valor <= Saldo && valor > 0)
            {
                Saldo -= valor;
            }
            else
            {
                Console.WriteLine("Saldo insuficiente");
            }
        }

        public void Transferencia(double valor, ContaCorrente destino)
        {
            if (valor <= Saldo && valor > 0)
            {
                Saque(valor);
                destino.Deposito(valor);
            }
            else
            {
                Console.WriteLine("Saldo insuficiente");
            }
        }

        public override string ToString()
        {
            return $"{Id} - Nome: {Titular.Nome}\nConta: {Conta}\nAgência: {Agencia}\nSaldo: {Saldo:F2} KLK";
        }
    }
}

