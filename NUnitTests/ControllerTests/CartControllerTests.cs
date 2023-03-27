using Business;
using Data.Models;
using Data;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework.Internal;

namespace NUnitTests.ControllerTests
{
    [TestFixture]
    public class CartControllerTests
    {
        private ShopContext _shopContext;
        private CartController _cartController;

        [SetUp]
        public void Setup()
        {
            // Set up a new in-memory database for testing
            var options = new DbContextOptionsBuilder<ShopContext>()
                .UseInMemoryDatabase(databaseName: "test_database")
            .Options;

            _shopContext = new ShopContext(options);
            _cartController = new CartController(_shopContext);
        }

        [TearDown]
        public void TearDown()
        {
            // Dispose of the in-memory database after each test
            _shopContext.Database.EnsureDeleted();
            _shopContext.Dispose();
        }

        [Test]
        public void Constructor_ShouldCreateCartControllerWithDefaultConnection()
        {
            // Arrange
            var cartController = new CartController();

            // Assert
            Assert.That(cartController, Is.Not.Null);
        }

        [Test]
        public void GetAll_ReturnsAllCarts()
        {
            // Arrange
            var carts = new List<Cart>
            {
                new Cart(1, 1),
                new Cart(1, 2),
                new Cart(1, 3)
            };

            _cartController.AddRange(carts);

            // Act
            var result = _cartController.GetAll();

            // Assert
            Assert.That(result, Has.Count.EqualTo(carts.Count));
            Assert.That(result.All(c => carts.Any(cc => cc.UserId == c.UserId && cc.ProductId == c.ProductId && cc.User == c.User && cc.Product == c.Product)), Is.True);
        }

        [Test]
        public void GetAll_ReturnsEmptyList_WhenNoCartsExist()
        {
            // Act
            var result = _cartController.GetAll();

            // Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void GetByID_ReturnsCartWithGivenID()
        {
            // Arrange
            var cart = new Cart(1, 1);

            _cartController.Add(cart);

            // Act
            var result = _cartController.GetByID(cart.UserId);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.UserId, Is.EqualTo(cart.UserId));
                Assert.That(result.ProductId, Is.EqualTo(cart.ProductId));
            });
        }

        [Test]
        public void GetByID_ReturnsNull_WhenCartWithGivenIDDoesNotExist()
        {
            // Arrange
            var cartId = 100; // Assuming cart with UserId 100 does not exist

            // Act
            var result = _cartController.GetByID(cartId);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Add_AddsCartToDatabase()
        {
            // Arrange
            var cart = new Cart(1, 1);

            // Act
            _cartController.Add(cart);

            var result = _cartController.GetByID(cart.UserId);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.UserId, Is.EqualTo(cart.UserId));
                Assert.That(result.ProductId, Is.EqualTo(cart.ProductId));
            });
        }

        [Test]
        public void Add_ShouldNotAdd_WhenCartIsNull()
        {
            // Act
            _cartController.Add(null);

            // Assert
            Assert.That(_cartController.GetAll(), Has.Count.EqualTo(0));
        }

        [Test]
        public void Delete_RemovesExistingCartFromDatabase()
        {
            // Arrange
            var cart = new Cart(1, 1);

            _cartController.Add(cart);

            // Act
            _cartController.Delete(cart.UserId);

            var result = _cartController.GetByID(cart.UserId);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Delete_ShouldNotThrowException_WhenCartDoesNotExist()
        {
            // Arrange
            var cartId = 100; // Assuming cart with UserId 100 does not exist

            // Act
            void testDelegate() => _cartController.Delete(cartId);

            // Assert
            Assert.That(testDelegate, Throws.Nothing);
        }

        [Test]
        public void DeleteAll_RemovesAllCartsFromDatabase()
        {
            // Arrange
            var carts = new List<Cart>
            {
                new Cart(1, 1),
                new Cart(2, 1),
                new Cart(3, 2),
            };

            _cartController.AddRange(carts);

            // Act
            _cartController.DeleteAll();

            // Assert
            Assert.That(_cartController.GetAll(), Is.Empty);
        }
    }
}
