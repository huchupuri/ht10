using Libra2;
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
            Building building1 = BuildingCreator.CreateBuild(50.5, 10, 100, 2);
            building1.PrintInfo();

            // Создание второго здания (с неполной информацией)
            Building building2 = BuildingCreator.CreateBuild(30.0, 5, 50);
            building2.PrintInfo();

            // Создание третьего здания (только с высотой и этажами)
            Building building3 = BuildingCreator.CreateBuild(20.0, 4);
            building3.PrintInfo();

            Building building4 = BuildingCreator.CreateBuild();
            building4.PrintInfo();


            BuildingCreator.DeleteBuild(2);

            BuildingCreator.DeleteBuild(5);
        }
    }
}