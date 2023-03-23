using Business;
using Data.Models;
using Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class UserTests
    {
        [TestCase]
        public void AddUserInDatabase()
        {
            var data = new List<User>()
            {
                new User("testProduct1", "Testcription1", 5.25m, 2, "https:www.testimage2.com", 1, 1) { Id = 1 },
                new User("testProduct2", "Testcription2", 11.96m, 0, "https:www.testimage2.com", 1, 1) { Id = 2 },
                new User("testProduct3", "Testcription3", 25.25m, 20, "https:www.testimage2.com", 1, 1) { Id = 3 },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ShopContext>();
            mockContext.Setup(c => c.Products).Returns(mockSet.Object);

            var service = new ProductController(mockContext.Object);
            data.ToList().ForEach(p => service.Add(p));

            var products = service.GetAll();

            Assert.That(products, Has.Count.EqualTo(3));
        }

        [TestCase]
        public void LoginUser()
        {

        }
    }
}
