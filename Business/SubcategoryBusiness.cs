using Data.Models;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class SubcategoryBusiness
    {
        private DatabaseContext? dbcontext;

        public List<Subcategory> GetAll()
        {
            using (dbcontext = new DatabaseContext())
            {
                return dbcontext.Subcategories.ToList();
            }
        }

        public Subcategory GetByID(int id)
        {
            using (dbcontext = new DatabaseContext())
            {
                return dbcontext.Subcategories.Find(id);
            }
        }

        public void Add(Subcategory subcategory)
        {
            using (dbcontext = new DatabaseContext())
            {
                dbcontext.Subcategories.Add(subcategory);
                dbcontext.SaveChanges();
            }
        }

        public void Update(Subcategory subcategory)
        {
            using (dbcontext = new DatabaseContext())
            {
                var item = dbcontext.Subcategories.Find(subcategory.Id);

                if (item != null)
                {
                    dbcontext.Entry(item).CurrentValues.SetValues(subcategory);
                    dbcontext.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (dbcontext = new DatabaseContext())
            {
                var item = dbcontext.Subcategories.Find(id);

                if (item != null)
                {
                    dbcontext.Subcategories.Remove(item);
                    dbcontext.SaveChanges();
                }
            }
        }
    }
}
