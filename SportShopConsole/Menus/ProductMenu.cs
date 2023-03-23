using Business;
using Data;
using Data.Models;

namespace SportShopConsole.Menus
{
    public class ProductMenu
    {
        private readonly int closeOperationId = 6;

        private readonly ProductController productBusiness = new();

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "PRODUCT MENU");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");
            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit entry");
            Console.WriteLine();
        }

        internal void Input()
        {
            int operation;

            do
            {
                ShowMenu();

                operation = int.Parse(Console.ReadLine());

                switch (operation)
                {
                    case 1:
                        ListAll();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Fetch();
                        break;
                    case 5:
                        Delete();
                        break;
                    default:
                        break;
                }

                Console.WriteLine("Press any key...");
                Console.ReadKey();
                Console.Clear();

            } while (operation != closeOperationId);
        }

        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "PRODUCTS");
            Console.WriteLine(new string('-', 40));

            List<Product> products = productBusiness.GetAll();

            foreach (Product product in products)
            {
                Console.WriteLine(product.ToString());
            }
        }

        private void Add()
        {
            Product product = new();

            Console.Write("Name: ");
            product.Name = Console.ReadLine();

            Console.Write("Description: ");
            product.Description = Console.ReadLine();

            Console.Write("Price: ");
            product.Price = decimal.Parse(Console.ReadLine());

            Console.Write("Discount: ");
            product.Discount = double.Parse(Console.ReadLine());

            Console.Write("Image: ");
            product.Image = Console.ReadLine();

            Console.Write("CategoryId: ");
            product.CategoryId = int.Parse(Console.ReadLine());

            Console.Write("SubCategoryId: ");
            product.SubCategoryId = int.Parse(Console.ReadLine());

            productBusiness.Add(product);

            Console.WriteLine("The product has been added!");
        }

        private void Update()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());

            Product product = productBusiness.GetByID(id);

            if (product is null)
            {
                Console.WriteLine("User not found!");

                return;
            }

            Console.WriteLine(product.ToString());

            Console.Write("Name: ");
            product.Name = Console.ReadLine();

            Console.Write("Description: ");
            product.Description = Console.ReadLine();

            Console.Write("Price: ");
            product.Price = decimal.Parse(Console.ReadLine());

            Console.Write("Discount: ");
            product.Discount = double.Parse(Console.ReadLine());

            Console.Write("Image: ");
            product.Image = Console.ReadLine();

            Console.Write("CategoryId: ");
            product.CategoryId = int.Parse(Console.ReadLine());

            Console.Write("SubCategoryId: ");
            product.SubCategoryId = int.Parse(Console.ReadLine());

            productBusiness.Update(product);

            Console.WriteLine("The product has been updated!");
        }

        private void Fetch()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());

            Product product = productBusiness.GetByID(id);

            if (product is null)
            {
                Console.WriteLine("Product not found!");

                return;
            }

            Console.WriteLine(new string('-', 40));
            Console.WriteLine("ID: " + product.Id);
            Console.WriteLine("Name: " + product.Name);
            Console.WriteLine("Description: " + product.Description);
            Console.WriteLine("Price: " + product.Price);
            Console.WriteLine("Discount: " + product.Discount);
            Console.WriteLine("Image: " + product.Image);
            Console.WriteLine("CategoryId: " + product.CategoryId);
            Console.WriteLine("SubCategoryId: " + product.SubCategoryId);
            Console.WriteLine(new string('-', 40));
        }

        private void Delete()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());

            Product product = productBusiness.GetByID(id);

            if (product is null)
            {
                Console.WriteLine("Product not found!");

                return;
            }

            productBusiness.Delete(id);
            Console.WriteLine("The product has been deleted!");
        }
    }
}
