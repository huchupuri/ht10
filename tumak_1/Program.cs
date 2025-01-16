using System;
using System.Diagnostics;
using hw10.Classes;
using hw10.Enums;
using tumak_1.Classes;
namespace program
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
        }
        static void Task1()
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
        static void Task2()
        {
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
        static void Task3()
        {
            Book[] books = new Book[]
        {
            new Book("Задача трёх тел", "Лю Цысинь", "Эксмо"),
            new Book("1984", "Джордж Оруэлл", "АСТ"),
            new Book("Мастер и Маргарита", "Михаил Булгаков", "Азбука"),
            new Book("Слепота", "Жозе Сарамаго", "Азбука")
        };

            // Создаём коллекцию книг
            BooksConteiner collection = new BooksConteiner(books);

            Console.WriteLine("Список книг до сортировки:");
            collection.PrintAllBooks();

            // Сортируем по названию
            Console.WriteLine("сортировка по названию:");
            collection.Sort(CompareByTitle);
            collection.PrintAllBooks();

            // Сортируем по автору
            Console.WriteLine("сортировка по автору:");
            collection.Sort(CompareByAuthor);
            collection.PrintAllBooks();

            // Сортируем по издательству
            Console.WriteLine("Сортировка по издательству:");
            collection.Sort(CompareByPublisher);
            collection.PrintAllBooks();
        }
        public static int CompareByTitle(Book book1, Book book2)
        {
            return string.Compare(book1.Title, book2.Title);
        }

        public static int CompareByAuthor(Book book1, Book book2)
        {
            return string.Compare(book1.Author, book2.Author);
        }

        public static int CompareByPublisher(Book book1, Book book2)
        {
            return string.Compare(book1.Publisher, book2.Publisher);
        }

    }
}