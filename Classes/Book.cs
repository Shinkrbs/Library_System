using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Library_System.Enums;

namespace Library_System.Classes
{
    public class Book
    {
        public int Book_ID {  get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public Book_Status isAvailable { get; private set; }

        public Book(int book_id, string title, string author)
        {
            this.Book_ID = book_id;
            this.Title = title;
            this.Author = author;
            this.isAvailable = Book_Status.AVAILABLE;
        }

        public void markasBorrowed()
        {
            this.isAvailable = Book_Status.BORROWED;
        }

        public void markasReturned()
        {
            this.isAvailable = Book_Status.RETURNED;
        }

        public void markasAvailable()
        {
            this.isAvailable = Book_Status.AVAILABLE;
        }

        public void markasNotAvailable()
        {
            this.isAvailable = Book_Status.NOT_AVAILABLE;
        }
    }
}