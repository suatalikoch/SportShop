using Business;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShopConsole.Controllers
{
    internal class FavouriteController
    {
        private readonly int closeOperationId = 6;

        private readonly FavouriteBusiness favouriteBusiness = new();

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "FAVOURITES MENU");
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
            Console.WriteLine(new string(' ', 18) + "FAVOURITES");
            Console.WriteLine(new string('-', 40));

            List<Favourite> favourites = favouriteBusiness.GetAll();

            foreach (Favourite favourite in favourites)
            {
                Console.WriteLine(favourite.ToString());
            }
        }

        private void Add()
        {
            Favourite favourite = new();

            Console.Write("UserId: ");
            favourite.UserId = int.Parse(Console.ReadLine());

            Console.Write("ProductId: ");
            favourite.ProductId = int.Parse(Console.ReadLine());

            favouriteBusiness.Add(favourite);

            Console.WriteLine("The favourite has been added!");
        }

        private void Fetch()
        {
            Console.Write("UserId: ");
            int userId = int.Parse(Console.ReadLine());

            Favourite favourite = favouriteBusiness.GetByID(userId);

            if (favourite is null)
            {
                Console.WriteLine("Favourite not found!");

                return;
            }

            Console.WriteLine(new string('-', 40));
            Console.WriteLine("UserId: " + favourite.UserId);
            Console.WriteLine("ProductId: " + favourite.ProductId);
            Console.WriteLine(new string('-', 40));
        }

        private void Delete()
        {
            Console.Write("UserId: ");
            int userId = int.Parse(Console.ReadLine());

            Favourite favourite = favouriteBusiness.GetByID(userId);

            if (favourite is null)
            {
                Console.WriteLine("Favourite not found!");

                return;
            }

            favouriteBusiness.Delete(userId);
            Console.WriteLine("The favourite has been deleted!");
        }
    }
}
