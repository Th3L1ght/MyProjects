namespace LibraryManagementSystem
{
    public class Book
    {
        public string Title { get; init; }
        public string Author { get; init; }
        public int Year { get; init; }

        public Book()
        {

        }

        public Book(string title, string author, int year)
        {
            Title = title;
            Author = author;
            Year = year;
        }
    }
}
