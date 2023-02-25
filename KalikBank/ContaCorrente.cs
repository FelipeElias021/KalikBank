namespace KalikBank
{
    public class ContaCorrente
    {
        public int Id { get; set; }
        public string Titular { get; set; }
        public int Idade { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Conta { get; set; }
        public int Agencia { get; set; }
        public int Senha4 { get; set; }
        public double Saldo { get; set; }
        public double Caixa { get; set; }

        public ContaCorrente(string titular, string conta, int agencia, double saldo)
        {
            Titular = titular;
            Conta = conta;
            Agencia = agencia;
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
            return $"Nome: {Titular}\nConta: {Conta}\nAgência: {Agencia}\nSaldo: {Saldo:F2} KLK";
        }
    }
}

