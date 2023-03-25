using Business;
using Data.Models;
using Data;
using Microsoft.EntityFrameworkCore;

namespace NUnitTests
{
    [TestFixture]
    internal class UserTests
    {
        private ShopContext _shopContext;
        private UserController _userController;

        [SetUp]
        public void Setup()
        {
            // Set up a new in-memory database for testing
            var options = new DbContextOptionsBuilder<ShopContext>()
                .UseInMemoryDatabase(databaseName: "test_database")
                .Options;

            _shopContext = new ShopContext(options);
            _userController = new UserController(_shopContext);
        }

        [TearDown]
        public void TearDown()
        {
            // Dispose of the in-memory database after each test
            _shopContext.Database.EnsureDeleted();
            _shopContext.Dispose();
        }

        [Test]
        public void GetAll_ReturnsAllUsers()
        {
            // Arrange
            var expectedUsers = new List<User>
            {
                new User("User 1", "Userov 1", "user1userov1@gmail.com", "$#$R31vdfasfasfsaasfsaf") { Id = 1 },
                new User("User 2", "Userov 2", "user2userov2@gmail.com", "$#$R3safasvdfasfasfsaasfsaf") { Id = 2 },
            };

            _userController.AddRange(expectedUsers);

            // Act
            var actualUsers = _userController.GetAll();

            // Assert
            Assert.That(actualUsers, Has.Count.EqualTo(expectedUsers.Count));

            foreach (var expectedUser in expectedUsers)
            {
                var actualUser = actualUsers.FirstOrDefault(x => x.Id == expectedUser.Id);
                Assert.That(actualUser, Is.Not.Null);
                Assert.Multiple(() =>
                {
                    Assert.That(actualUser.FirstName, Is.EqualTo(expectedUser.FirstName));
                    Assert.That(actualUser.LastName, Is.EqualTo(expectedUser.LastName));
                });
            }
        }

        [Test]
        public void GetAll_ReturnsEmptyList_WhenNoUsersExist()
        {
            // Arrange
            _userController.RemoveRange(_shopContext.Users.ToList());

            var expectedUsers = new List<User>();

            // Act
            var actualUsers = _userController.GetAll();

            // Assert
            Assert.That(actualUsers, Has.Count.EqualTo(expectedUsers.Count));
            CollectionAssert.AreEquivalent(expectedUsers, actualUsers);
        }

        [Test]
        public void GetByID_ReturnsCorrectUser()
        {
            // Arrange
            var expectedUser = new User("User 1", "Userov 1", "user1userov1@gmail.com", "$#$R31vdfasfasfsaasfsaf") { Id = 1 };

            _userController.Add(expectedUser);

            // Act
            var actualUser = _userController.GetByID(expectedUser.Id);

            // Assert
            Assert.That(actualUser, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(actualUser.Id, Is.EqualTo(expectedUser.Id));
                Assert.That(actualUser.FirstName, Is.EqualTo(expectedUser.FirstName));
                Assert.That(actualUser.LastName, Is.EqualTo(expectedUser.LastName));
            });
        }

        [Test]
        public void GetByID_ReturnsNullWhenUserDoesNotExist()
        {
            // Act
            var actualUser = _userController.GetByID(1);

            // Assert
            Assert.That(actualUser, Is.Null);
        }

        [Test]
        public void GetByEmail_ReturnsUserWithMatchingEmail()
        {
            // Arrange
            var expectedUser = new User("User 1", "Userov 1", "useruserov@gmail.com", "@dsfwqfas25151dsafasf1o1v") { Id = 1 };

            // Act
            var result = _userController.GetByEmail("useruserov@gmail.com");

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.Id, Is.EqualTo(expectedUser.Id));
                Assert.That(result.FirstName, Is.EqualTo(expectedUser.FirstName));
                Assert.That(result.Email, Is.EqualTo(expectedUser.Email));
            });
        }

        [Test]
        public void GetByEmail_ReturnsNullWhenNoMatchingEmail()
        {
            // Act
            var result = _userController.GetByEmail("nonexisting@test.com");

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Add_AddsUserToDatabase()
        {
            // Arrange
            var expectedUser = new User("User 1", "Userov 1", "useruserov@gmail.com", "@dsfwqfas25151dsafasf1o1v") { Id = 1 };

            // Act
            _userController.Add(expectedUser);

            // Assert
            var actualUser = _userController.GetByID(expectedUser.Id);

            Assert.That(actualUser, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(actualUser.FirstName, Is.EqualTo(expectedUser.FirstName));
                Assert.That(actualUser.LastName, Is.EqualTo(expectedUser.LastName));
            });
        }

        [Test]
        public void Add_DoesNotAddNullUser()
        {
            // Act
            _userController.Add(null);

            var actualUser = _userController.GetAll();

            // Assert
            Assert.That(actualUser, Is.Empty);
        }

        [Test]
        public void Update_UpdatesUserInDatabase()
        {
            // Arrange
            var expectedUser = new User("User 1", "Userov 1", "useruserov@gmail.com", "@dsfwqfas25151dsafasf1o1v") { Id = 1 };

            _userController.Add(expectedUser);

            // Act

            expectedUser.FirstName = "New FirstName";
            expectedUser.LastName = "New LastName";

            _userController.Update(expectedUser);

            // Assert
            var actualUser = _userController.GetByID(expectedUser.Id);

            Assert.That(actualUser, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(actualUser.FirstName, Is.EqualTo(expectedUser.FirstName));
                Assert.That(actualUser.LastName, Is.EqualTo(expectedUser.LastName));
            });
        }

        [Test]
        public void Update_DoesNotUpdateNonexistentUser()
        {
            // Arrange
            var expectedUser = new User("User 1", "Userov 1", "useruserov@gmail.com", "@dsfwqfas25151dsafasf1o1v") { Id = 1 };

            // Act
            _userController.Update(expectedUser);

            var actualUser = _userController.GetAll();

            // Assert
            Assert.That(actualUser, Is.Empty);
        }

        [Test]
        public void Delete_RemovesUserFromDatabase()
        {
            // Arrange
            var expectedUser = new User("User 1", "Userov 1", "useruserov@gmail.com", "@dsfwqfas25151dsafasf1o1v") { Id = 1 };

            _userController.Add(expectedUser);

            // Act
            _userController.Delete(expectedUser.Id);

            // Assert
            var actualUser = _userController.GetByID(expectedUser.Id);
            Assert.That(actualUser, Is.Null);
        }

        [Test]
        public void Delete_DoesNotRemoveNonexistentUser()
        {
            // Act
            _userController.Delete(1);

            var actualUser = _userController.GetAll();

            // Assert
            Assert.That(actualUser, Is.Empty);
        }
    }
}
