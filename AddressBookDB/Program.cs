using System;

namespace AddressBookDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Welcome to AddressBookDB !");
            Console.WriteLine("Choose::\n[1] View.\n[2] Add.\nPress 'X' to Exit.");
            AddressBookSQLRepo repo = new AddressBookSQLRepo();
            AddressBookModel enter = new AddressBookModel();
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    repo.GetDetails();
                    break;
                case "2":
                    Console.WriteLine("Enter Type of AddressBook");
                    string type = Console.ReadLine();
                    Console.WriteLine("Enter AddressBookName");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter First Name");
                    string firstName = Console.ReadLine();
                    Console.WriteLine("Enter Last Name");
                    string lastName = Console.ReadLine();
                    Console.WriteLine("Enter Address");
                    string address = Console.ReadLine();
                    Console.WriteLine("Enter City");
                    string city = Console.ReadLine();
                    Console.WriteLine("Enter State");
                    string state = Console.ReadLine();
                    Console.WriteLine("Enter Zip");
                    string zip = Console.ReadLine();
                    Console.WriteLine("Enter Phone Number");
                    string phoneNumber = Console.ReadLine();
                    Console.WriteLine("Enter Email");
                    string email = Console.ReadLine();
                    enter.Type = type;
                    enter.AddressBookName = name;
                    enter.FirstName = firstName;
                    enter.LastName = lastName;
                    enter.Address = address;
                    enter.City = city;
                    enter.State = state;
                    enter.Zip = zip;
                    enter.PhoneNumber = phoneNumber;
                    enter.Email = email;
                    break;
                case "x":
                    return;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }
    }
}
