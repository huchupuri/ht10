using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tumak_1.Classes
{
    internal class BooksConteiner
    {
        private Book[] books;

        public BooksConteiner(Book[] books)
        {
            this.books = books;
        }

        /// <summary>
        /// Метод сортировки книг с использованием делегата
        /// </summary>
        public void Sort(BookComparer comparer)
        {
            for (int i = 0; i < books.Length - 1; i++)
            {
                for (int j = 0; j < books.Length - i - 1; j++)
                {
                    if (comparer(books[j], books[j + 1]) > 0)
                    {
                        (books[j], books[j + 1]) = (books[j+1], books[j]);
                    }
                }
            }
        }
        public void PrintAllBooks()
        {
            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }
        }

    }
}
