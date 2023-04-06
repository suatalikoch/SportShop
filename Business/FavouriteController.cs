using Data.Models;
using Data;

namespace Business
{
    public class FavouriteController
    {
        private readonly ShopContext _shopContext;

        public FavouriteController()
        {
            _shopContext = new ShopContext();
        }

        public FavouriteController(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        // Get all favourites
        public List<Favourite> GetAll()
        {
            return _shopContext.Favourites.ToList();
        }

        // Get favourite by ID
        public Favourite GetByID(int userId)
        {
            return _shopContext.Favourites.FirstOrDefault(x => x.UserId == userId);
        }

        // Add new favourite
        public void Add(Favourite favourite)
        {
            if (favourite is not null)
            {
                _shopContext.Favourites.Add(favourite);
                _shopContext.SaveChanges();
            }
        }

        // Add new favourites
        public void AddRange(List<Favourite> favourites)
        {
            if (favourites is not null)
            {
                _shopContext.Favourites.AddRange(favourites);
                _shopContext.SaveChanges();
            }
        }

        // Remove favourite
        public void Delete(int userId)
        {
            var item = GetByID(userId);

            if (item is not null)
            {
                _shopContext.Favourites.Remove(item);
                _shopContext.SaveChanges();
            }
        }

        // Remove all favourites
        public void DeleteAll()
        {
            _shopContext.Favourites.RemoveRange(_shopContext.Favourites);
            _shopContext.SaveChanges();
        }
    }
}
