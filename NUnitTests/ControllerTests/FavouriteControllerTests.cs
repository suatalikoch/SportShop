using Business;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace NUnitTests.ControllerTests
{
    [TestFixture]
    public class FavouriteControllerTests
    {
        private ShopContext _shopContext;
        private FavouriteController _favouriteController;

        [SetUp]
        public void Setup()
        {
            // Set up a new in-memory database for testing
            var options = new DbContextOptionsBuilder<ShopContext>()
                .UseInMemoryDatabase(databaseName: "test_database")
            .Options;

            _shopContext = new ShopContext(options);
            _favouriteController = new FavouriteController(_shopContext);
        }

        [TearDown]
        public void TearDown()
        {
            // Dispose of the in-memory database after each test
            _shopContext.Database.EnsureDeleted();
            _shopContext.Dispose();
        }

        [Test]
        public void Constructor_ShouldCreateFavouriteControllerWithDefaultConnection()
        {
            // Arrange
            var favouriteController = new FavouriteController();

            // Assert
            Assert.That(favouriteController, Is.Not.Null);
        }

        [Test]
        public void GetAll_ReturnsAllFavourites()
        {
            // Arrange
            var favourites = new List<Favourite>
            {
                new Favourite(1, 1),
                new Favourite(1, 2),
                new Favourite(1, 3)
            };

            _favouriteController.AddRange(favourites);

            // Act
            var result = _favouriteController.GetAll();

            // Assert
            Assert.That(result, Has.Count.EqualTo(favourites.Count));
            Assert.That(result.All(c => favourites.Any(cc => cc.UserId == c.UserId && cc.ProductId == c.ProductId)), Is.True);
        }

        [Test]
        public void GetAll_ReturnsEmptyList_WhenNoFavouritesExist()
        {
            // Act
            var result = _favouriteController.GetAll();

            // Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void GetByID_ReturnsFavouriteWithGivenID()
        {
            // Arrange
            var favourite = new Favourite(1, 1);

            _favouriteController.Add(favourite);

            // Act
            var result = _favouriteController.GetByID(favourite.UserId);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.UserId, Is.EqualTo(favourite.UserId));
                Assert.That(result.ProductId, Is.EqualTo(favourite.ProductId));
            });
        }

        [Test]
        public void GetByID_ReturnsNull_WhenFavouriteWithGivenIDDoesNotExist()
        {
            // Arrange
            var favouriteId = 100; // Assuming favourite with UserId 100 does not exist

            // Act
            var result = _favouriteController.GetByID(favouriteId);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Add_AddsFavouriteToDatabase()
        {
            // Arrange
            var favourite = new Favourite(1, 1);

            // Act
            _favouriteController.Add(favourite);

            var result = _favouriteController.GetByID(favourite.UserId);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.UserId, Is.EqualTo(favourite.UserId));
                Assert.That(result.ProductId, Is.EqualTo(favourite.ProductId));
            });
        }

        [Test]
        public void Add_ShouldNotAdd_WhenFavouriteIsNull()
        {
            // Act
            _favouriteController.Add(null);

            // Assert
            Assert.That(_favouriteController.GetAll(), Has.Count.EqualTo(0));
        }

        [Test]
        public void Delete_RemovesExistingFavouriteFromDatabase()
        {
            // Arrange
            var favourite = new Favourite(1, 1);

            _favouriteController.Add(favourite);

            // Act
            _favouriteController.Delete(favourite.UserId);

            var result = _favouriteController.GetByID(favourite.UserId);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Delete_ShouldNotThrowException_WhenFavouriteDoesNotExist()
        {
            // Arrange
            var favouriteId = 100; // Assuming favourite with UserId 100 does not exist

            // Act
            void testDelegate() => _favouriteController.Delete(favouriteId);

            // Assert
            Assert.That(testDelegate, Throws.Nothing);
        }

        [Test]
        public void DeleteAll_RemovesAllFavouritesFromDatabase()
        {
            // Arrange
            var favourites = new List<Favourite>
            {
                new Favourite(1, 1),
                new Favourite(2, 1),
                new Favourite(3, 2),
            };

            _favouriteController.AddRange(favourites);

            // Act
            _favouriteController.DeleteAll();

            // Assert
            Assert.That(_favouriteController.GetAll(), Is.Empty);
        }
    }
}
