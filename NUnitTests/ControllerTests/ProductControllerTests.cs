using Business;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace NUnitTests.ControllerTests
{
    [TestFixture]
    public class ProductControllerTests
    {
        private ShopContext _shopContext;
        private UserController _userController;
        private ProductController _productController;
        private FavouriteController _favouriteController;
        private CartController _cartController;

        [SetUp]
        public void Setup()
        {
            // Set up a new in-memory database for testing
            var options = new DbContextOptionsBuilder<ShopContext>()
                .UseInMemoryDatabase(databaseName: "test_database")
                .Options;

            _shopContext = new ShopContext(options);
            _userController = new UserController(_shopContext);
            _productController = new ProductController(_shopContext);
            _favouriteController = new FavouriteController(_shopContext);
            _cartController = new CartController(_shopContext);
        }

        [TearDown]
        public void TearDown()
        {
            // Dispose of the in-memory database after each test
            _shopContext.Database.EnsureDeleted();
            _shopContext.Dispose();
        }

        [Test]
        public void Constructor_ShouldCreateProductControllerWithDefaultConnection()
        {
            // Arrange
            var productController = new ProductController();

            // Assert
            Assert.That(productController, Is.Not.Null);
        }

        [Test]
        public void GetAll_ReturnsAllProducts()
        {
            // Arrange
            var expectedProducts = new List<Product>
            {
                new Product("Product1", "Description1Description1Description1Description1Description1Description1Description1Description1Description1", 10.00m, "image1.jpg") { Id = 1 },
                new Product("Product2", "Description2Description2Description2Description2Description2Description2Description2Description2Description2", 20.00m, "image2.jpg") { Id = 2 },
                new Product("Product3", "Description3Description3Description3Description3Description3Description3Description3Description3Description3", 30.00m, "image3.jpg") { Id = 3 },
            };

            _productController.AddRange(expectedProducts);

            // Act
            var actualProducts = _productController.GetAll();

            // Assert
            Assert.That(actualProducts, Has.Count.EqualTo(expectedProducts.Count));

            foreach (var expectedProduct in expectedProducts)
            {
                var actualProduct = actualProducts.FirstOrDefault(x => x.Id == expectedProduct.Id);
                Assert.That(actualProduct, Is.Not.Null);
                Assert.Multiple(() =>
                {
                    Assert.That(actualProduct.Name, Is.EqualTo(expectedProduct.Name));
                    Assert.That(actualProduct.Price, Is.EqualTo(expectedProduct.Price));
                });
            }
        }

        [Test]
        public void GetAll_ReturnsEmptyList_WhenNoProductsExist()
        {
            // Arrange
            _productController.RemoveRange(_shopContext.Products.ToList());

            var expectedProducts = new List<Product>();

            // Act
            var actualProducts = _productController.GetAll();

            // Assert
            Assert.That(actualProducts, Has.Count.EqualTo(expectedProducts.Count));
            CollectionAssert.AreEquivalent(expectedProducts, actualProducts);
        }

        [Test]
        public void GetByID_ReturnsCorrectProduct()
        {
            // Arrange
            var expectedProduct = new Product("Product1", "Description1Description1Description1Description1Description1Description1Description1Description1Description1", 10.00m, "image1.jpg") { Id = 1 };

            _productController.Add(expectedProduct);

            // Act
            var actualProduct = _productController.GetByID(expectedProduct.Id);

            // Assert
            Assert.That(actualProduct, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(actualProduct.Id, Is.EqualTo(expectedProduct.Id));
                Assert.That(actualProduct.Name, Is.EqualTo(expectedProduct.Name));
                Assert.That(actualProduct.Price, Is.EqualTo(expectedProduct.Price));
            });
        }

        [Test]
        public void GetByID_ReturnsNullWhenProductDoesNotExist()
        {
            // Act
            var actualProduct = _productController.GetByID(1);

            // Assert
            Assert.That(actualProduct, Is.Null);
        }

        [Test]
        public void GetFavouriteProducts_WhenUserHasFavourites_ReturnsListOfProducts()
        {
            // Arrange
            int userId = 2; // user ID that has favourites

            var expectedProducts = new List<Product>
            {
                new Product("Product1", "Description1Description1Description1Description1Description1Description1Description1Description1Description1", 10.00m, "image1.jpg") { Id = 1 },
                new Product("Product2", "Description2Description2Description2Description2Description2Description2Description2Description2Description2", 20.00m, "image2.jpg") { Id = 2 },
                new Product("Product3", "Description3Description3Description3Description3Description3Description3Description3Description3Description3", 30.00m, "image3.jpg") { Id = 3 },
            };

            // Add some products to the favourites for the user
            var favourites = new List<Favourite>()
            {
                new Favourite { UserId = userId, ProductId = 1 },
                new Favourite { UserId = userId, ProductId = 2 },
                new Favourite { UserId = userId, ProductId = 3 }
            };

            var user = new User("User1", "Userov1", "useruserov@gmail.com", "@dsfwqfas25151dsafasf1o1v") { Id = userId };

            _productController.AddRange(expectedProducts);
            _favouriteController.AddRange(favourites);
            _userController.Add(user);

            // Act
            var result = _productController.GetFavouriteProducts(userId);

            // Assert
            Assert.That(result, Is.Not.Empty);
            Assert.That(result, Has.All.InstanceOf<Product>());
        }

        [Test]
        public void GetFavouriteProducts_WhenUserIdDoesNotExist_ReturnsEmptyList()
        {
            // Arrange
            int userId = 10; // user ID that does not exist

            // Act
            var result = _productController.GetFavouriteProducts(userId);

            // Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void GetFavouriteProducts_WhenUserHasNoFavourites_ReturnsEmptyList()
        {
            // Arrange
            int userId = 1; // user ID that exists but has no favourites

            // Act
            var result = _productController.GetFavouriteProducts(userId);

            // Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void GetCartProducts_ReturnsAllCartProductsForUser()
        {
            // Arrange
            int userId = 1;

            var expectedProducts = new List<Product>
            {
                new Product("Product1", "Description1Description1Description1Description1Description1Description1Description1Description1Description1", 10.00m, "image1.jpg") { Id = 1 },
                new Product("Product2", "Description2Description2Description2Description2Description2Description2Description2Description2Description2", 20.00m, "image2.jpg") { Id = 2 },
                new Product("Product3", "Description3Description3Description3Description3Description3Description3Description3Description3Description3", 30.00m, "image3.jpg") { Id = 3 },
            };

            // Add some products to the cart for the user
            var carts = new List<Cart>()
            {
                new Cart { UserId = userId, ProductId = 1 },
                new Cart { UserId = userId, ProductId = 2 },
                new Cart { UserId = userId, ProductId = 3 }
            };

            var user = new User("User1", "Userov1", "useruserov@gmail.com", "@dsfwqfas25151dsafasf1o1v") { Id = userId };

            _productController.AddRange(expectedProducts);
            _cartController.AddRange(carts);
            _userController.Add(user);

            // Act
            var result = _productController.GetCartProducts(userId);

            // Assert
            Assert.That(result, Has.Count.EqualTo(3));
            Assert.Multiple(() =>
            {
                Assert.That(result.Any(x => x.Id == 1), Is.True);
                Assert.That(result.Any(x => x.Id == 2), Is.True);
                Assert.That(result.Any(x => x.Id == 3), Is.True);
            });
        }

        [Test]
        public void Add_AddsProductToDatabase()
        {
            // Arrange
            var product = new Product("Product1", "Description1Description1Description1Description1Description1Description1Description1Description1Description1", 10.00m, "image1.jpg") { Id = 1 };

            // Act
            _productController.Add(product);

            // Assert
            var result = _productController.GetByID(product.Id);

            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.Name, Is.EqualTo(product.Name));
                Assert.That(result.Price, Is.EqualTo(product.Price));
            });
        }

        [Test]
        public void Add_DoesNotAddNullProduct()
        {
            // Act
            _productController.Add(null);

            var result = _productController.GetAll();

            // Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Update_UpdatesProductInDatabase()
        {
            // Arrange
            var product = new Product("Product1", "Description1Description1Description1Description1Description1Description1Description1Description1Description1", 10.00m, "image1.jpg") { Id = 1 };

            _productController.Add(product);

            // Act

            product.Name = "New Name";
            product.Price = 12.99m;

            _productController.Update(product);

            // Assert
            var result = _productController.GetByID(product.Id);

            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.Name, Is.EqualTo(product.Name));
                Assert.That(result.Price, Is.EqualTo(product.Price));
            });
        }

        [Test]
        public void Update_DoesNotUpdateNonexistentProduct()
        {
            // Arrange
            var product = new Product("Product1", "Description1Description1Description1Description1Description1Description1Description1Description1Description1", 10.00m, "image1.jpg") { Id = 1 };

            // Act
            _productController.Update(product);

            var result = _productController.GetAll();

            // Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Delete_RemovesProductFromDatabase()
        {
            // Arrange
            var product = new Product("Product1", "Description1Description1Description1Description1Description1Description1Description1Description1Description1", 10.00m, "image1.jpg") { Id = 1 };

            _productController.Add(product);

            // Act
            _productController.Delete(product.Id);

            // Assert
            var result = _productController.GetByID(product.Id);
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Delete_DoesNotRemoveNonexistentProduct()
        {
            // Act
            _productController.Delete(1);

            var result = _productController.GetAll();

            // Assert
            Assert.That(result, Is.Empty);
        }
    }
}
