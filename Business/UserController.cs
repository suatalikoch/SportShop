using Data.Models;
using Data;

namespace Business
{
    public class UserController
    {
        private ShopContext? _shopContext;

        public UserController()
        {
            _shopContext = new ShopContext();
        }

        public UserController(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<User> GetAll()
        {
            return _shopContext.Users.ToList();
        }

        public User GetByID(int id)
        {
            return _shopContext.Users.Find(id);
        }

        public User? GetByEmail(string email)
        {
            if (_shopContext.Users.Any(x => x.Email.Equals(email)))
            {
                return _shopContext.Users.Where(x => x.Email.Equals(email)).First();
            };

            return null;
        }

        public void Add(User user)
        {
            _shopContext.Users.Add(user);
            _shopContext.SaveChanges();
        }

        public void Update(User user)
        {
            var item = _shopContext.Users.Find(user.Id);

            if (item != null)
            {
                _shopContext.Entry(item).CurrentValues.SetValues(user);
                _shopContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var item = _shopContext.Users.Find(id);

            if (item != null)
            {
                _shopContext.Users.Remove(item);
                _shopContext.SaveChanges();
            }
        }
    }
}
