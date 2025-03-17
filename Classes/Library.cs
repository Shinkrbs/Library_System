using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_System.Enums;
using Library_System.Exceptions;

namespace Library_System.Classes
{
    public class Library
    {
        private List<Book> Books;
        private List<Member> Members;

        public Library()
        {
            this.Books = new List<Book>();
            this.Members = new List<Member>();
        }

        public void AddBook(Book book)
        {
            this.Books.Add(book);
            Console.WriteLine($"Successfully added {book.Title}.");
        }

        public void RemoveBook(Book book)
        {
            for(int i = 0; i < this.Books.Count; i++)
            {
                if (this.Books[i].Book_ID == book.Book_ID)
                {
                    this.Books.RemoveAt(i);
                    Console.WriteLine($"Successfully removed {book.Title}.");
                    return;
                }
            }
            throw new BooknotFoundException($"{book.Title} not found on inventory", book);
        }

        public void RegisterMember(Member member)
        {
            this.Members.Add(member);
            Console.WriteLine($"Successfully Registered {member.Name}.");
        }

        public void BorrowBook()
        {

        }
    }
}
