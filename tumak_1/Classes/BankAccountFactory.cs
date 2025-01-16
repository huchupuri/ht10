using hw10.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace hw10.Classes
{
    internal class BankAccountFactory
    {
        public static Hashtable accounts = new Hashtable();
        public uint CreatBankAccount()
        {
            BankAccount bankAccount = new BankAccount();
            accounts.Add(bankAccount.GetID(), bankAccount);
            return bankAccount.GetID();
        }
        public uint CreatBankAccount(decimal balance)
        {
            BankAccount bankAccount = new BankAccount(balance);
            accounts.Add(bankAccount.GetID(), bankAccount);
            return bankAccount.GetID();
        }
        public uint CreatBankAccount(AccountType? accountType)
        {
            BankAccount bankAccount = new BankAccount(accountType);
            accounts.Add(bankAccount.GetID(), bankAccount);
            return bankAccount.GetID();
        }
        public uint CreatBankAccount(decimal balance, AccountType? accountType)
        {
            BankAccount bankAccount = new BankAccount(balance, accountType);
            accounts.Add(bankAccount.GetID(), bankAccount);
            return bankAccount.GetID();
        }
        public static void CloseAccount(uint id)
        {
            accounts.Remove(id);
        }
    }
}
