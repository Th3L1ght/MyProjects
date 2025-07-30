namespace LibraryManagementSystem
{
    public class Library
    {
        private List<Book> bookshelf = new List<Book>();

        public void AddBook(Book book)
        {
            bookshelf.Add(book);
        }

        public bool RemoveBook(string title)
        {
            int removedCount = bookshelf.RemoveAll(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            return removedCount > 0;
        }

        public Book FindBookByTitle(string title)
        {
            foreach(Book book in bookshelf)
            {
                if(book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    return book;
                }
            }
            return null;
        }

        public List<Book> GetAllBooks()
        {
            return bookshelf;
        }
    }
}
