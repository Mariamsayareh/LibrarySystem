using System;

namespace LibrarySystem
{
    public abstract class Member
    {
        public int Id { get; }
        public string Name { get; }
        public string Phone { get; }

        protected Book[] borrowedBooks;
        protected int borrowCount;

        public Member(int id, string name, string phone)
        {
            Id = id;
            Name = name;
            Phone = phone;

            borrowedBooks = new Book[10];
            borrowCount = 0;
        }

        public void BorrowBook(Book book)
        {
            if (book.IsBorrowed)
            {
                Console.WriteLine("Book already borrowed.");
                return;
            }

            if (borrowCount >= GetMaxBorrowLimit())
            {
                Console.WriteLine("Reached max borrow limit.");
                return;
            }

            borrowedBooks[borrowCount++] = book;
            book.IsBorrowed = true;
            Library.TotalBorrowedBooks++;

            Console.WriteLine("Book borrowed successfully.");
        }

        public void ReturnBook(Book book)
        {
            for (int i = 0; i < borrowCount; i++)
            {
                if (borrowedBooks[i].Id == book.Id)
                {
                    book.IsBorrowed = false;
                    borrowedBooks[i] = null;
                    borrowCount--;
                    Library.TotalBorrowedBooks--;

                    Console.WriteLine("Book returned successfully.");
                    return;
                }
            }

            Console.WriteLine("This member didn't borrow this book.");
        }

        public int GetBorrowedCount()
        {
            return borrowCount;
        }

        public abstract int GetMaxBorrowLimit();

        // Operator Overloading
        public static bool operator >(Member m1, Member m2)
        {
            return m1.borrowCount > m2.borrowCount;
        }

        public static bool operator <(Member m1, Member m2)
        {
            return m1.borrowCount < m2.borrowCount;
        }

        public static int operator +(Member m1, Member m2)
        {
            return m1.borrowCount + m2.borrowCount;
        }
    }
}