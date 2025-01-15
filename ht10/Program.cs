using MyLibrary;
using System;

namespace ht10
{
    class Program
    {
        static void Main()
        {
            List<uint> accounts = new List<uint>()
            {
                new BankAccountFactory().CreatBankAccount(),
                new BankAccountFactory().CreatBankAccount(1000),
                new BankAccountFactory().CreatBankAccount(1000, AccountType.debit),
                new BankAccountFactory().CreatBankAccount(AccountType.debit)
            };
            foreach (uint account in accounts)
            {
                Console.WriteLine(BankAccountFactory.accounts[account]);
            }

        }
    }
}