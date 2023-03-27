using Data.Models;

namespace NUnitTests.ModelTests
{
    [TestFixture]
    internal class CartTests
    {
        [Test]
        public void Cart_Constructor_Should_Create_Object_With_Expected_Values()
        {
            // Arrange
            int userId = 1;
            int productId = 2;

            // Act
            var cart = new Cart(userId, productId);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(cart.UserId, Is.EqualTo(userId));
                Assert.That(cart.ProductId, Is.EqualTo(productId));
            });
        }

        [Test]
        public void Cart_ToString_Should_Return_Expected_String()
        {
            // Arrange
            int userId = 1;
            int productId = 2;
            var cart = new Cart(userId, productId);

            // Act
            var result = cart.ToString();

            // Assert
            Assert.That(result, Is.EqualTo($"{userId} {productId}"));
        }

        [Test]
        public void Cart_User_Should_Return_Expected_User()
        {
            // Arrange
            int userId = 1;
            int productId = 2;
            var user = new User { Id = userId };
            var product = new Product { Id = productId };
            var cart = new Cart { UserId = userId, ProductId = productId, User = user, Product = product };

            // Act
            var result = cart.User;

            // Assert
            Assert.That(result, Is.EqualTo(user));
        }

        [Test]
        public void Cart_Product_Should_Return_Expected_Product()
        {
            // Arrange
            int userId = 1;
            int productId = 2;
            var user = new User { Id = userId };
            var product = new Product { Id = productId };
            var cart = new Cart { UserId = userId, ProductId = productId, User = user, Product = product };

            // Act
            var result = cart.Product;

            // Assert
            Assert.That(result, Is.EqualTo(product));
        }
    }
}
