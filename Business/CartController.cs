using Data.Models;
using Data;

namespace Business
{
    public class CartController
    {
        private ShopContext? _shopContext;

        public CartController()
        {
            _shopContext = new ShopContext();
        }

        public CartController(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<Cart> GetAll()
        {
            return _shopContext.Carts.ToList();
        }

        public Cart GetByID(int userId)
        {
            return _shopContext.Carts.Find(userId);
        }

        public void Add(Cart cart)
        {
            _shopContext.Carts.Add(cart);
            _shopContext.SaveChanges();
        }

        public void Delete(int userId)
        {
            var item = _shopContext.Carts.Find(userId);

            if (item != null)
            {
                _shopContext.Carts.Remove(item);
                _shopContext.SaveChanges();
            }
        }
    }
}
