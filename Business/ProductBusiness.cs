﻿using Data;
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
