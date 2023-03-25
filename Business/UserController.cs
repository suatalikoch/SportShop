using Data.Models;
using Data;

namespace Business
{
    public class UserController
    {
        private readonly ShopContext _shopContext;

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
            return _shopContext.Users.FirstOrDefault(x => x.Id == id);
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
            if (user is not null)
            {
                _shopContext.Users.Add(user);
                _shopContext.SaveChanges();
            }
        }

        public void AddRange(List<User> users)
        {
            if (users is not null)
            {
                _shopContext.Users.AddRange(users);
                _shopContext.SaveChanges();
            }
        }

        public void Update(User user)
        {
            var item = _shopContext.Users.Find(user.Id);

            if (item is not null)
            {
                _shopContext.Entry(item).CurrentValues.SetValues(user);
                _shopContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var item = _shopContext.Users.Find(id);

            if (item is not null)
            {
                _shopContext.Users.Remove(item);
                _shopContext.SaveChanges();
            }
        }

        public void RemoveRange(List<User> users)
        {
            if (users is not null)
            {
                _shopContext.Users.RemoveRange(users);
                _shopContext.SaveChanges();
            }
        }

        public void DeleteAll()
        {
            _shopContext.Users.RemoveRange(_shopContext.Users);
            _shopContext.SaveChanges();
        }
    }
}
