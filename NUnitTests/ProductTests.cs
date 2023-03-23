using Business;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace NUnitTests
{
    public class ProductTests
    {
        [TestCase]
        public void ListAllProductsInDatabase()
        {
            var data = new List<Product>()
            {
                new Product("testProduct1", "Testcription1", 5.25m, 2, "https:www.testimage2.com", 1, 1) { Id = 1 },
                new Product("testProduct2", "Testcription2", 11.96m, 0, "https:www.testimage2.com", 1, 1) { Id = 2 },
                new Product("testProduct3", "Testcription3", 25.25m, 20, "https:www.testimage2.com", 1, 1) { Id = 3 },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ShopContext>();
            mockContext.Setup(c => c.Products).Returns(mockSet.Object);

            var service = new ProductController(mockContext.Object);
            data.ToList().ForEach(p => service.Add(p));

            var products = service.GetAll();

            Assert.That(products, Has.Count.EqualTo(3));
        }

        [TestCase]
        public void AddProductInDatabase()
        {
            var data = new List<Product>()
            {
                new Product("testProduct1", "Testcription", 4.25m, 5, "https:www.testimage.com", 1, 1) { Id = 1 }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ShopContext>();
            mockContext.Setup(c => c.Products).Returns(mockSet.Object);

            var service = new ProductController(mockContext.Object);
            data.ToList().ForEach(p => service.Add(p));

            var product = service.GetByID(1);

            Assert.That(product, Is.Not.Null);
        }

        [TestCase]
        public void FetchProductInDatabase()
        {
            var data = new List<Product>()
            {
                new Product("testProduct1", "Testcription", 4.25m, 5, "https:www.testimage.com", 1, 1) { Id = 1 }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ShopContext>();
            mockContext.Setup(c => c.Products).Returns(mockSet.Object);

            var service = new ProductController(mockContext.Object);
            data.ToList().ForEach(p => service.Add(p));

            var product = service.GetByID(1);

            Assert.That(product.Name, Is.EqualTo("testProduct1"));
        }

        [TestCase]
        public void UpdateProductInDatabase()
        {
            var data = new List<Product>()
            {
                new Product("testProduct1", "Testcription", 4.25m, 5, "https:www.testimage.com", 1, 1) { Id = 1 }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ShopContext>();
            mockContext.Setup(c => c.Products).Returns(mockSet.Object);

            var service = new ProductController(mockContext.Object);
            data.ToList().ForEach(p => service.Add(p));

            var product = service.GetByID(1);
            product.Name = "testProduct2";

            service.Update(product);

            var productChanged = service.GetByID(1);

            Assert.That(productChanged.Name, Is.EqualTo("testProduct2"));
        }

        [TestCase]
        public void DeleteProductInDatabase()
        {
            var data = new List<Product>()
            {
                new Product("testProduct1", "Testcription", 4.25m, 5, "https:www.testimage.com", 1, 1) { Id = 1 }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ShopContext>();
            mockContext.Setup(c => c.Products).Returns(mockSet.Object);

            var service = new ProductController(mockContext.Object);
            data.ToList().ForEach(p => service.Add(p));

            service.Delete(1);

            var product = service.GetByID(1);

            Assert.That(product, Is.EqualTo(null));
        }
    }
}
