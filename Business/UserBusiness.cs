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
