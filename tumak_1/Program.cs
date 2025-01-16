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
            Task3();
            Task4();
            Task5(); 
        }
        static void Task1()
        {
//            Создать новый класс, который будет являться фабрикой объектов класса
//банковский счет. Изменить модификатор доступа у конструкторов класса банковский счет на
//internal. Добавить в фабричный класс перегруженные методы создания счета CreateAccount,
//которые бы вызывали конструктор класса банковский счет и возвращали номер созданного
//счета.Использовать хеш-таблицу для хранения всех объектов банковских счетов в
//фабричном классе. В фабричном классе предусмотреть метод закрытия счета, который
//удаляет счет из хеш-таблицы (методу в качестве параметра передается номер банковского
//счета). Использовать утилиту ILDASM для просмотра структуры классов.
            Console.WriteLine("задание 1");
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
//            Для реализованного класса из домашнего задания 7.1 создать
//новый класс Creator, который будет являться фабрикой объектов класса здания. Для этого
//изменить модификатор доступа к конструкторам класса, в новый созданный класс добавить
//перегруженные фабричные методы CreateBuild для создания объектов класса здания.В
//классе Creator все методы сделать статическими, конструктор класса сделать закрытым. Для
//хранения объектов класса здания в классе Creator использовать хеш-таблицу.Предусмотреть
//возможность удаления объекта здания по его уникальному номеру из хеш-таблицы.Создать
//тестовый пример, работающий с созданными классами.
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
        static void Task3()
        {
//            Создать класс рациональных чисел. В классе два поля – числитель и
//знаменатель.Предусмотреть конструктор. Определить операторы ==, != (метод Equals()), <,
//>, <=, >=, +, – , ++, --.Переопределить метод ToString() для вывода дроби.Определить
//операторы преобразования типов между типом дробь, float, int.Определить операторы *, /,
//%.
            Console.WriteLine("задание 3");
            RationalNums r1 = new RationalNums(3, 4);
            RationalNums r2 = new RationalNums(13, 5);

            Console.WriteLine($"r1: {r1}");
            Console.WriteLine($"r2: {r2}");
            Console.WriteLine($"r1 + r2: {r1 + r2}");
            Console.WriteLine($"r1 - r2: {r1 - r2}");
            Console.WriteLine($"r1 * r2: {r1 * r2}");   
            Console.WriteLine($"r1 / r2: {r1 / r2}");
            Console.WriteLine($"r1 % r2: {r1 % r2}");
            Console.WriteLine($"r1 == r2: {r1 == r2}");
            Console.WriteLine($"r1 != r2: {r1 != r2}");
            Console.WriteLine($"r1 > r2: {r1 > r2}");
            Console.WriteLine($"r1 < r2: {r1 < r2}");
            Console.WriteLine($"(float)r1: {(float)r1}");
            Console.WriteLine($"(int)r1: {(int)r2}");
            Console.WriteLine($"r1++: {r1++}");
            Console.WriteLine($"r1--: {r1--}");

        }
        static void Task4()
        {
            Complex c1 = new Complex(3, 4); 
            Complex c2 = new Complex(1, -2);
            Console.WriteLine($"Первое число: {c1}");
            Console.WriteLine($"Второе число: {c2}");
            Console.WriteLine($"Сумма: {c1+c2}");
            Console.WriteLine($"Разность: {c1-c2}");
            Console.WriteLine($"Произведение: {c1*c2}");
        }
        static void Task5()
        {
            //            Написать делегат, с помощью которого реализуется сортировка
            //книг.Книга представляет собой класс с полями Название, Автор, Издательство и
            //конструктором.Создать класс, являющийся контейнером для множества книг(массив книг).
            //В этом классе предусмотреть метод сортировки книг.Критерий сортировки определяется
            //экземпляром делегата, который передается методу в качестве параметра. Каждый экземпляр
            //делегата должен сравнивать книги по какому-то одному полю: названию, автору,
            //издательству.
            Console.WriteLine("задание Написать делегат, с помощью которого реализуется сортировка\r\nкниг.Книга представляет собой класс с полями Название, Автор, Издательство и\r\nконструктором.Создать класс, являющийся контейнером для множества книг(массив книг).");
            Book[] books = new Book[]
            {
                new Book("Преступление и наказание", "ДОстоевский", "idk"),
                new Book("1984", "Джордж Оруэлл", "1idk"),
                new Book("Мастер и Маргарита", "Михаил Булгаков", "2idk"),
                new Book("Обломов", "Гончаров", "3idk")
            };
            BooksConteiner collection = new BooksConteiner(books);
            Console.WriteLine("список книг до сортировки:");
            collection.PrintAllBooks();
            Console.WriteLine("сортировка по названию");
            collection.Sort(CompareByTitle);
            collection.PrintAllBooks();
            Console.WriteLine("сортировка по автору:");
            collection.Sort(CompareByAuthor);
            collection.PrintAllBooks();
            Console.WriteLine("Сортировка по издательству:");
            collection.Sort(CompareByPublisher);
            collection.PrintAllBooks();
        }

        /// <summary>
        /// методы сравнения
        /// </summary>
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