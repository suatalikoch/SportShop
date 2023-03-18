using Business;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShopConsole.Controllers
{
    internal class UserController
    {
        private readonly int closeOperationId = 6;

        private readonly UserBusiness userBusiness = new();

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "USER MENU");
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
            Console.WriteLine(new string(' ', 18) + "USERS");
            Console.WriteLine(new string('-', 40));

            List<User> users = userBusiness.GetAll();

            foreach (User user in users)
            {
                Console.WriteLine(user.ToString());
            }
        }

        private void Add()
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

        private void Update()
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

        private void Fetch()
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

        private void Delete()
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
    }
}
