using System;
using System.Collections.Generic;
using System.Globalization;

//Problem: Library Book Management
//Create a small program to manage books in a library. The program should allow:
//Adding new books.
//Borrowing a book(reducing available copies).
//Returning a book (increasing available copies).
//Displaying book details.

//Requirements: Class: Book
//Properties: Title(string) | Author(string) | ISBN(string) | CopiesAvailable(int)
//Methods: BorrowBook() | ReturnBook()  | DisplayDetails() 

//Main Program: Create 3 instances of Book | Borrow and return books | Display their details before / after changes.

namespace ConsoleAppIns
{
    public class Book
    {
        public int ID {  get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int copies { get; set; }

        public Book(int ID, string Title, string Author, string ISBN, int copies)
        {
            this.ID = ID;
            this.Title = Title;
            this.Author = Author;
            this.ISBN = ISBN;
            this.copies = copies;
        }
        public static void borrow(string title)
        {
            int y = Program.library.FindIndex(p => p.Title == title);
            if (y == -1)
            {
                Console.WriteLine($"Book {title} not found");
                return;
            }
            borrowBook(Program.library[y]);
        }
            
        public static void borrowBook(Book x)
        {
            if (x.copies == 0)
                Console.WriteLine($"{x.Title} has no more copies left to borrow");
            else
                x.copies--;
        }
        public static void return1(string title)
        {
            int y = Program.library.FindIndex(p => p.Title == title);
            if (y == -1)
            {
                Console.WriteLine($"Book {title} not found");
                return;
            }
            returnBook(Program.library[y]);
        }

        public static void returnBook(Book x)
        { 
            x.copies++; 
        }
        
        public void display()
            { Console.WriteLine($"{this.Title} {this.Author} " +
                $"{this.copies} copies available");}
    }
    public class Program
    {
        public static List<Book> library = new List<Book>();
        static void Main(string[] args)
       {
            
            addBooks(1, "The Sound of Thunder", "Wilbur Smith", null, 4);
            addBooks(2, "When the lion feeds", "Wilbur Smith", null, 3);
            addBooks(3, "Sea of Poppies", "Amitav Ghosh", null, 2);

            displayLibrary();
            
            Console.WriteLine("\nBorrow : The Sound of Thunder");
            Book.borrow("The Sound of Thunder");
            Console.WriteLine("Borrow : When the lion feeds\n");
            Book.borrow("When the lion feeds");

            Console.WriteLine("\nReturn : The Sound of Thunder");
            Book.return1("The Sound of Thunder");

            Console.WriteLine("\nBorrow : The Golden Road");
            Book.borrow("The Golden Road");

            Console.WriteLine("\nReturn : The Anarchy");
            Book.return1("The Anarchy");

            Console.WriteLine("\nBorrow : Sea of Poppies");
            Book.borrow("Sea of Poppies");

            Console.WriteLine("\nBorrow : Sea of Poppies");
            Book.borrow("Sea of Poppies");
            
            Console.WriteLine("\nBorrow : Sea of Poppies");
            Book.borrow("Sea of Poppies");

            Console.WriteLine("\nAdd : The Golden Road");
            addBooks(1, "The Golden Road", "William Dalrymple", null, 1);
            

            Console.WriteLine("\nAdd new copy : The Sound of Thunder");
            addBooks(1, "The Sound of Thunder", "Wilbur Smith", null, 1);
            displayLibrary();
        }
        static void displayLibrary()
        {
            foreach (Book x in library)
                x.display();
        }

        static void addBooks(int x,string title, string author, string isbn, int copies)
        {
            int y = library.FindIndex(p => p.Title == title);
            if (y == -1)
                library.Add(new Book(x, title, author, isbn, copies));
            else
                Book.returnBook(library[y]);
        }
    }
}
