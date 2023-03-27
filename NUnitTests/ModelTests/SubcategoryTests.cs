using Data.Models;

namespace NUnitTests.ModelTests
{
    [TestFixture]
    internal class SubcategoryTests
    {
        [Test]
        public void Subcategory_Id_Should_Set_Correctly()
        {
            // Arrange
            int expectedId = 1;

            // Act
            Subcategory subcategory = new();
            subcategory.Id = expectedId;

            // Assert
            Assert.That(subcategory.Id, Is.EqualTo(expectedId));
        }

        [Test]
        public void Subcategory_Name_Should_Set_Correctly()
        {
            // Arrange
            string expectedName = "Test Subcategory";

            // Act
            Subcategory subcategory = new();
            subcategory.Name = expectedName;

            // Assert
            Assert.That(subcategory.Name, Is.EqualTo(expectedName));
        }

        [Test]
        public void Subcategory_CategoryId_Should_Set_Correctly()
        {
            // Arrange
            int expectedCategoryId = 1;

            // Act
            Subcategory subcategory = new();
            subcategory.CategoryId = expectedCategoryId;

            // Assert
            Assert.That(subcategory.CategoryId, Is.EqualTo(expectedCategoryId));
        }

        [Test]
        public void Subcategory_Constructor_Should_Set_Properties_Correctly()
        {
            // Arrange
            string expectedName = "Test Subcategory";
            int expectedCategoryId = 1;

            // Act
            Subcategory subcategory = new(expectedName, expectedCategoryId);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(subcategory.Name, Is.EqualTo(expectedName));
                Assert.That(subcategory.CategoryId, Is.EqualTo(expectedCategoryId));
            });
        }

        [Test]
        public void Subcategory_ToString_Should_Return_Correct_String()
        {
            // Arrange
            int expectedId = 1;
            string expectedName = "Test Subcategory";
            int expectedCategoryId = 2;
            Subcategory subcategory = new(expectedName, expectedCategoryId);
            subcategory.Id = expectedId;

            // Act
            string result = subcategory.ToString();

            // Assert
            string expectedString = $"{expectedId} {expectedName} {expectedCategoryId}";
            Assert.That(result, Is.EqualTo(expectedString));
        }
    }
}
