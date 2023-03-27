using Data.Models;
using System.ComponentModel.DataAnnotations;

namespace NUnitTests.ModelTests
{
    internal class UserTests
    {
        private User _user;

        [SetUp]
        public void Setup()
        {
            _user = new User();
        }

        [Test]
        public void UserConstructor_ShouldSetProperties()
        {
            // Assert
            var user = new User("John", "Doe", "johndoe@example.com", "password");

            Assert.That(user.FirstName, Is.EqualTo("John"));
            Assert.Multiple(() =>
            {
                Assert.That(user.LastName, Is.EqualTo("Doe"));
                Assert.That(user.Email, Is.EqualTo("johndoe@example.com"));
                Assert.That(user.Password, Is.EqualTo("password"));
            });
        }

        [Test]
        public void UserConstructor_WithAllParameters_ShouldSetProperties()
        {
            // Arrange
            DateTimeOffset registrationDate = DateTimeOffset.Now;
            DateTimeOffset lastLoginDate = DateTimeOffset.Now;

            // Act
            var user = new User("John", "Doe", "johndoe@example.com", "password", "1234567890", "123 Main St", "Anytown", "CA", "12345", "USA", true, true, registrationDate, lastLoginDate);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(user.FirstName, Is.EqualTo("John"));
                Assert.That(user.LastName, Is.EqualTo("Doe"));
                Assert.That(user.Email, Is.EqualTo("johndoe@example.com"));
                Assert.That(user.Password, Is.EqualTo("password"));
                Assert.That(user.Phone, Is.EqualTo("1234567890"));
                Assert.That(user.Address, Is.EqualTo("123 Main St"));
                Assert.That(user.City, Is.EqualTo("Anytown"));
                Assert.That(user.Region, Is.EqualTo("CA"));
                Assert.That(user.PostalCode, Is.EqualTo("12345"));
                Assert.That(user.Country, Is.EqualTo("USA"));
                Assert.That(user.IsEmailConfirmed, Is.EqualTo(true));
                Assert.That(user.IsActive, Is.EqualTo(true));
                Assert.That(user.RegistrationDate, Is.EqualTo(registrationDate));
                Assert.That(user.LastLoginDate, Is.EqualTo(lastLoginDate));
            });
        }

        [Test]
        public void ToString_ShouldReturnStringRepresentation()
        {
            // Arrange
            var user = new User("John", "Doe", "johndoe@example.com", "password");
            
            user.Phone = "1234567890";
            user.Address = "123 Main St";
            user.City = "Anytown";
            user.Region = "CA";
            user.PostalCode = "12345";
            user.Country = "USA";
            user.IsEmailConfirmed = true;
            user.IsActive = true;
            DateTimeOffset registrationDate = DateTimeOffset.Now;
            user.RegistrationDate = registrationDate;
            DateTimeOffset lastLoginDate = DateTimeOffset.Now;
            user.LastLoginDate = lastLoginDate;

            // Act
            string result = user.ToString();

            // Assert
            string expected = $"{user.Id} {user.FirstName} {user.LastName} {user.Email} {user.Phone} {user.Address} {user.City} {user.Region} {user.PostalCode} {user.Country} {user.IsEmailConfirmed} {user.IsActive} {registrationDate} {lastLoginDate}";
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void FirstName_WithWhiteSpace_ShouldNotSetProperty()
        {
            // Assert
            var user = new User("John", "Doe", "johndoe@example.com", "password");

            // Act
            Assert.Throws<ValidationException>(() => user.FirstName = "John ");
        }

        [Test]
        public void LastName_WithWhiteSpace_ShouldNotSetProperty()
        {
            // Assert
            var user = new User("John", "Doe", "johndoe@example.com", "password");

            // Act
            Assert.Throws<ValidationException>(() => user.LastName = "Doe ");
        }

        [Test]
        public void Email_WithWhiteSpace_ShouldNotSetProperty()
        {
            // Assert
            var user = new User("John", "Doe", "johndoe@example.com", "password");

            // Act
            Assert.Throws<ValidationException>(() => user.Email = "johndoe@example.com ");
        }

        [Test]
        public void Password_SettingValidPassword_SetsPassword()
        {
            // Arrange
            string password = "validpassword123";

            // Act
            _user.Password = password;

            // Assert
            Assert.That(_user.Password, Is.EqualTo(password));
        }

        [Test]
        public void Password_SettingInvalidPasswordWithWhitespace_ThrowsValidationException()
        {
            // Arrange
            string password = "invalid password";

            // Act + Assert
            Assert.Throws<ValidationException>(() => _user.Password = password);
        }

        [Test]
        public void Password_SettingInvalidPasswordWithLengthLessThanThree_ThrowsValidationException()
        {
            // Arrange
            string password = "pa";

            // Act + Assert
            Assert.Throws<ValidationException>(() => _user.Password = password);
        }

        [Test]
        public void Password_SettingInvalidPasswordWithLengthMoreThan255_ThrowsValidationException()
        {
            // Arrange
            string password = new string('x', 256);

            // Act + Assert
            Assert.Throws<ValidationException>(() => _user.Password = password);
        }
    }
}
