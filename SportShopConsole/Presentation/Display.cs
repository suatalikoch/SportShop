using Business;
using Data.Models;

namespace SportShopConsole.Presentation
{
    internal class Display
    {
        private readonly int closeOperationId = 6;
        private readonly CartBusiness cartBusiness = new();
        private readonly CategoryBusiness categoryBusiness = new();
        private readonly FavouriteBusiness favouriteBusiness = new();
        private readonly ProductBusiness productBusiness = new();
        private readonly SubcategoryBusiness subcategoryBusiness = new();
        private readonly UserBusiness userBusiness = new();

        public Display()
        {
            //UserInput();
        }

        //- Cart

        private void ShowCartMenu()
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
            Console.WriteLine();
        }

        private void CartInput()
        {
            int operation;

            do
            {
                ShowCartMenu();

                operation = int.Parse(Console.ReadLine());

                switch (operation)
                {
                    case 1:
                        ListAllCarts();
                        break;
                    case 2:
                        AddCart();
                        break;
                    case 3:
                        FetchCart();
                        break;
                    case 4:
                        DeleteCart();
                        break;
                    default:
                        break;
                }

                Console.WriteLine("Press any key...");
                Console.ReadKey();
                Console.Clear();

            } while (operation != closeOperationId);
        }

        private void ListAllCarts()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "USERS");
            Console.WriteLine(new string('-', 40));

            List<User> users = userBusiness.GetAll();

            foreach (User user in users)
            {
                Console.WriteLine(user.ToString());
            }
        }

        private void AddCart()
        {
            User user = new();

            Console.Write("FirstName: ");
            user.FirstName = Console.ReadLine();

            Console.Write("LastName: ");
            user.LastName = Console.ReadLine();

            Console.Write("Email: ");
            user.Email = Console.ReadLine();

            Console.Write("Phone: ");
            user.Phone = Console.ReadLine();

            Console.Write("Address: ");
            user.Address = Console.ReadLine();

            Console.Write("City: ");
            user.City = Console.ReadLine();

            Console.Write("Region: ");
            user.Region = Console.ReadLine();

            Console.Write("PostalCode: ");
            user.PostalCode = Console.ReadLine();

            Console.Write("Country: ");
            user.Country = Console.ReadLine();

            Console.Write("RegistrationDate: ");
            user.RegistrationDate = DateTime.Now;

            userBusiness.Add(user);

            Console.WriteLine("The user has been added!");
        }

        private void FetchCart()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());

            User user = userBusiness.GetByID(id);

            if (user is null)
            {
                Console.WriteLine("Product not found!");

                return;
            }

            Console.WriteLine(new string('-', 40));
            Console.WriteLine("ID: " + user.Id);
            Console.WriteLine("FirstName: " + user.FirstName);
            Console.WriteLine("LastName: " + user.LastName);
            Console.WriteLine("Email: " + user.Email);
            Console.WriteLine("Phone: " + user.Phone);
            Console.WriteLine("Address: " + user.Address);
            Console.WriteLine("City: " + user.City);
            Console.WriteLine("Region: " + user.Region);
            Console.WriteLine("PostalCode: " + user.PostalCode);
            Console.WriteLine("Country: " + user.Country);
            Console.WriteLine("IsEmailConfirmed: " + user.IsEmailConfirmed);
            Console.WriteLine("RegisterDate: " + user.RegistrationDate);
            Console.WriteLine("LastLoginDate: " + user.LastLoginDate);
            Console.WriteLine(new string('-', 40));
        }

        private void DeleteCart()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());

            User user = userBusiness.GetByID(id);

            if (user is null)
            {
                Console.WriteLine("Product not found!");

                return;
            }

            userBusiness.Delete(id);
            Console.WriteLine("The product has been deleted!");
        }

        //- Category

        private void ShowCategoryMenu()
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
            Console.WriteLine();
        }

        private void CategoryInput()
        {
            int operation;

            do
            {
                ShowCategoryMenu();

                operation = int.Parse(Console.ReadLine());

                switch (operation)
                {
                    case 1:
                        ListAllCategories();
                        break;
                    case 2:
                        AddCategory();
                        break;
                    case 3:
                        FetchCategory();
                        break;
                    case 4:
                        UpdateCategory();
                        break;
                    case 5:
                        DeleteCategory();
                        break;
                    default:
                        break;
                }

                Console.WriteLine("Press any key...");
                Console.ReadKey();
                Console.Clear();

            } while (operation != closeOperationId);
        }

        private void ListAllCategories()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "USERS");
            Console.WriteLine(new string('-', 40));

            List<User> users = userBusiness.GetAll();

            foreach (User user in users)
            {
                Console.WriteLine(user.ToString());
            }
        }

        private void AddCategory()
        {
            User user = new();

            Console.Write("FirstName: ");
            user.FirstName = Console.ReadLine();

            Console.Write("LastName: ");
            user.LastName = Console.ReadLine();

            Console.Write("Email: ");
            user.Email = Console.ReadLine();

            Console.Write("Phone: ");
            user.Phone = Console.ReadLine();

            Console.Write("Address: ");
            user.Address = Console.ReadLine();

            Console.Write("City: ");
            user.City = Console.ReadLine();

            Console.Write("Region: ");
            user.Region = Console.ReadLine();

            Console.Write("PostalCode: ");
            user.PostalCode = Console.ReadLine();

            Console.Write("Country: ");
            user.Country = Console.ReadLine();

            Console.Write("RegistrationDate: ");
            user.RegistrationDate = DateTime.Now;

            userBusiness.Add(user);

            Console.WriteLine("The user has been added!");
        }

        private void UpdateCategory()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());

            User user = userBusiness.GetByID(id);

            if (user is null)
            {
                Console.WriteLine("User not found!");

                return;
            }

            Console.WriteLine(user.ToString());

            Console.Write("FirstName: ");
            user.FirstName = Console.ReadLine();

            Console.Write("LastName: ");
            user.LastName = Console.ReadLine();

            Console.Write("Email: ");
            user.Email = Console.ReadLine();

            Console.Write("Phone: ");
            user.Phone = Console.ReadLine();

            Console.Write("Address: ");
            user.Address = Console.ReadLine();

            Console.Write("City: ");
            user.City = Console.ReadLine();

            Console.Write("Region: ");
            user.Region = Console.ReadLine();

            Console.Write("PostalCode: ");
            user.PostalCode = Console.ReadLine();

            Console.Write("Country: ");
            user.Country = Console.ReadLine();

            userBusiness.Update(user);

            Console.WriteLine("The user has been updated!");
        }

        private void FetchCategory()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());

            User user = userBusiness.GetByID(id);

            if (user is null)
            {
                Console.WriteLine("Product not found!");

                return;
            }

            Console.WriteLine(new string('-', 40));
            Console.WriteLine("ID: " + user.Id);
            Console.WriteLine("FirstName: " + user.FirstName);
            Console.WriteLine("LastName: " + user.LastName);
            Console.WriteLine("Email: " + user.Email);
            Console.WriteLine("Phone: " + user.Phone);
            Console.WriteLine("Address: " + user.Address);
            Console.WriteLine("City: " + user.City);
            Console.WriteLine("Region: " + user.Region);
            Console.WriteLine("PostalCode: " + user.PostalCode);
            Console.WriteLine("Country: " + user.Country);
            Console.WriteLine("IsEmailConfirmed: " + user.IsEmailConfirmed);
            Console.WriteLine("RegisterDate: " + user.RegistrationDate);
            Console.WriteLine("LastLoginDate: " + user.LastLoginDate);
            Console.WriteLine(new string('-', 40));
        }

        private void DeleteCategory()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());

            User user = userBusiness.GetByID(id);

            if (user is null)
            {
                Console.WriteLine("Product not found!");

                return;
            }

            userBusiness.Delete(id);
            Console.WriteLine("The product has been deleted!");
        }

        //- Favourite

        private void ShowFavouriteMenu()
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
            Console.WriteLine();
        }

        private void FavouriteInput()
        {
            int operation;

            do
            {
                ShowFavouriteMenu();

                operation = int.Parse(Console.ReadLine());

                switch (operation)
                {
                    case 1:
                        ListAllFavourites();
                        break;
                    case 2:
                        AddFavourite();
                        break;
                    case 3:
                        FetchFavourite();
                        break;
                    case 4:
                        DeleteFavourite();
                        break;
                    default:
                        break;
                }

                Console.WriteLine("Press any key...");
                Console.ReadKey();
                Console.Clear();

            } while (operation != closeOperationId);
        }

        private void ListAllFavourites()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "USERS");
            Console.WriteLine(new string('-', 40));

            List<User> users = userBusiness.GetAll();

            foreach (User user in users)
            {
                Console.WriteLine(user.ToString());
            }
        }

        private void AddFavourite()
        {
            User user = new();

            Console.Write("FirstName: ");
            user.FirstName = Console.ReadLine();

            Console.Write("LastName: ");
            user.LastName = Console.ReadLine();

            Console.Write("Email: ");
            user.Email = Console.ReadLine();

            Console.Write("Phone: ");
            user.Phone = Console.ReadLine();

            Console.Write("Address: ");
            user.Address = Console.ReadLine();

            Console.Write("City: ");
            user.City = Console.ReadLine();

            Console.Write("Region: ");
            user.Region = Console.ReadLine();

            Console.Write("PostalCode: ");
            user.PostalCode = Console.ReadLine();

            Console.Write("Country: ");
            user.Country = Console.ReadLine();

            Console.Write("RegistrationDate: ");
            user.RegistrationDate = DateTime.Now;

            userBusiness.Add(user);

            Console.WriteLine("The user has been added!");
        }

        private void FetchFavourite()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());

            User user = userBusiness.GetByID(id);

            if (user is null)
            {
                Console.WriteLine("Product not found!");

                return;
            }

            Console.WriteLine(new string('-', 40));
            Console.WriteLine("ID: " + user.Id);
            Console.WriteLine("FirstName: " + user.FirstName);
            Console.WriteLine("LastName: " + user.LastName);
            Console.WriteLine("Email: " + user.Email);
            Console.WriteLine("Phone: " + user.Phone);
            Console.WriteLine("Address: " + user.Address);
            Console.WriteLine("City: " + user.City);
            Console.WriteLine("Region: " + user.Region);
            Console.WriteLine("PostalCode: " + user.PostalCode);
            Console.WriteLine("Country: " + user.Country);
            Console.WriteLine("IsEmailConfirmed: " + user.IsEmailConfirmed);
            Console.WriteLine("RegisterDate: " + user.RegistrationDate);
            Console.WriteLine("LastLoginDate: " + user.LastLoginDate);
            Console.WriteLine(new string('-', 40));
        }

        private void DeleteFavourite()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());

            User user = userBusiness.GetByID(id);

            if (user is null)
            {
                Console.WriteLine("Product not found!");

                return;
            }

            userBusiness.Delete(id);
            Console.WriteLine("The product has been deleted!");
        }

        //- Product

        private void ShowProductMenu()
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
            Console.WriteLine();
        }

        private void ProductInput()
        {
            int operation;

            do
            {
                ShowProductMenu();

                operation = int.Parse(Console.ReadLine());

                switch (operation)
                {
                    case 1:
                        ListAllProducts();
                        break;
                    case 2:
                        AddProduct();
                        break;
                    case 3:
                        FetchProduct();
                        break;
                    case 4:
                        UpdateProduct();
                        break;
                    case 5:
                        DeleteProduct();
                        break;
                    default:
                        break;
                }

                Console.WriteLine("Press any key...");
                Console.ReadKey();
                Console.Clear();

            } while (operation != closeOperationId);
        }

        private void ListAllProducts()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "USERS");
            Console.WriteLine(new string('-', 40));

            List<User> users = userBusiness.GetAll();

            foreach (User user in users)
            {
                Console.WriteLine(user.ToString());
            }
        }

        private void AddProduct()
        {
            User user = new();

            Console.Write("FirstName: ");
            user.FirstName = Console.ReadLine();

            Console.Write("LastName: ");
            user.LastName = Console.ReadLine();

            Console.Write("Email: ");
            user.Email = Console.ReadLine();

            Console.Write("Phone: ");
            user.Phone = Console.ReadLine();

            Console.Write("Address: ");
            user.Address = Console.ReadLine();

            Console.Write("City: ");
            user.City = Console.ReadLine();

            Console.Write("Region: ");
            user.Region = Console.ReadLine();

            Console.Write("PostalCode: ");
            user.PostalCode = Console.ReadLine();

            Console.Write("Country: ");
            user.Country = Console.ReadLine();

            Console.Write("RegistrationDate: ");
            user.RegistrationDate = DateTime.Now;

            userBusiness.Add(user);

            Console.WriteLine("The user has been added!");
        }

        private void UpdateProduct()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());

            User user = userBusiness.GetByID(id);

            if (user is null)
            {
                Console.WriteLine("User not found!");

                return;
            }

            Console.WriteLine(user.ToString());

            Console.Write("FirstName: ");
            user.FirstName = Console.ReadLine();

            Console.Write("LastName: ");
            user.LastName = Console.ReadLine();

            Console.Write("Email: ");
            user.Email = Console.ReadLine();

            Console.Write("Phone: ");
            user.Phone = Console.ReadLine();

            Console.Write("Address: ");
            user.Address = Console.ReadLine();

            Console.Write("City: ");
            user.City = Console.ReadLine();

            Console.Write("Region: ");
            user.Region = Console.ReadLine();

            Console.Write("PostalCode: ");
            user.PostalCode = Console.ReadLine();

            Console.Write("Country: ");
            user.Country = Console.ReadLine();

            userBusiness.Update(user);

            Console.WriteLine("The user has been updated!");
        }

        private void FetchProduct()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());

            User user = userBusiness.GetByID(id);

            if (user is null)
            {
                Console.WriteLine("Product not found!");

                return;
            }

            Console.WriteLine(new string('-', 40));
            Console.WriteLine("ID: " + user.Id);
            Console.WriteLine("FirstName: " + user.FirstName);
            Console.WriteLine("LastName: " + user.LastName);
            Console.WriteLine("Email: " + user.Email);
            Console.WriteLine("Phone: " + user.Phone);
            Console.WriteLine("Address: " + user.Address);
            Console.WriteLine("City: " + user.City);
            Console.WriteLine("Region: " + user.Region);
            Console.WriteLine("PostalCode: " + user.PostalCode);
            Console.WriteLine("Country: " + user.Country);
            Console.WriteLine("IsEmailConfirmed: " + user.IsEmailConfirmed);
            Console.WriteLine("RegisterDate: " + user.RegistrationDate);
            Console.WriteLine("LastLoginDate: " + user.LastLoginDate);
            Console.WriteLine(new string('-', 40));
        }

        private void DeleteProduct()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());

            User user = userBusiness.GetByID(id);

            if (user is null)
            {
                Console.WriteLine("Product not found!");

                return;
            }

            userBusiness.Delete(id);
            Console.WriteLine("The product has been deleted!");
        }

        //- Subcategory

        private void ShowSubcMenu()
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
            Console.WriteLine();
        }
        /*
        private void CategoryInput()
        {
            int operation;

            do
            {
                ShowCategoryMenu();

                operation = int.Parse(Console.ReadLine());

                switch (operation)
                {
                    case 1:
                        ListAllCategories();
                        break;
                    case 2:
                        AddCategory();
                        break;
                    case 3:
                        FetchCategory();
                        break;
                    case 4:
                        UpdateCategory();
                        break;
                    case 5:
                        DeleteCategory();
                        break;
                    default:
                        break;
                }

                Console.WriteLine("Press any key...");
                Console.ReadKey();
                Console.Clear();

            } while (operation != closeOperationId);
        }

        private void ListAllCategories()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "USERS");
            Console.WriteLine(new string('-', 40));

            List<User> users = userBusiness.GetAll();

            foreach (User user in users)
            {
                Console.WriteLine(user.ToString());
            }
        }

        private void AddCategory()
        {
            User user = new();

            Console.Write("FirstName: ");
            user.FirstName = Console.ReadLine();

            Console.Write("LastName: ");
            user.LastName = Console.ReadLine();

            Console.Write("Email: ");
            user.Email = Console.ReadLine();

            Console.Write("Phone: ");
            user.Phone = Console.ReadLine();

            Console.Write("Address: ");
            user.Address = Console.ReadLine();

            Console.Write("City: ");
            user.City = Console.ReadLine();

            Console.Write("Region: ");
            user.Region = Console.ReadLine();

            Console.Write("PostalCode: ");
            user.PostalCode = Console.ReadLine();

            Console.Write("Country: ");
            user.Country = Console.ReadLine();

            Console.Write("RegistrationDate: ");
            user.RegistrationDate = DateTime.Now;

            userBusiness.Add(user);

            Console.WriteLine("The user has been added!");
        }

        private void UpdateCategory()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());

            User user = userBusiness.GetByID(id);

            if (user is null)
            {
                Console.WriteLine("User not found!");

                return;
            }

            Console.WriteLine(user.ToString());

            Console.Write("FirstName: ");
            user.FirstName = Console.ReadLine();

            Console.Write("LastName: ");
            user.LastName = Console.ReadLine();

            Console.Write("Email: ");
            user.Email = Console.ReadLine();

            Console.Write("Phone: ");
            user.Phone = Console.ReadLine();

            Console.Write("Address: ");
            user.Address = Console.ReadLine();

            Console.Write("City: ");
            user.City = Console.ReadLine();

            Console.Write("Region: ");
            user.Region = Console.ReadLine();

            Console.Write("PostalCode: ");
            user.PostalCode = Console.ReadLine();

            Console.Write("Country: ");
            user.Country = Console.ReadLine();

            userBusiness.Update(user);

            Console.WriteLine("The user has been updated!");
        }

        private void FetchCategory()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());

            User user = userBusiness.GetByID(id);

            if (user is null)
            {
                Console.WriteLine("Product not found!");

                return;
            }

            Console.WriteLine(new string('-', 40));
            Console.WriteLine("ID: " + user.Id);
            Console.WriteLine("FirstName: " + user.FirstName);
            Console.WriteLine("LastName: " + user.LastName);
            Console.WriteLine("Email: " + user.Email);
            Console.WriteLine("Phone: " + user.Phone);
            Console.WriteLine("Address: " + user.Address);
            Console.WriteLine("City: " + user.City);
            Console.WriteLine("Region: " + user.Region);
            Console.WriteLine("PostalCode: " + user.PostalCode);
            Console.WriteLine("Country: " + user.Country);
            Console.WriteLine("IsEmailConfirmed: " + user.IsEmailConfirmed);
            Console.WriteLine("RegisterDate: " + user.RegistrationDate);
            Console.WriteLine("LastLoginDate: " + user.LastLoginDate);
            Console.WriteLine(new string('-', 40));
        }

        private void DeleteCategory()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());

            User user = userBusiness.GetByID(id);

            if (user is null)
            {
                Console.WriteLine("Product not found!");

                return;
            }

            userBusiness.Delete(id);
            Console.WriteLine("The product has been deleted!");
        }
        */
        
    }
}
