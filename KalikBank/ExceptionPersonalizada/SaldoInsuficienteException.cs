namespace KalikBank.ExceptionPersonalizada
{
    public class SaldoInsuficienteException : OperacaoFinanceiraException
    {
        public SaldoInsuficienteException(string message) : base(message)
        {
        }
    }
}
