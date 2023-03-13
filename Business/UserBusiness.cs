using Data;
using Data.Models;
using SportShop.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows.Documents;

namespace Business
{
    public class UserBusiness
    {
        private DatabaseContext dbcontext;

        public List<User> GetAll()
        {
            using (dbcontext = new DatabaseContext())
            {
                return dbcontext.Users.ToList();
            }
        }

        public User GetByID(int id)
        {
            using (dbcontext = new DatabaseContext())
            {
                return dbcontext.Users.Find(id);
            }
        }
        public User GetByUsername(string username)
        {
            using (dbcontext = new DatabaseContext())
            {
                return dbcontext.Users.Where(x => x.Username.Equals(username)).First();
                
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
