using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_System.Classes
{
    public class Transaction
    {
        public string TransactionID { get; private set; }
        public Member MemberBorrower { get; private set; }
        public Book BookBorrowed { get; private set; }
        public DateTime BorrowDate { get; private set; }
        public DateTime ReturnDate { get; private set; }
        public int TotalCost { get; private set; }
        private const int fine_perday = 10;  // Adds Ten for every day (overdue)
        private const int daily_cost = 40;  // 40 per day borrowed

        public Transaction(string transactionid, Member memberborrower, Book bookborrowed, DateTime borrowdate, DateTime returnDate)
        {
            this.TransactionID = transactionid;
            this.MemberBorrower = memberborrower;
            this.BookBorrowed = bookborrowed;
            this.ReturnDate = returnDate;
            this.BorrowDate = borrowdate;
            CalculateTotalCost();
        }

        public void CalculateTotalCost()
        {
            TimeSpan Duration = this.ReturnDate - this.BorrowDate;
            int TotalDays = Math.Max(Duration.Days, 0);

            this.TotalCost = TotalDays * daily_cost;
        }

        public void CalculateFine()
        {
            int OverdueDays = Math.Max((DateTime.Now - this.ReturnDate).Days,0);

            if (OverdueDays <= 0)
            {
                Console.WriteLine($"The Book {this.BookBorrowed.Title} is not overdue.");
                return;
            }
            this.TotalCost += OverdueDays * fine_perday;
            Console.WriteLine($"The Book {this.BookBorrowed.Title} is overdue for {OverdueDays}\n" +
                $"New Cost is: {this.TotalCost}");
        }

        public int GetTotalCost() 
        { 
            return this.TotalCost; 
        }

        public string GenerateReceipt()
        {
            StringBuilder receipt = new StringBuilder();
            receipt.AppendLine("===== LIBRARY TRANSACTION RECEIPT =====");
            receipt.AppendLine($"Transaction ID: {TransactionID}");
            receipt.AppendLine($"Member: {MemberBorrower.Name}");
            receipt.AppendLine($"Book Title: {BookBorrowed.Title}");
            receipt.AppendLine($"Author: {BookBorrowed.Author}");
            receipt.AppendLine($"Borrow Date: {BorrowDate:MMMM dd, yyyy}");
            receipt.AppendLine($"Return Date: {ReturnDate:MMMM dd, yyyy}");

            // Calculate overdue fine before printing total cost
            CalculateFine();

            receipt.AppendLine($"Total Cost: PHP {TotalCost}");
            receipt.AppendLine("========================================");

            return receipt.ToString();
        }
    }
}
