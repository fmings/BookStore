using Xunit;
using Moq;

namespace BookStore.Tests
{
    public class BookServiceTests
    {
        // The BookService class is dependent on the IBookRepository interface.
        // We do not need to mock the Book class because it is a simple class.
        private readonly BookService _bookService;

        // The Mock class is used to create a mock object of the IBookRepository interface.
        // Mock objects are used to simulate the behavior of real objects.
        // Mock objects are used in unit testing to isolate the code under test.
        // We are mocking the IBookRepository interface because we do not want to test the actual implementation of the BookRepository class.
        // Mock just means that we are creating a fake object that simulates the behavior of the real object.
        private readonly Mock<IBookRepository> _mockBookRepository;

        public BookServiceTests()
        {
            _mockBookRepository = new Mock<IBookRepository>();
            _bookService = new BookService(_mockBookRepository.Object);
        }

        [Fact]
        public void GetBookDetails_ShouldReturnBook_WhenBookExists()
        {
            // Arrange - means to set up the test
            var bookId = 1;

            // Here, we are creating an instance of the Book class with the Id, Title, and Author properties set.
            // The expectedBook does not have to match the actual book in the repository.
            var expectedBook = new Book { Id = bookId, Title = "Star Wars", Author = "George Lucas" };

            // The Setup method is used to set up the behavior of the mock object.
            // This means that when the GetBookById method is called with the bookId parameter, the mock object should return the expectedBook instance.
            // The expectedBook is the object that we set up to be returned by the mock object.
            _mockBookRepository.Setup(repo => repo.GetBookById(bookId)).Returns(expectedBook);

            // Act - means to run the test
            // The GetBookById method is called with the bookId parameter.
            // The actual book returned by the GetBookById method comes from the mock object.
            var actualBook = _bookService.GetBookById(bookId);

            // Assert - means to check the result
            // The actualBook returned by the GetBookById method should be equal to the expectedBook instance.
            Assert.Equal(expectedBook, actualBook);
        }

        [Fact]
        public void GetBookDetails_ShouldReturnNull_WhenBookDoesNotExist()
        {
            // Arrange - means to set up the test
            // The book with Id 99 does not exist in the repository
            // Therefore, the GetBookById method should return null.
            var bookId = 99;

            // The Setup method is used to set up the behavior of the mock object.
            _mockBookRepository.Setup(repo => repo.GetBookById(bookId)).Returns((Book)null);

            // Act - means to run the test
            // The GetBookById method is called with the bookId parameter.
            var actualBook = _bookService.GetBookById(bookId);

            // Assert - means to check the result
            // The actualBook returned by the GetBookById method should be null.
            Assert.Null(actualBook);
        }

        [Fact]
        public void AddBook_ShouldReturnBook_WhenBookIsCreated()
        {
            // Arrange - means to set up the test
            var newBook =
             new Book()
             {
                 Title = "Test Title",
                 Author = "Test Author"
             };

            // The Setup method is used to set up the behavior of the mock object.
            _mockBookRepository.Setup(repo => repo.AddBook(newBook)).Returns(newBook);

            // Act - means to run the test
            // The AddBook method is called with the newBook parameter.
            var actualBook = _bookService.AddBook(newBook);

            // Assert - means to check the result
            // The actualBook returned by the GetBookById method should be equal to newBook.
            Assert.Equal(newBook, actualBook);
        }

        [Fact]
        public void DeleteBook_ShouldReturnTrue_WhenBookIsDeleted()
        {
            // Arrange - means to set up the test
            // The book with Id 99 does not exist in the repository
            // Therefore, the GetBookById method should return null.
            var bookId = 2;

            // The Setup method is used to set up the behavior of the mock object.
            _mockBookRepository.Setup(repo => repo.DeleteBook(bookId)).Returns(true);

            // Act - means to run the test
            // The GetBookById method is called with the bookId parameter.
            var result = _bookService.DeleteBook(bookId);

            // Assert - means to check the result
            // The actualBook returned by the GetBookById method should be null.
            Assert.True(result);
        }

        [Fact]
        public void UpdateBook_ShouldReturnBook_WhenBookIsUpdated()
        {
            // Arrange - means to set up the test
            var bookId = 1;
            var newTitle = "Test New Title";
            var newAuthor = "Test New Author";

            var expectedBook = new Book
            {
                Id = bookId,
                Title = newTitle,
                Author = newAuthor
            };


            // The Setup method is used to set up the behavior of the mock object.
            _mockBookRepository.Setup(repo => repo.UpdateBook(bookId, newTitle, newAuthor)).Returns(true);

            // Act - means to run the test
            // The AddBook method is called with the newBook parameter.
            var actualBook = _bookService.UpdateBook(bookId, newTitle, newAuthor);

            // Assert - means to check the result
            // The actualBook returned by the GetBookById method should be equal to newBook.
            Assert.True(actualBook);
        }
    }
}
