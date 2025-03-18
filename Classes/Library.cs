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
            if (isBook(book))
            {
                Console.WriteLine($"The book {book.Title} already exists.");
                return;
            }
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
            throw new BooknotFoundException($"{book.Title} not found in inventory", book);
        }

        public void RegisterMember(Member member)
        {
            if (isMember(member))
            {
                Console.WriteLine($"{member.Name} is already a registered member.");
                return;
            }
            this.Members.Add(member);
            Console.WriteLine($"Successfully registered {member.Name}.");
        }

        public void BorrowBook(Member member, Book book, int daysborrowed)
        {
            // Check first if member and book exists
            if (!isMember(member))
                throw new MembernotFoundException($"{member.Name} is not a registered member.", member);
            if (!isBook(book))
                throw new BooknotFoundException($"{book.Title} is not found in book list", book);

            // If all is good
            member.Borrow(book);

            // Perfrom Transaction Here
            Transaction transaction = new Transaction("00000", member, book, DateTime.Now, DateTime.Now.AddDays(daysborrowed));
            Console.WriteLine(transaction.GenerateReceipt());
        }

        public void returnBook(Member member, Book book)
        {
            // Check first if member and book exists
            if (!isMember(member))
                throw new MembernotFoundException($"{member.Name} is not a registered member.", member);
            if (!isBook(book))
                throw new BooknotFoundException($"{book.Title} is not found in book list", book);

            // All is good
            member.Return(book);
        }

        #region Helper Functions
        public bool isMember(Member member)
        {
            for(int i = 0; i < this.Members.Count; i++)
            {
                if (this.Members[i].Member_ID == member.Member_ID)
                    return true;
            }
            return false;
        }

        public bool isBook(Book book)
        {
            for(int i = 0; i < this.Books.Count; i++)
            {
                if (this.Books[i].Book_ID == book.Book_ID)
                    return true;
            }
            return false;
        }
        #endregion
    }
}
