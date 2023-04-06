using Data.Models;
using Data;

namespace Business
{
    public class ProductController
    {
        private readonly ShopContext _shopContext;

        public ProductController()
        {
            _shopContext = new ShopContext();
        }

        public ProductController(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        // Get all products
        public List<Product> GetAll()
        {
            return _shopContext.Products.ToList();
        }

        // Get product by ID
        public Product GetByID(int id)
        {
            return _shopContext.Products.FirstOrDefault(x => x.Id == id);
        }

        // Get products in favourites by userID
        public List<Product> GetFavouriteProducts(int userId)
        {
            List<Product> products = new();
            List<Favourite> favourites = _shopContext.Favourites.Where(x => x.UserId == userId).ToList();

            foreach (Favourite favourite in favourites)
            {
                if (GetByID(favourite.ProductId) is not null)
                {
                    products.Add(GetByID(favourite.ProductId));
                }
            }
            
            return products;
        }

        // Get products in cart by userID
        public List<Product> GetCartProducts(int userId)
        {
            List<Product> products = new();
            List<Cart> carts = _shopContext.Carts.Where(x => x.UserId == userId).ToList();

            foreach (Cart cart in carts)
            {
                if (GetByID(cart.ProductId) is not null)
                {
                    products.Add(GetByID(cart.ProductId));
                }
            }

            return products;
        }

        // Add new product
        public void Add(Product product)
        {
            if (product is not null)
            {
                _shopContext.Products.Add(product);
                _shopContext.SaveChanges();
            }
        }

        // Add new products
        public void AddRange(List<Product> products)
        {
            if (products is not null)
            {
                _shopContext.Products.AddRange(products);
                _shopContext.SaveChanges();
            }
        }

        // Update existing product
        public void Update(Product product)
        {
            var item = GetByID(product.Id);

            if (item is not null)
            {
                item.Name = product.Name;
                item.Description = product.Description;
                item.Price = product.Price;
                item.Discount = product.Discount;
                item.Image = product.Image;
                item.CategoryId = product.CategoryId;
                item.SubCategoryId = product.SubCategoryId;
                item.Category = product.Category;
                item.Subcategory = product.Subcategory;
                
                _shopContext.SaveChanges();
            }
        }

        // Remove products
        public void RemoveRange(List<Product> products)
        {
            if (products is not null)
            {
                _shopContext.Products.RemoveRange(products);
                _shopContext.SaveChanges();
            }
        }

        // Remove product by ID
        public void Delete(int id)
        {
            var item = GetByID(id);

            if (item is not null)
            {
                _shopContext.Products.Remove(item);
                _shopContext.SaveChanges();
            }
        }
    }
}
