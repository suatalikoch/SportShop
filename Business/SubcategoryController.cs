﻿using Data.Models;
using Data;

namespace Business
{
    public class SubcategoryController
    {
        private readonly ShopContext _shopContext;

        public SubcategoryController()
        {
            _shopContext = new ShopContext();
        }

        public SubcategoryController(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        // Get all subcategories
        public List<Subcategory> GetAll()
        {
            return _shopContext.Subcategories.ToList();
        }

        // Get subcategory by ID
        public Subcategory GetByID(int id)
        {
            return _shopContext.Subcategories.FirstOrDefault(x => x.Id == id);
        }

        // Add new subcategory
        public void Add(Subcategory subcategory)
        {
            if (subcategory is not null)
            {
                _shopContext.Subcategories.Add(subcategory);
                _shopContext.SaveChanges();
            }
        }

        // Add new subcategories
        public void AddRange(List<Subcategory> subcategories)
        {
            if (subcategories is not null)
            {
                _shopContext.Subcategories.AddRange(subcategories);
                _shopContext.SaveChanges();
            }
        }

        // Update existing subcategory
        public void Update(Subcategory subcategory)
        {
            var item = GetByID(subcategory.Id);

            if (item is not null)
            {
                _shopContext.Entry(item).CurrentValues.SetValues(subcategory);
                _shopContext.SaveChanges();
            }
        }

        // Remove subcategory
        public void Delete(int id)
        {
            var item = GetByID(id);

            if (item is not null)
            {
                _shopContext.Subcategories.Remove(item);
                _shopContext.SaveChanges();
            }
        }
    }
}
