using Data;
using Data.Models;

namespace Business
{
    public class ProductBusiness
    {
        private DatabaseContext? dbcontext;

        public List<Product> GetAll()
        {
            using (dbcontext = new DatabaseContext())
            {
                return dbcontext.Products.ToList();
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
                    products.Add(GetByID(favourite.ProductId));
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
                    products.Add(GetByID(cart.ProductId));
                }

                return products;
            }
        }

        public Product GetByID(int id)
        {
            using (dbcontext = new DatabaseContext())
            {
                return dbcontext.Products.Find(id);
            }
        }

        public void Add(Product product)
        {
            using (dbcontext = new DatabaseContext())
            {
                dbcontext.Products.Add(product);
                dbcontext.SaveChanges();
            }
        }

        public void Update(Product product)
        {
            using (dbcontext = new DatabaseContext())
            {
                var item = dbcontext.Products.Find(product.Id);

                if (item != null)
                {
                    dbcontext.Entry(item).CurrentValues.SetValues(product);
                    dbcontext.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (dbcontext = new DatabaseContext())
            {
                var item = dbcontext.Products.Find(id);

                if (item != null)
                {
                    dbcontext.Products.Remove(item);
                    dbcontext.SaveChanges();
                }
            }
        }
    }
}
