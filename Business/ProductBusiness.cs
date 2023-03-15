using Data;
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
    }
}
