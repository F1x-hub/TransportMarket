using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18
{
    internal class ManageOfTransport : Transport
    {
        List<Transport> transports= new List<Transport>()
        {

        };

        List<User> users = new List<User>()
        {
            new Customer(){Name = "Fox", Email = "Fox_1999@gmail.com", Password = "12345678", UserName = "HotDog", Money = 50000, Transport = new List<Transport>()
            {
                new Car(){Manufacturer = "MBW", Model = "X4 M", Year = 2024 , Engine = 6, Price = 40000},
                new Motorcycle(){Manufacturer = "Yamaha", Model = "YZF-R1", Year = 2009 , Engine = 4, Price = 13000},
                
            }, SoldTranport = new List<Transport>()
            {

            } },
            new Customer(){Name = "bob", Email = "bobson@gmail.com", Password = "Dbd123", UserName = "Boxbix", Money = 50000, Transport = new List<Transport>()
            {
                new Truck(){Manufacturer = "Ford", Model = "F-150", Year = 2009 , Engine = 8, Price = 27000}
            } }
        };
     

        public void NavigationMenu()
        {
            int control = 0;
            while (control != 4) 
            {
                Console.WriteLine("1. View All Transport\n2. Buy Tranport\n3. Admin Panel\n4. Exit");
                control = int.Parse(Console.ReadLine());

                if (control == 1)
                {
                    Print();
                }
                if( control == 2)
                {
                    BuyTransportMenu();
                }
                if (control == 3)
                {
                    Admin();
                }
            }
        }
        public void Admin()
        {
            Console.WriteLine("Admin View - All Users and Their Vehicles:");

            foreach (User user in users)
            {
                Console.WriteLine($"User: {user.Name}");

                if (user.Transport.Any())
                {
                    Console.WriteLine("Vehicles:");
                    foreach (Transport vehicle in user.Transport)
                    {
                        Console.WriteLine(vehicle);
                    }
                }
                else
                {
                    Console.WriteLine("No vehicles owned.");
                }

                Console.WriteLine();
            }
        }
        public void BuyTransportMenu()
        {
            int control = 0;
            while (control != 3)
            {
                Console.WriteLine("1. Registration\n2. Sign In\n3. Back");
                control = int.Parse(Console.ReadLine());

                if(control == 1)
                {
                    Registration();
                }
                if( control == 2)
                {
                    BuyMenu();
                }
                
            }
        }
        public void Registration()
        {
            Console.Write("Enter Name: ");
            string Name = Console.ReadLine();
            Console.Write("Enter Email: ");
            string Email = Console.ReadLine();
            Console.Write("Enter Password: ");
            string Password = Console.ReadLine();
            Console.Write("Enter UserName: ");
            string UserName = Console.ReadLine();
            Console.Write("Enter Money: ");
            int Money = int.Parse(Console.ReadLine());

            users.Add(new Customer()
            {
                Name = Name,
                Email = Email,
                Password = Password,
                UserName = UserName,
                Money = Money
            });
            Console.WriteLine("Registration Successfully Completed");
        }
        public User SignIn() 
        {
            User user1 = new User();
            Console.Write("Enter UserName: ");
            string enteredUsername = Console.ReadLine();

            Console.Write("Enter Password: ");
            string enteredPassword = Console.ReadLine();
            foreach (Customer user in users) 
            {
                
                if (user.UserName.ToLower() == enteredUsername.ToLower() && user.Password.ToLower() == enteredPassword.ToLower())
                {
                    
                    user1 = user;
                    break;
                }
                else
                {
                    user1 = null;
                    Console.WriteLine("User Not Found");
                    break;
                }
            }
            return user1;
        }
        public void BuyMenu()
        {
            User user = SignIn();
            int control = 0;
            if(user != null)
            {
                while (control != 5)
                {
                    Console.WriteLine("1. Buy Tranport\n2. Add Transport\n3. View Profile Info\n4. Favorite\n5. back");

                    control = int.Parse(Console.ReadLine());

                    if (control == 1)
                    {
                        BuyTransport(user);
                    }
                    if (control == 2)
                    {
                        AddTransport(user);
                    }
                    if (control == 3)
                    {
                        ProfileInfo(user);
                    }
                    if (control == 4)
                    {
                        Favorite(user);
                    }



                }
            }
            
        }
        public void Favorite(User currentUser)
        {
            ProfileInfo(currentUser);

            if (currentUser != null)
            {
                Console.WriteLine("Favorite Vehicles:");
                if (currentUser.FavoriteTransport.Any())
                {
                    foreach (Transport favoriteTransport in currentUser.FavoriteTransport)
                    {
                        Console.WriteLine(favoriteTransport);
                    }
                }
                else
                {
                    Console.WriteLine("No vehicles marked as favorites.");
                }

                Console.Write("Enter the model of the vehicle to mark as a favorite: ");
                string chosenModel = Console.ReadLine();

                Transport chosenTransport = currentUser.Transport.FirstOrDefault(t => t.Model.Equals(chosenModel, StringComparison.OrdinalIgnoreCase));

                if (chosenTransport != null)
                {
                    if (!currentUser.FavoriteTransport.Contains(chosenTransport))
                    {
                        currentUser.FavoriteTransport.Add(chosenTransport);
                        Console.WriteLine($"{chosenTransport.Manufacturer} {chosenTransport.Model} marked as a favorite!");
                    }
                    else
                    {
                        Console.WriteLine($"{chosenTransport.Manufacturer} {chosenTransport.Model} is already marked as a favorite.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid model entered or the vehicle is not owned by the user.");
                }
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }
        public void AddTransport(User currentUser)
        {
            if (currentUser != null)
            {
                Console.WriteLine("Select the type of transport to add:");
                Console.WriteLine("1. Car\n2. Motorcycle\n3. Truck");

                int transportType = int.Parse(Console.ReadLine());

                Transport newTransport;
                if (transportType == 1)
                {
                    newTransport = new Car();
                }
                else if (transportType == 2)
                {
                    newTransport = new Motorcycle();
                }
                else if (transportType == 3)
                {
                    newTransport = new Truck();
                }
                else
                {
                    Console.WriteLine("Invalid choice. Transport not added.");
                    return;
                }

                Console.Write("Enter Manufacturer: ");
                newTransport.Manufacturer = Console.ReadLine();

                Console.Write("Enter Model: ");
                newTransport.Model = Console.ReadLine();

                Console.Write("Enter Year: ");
                newTransport.Year = int.Parse(Console.ReadLine());

                Console.Write("Enter Engine: ");
                newTransport.Engine = int.Parse(Console.ReadLine());

                Console.Write("Enter Price: ");
                newTransport.Price = int.Parse(Console.ReadLine());

                currentUser.Transport.Add(newTransport);

                Console.WriteLine("New transport added successfully!");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }
        public void BuyTransport(User currentUser)
        {
            if (currentUser != null)
            {
                Console.WriteLine("Select a user to view their vehicles:");
                foreach (User user in users.Where(u => u != currentUser))
                {
                    Console.WriteLine($"{user.Name}");
                }

                Console.Write("Enter the name of the user: ");
                string selectedUserName = Console.ReadLine();

                User selectedUser = users.FirstOrDefault(u => u.Name.Equals(selectedUserName, StringComparison.OrdinalIgnoreCase));

                if (selectedUser != null)
                {
                    Console.WriteLine($"User: {selectedUser.Name}");

                    foreach (Transport transport in selectedUser.Transport)
                    {
                        Console.WriteLine(transport);
                    }

                    Console.Write("Enter the model of the vehicle you want to buy: ");
                    string chosenModel = Console.ReadLine();

                    Transport chosenTransport = selectedUser.Transport.FirstOrDefault(t => t.Model.Equals(chosenModel, StringComparison.OrdinalIgnoreCase));

                    if (chosenTransport != null)
                    {
                        Console.Write($"Do you want to buy {chosenTransport.Manufacturer} {chosenTransport.Model}? (yes/no): ");
                        string buyDecision = Console.ReadLine().ToLower();

                        if (buyDecision == "yes")
                        {
                            if (chosenTransport.Price <= currentUser.Money)
                            {
                                currentUser.Transport.Add(chosenTransport);
                                currentUser.Money -= chosenTransport.Price;
                                Console.WriteLine($"You have successfully bought {chosenTransport.Manufacturer} {chosenTransport.Model}!");
                            }
                            else
                            {
                                Console.WriteLine("Insufficient funds to buy this vehicle.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Purchase canceled.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid model entered or the vehicle is not available for the selected user.");
                    }
                }
                else
                {
                    Console.WriteLine("User not found.");
                }
            }
        }

        public void SearchByModel(string enteredUsername, string parameterToFind)
        {
            Console.WriteLine($"Search results for parameter: {parameterToFind}");
            foreach (User user in users)
            {
                if(user is Customer customer && customer.UserName.ToLower() == enteredUsername)
                {
                    foreach (Transport vehicle in customer.Transport)
                    {
                        Console.WriteLine("1");
                        if (vehicle.Model.ToLower() == parameterToFind.ToLower())
                        {
                            Console.WriteLine("2");
                            if (vehicle.Price < customer.Money)
                            {
                                customer.SoldTranport.Add(vehicle);
                                Console.WriteLine(vehicle);
                            }

                            break;
                        }
                        else
                        {
                            Console.WriteLine("Transport Not Found");
                            break;
                        }

                    }
                }
                
            }
        }
        
        public void Print()
        {
            foreach (User user in users)
            {
                if (user is Customer customer)
                {
                    Console.WriteLine($"User: {user.Name}");

                    foreach (Transport vehicle in user.Transport)
                    {
                        Console.WriteLine(vehicle);
                    }

                    Console.WriteLine();
                }
                
            }
        }
        public void ProfileInfo(User currentUser)
        {
            if (currentUser != null)
            {
                Console.WriteLine($"Profile Information for {currentUser.Name}:");
                Console.WriteLine($"Money: {currentUser.Money}");

                if (currentUser.Transport.Any())
                {
                    Console.WriteLine("Vehicles:");
                    foreach (Transport vehicle in currentUser.Transport)
                    {
                        Console.WriteLine(vehicle);
                    }
                }
                else
                {
                    Console.WriteLine("No vehicles owned.");
                }
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }
    }
}
