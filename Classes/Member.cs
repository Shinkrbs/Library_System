using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_System.Enums;
using Library_System.Exceptions;

namespace Library_System.Classes
{
    public class Member
    {
        public int Member_ID { get; private set; }
        public string Name { get; private set; }
        public List<Book> Borrowed_Books;
        private int BorrowingLimit = 10;

        public Member(int member_id, string name)
        {
            this.Member_ID = member_id;
            this.Name = name;
            Borrowed_Books = new List<Book>();
        }

        public void Borrow(Book book)
        {
            if (this.Borrowed_Books.Count >= BorrowingLimit)
                throw new MaxBooksReachedException("Borrowing limit reached, can't borrow anymore.");
            if (book.isAvailable != Book_Status.AVAILABLE)
                throw new BooknotAvailableException($"{book.Title} is not available for borrowing.", book);
            else
            {
                book.markasBorrowed();
                Borrowed_Books.Add(book);
                Console.WriteLine($"Succesfully Borrowed {book.Title}.");
            }
        }

        public void Return(Book book)
        {
            for(int i = 0; i < this.Borrowed_Books.Count; i++)
            {
                if (Borrowed_Books[i].Book_ID == book.Book_ID)
                {
                    Borrowed_Books[i].markasReturned();
                    Borrowed_Books.RemoveAt(i);
                    Console.WriteLine($"Succesfully returned {book.Title}");
                    return;
                }
            }
            throw new BooknotFoundException($"{book.Title} is not borrowed by {this.Name}.", book);
        }
    }
}
