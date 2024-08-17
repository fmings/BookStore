namespace BookStore
{

    // This is the BookService class
    // The BookService class is responsible for getting the book data from the repository
    // The BookService class is dependent on the IBookRepository interface (dependency injection)
    // The BookService class implements the IBookService interface (contract)
    // We are using dependency injection to inject the IBookRepository interface into the BookService class
    // Dependency injection is a design pattern that allows us to inject the dependencies of a class from the outside without instantiating them inside the class
    // This makes the class more modular (modular means that the class is easier to test and maintain because its separated out into its own thing)  
    // We do not inject the BookRepository class directly into the BookService class because we want to be able to mock the repository in our unit tests
    // If we inject the BookRepository class directly into the BookService class, we would not be able to mock the repository in our unit tests because the BookRepository class is a concrete class (not an interface) and we should not be testing the actual implementation of the BookRepository class in our unit tests
    // We only want to test the behavior and not the actual implementation of the BookRepository class
    // We also do not want the BookService class to be dependent on the BookRepository class
    public class BookService : IBookService // if you your interface hasn't been implemented, you can press ctrl + . and click on implement interface
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Book GetBookById(int id)
        {
            return _bookRepository.GetBookById(id);
        }

        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }

        public Book AddBook(Book book)
        {
            return _bookRepository.AddBook(book);
        }

        public bool UpdateBook(int id, string title, string author)
        {
            return (_bookRepository.UpdateBook(id, title, author));
        }

        public bool DeleteBook(int id)
        {
            return _bookRepository.DeleteBook(id); 
        }
    }
}
