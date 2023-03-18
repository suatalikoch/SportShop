using SportShopConsole.Controllers;

namespace SportShopConsole.Presentation
{
    internal class Display
    {
        private readonly int closeOperationId = 7;

        private readonly CartController cartController = new();
        private readonly CategoryController categoryController = new();
        private readonly FavouriteController favouriteController = new();
        private readonly ProductController productController = new();
        private readonly SubcategoryController subcategoryController = new();
        private readonly UserController userController = new();

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
                        cartController.Input();
                        break;
                    case 2:
                        categoryController.Input();
                        break;
                    case 3:
                        favouriteController.Input();
                        break;
                    case 4:
                        productController.Input();
                        break;
                    case 5:
                        subcategoryController.Input();
                        break;
                    case 6:
                        userController.Input();
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
