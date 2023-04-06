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

        // Get all users
        public List<User> GetAll()
        {
            return _shopContext.Users.ToList();
        }

        // Get user by ID
        public User GetByID(int id)
        {
            return _shopContext.Users.FirstOrDefault(x => x.Id == id);
        }

        // Get user by email
        public User GetByEmail(string email)
        {
            return _shopContext.Users.FirstOrDefault(x => x.Email == email);
        }

        // Add new user
        public void Add(User user)
        {
            if (user is not null)
            {
                _shopContext.Users.Add(user);
                _shopContext.SaveChanges();
            }
        }

        // Add new users
        public void AddRange(List<User> users)
        {
            if (users is not null)
            {
                _shopContext.Users.AddRange(users);
                _shopContext.SaveChanges();
            }
        }

        // Update existing user
        public void Update(User user)
        {
            var item = _shopContext.Users.Find(user.Id);

            if (item is not null)
            {
                _shopContext.Entry(item).CurrentValues.SetValues(user);
                _shopContext.SaveChanges();
            }
        }

        // Remove user by ID
        public void Delete(int id)
        {
            var item = _shopContext.Users.Find(id);

            if (item is not null)
            {
                _shopContext.Users.Remove(item);
                _shopContext.SaveChanges();
            }
        }

        // Remove users
        public void RemoveRange(List<User> users)
        {
            if (users is not null)
            {
                _shopContext.Users.RemoveRange(users);
                _shopContext.SaveChanges();
            }
        }
    }
}
