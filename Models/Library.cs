using System;

namespace LibrarySystem
{
    public class Library
    {
        private Book[] books;
        private Member[] members;
        private Transaction[] transactions;

        private int bookIndex = 0;
        private int memberIndex = 0;
        private int transactionIndex = 0;

        public static int TotalBorrowedBooks { get; set; } = 0;

        private IFineCalculator fineCalculator;

        public Library(int bookSize, int memberSize, int transactionSize)
        {
            books = new Book[bookSize];
            members = new Member[memberSize];
            transactions = new Transaction[transactionSize];

            fineCalculator = new FineCalculator();
        }

        public void AddBook(Book book)
        {
            books[bookIndex++] = book;
        }

        public void AddMember(Member member)
        {
            members[memberIndex++] = member;
        }

        public void BorrowBook(int memberId, int bookId)
        {
            Member member = FindMember(memberId);
            Book book = FindBook(bookId);

            if (member == null || book == null)
            {
                Console.WriteLine("Invalid Member or Book.");
                return;
            }

            member.BorrowBook(book);

            transactions[transactionIndex++] =
                new Transaction(transactionIndex, book.Title, member.Name, TransactionType.Borrow);
        }

        public void ReturnBook(int memberId, int bookId, int daysLate)
        {
            Member member = FindMember(memberId);
            Book book = FindBook(bookId);

            if (member == null || book == null)
            {
                Console.WriteLine("Invalid Member or Book.");
                return;
            }

            member.ReturnBook(book);

            if (daysLate > 0)
            {
                double fine = fineCalculator.CalculateFine(daysLate);
                Console.WriteLine($"Fine = {fine}");
            }

            transactions[transactionIndex++] =
                new Transaction(transactionIndex, book.Title, member.Name, TransactionType.Return);
        }

        public void PrintTransactions()
        {
            for (int i = 0; i < transactionIndex; i++)
            {
                transactions[i].Display();
            }
        }

        private Member FindMember(int id)
        {
            for (int i = 0; i < memberIndex; i++)
                if (members[i].Id == id)
                    return members[i];

            return null;
        }

        private Book FindBook(int id)
        {
            for (int i = 0; i < bookIndex; i++)
                if (books[i].Id == id)
                    return books[i];

            return null;
        }
    }
}