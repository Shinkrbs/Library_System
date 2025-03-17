using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_System.Classes;

namespace Library_System.Exceptions
{
    public class BooknotAvailableException : Exception
    {
        public Book Book_Borrowed { get; private set; }
        public BooknotAvailableException(string message, Book book_borrowed) : base(message)
        {
            this.Book_Borrowed = book_borrowed;
        }
    }
}
