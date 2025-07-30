namespace LibraryManagementSystem
{
    static class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            Book book1 = new Book { Title = "1984",                     Author = "George Orwell",   Year = 1949 };
            Book book2 = new Book { Title = "To Kill a Mockingbird",    Author = "Harper Lee",      Year = 1960 };
            Book book3 = new Book { Title = "The Lord of the Rings",    Author = "J.R.R. Tolkien",  Year = 1954 };
            Book book4 = new Book { Title = "Dune",                     Author = "Frank Herbert",   Year = 1965 };
            library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);
            library.AddBook(book4);

            while (true)
            {
                Console.WriteLine("Choose the operation: ");
                Console.WriteLine("1. Add new book to the library.");
                Console.WriteLine("2. Remove book from the library.");
                Console.WriteLine("3. Show the info about one book by the title.");
                Console.WriteLine("4. Show the info about every book in the library.");
                Console.WriteLine("Enter \"exit\" to quit the program.");

                switch (Console.ReadLine())
                {
                    case "1":
                        HandleAddBook(library);
                        break;
                    case "2":
                        HandleRemoveBook(library);
                        break;
                    case "3":
                        HandleShowBook(library);
                        break;
                    case "4":
                        ShowAllBooks(library.GetAllBooks()); 
                        break;
                    case "exit":
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong operation!");
                        Console.ResetColor();
                        break;
                }
            }
        }

        private static void HandleAddBook(Library library)
        {
            string title = GetCorrectInput("Enter the title: ");

            string author = GetCorrectInput("Enter the author: ");

            int year;
            while (true)
            {
                Console.Write("Enter the year: ");
                if (int.TryParse(Console.ReadLine(), out year))
                    break;
                Console.WriteLine("Error: incorrect input - Year only contains from digits.");
            }

            Book book = new Book(title, author, year);
            library.AddBook(book);
        }

        private static void HandleRemoveBook(Library library)
        {
            Console.Write("Enter the title: ");
            string title = Console.ReadLine();
            if (library.RemoveBook(title))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Book deleted successfully.\n");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No book found with this title!\n");
                Console.ResetColor();
            }
        }

        private static void HandleShowBook(Library library)
        {
            Console.Write("Enter the title: ");
            string title = Console.ReadLine();
            Book book = library.FindBookByTitle(title);
            if (book != null)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Title:  {book.Title}");
                Console.WriteLine($"Author: {book.Author}");
                Console.WriteLine($"Year:   {book.Year}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No book found with this title!\n");
                Console.ResetColor();
            }
        }

        private static string GetCorrectInput(string prompt)
        {
            string input;
            while (true)
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    break;

                Console.WriteLine("Error: incorrect input - cannot be empty.");
            }
            return input.Trim();
        }

        private static void ShowAllBooks(List<Book> bookshelf)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (Book book in bookshelf)
            {
                Console.WriteLine($"Title:  {book.Title}");
                Console.WriteLine($"Author: {book.Author}");
                Console.WriteLine($"Year:   {book.Year}");
                Console.WriteLine();
            }
            Console.WriteLine(new string('-', 20));
            Console.ResetColor();
        }
    }
}
