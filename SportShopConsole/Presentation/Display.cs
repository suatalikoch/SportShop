using SportShopConsole.Menus;

namespace SportShopConsole.Presentation
{
    internal class Display
    {
        private readonly int closeOperationId = 7;

        private readonly CartMenu cartMenu = new();
        private readonly CategoryMenu categoryMenu = new();
        private readonly FavouriteMenu favouriteMenu = new();
        private readonly ProductMenu productMenu = new();
        private readonly SubcategoryMenu subcategoryMenu = new();
        private readonly UserMenu userMenu = new();

        public Display()
        {
            Input();
        }

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MAIN MENU");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. Cart menu");
            Console.WriteLine("2. Category menu");
            Console.WriteLine("3. Favourite menu");
            Console.WriteLine("4. Product menu");
            Console.WriteLine("5. Subcategory menu");
            Console.WriteLine("6. User menu");
            Console.WriteLine("7. Exit entry");
            Console.WriteLine();
        }

        private void Input()
        {
            int operation;

            do
            {
                ShowMenu();

                operation = int.Parse(Console.ReadLine());

                switch (operation)
                {
                    case 1:
                        cartMenu.Input();
                        break;
                    case 2:
                        categoryMenu.Input();
                        break;
                    case 3:
                        favouriteMenu.Input();
                        break;
                    case 4:
                        productMenu.Input();
                        break;
                    case 5:
                        subcategoryMenu.Input();
                        break;
                    case 6:
                        userMenu.Input();
                        break;
                    case 7:
                        Console.WriteLine("Press any key...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        break;
                }
            } while (operation != closeOperationId);
        }
    }
}
