using Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace NUnitTests.ModelTests
{
    [TestFixture]
    internal class FavouriteTests
    {
        [Test]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            const int userId = 1;
            const int productId = 2;

            // Act
            var favourite = new Favourite(userId, productId);
            
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(favourite.UserId, Is.EqualTo(userId));
                Assert.That(favourite.ProductId, Is.EqualTo(productId));
            });
        }

        [Test]
        public void ToString_ShouldReturnStringWithUserIdAndProductId()
        {
            // Arrange
            const int userId = 1;
            const int productId = 2;
            var favourite = new Favourite(userId, productId);

            // Act
            var result = favourite.ToString();

            // Assert
            Assert.That(result, Is.EqualTo($"{userId} {productId}"));
        }

        [Test]
        public void User_ShouldGetAndSetUser()
        {
            // Arrange
            var user = new User();
            var favourite = new Favourite();

            // Act
            favourite.User = user;

            // Assert
            Assert.That(favourite.User, Is.SameAs(user));
        }

        [Test]
        public void Product_ShouldGetAndSetProduct()
        {
            // Arrange
            var product = new Product();
            var favourite = new Favourite();

            // Act
            favourite.Product = product;

            // Assert
            Assert.That(favourite.Product, Is.SameAs(product));
        }

        [Test]
        public void UserId_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var propertyInfo = typeof(Favourite).GetProperty(nameof(Favourite.UserId));

            // Act
            var attribute = propertyInfo.GetCustomAttribute<RequiredAttribute>();

            // Assert
            Assert.That(attribute, Is.Not.Null);
        }

        [Test]
        public void UserId_ShouldHaveForeignKeyAttributeReferencingUser()
        {
            // Arrange
            var propertyInfo = typeof(Favourite).GetProperty(nameof(Favourite.UserId));

            // Act
            var attribute = propertyInfo.GetCustomAttribute<ForeignKeyAttribute>();

            // Assert
            Assert.That(attribute, Is.Not.Null);
            Assert.That(attribute.Name, Is.EqualTo(nameof(Favourite.User)));
        }

        [Test]
        public void ProductId_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var propertyInfo = typeof(Favourite).GetProperty(nameof(Favourite.ProductId));

            // Act
            var attribute = propertyInfo.GetCustomAttribute<RequiredAttribute>();

            // Assert
            Assert.That(attribute, Is.Not.Null);
        }

        [Test]
        public void ProductId_ShouldHaveForeignKeyAttributeReferencingProduct()
        {
            // Arrange
            var propertyInfo = typeof(Favourite).GetProperty(nameof(Favourite.ProductId));

            // Act
            var attribute = propertyInfo.GetCustomAttribute<ForeignKeyAttribute>();

            // Assert
            Assert.That(attribute, Is.Not.Null);
            Assert.That(attribute.Name, Is.EqualTo(nameof(Favourite.Product)));
        }
    }
}
