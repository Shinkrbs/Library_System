using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_System.Classes;
using Library_System.Enums;
using Library_System.Exceptions;

namespace Library_System
{
    class Main_Program
    {
        static void Main(string[] args)
        {
            try
            { 
                Library library = new Library();

                // Create Books
                Book book1 = new Book(1, "The Great Gatsby", "F. Scott Fitzgerald");
                Book book2 = new Book(2, "1984", "George Orwell");
                Book book3 = new Book(3, "To Kill a Mockingbird", "Harper Lee");

                // Add Books to Library
                library.AddBook(book1);
                library.AddBook(book2);
                library.AddBook(book3);
             
                // Create Members
                Member member1 = new Member(101, "Alice Johnson");
                Member member2 = new Member(102, "Bob Smith");

                // Register Members
                library.RegisterMember(member1);
                library.RegisterMember(member2);

                // Borrow Books
                Console.WriteLine("\nBorrowing Books:");
                library.BorrowBook(member1, book1, 5);
                library.BorrowBook(member2, book2, 10);

                // Try Borrowing Already Borrowed Book (Should Fail)
                Console.WriteLine("\nAttempting to Borrow an Already Borrowed Book:");
                try
                {
                    library.BorrowBook(member1, book1, 7); // Should throw exception
                }
                catch (BooknotAvailableException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }

                // Return Books
                Console.WriteLine("\nReturning Books:");
                member1.Return(book1);
                member2.Return(book2);

                // Attempt Returning a Book Not Borrowed (Should Fail)
                Console.WriteLine("\nAttempting to Return a Book Not Borrowed:");
                try
                {
                    member1.Return(book3); // Should throw exception
                }
                catch (BooknotFoundException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }

        }
        catch (BooknotFoundException ex)
        {
            Console.WriteLine($"Book Error: {ex.Message}");
        }
        catch (MembernotFoundException ex)
        {
            Console.WriteLine($"Member Error: {ex.Message}");
        }
        catch (MaxBooksReachedException ex)
        {
            Console.WriteLine($"Limit Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"General Error: {ex.Message}");
        }

        Console.WriteLine("\nTest Completed.");
        }
    }
}
