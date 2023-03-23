using Data.Models;
using Data;

namespace Business
{
    public class FavouriteController
    {
        private ShopContext? _shopContext;

        public FavouriteController()
        {
            _shopContext = new ShopContext();
        }

        public FavouriteController(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<Favourite> GetAll()
        {
            return _shopContext.Favourites.ToList();
        }

        public Favourite GetByID(int userId)
        {
            return _shopContext.Favourites.Find(userId);
        }

        public void Add(Favourite favourite)
        {
            _shopContext.Favourites.Add(favourite);
            _shopContext.SaveChanges();
        }

        public void Delete(int userId)
        {
            var item = _shopContext.Favourites.Find(userId);

            if (item != null)
            {
                _shopContext.Favourites.Remove(item);
                _shopContext.SaveChanges();
            }
        }
    }
}
