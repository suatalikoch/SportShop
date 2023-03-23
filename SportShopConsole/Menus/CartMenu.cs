using Business;
using Data.Models;

namespace SportShopConsole.Menus
{
    internal class CartMenu
    {
        private readonly int closeOperationId = 6;

        private readonly CartController cartBusiness = new();

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "CART MENU");
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
            Console.WriteLine(new string(' ', 18) + "CARTS");
            Console.WriteLine(new string('-', 40));

            List<Cart> carts = cartBusiness.GetAll();

            foreach (Cart cart in carts)
            {
                Console.WriteLine(cart.ToString());
            }
        }

        private void Add()
        {
            Cart cart = new();

            Console.Write("UserId: ");
            cart.UserId = int.Parse(Console.ReadLine());

            Console.Write("ProductId: ");
            cart.ProductId = int.Parse(Console.ReadLine());

            cartBusiness.Add(cart);

            Console.WriteLine("The cart has been added!");
        }

        private void Fetch()
        {
            Console.Write("UserId: ");
            int userId = int.Parse(Console.ReadLine());

            Cart cart = cartBusiness.GetByID(userId);

            if (cart is null)
            {
                Console.WriteLine("Cart not found!");

                return;
            }

            Console.WriteLine(new string('-', 40));
            Console.WriteLine("UserId: " + cart.UserId);
            Console.WriteLine("ProductId: " + cart.ProductId);
            Console.WriteLine(new string('-', 40));
        }

        private void Delete()
        {
            Console.Write("UserId: ");
            int userId = int.Parse(Console.ReadLine());

            Cart cart = cartBusiness.GetByID(userId);

            if (cart is null)
            {
                Console.WriteLine("Cart not found!");

                return;
            }

            cartBusiness.Delete(userId);
            Console.WriteLine("The cart has been deleted!");
        }
    }
}
