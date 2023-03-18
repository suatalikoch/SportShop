using Business;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShopConsole.Controllers
{
    internal class SubcategoryController
    {
        private readonly int closeOperationId = 6;

        private readonly SubcategoryBusiness subcategoryBusiness = new();

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "SUBCATEGORIES MENU");
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
            Console.WriteLine(new string(' ', 18) + "SUBCATEGORIES");
            Console.WriteLine(new string('-', 40));

            List<Subcategory> subcategories = subcategoryBusiness.GetAll();

            foreach (Subcategory subcategory in subcategories)
            {
                Console.WriteLine(subcategory.ToString());
            }
        }

        private void Add()
        {
            Subcategory user = new();

            Console.Write("Name: ");
            user.Name = Console.ReadLine();

            Console.Write("CategoryId: ");
            user.CategoryId = int.Parse(Console.ReadLine());

            subcategoryBusiness.Add(user);

            Console.WriteLine("The subcategory has been added!");
        }

        private void Update()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());

            Subcategory subcategory = subcategoryBusiness.GetByID(id);

            if (subcategory is null)
            {
                Console.WriteLine("Subcategory not found!");

                return;
            }

            Console.WriteLine(subcategory.ToString());

            Console.Write("Name: ");
            subcategory.Name = Console.ReadLine();

            Console.Write("CategoryId: ");
            subcategory.CategoryId = int.Parse(Console.ReadLine());

            subcategoryBusiness.Update(subcategory);

            Console.WriteLine("The subcategory has been updated!");
        }

        private void Fetch()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());

            Subcategory subcategory = subcategoryBusiness.GetByID(id);

            if (subcategory is null)
            {
                Console.WriteLine("Subcategory not found!");

                return;
            }

            Console.WriteLine(new string('-', 40));
            Console.WriteLine("ID: " + subcategory.Id);
            Console.WriteLine("Name: " + subcategory.Name);
            Console.WriteLine("CategoryId: " + subcategory.CategoryId);
            Console.WriteLine(new string('-', 40));
        }

        private void Delete()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());

            Subcategory subcategory = subcategoryBusiness.GetByID(id);

            if (subcategory is null)
            {
                Console.WriteLine("Subcategory not found!");

                return;
            }

            subcategoryBusiness.Delete(id);
            Console.WriteLine("The subcategory has been deleted!");
        }
    }
}
