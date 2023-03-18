using Business;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShopConsole.Controllers
{
    internal class CategoryController
    {
        private readonly int closeOperationId = 6;

        private readonly CategoryBusiness categoryBusiness = new();

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "CATEGORY MENU");
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
                        Fetch();
                        break;
                    case 4:
                        Update();
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
            Console.WriteLine(new string(' ', 18) + "CATEGORIES");
            Console.WriteLine(new string('-', 40));

            List<Category> categories = categoryBusiness.GetAll();

            foreach (Category category in categories)
            {
                Console.WriteLine(category.ToString());
            }
        }

        private void Add()
        {
            Category category = new();

            Console.Write("Name: ");
            category.Name = Console.ReadLine();

            categoryBusiness.Add(category);

            Console.WriteLine("The category has been added!");
        }

        private void Update()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());

            Category category = categoryBusiness.GetByID(id);

            if (category is null)
            {
                Console.WriteLine("Category not found!");

                return;
            }

            Console.WriteLine(category.ToString());

            Console.Write("Name: ");
            category.Name = Console.ReadLine();

            categoryBusiness.Update(category);

            Console.WriteLine("The category has been updated!");
        }

        private void Fetch()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());

            Category category = categoryBusiness.GetByID(id);

            if (category is null)
            {
                Console.WriteLine("Category not found!");

                return;
            }

            Console.WriteLine(new string('-', 40));
            Console.WriteLine("ID: " + category.Id);
            Console.WriteLine("Name: " + category.Name);
            Console.WriteLine(new string('-', 40));
        }

        private void Delete()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());

            Category category = categoryBusiness.GetByID(id);

            if (category is null)
            {
                Console.WriteLine("Category not found!");

                return;
            }

            categoryBusiness.Delete(id);
            Console.WriteLine("The category has been deleted!");
        }
    }
}
