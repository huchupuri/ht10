using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hw10.Enums;

namespace hw10.Classes
{
    class BankAccount : IDisposable
    {
        public uint id;
        public static uint autoID = 0;
        public decimal? balance;
        public AccountType? accountType;
        private Queue<BankTransaction> transactions = new Queue<BankTransaction>();
        private bool disposed = false;
        /// <summary>
        /// пустой конструктор 
        /// </summary>
        internal BankAccount()
        {
            this.id = GenerateID();
            this.balance = null;
            this.accountType = null;
        }
        /// <summary>
        /// конструктор с балансом
        /// </summary>
        internal BankAccount(decimal balance)
        {
            this.id = GenerateID();
            this.balance = balance;
            this.accountType = null;
        }

        /// <summary>
        /// конструктор с типом аккаунта
        /// </summary>
        internal BankAccount(AccountType? accountType)
        {
            this.id = GenerateID();
            this.balance = 0;
            this.accountType = accountType;
        }

        /// <summary>
        /// конструктор с типом аккаунта и балансом
        /// </summary>
        internal BankAccount(decimal balance, AccountType? accountType)
        {
            this.id = GenerateID();
            this.balance = balance;
            this.accountType = accountType;
        }

        /// <summary>
        /// генерация ID
        /// </summary>
        private uint GenerateID()
        {
            autoID++;
            return autoID;
        }

        /// <summary>
        /// перевод средств
        /// </summary>
        public bool Transfer(BankAccount account, decimal amount)
        {
            if (account.WithdrawCash(amount))
            {
                this.Deposit(amount);
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// вывод номера аккаунта
        /// </summary>
        public uint GetID()
        {
            return id;
        }

        /// <summary>
        /// вывод типа аккаунта
        /// </summary>
        public decimal? GetBalance()
        {
            return balance;
        }

        /// <summary>
        /// вывод типа аккаунта
        /// </summary>
        public AccountType? GetAccountType()
        {
            return accountType;
        }

        /// <summary>
        /// вывод информации по клиенту
        /// </summary>
        public override string ToString()
        {
            return ($"Номер счета: {id}, Баланс: {balance}, Тип счета: {accountType}\n");
        }

        /// <summary>
        /// снятие денег
        /// </summary>
        public bool WithdrawCash(decimal cash)
        {
            if (cash < 0)
            {
                Console.WriteLine($"сумма должна быть больше 0");
                return false;
            }

            if ((balance - cash) > 0)
            {
                balance -= cash;
                AddTransaction(-cash);
                return true;
            }
            else return false;
        }

        /// <summary>
        /// пополнение счета
        /// </summary>
        public void Deposit(decimal cash)
        {
            if (cash <= 0)
            {
                Console.WriteLine("Сумма депозита должна быть больше нуля.");
            }
            balance += cash;
            AddTransaction(cash);
        }

        /// <summary>
        /// создание транзакции
        /// </summary>
        private void AddTransaction(decimal amount)
        {
            BankTransaction transaction = new BankTransaction(amount);
            transactions.Enqueue(transaction);
        }

        /// <summary>
        /// реализация интерфейса IDisposable
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// переопределение оператора ==
        /// </summary>
        public static bool operator ==(BankAccount bankAccountA, BankAccount bankAccountB)
        {
             return (bankAccountA.GetID() == bankAccountB.GetID());
        }
        /// <summary>
        /// переопределение оператора !=
        /// </summary>
        public static bool operator !=(BankAccount bankAccountA, BankAccount bankAccountB)
        {
            return !(bankAccountA.GetID() == bankAccountB.GetID());
        }
        /// <summary>
        /// переопредельге метода GetHashCode
        /// </summary>
        public override int GetHashCode()
        {
            return this.GetID().GetHashCode();
        }
        /// <summary>
        /// переопределние метода Equals
        /// </summary>
        public override bool Equals(object bankAccount)
        {
            
            if (bankAccount is BankAccount account)
            {
                return this == bankAccount;
            }

            return false;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                using (StreamWriter writer = new StreamWriter("transaction.txt", true))
                {
                    while (transactions.Count > 0)
                    {
                        BankTransaction transaction = transactions.Dequeue();
                        writer.WriteLine($"{transaction.transactionDate} : {transaction.Amount}");
                    }
                }
            }
            disposed = true;
        }
    }
}
