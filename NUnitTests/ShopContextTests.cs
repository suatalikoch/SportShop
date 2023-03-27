using Data;
using Microsoft.EntityFrameworkCore;

namespace NUnitTests
{
    internal class ShopContextTests
    {
        private ShopContext _context;
        private DbContextOptions<ShopContext> _options;

        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<ShopContext>()
                .UseInMemoryDatabase(databaseName: "test_database")
                .Options;
            _context = ShopContext.CreateTestContext();
        }

        [TearDown]
        public void Teardown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Test]
        public void TestConstructor()
        {
            // Act
            var categories = _context.Categories.ToList();

            // Assert
            Assert.That(categories, Is.Not.Null);
            Assert.That(categories, Is.Empty);
        }

        [Test]
        public void TestConstructorWithOptions()
        {
            // Act
            var categories = _context.Categories.ToList();

            // Assert
            Assert.That(categories, Is.Not.Null);
            Assert.That(categories, Is.Empty);
        }

        [Test]
        public void TestCreateTestContext()
        {
            // Act
            var categories = _context.Categories.ToList();

            // Assert
            Assert.That(categories, Is.Not.Null);
            Assert.That(categories, Is.Empty);
        }
    }
}
