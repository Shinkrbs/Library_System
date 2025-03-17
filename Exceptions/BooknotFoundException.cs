using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_System.Classes;

namespace Library_System.Exceptions
{
    public class BooknotFoundException : Exception
    {
        public Book Borrowed_Book { get; private set; }
        public BooknotFoundException(string message, Book borrowed_book) : base(message)
        {
            this.Borrowed_Book = borrowed_book;
        }
    }
}