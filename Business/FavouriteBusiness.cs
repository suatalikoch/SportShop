using Data.Models;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class FavouriteBusiness
    {
        private DatabaseContext? dbcontext;

        public List<Favourite> GetAll()
        {
            using (dbcontext = new DatabaseContext())
            {
                return dbcontext.Favourites.ToList();
            }
        }

        public Favourite GetByID(int userId)
        {
            using (dbcontext = new DatabaseContext())
            {
                return dbcontext.Favourites.Find(userId);
            }
        }

        public void Add(Favourite favourite)
        {
            using (dbcontext = new DatabaseContext())
            {
                dbcontext.Favourites.Add(favourite);
                dbcontext.SaveChanges();
            }
        }

        public void Delete(int userId)
        {
            using (dbcontext = new DatabaseContext())
            {
                var item = dbcontext.Favourites.Find(userId);

                if (item != null)
                {
                    dbcontext.Favourites.Remove(item);
                    dbcontext.SaveChanges();
                }
            }
        }
    }
}
