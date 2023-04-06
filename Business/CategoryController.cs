using Data.Models;
using Data;

namespace Business
{
    public class CategoryController
    {
        private readonly ShopContext _shopContext;

        public CategoryController()
        {
            _shopContext = new ShopContext();
        }

        public CategoryController(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        // Get all categories
        public List<Category> GetAll()
        {
            return _shopContext.Categories.ToList();
        }

        // Get category by ID
        public Category GetByID(int id)
        {
            return _shopContext.Categories.FirstOrDefault(x => x.Id == id);
        }

        // Add new category
        public void Add(Category category)
        {
            if (category is not null)
            {
                _shopContext.Categories.Add(category);
                _shopContext.SaveChanges();
            }
        }

        // Add new categories
        public void AddRange(List<Category> categories)
        {
            if (categories is not null)
            {
                _shopContext.Categories.AddRange(categories);
                _shopContext.SaveChanges();
            }
        }

        // Update existing category
        public void Update(Category category)
        {
            var item = GetByID(category.Id);

            if (item is not null)
            {
                _shopContext.Entry(item).CurrentValues.SetValues(category);
                _shopContext.SaveChanges();
            }
        }

        // Remove category
        public void Delete(int id)
        {
            var item = GetByID(id);

            if (item is not null)
            {
                _shopContext.Categories.Remove(item);
                _shopContext.SaveChanges();
            }
        }
    }
}
