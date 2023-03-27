using Business;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace NUnitTests.ControllerTests
{
    [TestFixture]
    public class CategoryControllerTests
    {
        private ShopContext _shopContext;
        private CategoryController _categoryController;

        [SetUp]
        public void Setup()
        {
            // Set up a new in-memory database for testing
            var options = new DbContextOptionsBuilder<ShopContext>()
                .UseInMemoryDatabase(databaseName: "test_database")
                .Options;

            _shopContext = new ShopContext(options);
            _categoryController = new CategoryController(_shopContext);
        }

        [TearDown]
        public void TearDown()
        {
            // Dispose of the in-memory database after each test
            _shopContext.Database.EnsureDeleted();
            _shopContext.Dispose();
        }

        [Test]
        public void Constructor_ShouldCreateCategoryControllerWithDefaultConnection()
        {
            // Arrange
            var categoryController = new CategoryController();

            // Assert
            Assert.That(categoryController, Is.Not.Null);
        }

        [Test]
        public void GetAll_ReturnsAllCategories()
        {
            // Arrange
            var categories = new List<Category>
            {
                new Category("Category 1"),
                new Category("Category 2"),
                new Category("Category 3")
            };

            _categoryController.AddRange(categories);

            // Act
            var result = _categoryController.GetAll();

            // Assert
            Assert.That(result, Has.Count.EqualTo(categories.Count));
            Assert.That(result.All(c => categories.Any(cc => cc.Id == c.Id && cc.Name == c.Name)), Is.True);
        }

        [Test]
        public void GetAll_ReturnsEmptyList_WhenNoCategoriesExist()
        {
            // Act
            var result = _categoryController.GetAll();

            // Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void GetByID_ReturnsCategoryWithGivenID()
        {
            // Arrange
            var category = new Category("Category 1");

            _categoryController.Add(category);

            // Act
            var result = _categoryController.GetByID(category.Id);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.Id, Is.EqualTo(category.Id));
                Assert.That(result.Name, Is.EqualTo(category.Name));
            });
        }

        [Test]
        public void GetByID_ReturnsNull_WhenCategoryWithGivenIDDoesNotExist()
        {
            // Arrange
            var categoryId = 100; // Assuming category with Id 100 does not exist

            // Act
            var result = _categoryController.GetByID(categoryId);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Add_AddsCategoryToDatabase()
        {
            // Arrange
            var category = new Category("Category 1");

            // Act
            _categoryController.Add(category);

            var result = _categoryController.GetByID(category.Id);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.Id, Is.EqualTo(category.Id));
                Assert.That(result.Name, Is.EqualTo(category.Name));
            });
        }

        [Test]
        public void Add_ShouldNotAdd_WhenCategoryIsNull()
        {
            // Act
            _categoryController.Add(null);

            // Assert
            Assert.That(_categoryController.GetAll(), Has.Count.EqualTo(0));
        }

        [Test]
        public void Update_UpdatesExistingCategoryInDatabase()
        {
            // Arrange
            var category = new Category("Category 1");

            _categoryController.Add(category);

            var updatedCategory = new Category("Category 2") { Id = category.Id };

            // Act
            _categoryController.Update(updatedCategory);

            var result = _categoryController.GetByID(category.Id);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.Id, Is.EqualTo(updatedCategory.Id));
                Assert.That(result.Name, Is.EqualTo(updatedCategory.Name));
            });
        }

        [Test]
        public void Delete_RemovesExistingCategoryFromDatabase()
        {
            // Arrange
            var category = new Category("Category 1");

            _categoryController.Add(category);

            // Act
            _categoryController.Delete(category.Id);

            var result = _categoryController.GetByID(category.Id);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Delete_ShouldNotThrowException_WhenCategoryDoesNotExist()
        {
            // Arrange
            var categoryId = 100; // Assuming category with Id 100 does not exist

            // Act
            void testDelegate() => _categoryController.Delete(categoryId);

            // Assert
            Assert.That(testDelegate, Throws.Nothing);
        }
    }
}
