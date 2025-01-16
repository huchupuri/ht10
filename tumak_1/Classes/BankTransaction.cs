using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw10.Classes
{
    internal class BankTransaction
    {
        public readonly DateTime transactionDate;
        public readonly decimal Amount;

        public BankTransaction(decimal Amount)
        {
            this.transactionDate = DateTime.Now;
            this.Amount = Amount;
        }
    }
}
