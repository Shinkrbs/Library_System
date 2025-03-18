using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_System.Classes;

namespace Library_System.Exceptions
{
    public class MaxBooksReachedException : Exception
    {
        public Book BookBorrowed { get; private set; }
        public MaxBooksReachedException(string message, Book bookborrowed) : base(message) 
        { 
            this.BookBorrowed = bookborrowed;
        }   
    }
}
