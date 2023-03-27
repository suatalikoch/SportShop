using Data.Models;

namespace NUnitTests.ModelTests
{
    [TestFixture]
    internal class CategoryTests
    {
        [Test]
        public void Category_DefaultConstructor_ShouldSetPropertiesToDefaultValues()
        {
            // Arrange & Act
            var category = new Category();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(category.Id, Is.EqualTo(0));
                Assert.That(category.Name, Is.Null);
            });
        }

        [Test]
        public void Category_ParameterizedConstructor_ShouldSetPropertiesToGivenValues()
        {
            // Arrange
            var expectedName = "Test Category";

            // Act
            var category = new Category(expectedName);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(category.Id, Is.EqualTo(0));
                Assert.That(category.Name, Is.EqualTo(expectedName));
            });
        }

        [Test]
        public void Category_ToString_ShouldReturnCorrectStringRepresentation()
        {
            // Arrange
            var category = new Category("Test Category");

            // Act
            var result = category.ToString();

            // Assert
            Assert.That(result, Is.EqualTo("0 Test Category"));
        }

        [Test]
        public void TestCategoryConstructor()
        {
            // Arrange
            string name = "TestCategory";

            // Act
            var category = new Category(name);

            // Assert
            Assert.That(category.Name, Is.EqualTo(name));
        }

        [Test]
        public void TestCategoryId()
        {
            // Arrange
            int id = 1;
            string name = "TestCategory";
            var category = new Category(name);

            // Act
            category.Id = id;

            // Assert
            Assert.That(category.Id, Is.EqualTo(id));
        }

        [Test]
        public void TestCategoryName()
        {
            // Arrange
            string name = "TestCategory";
            var category = new Category(name);

            // Act
            category.Name = "NewTestCategory";

            // Assert
            Assert.That(category.Name, Is.EqualTo("NewTestCategory"));
        }

        [Test]
        public void TestCategoryToString()
        {
            // Arrange
            int id = 1;
            string name = "TestCategory";
            var category = new Category(name);
            category.Id = id;

            // Act
            var result = category.ToString();

            // Assert
            Assert.That(result, Is.EqualTo($"{id} {name}"));
        }
    }
}
