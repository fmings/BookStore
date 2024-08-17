namespace BookStore
{
    // This is the interface for the BookRepository class
    // An interface is a contract that defines the methods that a class must implement
    // In this case, the IBookRepository interface defines a single method, GetBookById
    // Interfaces are good for testing because they allow us to create mock (fake) objects that simulate the behavior of real objects
    // Mock objects are used in unit testing to isolate the code you are testing.
    public interface IBookRepository
    {
        // Create a method to get all books
        // The method should return a list of Book objects
        List<Book> GetAllBooks();

        Book GetBookById(int id);

        // Create a method to add a book
        // The method should take a Book object as a parameter and return the ID of the newly added book
        Book AddBook(Book book);

        // Create a method to update a book
        // The method should take a Book object as a parameter and return a boolean value indicating whether the update was successful
        bool UpdateBook(int id, string title, string author);

        // Create a method to delete a book
        // The method should take an ID as a parameter and return a boolean value indicating whether the delete was successful
        bool DeleteBook(int id);
    }
}
