using Data.Models;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CategoryBusiness
    {
        private DatabaseContext? dbcontext;

        public List<Category> GetAll()
        {
            using (dbcontext = new DatabaseContext())
            {
                return dbcontext.Categories.ToList();
            }
        }

        public Category GetByID(int id)
        {
            using (dbcontext = new DatabaseContext())
            {
                return dbcontext.Categories.Find(id);
            }
        }

        public void Add(Category category)
        {
            using (dbcontext = new DatabaseContext())
            {
                dbcontext.Categories.Add(category);
                dbcontext.SaveChanges();
            }
        }

        public void Update(Category category)
        {
            using (dbcontext = new DatabaseContext())
            {
                var item = dbcontext.Categories.Find(category.Id);

                if (item != null)
                {
                    dbcontext.Entry(item).CurrentValues.SetValues(category);
                    dbcontext.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (dbcontext = new DatabaseContext())
            {
                var item = dbcontext.Categories.Find(id);

                if (item != null)
                {
                    dbcontext.Categories.Remove(item);
                    dbcontext.SaveChanges();
                }
            }
        }
    }
}
