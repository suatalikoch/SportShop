using Data;
using Data.Models;

namespace Business
{
    public class UserBusiness
    {
        private DatabaseContext? dbcontext;

        public List<User> GetAll()
        {
            using (dbcontext = new DatabaseContext())
            {
                return dbcontext.Users.ToList();
            }
        }

        public List<Product> GetFavouriteProducts(int id)
        {
            using (dbcontext = new DatabaseContext())
            {
                List<Product> products = new();
                List<Favourite> favourites = dbcontext.Favourites.Where(x => x.UserId == id).ToList();

                foreach (Favourite favourite in favourites)
                {
                    ProductBusiness productBusiness = new();
                    products.Add(productBusiness.GetByID(favourite.ProductId));
                }

                return products;
            }
        }

        public List<Product> GetCartProducts(int id)
        {
            using (dbcontext = new DatabaseContext())
            {
                List<Product> products = new();
                List<Cart> carts = dbcontext.Carts.Where(x => x.UserId == id).ToList();

                foreach (Cart cart in carts)
                {
                    ProductBusiness productBusiness = new();
                    products.Add(productBusiness.GetByID(cart.ProductId));
                }

                return products;
            }
        }

        public User GetByID(int id)
        {
            using (dbcontext = new DatabaseContext())
            {
                return dbcontext.Users.Find(id);
            }
        }

        public User? GetByEmail(string email)
        {
            using (dbcontext = new DatabaseContext())   
            {
                if (dbcontext.Users.Any(x => x.Email.Equals(email)))
                {
                    return dbcontext.Users.Where(x => x.Email.Equals(email)).First();
                };

                return null;
            }
        }

        public void Add(User user)
        {
            using (dbcontext = new DatabaseContext())
            {
                dbcontext.Users.Add(user);
                dbcontext.SaveChanges();
            }
        }

        public void Update(User user)
        {
            using (dbcontext = new DatabaseContext())
            {
                var item = dbcontext.Users.Find(user.Id);

                if (item != null)
                {
                    dbcontext.Entry(item).CurrentValues.SetValues(user);
                    dbcontext.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (dbcontext = new DatabaseContext())
            {
                var item = dbcontext.Users.Find(id);

                if (item != null)
                {
                    dbcontext.Users.Remove(item);
                    dbcontext.SaveChanges();
                }
            }
        }
    }
}
