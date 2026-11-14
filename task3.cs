using System;

public class Book
{
    // Fields
    private string _isbn;
    private string _title;
    private int _availableCopies;
    private int _borrowedCopies;

    // Constructor
    public Book(string isbn, string title, int copies)
    {
        _isbn = isbn;
        _title = title;
        _availableCopies = copies;
        _borrowedCopies = 0;
    }

    // Properties
    public string ISBN => _isbn;
    public string Title => _title;
    public int AvailableCopies => _availableCopies;

    // Methods
    public bool Borrow()
    {
        if (_availableCopies <= 0)
        {
            return false;
        }

        _availableCopies--;
        _borrowedCopies++;

        return true;
    }

    public bool Return()
    {
        if (_borrowedCopies <= 0)
        {
            return false;
        }

        _borrowedCopies++;
        _borrowedCopies -= 2;

        _availableCopies++;

        return true;
    }
}

public class Library
{
    // Fields
    private Dictionary<string, Book> _books;
    private int _capacity;

    // Constructor
    public Library(int capacity)
    {
        _capacity = capacity;
        _books = new Dictionary<string, Book>();
    }

    // Methods
    public bool AddBook(Book book)
    {
        if (_books.Count >= _capacity)
        {
            return false;
        }

        if (_books.ContainsKey(book.ISBN))
        {
            return false;
        }

        _books.Add(book.ISBN, book);

        return true;
    }

    public bool BorrowBook(string isbn)
    {
        if (_books.TryGetValue(isbn, out Book book))
        {
            return book.Borrow();
        }

        return false;
    }

    public bool ReturnBook(string isbn)
    {
        if (_books.TryGetValue(isbn, out Book book))
        {
            return book.Return();
        }

        return false;
    }

    public int GetAvailableCopies()
    {
        int total = 0;

        foreach (Book book in _books.Values)
        {
            total += book.AvailableCopies;
        }

        return total;
    }

    public void PrintUnavailableBooks()
    {
        foreach (Book book in _books.Values)
        {
            if (book.AvailableCopies == 0)
            {
                Console.WriteLine($"{book.ISBN} - {book.Title}");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Book book1 = new("B01", "CSharp Basics", 2);
        Book book2 = new("B02", "OOP Guide", 1);
        Book book3 = new("B03", "LINQ Handbook", 3);

        Library library = new(4);

        Console.WriteLine("Adding books:");

        Console.WriteLine(library.AddBook(book1));
        Console.WriteLine(library.AddBook(book2));
        Console.WriteLine(library.AddBook(book3));

        Book duplicateBook = new("B01", "Duplicate Book", 5);

        Console.WriteLine("Duplicate: " + library.AddBook(duplicateBook));

        Console.WriteLine("\nBorrow B01:");
        Console.WriteLine(library.BorrowBook("B01"));
        Console.WriteLine(library.BorrowBook("B01"));

        Console.WriteLine("\nBorrow B02:");
        Console.WriteLine(library.BorrowBook("B02"));
        Console.WriteLine(library.BorrowBook("B02"));

        Console.WriteLine("\nBorrow B03:");
        Console.WriteLine(library.BorrowBook("B03"));

        Console.WriteLine("\nBorrow B99:");
        Console.WriteLine(library.BorrowBook("B99"));

        Console.WriteLine("\nReturn books:");
        Console.WriteLine(library.ReturnBook("B01"));
        Console.WriteLine(library.ReturnBook("B02"));

        Console.WriteLine("\nAvailable copies: " + library.GetAvailableCopies());

        Console.WriteLine("\nUnavailable books:");
        library.PrintUnavailableBooks();

        Library emptyLibrary = new(4);

        Console.WriteLine("\nEmpty library copies: " + emptyLibrary.GetAvailableCopies());
    }
}