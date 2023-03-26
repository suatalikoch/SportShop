using Business;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace NUnitTests
{
    [TestFixture]
    public class SubcategoryTests
    {
        private ShopContext _shopContext;
        private SubcategoryController _subcategoryController;

        [SetUp]
        public void Setup()
        {
            // Set up a new in-memory database for testing
            var options = new DbContextOptionsBuilder<ShopContext>()
                .UseInMemoryDatabase(databaseName: "test_database")
                .Options;

            _shopContext = new ShopContext(options);
            _subcategoryController = new SubcategoryController(_shopContext);
        }

        [TearDown]
        public void TearDown()
        {
            // Dispose of the in-memory database after each test
            _shopContext.Database.EnsureDeleted();
            _shopContext.Dispose();
        }

        [Test]
        public void GetAll_ShouldReturnAllSubcategories()
        {
            // Arrange
            var subcategories = new List<Subcategory>
            {
                new Subcategory("Subcategory 1", 1),
                new Subcategory("Subcategory 2", 1),
                new Subcategory("Subcategory 3", 2)
            };

            _subcategoryController.AddRange(subcategories);

            // Act
            var result = _subcategoryController.GetAll();

            // Assert
            Assert.That(result, Has.Count.EqualTo(subcategories.Count));

            foreach (var subcategory in subcategories)
            {
                Assert.That(result, Contains.Item(subcategory));
            }
        }

        [Test]
        public void GetByID_ShouldReturnSubcategoryWithGivenID()
        {
            // Arrange
            var subcategory1 = new Subcategory("Subcategory 1", 1);
            var subcategory2 = new Subcategory("Subcategory 2", 1);

            _subcategoryController.AddRange(new List<Subcategory> { subcategory1, subcategory2 });

            // Act
            var result = _subcategoryController.GetByID(subcategory2.Id);

            // Assert
            Assert.That(result, Is.EqualTo(subcategory2));
        }

        [Test]
        public void Add_ShouldAddSubcategoryToDatabase()
        {
            // Arrange
            var subcategory = new Subcategory("Subcategory 1", 1);

            // Act
            _subcategoryController.Add(subcategory);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(_shopContext.Subcategories.Count(), Is.EqualTo(1));
                Assert.That(_shopContext.Subcategories, Contains.Item(subcategory));
            });
        }

        [Test]
        public void Add_ShouldNotAddSubcategory_WhenGivenSubcategoryIsNull()
        {
            // Act
            void testDelegate() => _subcategoryController.Add(null);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(testDelegate, Throws.Nothing);
                Assert.That(_shopContext.Subcategories.Count(), Is.EqualTo(0));
            });
        }

        [Test]
        public void AddRange_ShouldAddListOfSubcategoriesToDatabase()
        {
            // Arrange
            var subcategories = new List<Subcategory>
            {
                new Subcategory("Subcategory 1", 1),
                new Subcategory("Subcategory 2", 1),
                new Subcategory("Subcategory 3", 2)
            };

            // Act
            _subcategoryController.AddRange(subcategories);

            // Assert
            Assert.That(_shopContext.Subcategories.Count(), Is.EqualTo(subcategories.Count));

            foreach (var subcategory in subcategories)
            {
                Assert.That(_shopContext.Subcategories, Contains.Item(subcategory));
            }
        }

        [Test]
        public void AddRange_ShouldNotAddListOfSubcategories_WhenGivenListIsNull()
        {
            // Act
            void testDelegate() => _subcategoryController.AddRange(null);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(testDelegate, Throws.Nothing);
                Assert.That(_shopContext.Subcategories.Count(), Is.EqualTo(0));
            });
        }

        [Test]
        public void Update_ShouldUpdateSubcategory_WhenGivenASubcategoryWithTheSameId()
        {
            // Arrange
            var subcategory = new Subcategory("TestCategory", 1);

            _subcategoryController.Add(subcategory);

            var updatedSubcategory = new Subcategory("TestCategoryUpdated", 2) { Id = subcategory.Id };

            // Act
            _subcategoryController.Update(updatedSubcategory);

            // Assert
            var retrievedSubcategory = _subcategoryController.GetByID(subcategory.Id);

            Assert.Multiple(() =>
            {
                Assert.That(retrievedSubcategory.Name, Is.EqualTo(updatedSubcategory.Name));
                Assert.That(retrievedSubcategory.CategoryId, Is.EqualTo(updatedSubcategory.CategoryId));
            });
        }

        [Test]
        public void Delete_ShouldRemoveSubcategory_WhenSubcategoryExists()
        {
            // Arrange
            var subcategory = new Subcategory("TestCategory", 1);

            _subcategoryController.Add(subcategory);

            // Act
            _subcategoryController.Delete(subcategory.Id);

            var deletedSubcategory = _subcategoryController.GetByID(subcategory.Id);

            // Assert
            Assert.That(deletedSubcategory, Is.Null);
        }

        [Test]
        public void Delete_ShouldNotThrowException_WhenSubcategoryDoesNotExist()
        {
            // Act
            void testDelegate() => _subcategoryController.Delete(999);

            // Assert
            Assert.That(testDelegate, Throws.Nothing);
        }
    }
}
