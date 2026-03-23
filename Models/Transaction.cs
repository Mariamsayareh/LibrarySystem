using System;

namespace LibrarySystem
{
    public enum TransactionType
    {
        Borrow,
        Return
    }

    public class Transaction
    {
        public int Id { get; }
        public string BookTitle { get; }
        public string MemberName { get; }
        public DateTime Date { get; }
        public TransactionType Type { get; }

        public Transaction(int id, string bookTitle, string memberName, TransactionType type)
        {
            Id = id;
            BookTitle = bookTitle;
            MemberName = memberName;
            Date = DateTime.Now;
            Type = type;
        }

        public void Display()
        {
            Console.WriteLine($"[{Id}] {Type} - {BookTitle} - {MemberName} - {Date}");
        }
    }
}