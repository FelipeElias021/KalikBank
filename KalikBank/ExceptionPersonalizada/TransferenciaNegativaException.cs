using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalikBank.ExceptionPersonalizada
{
    public class TransferenciaNegativaException : OperacaoFinanceiraException
    {
        public TransferenciaNegativaException(string message) : base(message) { }
    }
}
