using Data.Models;
using Data;

namespace Business
{
    public class ProductController
    {
        private readonly ShopContext? _shopContext;

        public ProductController()
        {
            _shopContext = new ShopContext();
        }

        public ProductController(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<Product> GetAll()
        {
            return _shopContext.Products.ToList();
        }

        public List<Product> GetFavouriteProducts(int id)
        {
            List<Product> products = new();
            List<Favourite> favourites = _shopContext.Favourites.Where(x => x.UserId == id).ToList();

            foreach (Favourite favourite in favourites)
            {
                products.Add(GetByID(favourite.ProductId));
            }

            return products;
        }

        public List<Product> GetCartProducts(int id)
        {
            List<Product> products = new();
            List<Cart> carts = _shopContext.Carts.Where(x => x.UserId == id).ToList();

            foreach (Cart cart in carts)
            {
                products.Add(GetByID(cart.ProductId));
            }

            return products;
        }

        public Product GetByID(int id)
        {
            return _shopContext.Products.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Product product)
        {
            _shopContext.Products.Add(product);
            _shopContext.SaveChanges();
        }

        public void Update(Product product)
        {
            var item = GetByID(product.Id);

            if (item != null)
            {
                _shopContext.Entry(item).CurrentValues.SetValues(product);
                _shopContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var item = GetByID(id);

            if (item != null)
            {
                _shopContext.Products.Remove(item);
                _shopContext.SaveChanges();
            }
        }
    }
}
