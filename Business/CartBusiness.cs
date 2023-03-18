using Data.Models;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CartBusiness
    {
        private DatabaseContext? dbcontext;

        public List<Cart> GetAll()
        {
            using (dbcontext = new DatabaseContext())
            {
                return dbcontext.Carts.ToList();
            }
        }

        public Cart GetByID(int userId)
        {
            using (dbcontext = new DatabaseContext())
            {
                return dbcontext.Carts.Find(userId);
            }
        }

        public void Add(Cart cart)
        {
            using (dbcontext = new DatabaseContext())
            {
                dbcontext.Carts.Add(cart);
                dbcontext.SaveChanges();
            }
        }

        public void Delete(int userId)
        {
            using (dbcontext = new DatabaseContext())
            {
                var item = dbcontext.Carts.Find(userId);

                if (item != null)
                {
                    dbcontext.Carts.Remove(item);
                    dbcontext.SaveChanges();
                }
            }
        }
    }
}
