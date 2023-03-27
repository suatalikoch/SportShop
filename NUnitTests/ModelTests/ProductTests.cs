using Data.Models;
using System.ComponentModel.DataAnnotations;

namespace NUnitTests.ModelTests
{
    [TestFixture]
    internal class ProductTests
    {
        [Test]
        public void Constructor_WithRequiredProperties_SetsProperties()
        {
            // Arrange
            string name = "Test Product";
            string description = "This is a test product.This is a test product.This is a test product.This is a test product.This is a test";
            decimal price = 10.99m;
            string image = "http://example.com/test.jpg";

            // Act
            Product product = new Product(name, description, price, image);

            // Assert
            Assert.That(product.Name, Is.EqualTo(name));
            Assert.Multiple(() =>
            {
                Assert.That(product.Description, Is.EqualTo(description));
                Assert.That(product.Price, Is.EqualTo(price));
                Assert.That(product.Image, Is.EqualTo(image));
            });
        }

        [Test]
        public void Constructor_WithAllProperties_SetsProperties()
        {
            // Arrange
            string name = "Test Product";
            string description = "This is a test product.This is a test product.This is a test product.This is a test product.This is a test product.";
            decimal price = 10.99m;
            double discount = 0.2;
            string image = "http://example.com/test.jpg";
            int categoryId = 1;
            int subCategoryId = 2;

            // Act
            Product product = new(name, description, price, discount, image, categoryId, subCategoryId);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(product.Name, Is.EqualTo(name));
                Assert.That(product.Description, Is.EqualTo(description));
                Assert.That(product.Price, Is.EqualTo(price));
                Assert.That(product.Discount, Is.EqualTo(discount));
                Assert.That(product.Image, Is.EqualTo(image));
                Assert.That(product.CategoryId, Is.EqualTo(categoryId));
                Assert.That(product.SubCategoryId, Is.EqualTo(subCategoryId));
            });
        }

        [Test]
        public void ToString_ReturnsExpectedString()
        {
            // Arrange
            int id = 1;
            string name = "Test Product";
            string description = "This is a test product.This is a test product.This is a test product.This is a test product.This is a test product.";
            decimal price = 10.99m;
            double discount = 0.2;
            string image = "http://example.com/test.jpg";
            int categoryId = 1;
            int subCategoryId = 2;
            Product product = new Product
            {
                Id = id,
                Name = name,
                Description = description,
                Price = price,
                Discount = discount,
                Image = image,
                CategoryId = categoryId,
                SubCategoryId = subCategoryId
            };

            // Act
            string result = product.ToString();

            // Assert
            string expected = $"{id} {name} {description} {price} {discount} {image} {categoryId} {subCategoryId}";
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Constructor_WithInvalidName_ThrowsValidationException()
        {
            // Arrange
            string name = "";
            string description = "This is a test product.";
            decimal price = 10.99m;
            string image = "http://example.com/test.jpg";

            // Act & Assert
            Assert.Throws<ValidationException>(() => new Product(name, description, price, image));
        }

        [Test]
        public void Constructor_WithInvalidDescription_ThrowsValidationException()
        {
            // Arrange
            string name = "Test Product";
            string description = "";
            decimal price = 10.99m;
            string image = "http://example.com/test.jpg";

            // Act & Assert
            Assert.Throws<ValidationException>(() => new Product(name, description, price, image));
        }
    }
}
