using Libra2;
using MyLibrary;
using System;

namespace ht10
{
    class Program
    {
        static void Main()
        {
            Task1();
            Task2();
        }
        static void Task1()
        {

            //Упражнение 11.2 Разбить созданные классы, связанные с банковским счетом, и тестовый
            //пример в разные исходные файлы. Разместить классы в одно пространство имен и создать
            //сборку.Подключить сборку к проекту и откомпилировать тестовый пример со сборкой.
            //Получить исполняемый файл, проверить с помощью утилиты ILDASM, что тестовый
            //пример ссылается на сборку и не содержит в себе классов, связанный с банковским счетом.
            Console.WriteLine("задание 1");
            BankAccountFactory factory = new BankAccountFactory();
            List<uint> Accounts = new List<uint>()
            {
                factory.CreatBankAccount(),
                factory.CreatBankAccount(1000),
                factory.CreatBankAccount(1000, AccountType.debit),
                factory.CreatBankAccount(AccountType.debit)
            };
            
            
            foreach (uint account in Accounts)
            {
                Console.WriteLine(BankAccountFactory.accounts[account]);
            }

        }
        static void Task2()
        {
//            Домашнее задание 11.2 Разбить созданные классы(здания, фабричный класс) и тестовый
//пример в разные исходные файлы.Разместить классы в одном пространстве имен. Создать
//сборку(DLL), включающие эти классы.Подключить сборку к проекту и откомпилировать
//тестовый пример со сборкой. Получить исполняемый файл, проверить с помощью утилиты
//ILDASM, что тестовый пример ссылается на сборку и не содержит в себе классов здания и
//Creator.
            Console.WriteLine("задание 2");
            Building building1 = BuildingCreator.CreateBuild(50.5, 10, 100, 2);
            building1.PrintInfo();
            Building building2 = BuildingCreator.CreateBuild(30.0, 5, 50);
            building2.PrintInfo();
            Building building3 = BuildingCreator.CreateBuild(20.0, 4);
            building3.PrintInfo();
            Building building4 = BuildingCreator.CreateBuild();
            building4.PrintInfo();
            BuildingCreator.DeleteBuild(2);
            BuildingCreator.DeleteBuild(5);
        }
    }
    
}