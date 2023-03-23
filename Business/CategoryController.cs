using Data.Models;
using Data;

namespace Business
{
    public class CategoryController
    {
        private ShopContext? _shopContext;

        public CategoryController()
        {
            _shopContext = new ShopContext();
        }

        public CategoryController(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<Category> GetAll()
        {
            return _shopContext.Categories.ToList();
        }

        public Category GetByID(int id)
        {
            return _shopContext.Categories.Find(id);
        }

        public void Add(Category category)
        {
            _shopContext.Categories.Add(category);
            _shopContext.SaveChanges();
        }

        public void Update(Category category)
        {
            var item = _shopContext.Categories.Find(category.Id);

            if (item != null)
            {
                _shopContext.Entry(item).CurrentValues.SetValues(category);
                _shopContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var item = _shopContext.Categories.Find(id);

            if (item != null)
            {
                _shopContext.Categories.Remove(item);
                _shopContext.SaveChanges();
            }
        }
    }
}
