using Business;
using SportShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShopConsole.Presentation
{
    internal class Display
    {
        private int closeOperationId = 6;
        UserBusiness userBusiness = new();

        public Display()
        {
            Input();
        }

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MENU");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");
            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit entry");
        }

        private void Input()
        {
            var operation = -1;
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
                Console.WriteLine("Press any key..."); Console.ReadKey(); Console.Clear();
            } while (operation != closeOperationId);
        }

        private void ListAll()
        {
            /*
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "PRODUCTS");
            Console.WriteLine(new string('-', 40));
            var products = userBusiness.GetAll();
            foreach (var item in products)
            {
                Console.WriteLine($"{item.Id} {item.Name} {item.Price} {item.Stock}");
            }
            */

        }

        private void Add()
        {
            /*
            User product = new User();
            Console.Write("Name: ");
            product.Name = Console.ReadLine();
            Console.Write("Price: ");
            product.Price = decimal.Parse(Console.ReadLine());
            Console.Write("Stock: ");
            product.Stock = int.Parse(Console.ReadLine());
            userBusiness.Add(product);
            Console.WriteLine("The product has been added!");
            */
        }

        private void Update()
        {
            /*
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());
            User product = userBusiness.Get(id);
            if (product != null)
            {
                Console.WriteLine($"{product.Id} {product.Name} {product.Price} {product.Stock}");
                Console.Write("Name: ");
                product.Name = Console.ReadLine();
                Console.Write("Price: ");
                product.Price = decimal.Parse(Console.ReadLine());
                Console.Write("Stock: ");
                product.Stock = int.Parse(Console.ReadLine());
                userBusiness.Update(product);
                Console.WriteLine("The product has been updated!");
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
            */
        }

        private void Fetch()
        {

            /*
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());
            User product = userBusiness.Get(id);
            if (product != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + product.Id);
                Console.WriteLine("Name: " + product.Name);
                Console.WriteLine("Price: " + product.Price);
                Console.WriteLine("Stock: " + product.Stock);
                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
            */
        }

        private void Delete()
        {
            /*
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());
            User product = userBusiness.Get(id);
            if (product != null)
            {
                userBusiness.Delete(id);
                Console.WriteLine("The product has been deleted!");
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
            */
        }
    }
}
