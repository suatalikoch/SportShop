using Data.Models;
using Data;

namespace Business
{
    public class CartController
    {
        private readonly ShopContext _shopContext;

        public CartController()
        {
            _shopContext = new ShopContext();
        }

        public CartController(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        // Get all carts
        public List<Cart> GetAll()
        {
            return _shopContext.Carts.ToList();
        }

        // Get cart by ID
        public Cart GetByID(int userId)
        {
            return _shopContext.Carts.FirstOrDefault(x => x.UserId == userId);
        }

        // Add new cart 
        public void Add(Cart cart)
        {
            if (cart is not null)
            {
                _shopContext.Carts.Add(cart);
                _shopContext.SaveChanges();
            }
        }

        // Add new carts
        public void AddRange(List<Cart> carts)
        {
            if (carts is not null)
            {
                _shopContext.Carts.AddRange(carts);
                _shopContext.SaveChanges();
            }
        }

        // Remove cart
        public void Delete(int userId)
        {
            var item = GetByID(userId);

            if (item is not null)
            {
                _shopContext.Carts.Remove(item);
                _shopContext.SaveChanges();
            }
        }

        // Remove all carts
        public void DeleteAll()
        {
            _shopContext.Carts.RemoveRange(_shopContext.Carts);
            _shopContext.SaveChanges();
        }
    }
}
