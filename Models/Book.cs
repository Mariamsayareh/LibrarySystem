using System;

namespace LibrarySystem
{
    public class Book
    {
        public int Id { get; }
        public string Title { get; }
        public string Author { get; }
        public double Price { get; }
        public bool IsBorrowed { get; set; }

        public Book(int id, string title, string author, double price)
        {
            Id = id;
            Title = title;
            Author = author;
            Price = price;
            IsBorrowed = false;
        }

        public void Display()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Price: {Price}");
            Console.WriteLine($"Borrowed: {IsBorrowed}");
        }
    }
}