using KalikBank.ExceptionPersonalizada;
using KalikBank.Titular;

namespace KalikBank.Contas
{
    public class ContaCorrente
    {
        public static int TotalContas { get; private set; }
        public static double TaxaOperacao { get; private set; }
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
            if (agencia <= 0)
            {
                throw new ArgumentException("Número de agência menor que zero", nameof(agencia));
            }

            Titular = titular;
            Conta = conta;
            Agencia = agencia;


            try
            {
                TaxaOperacao = 30 / TotalContas;
            }
            catch (DivideByZeroException)
            {
            }

            Id = ++TotalContas;

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
                throw new OperacaoFinanceiraException("Não é possível depositar valores negativos");
            }

            Saldo += valor;
        }

        public void Saque(double valor)
        {
            if (valor <= 0)
            {
                throw new TransferenciaNegativaException("Não é possível sacar valores negativos");
            }
            if (valor > Saldo)
            {
                throw new SaldoInsuficienteException("Saldo insuficiente para saque");
            }

            Saldo -= valor;
        }

        public void Transferencia(double valor, ContaCorrente destino)
        {
            if (valor <= 0)
            {
                throw new TransferenciaNegativaException("Não é possível transferir valores negativos");
            }
            if (valor > Saldo)
            {
                throw new SaldoInsuficienteException("Saldo insuficiente para transferência");
            }

            Saque(valor);
            destino.Deposito(valor);

        }

        public override string ToString()
        {
            return $"{Id} - Nome: {Titular.Nome}\nConta: {Conta}\nAgência: {Agencia}\nSaldo: {Saldo:F2} KLK";
        }
    }
}

