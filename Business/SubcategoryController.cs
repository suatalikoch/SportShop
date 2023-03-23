using Data.Models;
using Data;

namespace Business
{
    public class SubcategoryController
    {
        private ShopContext? _shopContext;

        public SubcategoryController()
        { }

        public SubcategoryController(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<Subcategory> GetAll()
        {
            return _shopContext.Subcategories.ToList();
        }

        public Subcategory GetByID(int id)
        {
            return _shopContext.Subcategories.Find(id);
        }

        public void Add(Subcategory subcategory)
        {
            _shopContext.Subcategories.Add(subcategory);
            _shopContext.SaveChanges();
        }

        public void Update(Subcategory subcategory)
        {
            var item = _shopContext.Subcategories.Find(subcategory.Id);

            if (item != null)
            {
                _shopContext.Entry(item).CurrentValues.SetValues(subcategory);
                _shopContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var item = _shopContext.Subcategories.Find(id);

            if (item != null)
            {
                _shopContext.Subcategories.Remove(item);
                _shopContext.SaveChanges();
            }
        }
    }
}
