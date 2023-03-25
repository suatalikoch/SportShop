using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq.Expressions;

namespace NUnitTests.Helpers
{
    public static class MockHelper
    {
        public static Mock<DbSet<T>> CreateMockSet<T>(List<T> data) where T : class
        {
            var queryableData = data.AsQueryable();
            var mockSet = new Mock<DbSet<T>>();

            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryableData.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryableData.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryableData.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryableData.GetEnumerator());

            return mockSet;
        }

        public static Mock<DbSet<T>> CreateMockSet<T>(Expression<Func<T, bool>> expression, List<T> data) where T : class
        {
            var queryableData = data.AsQueryable().Where(expression);
            var mockSet = new Mock<DbSet<T>>();

            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryableData.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryableData.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryableData.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryableData.GetEnumerator());

            return mockSet;
        }

        public static Mock<T> CreateMock<T>() where T : class
        {
            return new Mock<T>();
        }

        public static Mock<T> CreateMock<T>(Expression<Func<T, bool>> expression) where T : class
        {
            var mock = new Mock<T>();
            mock.Setup(expression);

            return mock;
        }

        public static Mock<T> CreateMock<T>(Action<Mock<T>> setup) where T : class
        {
            var mock = new Mock<T>();
            setup(mock);

            return mock;
        }

        public static Mock<T> CreateMock<T>(Expression<Func<T, bool>> expression, Action<Mock<T>> setup) where T : class
        {
            var mock = CreateMock(expression);
            setup(mock);

            return mock;
        }

        public static T Create<T>() where T : class
        {
            return new Mock<T>().Object;
        }

        public static T Create<T>(Action<Mock<T>> setup) where T : class
        {
            var mock = new Mock<T>();
            setup(mock);

            return mock.Object;
        }

        public static T Create<T>(Expression<Func<T, bool>> expression) where T : class
        {
            var mock = new Mock<T>();
            mock.Setup(expression);

            return mock.Object;
        }

        public static T Create<T>(Expression<Func<T, bool>> expression, Action<Mock<T>> setup) where T : class
        {
            var mock = CreateMock(expression);
            setup(mock);

            return mock.Object;
        }
    }
}
